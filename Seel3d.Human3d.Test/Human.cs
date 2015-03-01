using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seel3d.Human3d.Object;
using Seel3d.Human3d.Spec;

namespace Seel3d.Human3d.Test
{
    [TestClass]
    public class HumanTest
    {
        protected Human Human { get; set; }

        [TestInitialize]
        public void IniitializeHuman()
        {
            //Human = new Human
            //{
            //    Height = 155f,
            //    Age = 25,
            //    Weight = 77.5f,
            //    Sexe = Sex.Man
            //};

            Human = new Human();
        }

        [TestMethod]
        public void TestHumanCreation()
        {
            Human.Export(@"C:\Users\Aurelien\Desktop\test3d\test.obj", Export3DType.WaveFront);
        }

        [TestMethod]
        public void TestHumanModification()
        {
            

            Human.Export(@"C:\Users\Aurelien\Desktop\test3d\test.obj", Export3DType.WaveFront);
        }

        [TestMethod]
        public void TestHumanImport()
        {
            Human.Export(@"C:\Users\Aurelien\Desktop\test3d\test.obj", Export3DType.WaveFront);
        }
    }
}
