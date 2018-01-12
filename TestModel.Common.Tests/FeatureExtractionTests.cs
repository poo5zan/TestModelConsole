using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel.Common.Tests
{
    [TestClass]
    public class FeatureExtractionTests
    {
        [TestMethod]
        public void Extract_Tests()
        {
            var featureExtraction = new FeatureExtraction();

            var validValues = "Button Fly,Button-End,D Ring,Double D Ring,Drawstring,Elastic,Flat Solid Buckle,Hook & Eye,J-Clip,Pull On,Round Classic Ring,Self Tie,Snap On,Snaps,Square Classic Ring,Velcro,Zipper";
            //Scenario 1: exact match
            var source1 = "Double D Ring";
            var scenario1 = featureExtraction.Extract(source1, validValues);
            Assert.AreEqual("Double D Ring",scenario1);
            //Scenario 2: source contains list of valid values
            // 2.1 source contains single matching
            // 2.2 source contains multiple matching
            // 2.2 source contains multiple matching but get only one
            // 2.3 source contains multiple matching but get only one 
            // with assistance of keyword
            var source21 = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var scenario21 = featureExtraction.Extract(source21, validValues);
            Assert.AreEqual("D Ring",scenario21);
            var source221 =
                "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported. Elastic";
            var scenario221 = featureExtraction.Extract(source221, validValues,
                3, 0);
            Assert.AreEqual("D Ring/Elastic", scenario221);

            var scenario222 = featureExtraction.Extract(source221, validValues,
                3, 1);
            Assert.AreEqual("D Ring",scenario222);

            //var scenario223 = featureExtraction.Extract(source221, validValues,
            //    3, 1, "/", "closure");
            //Assert.AreEqual("Snaps", scenario223);

            //Scenario 3: 

            //Scenario 4: similarity checks
            // return multiple result
            var source4 = "Versace Collection woven D Rin leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var scenario4 = featureExtraction.Extract(source4, validValues, 1, 0);

            var source41 = "Versace Collection woven Elasti leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var scenario41 = featureExtraction.Extract(source41, validValues, 1, 1);


            //var source = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";

            //var s = new FeatureExtraction().Extract(source,validValues,3);

        }

        [TestMethod]
        public void Extract_WithKeyword()
        {
            var keyword = "closure";
            var position = "right";//"left";//right
            var output = "";
            var source = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var indexOf = source.IndexOf(keyword, StringComparison.Ordinal);
            if (position == "left")
            {
                var sourceToKeyword = source.Substring(0, indexOf).TrimEnd();
                var lastIndexOf = sourceToKeyword.LastIndexOf(' ');
                //get first word
                var expectedWord = sourceToKeyword.Substring(lastIndexOf,sourceToKeyword.Length - lastIndexOf);
            }
            else if (position == "right")
            {
                var str = source.Substring(indexOf + keyword.Length, source.Length - indexOf - keyword.Length).TrimStart();
                Regex rgx = new Regex("[^a-zA-Z0-9] ");
                var str1 = rgx.Replace(str, " ").TrimStart();
                var str2 = str1.Substring(0, str1.IndexOf(' '));
            }
        }

        [TestMethod]
        public void split()
        {
            var source = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var sourceArray = source.Split(new string[] {". "},StringSplitOptions.None);
        }

        
    }
}
