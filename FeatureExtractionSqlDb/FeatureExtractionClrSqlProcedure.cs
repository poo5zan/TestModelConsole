using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace FeatureExtractionSqlDb
{
    public class FeatureExtractionClrSqlProcedure
    {
        //string inputText,string validValues,
        //    int matchLimit = 1,int returnRecordSize = 0,
        //    string separator = "/",string keyword = ""
        //[SqlProcedure]
        [SqlFunction]
        public static string ExtractFeature(
            SqlString inputText,
            SqlString validValues,
            SqlInt32 matchLimit ,
            SqlInt32 returnRecordSize ,
            SqlString separator,
            SqlString keyword//,
            //out SqlString matchedWords
            )
        {
            var featureExtraction = new FeatureExtraction();
            var feature = featureExtraction.Extract(
                inputText.Value,
                validValues.Value,
                matchLimit.Value,
                returnRecordSize.Value,
                separator.Value,
                keyword.Value);

            // if keyword returns empty result, search again, without keyword
            if (!String.IsNullOrWhiteSpace(keyword.Value)
                && String.IsNullOrWhiteSpace(feature))
            {
                feature = featureExtraction.Extract(
                    inputText.Value,
                    validValues.Value,
                    matchLimit.Value,
                    returnRecordSize.Value,
                    separator.Value,
                    "");
            }

            return feature;

        }
    }
}