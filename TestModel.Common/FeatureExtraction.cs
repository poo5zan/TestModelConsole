using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestModel.Common
{
    public class FeatureExtraction
    {

        public string Extract(string text,string validValues,int matchLimit)
        {
            text = text.ToLower();
            validValues = validValues.ToLower();

            string matchedWord = "";
            
            var validValuesArray = validValues.Split(',');
            HashSet<string> validValuesHashSet = new HashSet<string>(validValuesArray);
            //Scenario 1: exact match
            matchedWord = validValuesHashSet.Contains(text) ? text : "";
            
            //Scenario 2: source contains list of valid values
            var matchedWords = validValuesHashSet.Where(text.Contains);

            //Scenario: 3: valid value contains source text
            var m = validValuesHashSet.Where(s => s.Contains(text));

            //Scenario: 4
            var sourceList = text.Split(' ').ToArray().Distinct();
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
                        Match = FuzzyMatcher.DamerauLevenshteinDistanceStr(vv,sv,10)
                    });
                }
            }

            var withMinMatch = lookup.Where(x => x.Match == 
                                lookup.Min(y => y.Match));

            var withinMatchLimit = lookup.Where(x => x.Match <= matchLimit);
            
            return matchedWord;

        }

        public class LookupTable
        {
            public string SourceValue { get; set; }
            public string SourceValueSplitted { get; set; }
            public string  LookupWith { get; set; }
            public string LookupValue { get; set; }
            public int Match { get; set; }

        }

    }
}
