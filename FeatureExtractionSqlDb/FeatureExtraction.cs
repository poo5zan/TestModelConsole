using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FeatureExtractionSqlDb
{
    public class FeatureExtraction
    {
        /// <summary>
        /// Extract feature from text 
        /// </summary>
        /// <param name="inputText">input String</param>
        /// <param name="validValues">allowed valid values</param>
        /// <param name="matchLimit">match limit 0 means highest, max:10</param>
        /// <param name="returnRecordSize">zero = all</param>
        /// <param name="keyword">keyword to assist lookup</param>
        /// <param name="separator">separator to combine result</param>
        /// <param name="isPositionLeft">position to look word for</param>
        /// <returns>subtext</returns>
        public string Extract(string inputText, string validValues,
            int matchLimit = 1, int returnRecordSize = 0,
            string separator = "/", string keyword = "",
            bool isPositionLeft = true
            )
        {
            var validValuesOriginal = validValues;
            var validValuesOrigArray = validValuesOriginal.Split(',');
            HashSet<string> validValuesOrigHashSet = new HashSet<string>(validValuesOrigArray);

            

            //if we have keyword mentioned, then work on it
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                var wordAroundKeyword = GetWordAroundKeyword(inputText, keyword, isPositionLeft);
                //if words found, then replace the input text
                if (!String.IsNullOrWhiteSpace(wordAroundKeyword))
                {
                    inputText = wordAroundKeyword;
                }
            }

            inputText = inputText.ToLower();
            validValues = validValues.ToLower();
            string matchedWord = "";

            var validValuesArray = validValues.Split(',');
            HashSet<string> validValuesHashSet = new HashSet<string>(validValuesArray);
            //Scenario 1: exact match
            matchedWord = validValuesHashSet.Contains(inputText) ? inputText : "";
            if (!String.IsNullOrWhiteSpace(matchedWord))
            {
                return validValuesOrigHashSet.FirstOrDefault(x => x.ToLower() == matchedWord);
            }

            //Scenario 2: source contains list of valid values
            var matchedWords = validValuesHashSet.Where(inputText.Contains).ToList();
            if (matchedWords.Any())
            {
                var matchedWordsOrig = validValuesOrigHashSet.Where(x => matchedWords.Contains(x.ToLower()));
                //return all
                if (returnRecordSize == default(int))
                {
                    matchedWord = String.Join(separator, matchedWordsOrig);
                }
                else
                {
                    var expectedRecord = matchedWordsOrig.Take(returnRecordSize);
                    matchedWord = String.Join(separator, expectedRecord);
                }
            }

            if (!String.IsNullOrWhiteSpace(matchedWord))
            {
                return matchedWord;
            }

            //Scenario: 3: valid value contains source text
            //matchedWord = validValuesHashSet.Where(s => s.Contains(inputText)).FirstOrDefault();
            //matchedWord = validValuesHashSet.FirstOrDefault(s => s.Contains(inputText));
            //if (!String.IsNullOrWhiteSpace(matchedWord))
            //{
            //    return matchedWord;
            //}

            //Scenario: 4
            var sourceList = inputText.Split(' ').ToArray().Distinct();
            var sourceListHashSet = new HashSet<string>(sourceList);
            //foreach record, get matching records
            var lookup = new List<LookupTable>();
            foreach (var sv in sourceListHashSet)
            {
                foreach (var vv in validValuesHashSet)
                {
                    lookup.Add(new LookupTable()
                    {
                        SourceValueSplitted = sv,
                        LookupWith = vv,
                        Match = FuzzyMatcher.DamerauLevenshteinDistanceStr(vv, sv, 10)
                    });
                }
            }

            //var withMinMatch = lookup.Where(x => x.Match == 
            //                    lookup.Min(y => y.Match));

            var withinMatchLimit = lookup.
                Where(x => x.Match <= matchLimit)
                .OrderBy(x => x.Match)
                //.Select(x => x.LookupWith)
                .ToList();
            if (withinMatchLimit.Any())
            {
                matchedWords = withinMatchLimit.Select(x => x.LookupWith).Distinct().ToList();
                var matchedWordsOrig = validValuesOrigHashSet.Where(x => matchedWords.Contains(x.ToLower()));
                if (returnRecordSize == default(int))
                {
                    matchedWord = String.Join(separator, matchedWordsOrig);
                }
                else
                {
                    var expectedMatches = matchedWordsOrig.Take(returnRecordSize);
                    matchedWord = String.Join(separator, expectedMatches);
                }
            }

            return matchedWord;

        }

        public class LookupTable
        {
            public string SourceValue { get; set; }
            public string SourceValueSplitted { get; set; }
            public string LookupWith { get; set; }
            public string LookupValue { get; set; }
            public int Match { get; set; }

        }

        private string GetWordAroundKeyword(string sourceText, string keyword
           , bool isPositionLeft)
        {
            var indexOfKeyword = sourceText.IndexOf(keyword, StringComparison.Ordinal);
            if (isPositionLeft)
            {
                var strLeftToKeyword = sourceText.Substring(0, indexOfKeyword).TrimEnd();
                var lastIndexOf = strLeftToKeyword.LastIndexOf(' ');
                //get first word, one word on the left of keyword
                return strLeftToKeyword.Substring(lastIndexOf, strLeftToKeyword.Length - lastIndexOf);
            }
            else
            {
                var strRightToKeyword = sourceText.Substring(indexOfKeyword + keyword.Length, sourceText.Length - indexOfKeyword - keyword.Length).TrimStart();
                Regex rgx = new Regex("[^a-zA-Z0-9] ");
                var removeSpecialCharacterExceptSpace = rgx.Replace(strRightToKeyword, " ").TrimStart();
                return removeSpecialCharacterExceptSpace.Substring(0, removeSpecialCharacterExceptSpace.IndexOf(' '));
            }
        }
    }
}