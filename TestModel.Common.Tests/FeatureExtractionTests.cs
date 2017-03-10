using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var source = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var validValues = "Button Fly,Button-End,D Ring,Double D Ring,Drawstring,Elastic,Flat Solid Buckle,Hook & Eye,J-Clip,Pull On,Round Classic Ring,Self Tie,Snap On,Snaps,Square Classic Ring,Velcro,Zipper";
            var s = new FeatureExtraction().Extract(source,validValues,3);

        }

        [TestMethod]
        public void split()
        {
            var source = "Versace Collection D Ring woven leather tote bag with golden hardware. Flat top handles with hanging logo medallion, 5.5\" drop. Removable chain shoulder strap, 18.5\" drop. Flap top with logo plaque; snap closure. Interior, cotton lining; one zip and two slip pockets. Metal feet protect bottom of bag. 10.5\"H x 14\"W x 4.5\"D; weighs 13 oz. Imported.";
            var sourceArray = source.Split(new string[] {". "},StringSplitOptions.None);
        }

    }
}
