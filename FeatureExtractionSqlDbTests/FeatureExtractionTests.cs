using System;
using System.Data.SqlTypes;
using FeatureExtractionSqlDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExtractionSqlDbTests
{
    [TestClass]
    public class FeatureExtractionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var source = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var validValues = "Button Fly,Button-End,D Ring,Double D Ring,Drawstring,Elastic,Flat Solid Buckle,Hook & Eye,J-Clip,Pull On,Round Classic Ring,Self Tie,Snap On,Snaps,Square Classic Ring,Velcro,Zipper";

            SqlString inputText = new SqlString(source);
            SqlString validValuesSql = new SqlString(validValues);
            SqlInt32 matchLimit = new SqlInt32(1);
            SqlInt32 returnRecordSize =new SqlInt32(1);
            SqlString separator = new SqlString("/");
            SqlString keyword = new SqlString("");
            
            // without keyword
            var response1 = FeatureExtractionClrSqlProcedure.ExtractFeature(
                inputText,validValuesSql,matchLimit,returnRecordSize,separator,keyword
                 );
            Assert.AreEqual("D Ring",response1);

            //with keyword, having nearly valid values
            keyword = new SqlString("closure");
            var response2 = FeatureExtractionClrSqlProcedure.ExtractFeature(
                inputText, validValuesSql, matchLimit, returnRecordSize, separator, keyword);
            Assert.AreEqual("Snaps",response2);
            //with keyword, without having valid values
            inputText = new SqlString("Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; pujan closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.");
            var response3 = FeatureExtractionClrSqlProcedure.ExtractFeature(
                inputText, validValuesSql, matchLimit, returnRecordSize, separator, keyword);
            Assert.AreEqual("D Ring",response3);
        }
    }
}
