using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seel3d.Human3d.Object;

namespace Seel3d.Human3d.Test
{
    [TestClass]
    public class HumanTest
    {
        [TestMethod]
        public void TestHumanCreation()
        {
            var human = new Human
            {
                Height = "155",
                Age = 25,
                Weight = 77.5f,
                Sexe = Sex.Man
            };

            human.Export("C://Desktop/", Export3DType.WaveFront);

        }
    }
}
