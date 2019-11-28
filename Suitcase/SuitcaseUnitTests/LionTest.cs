using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class LionTest
    {
        [TestMethod]
        public void LionConstructor()
        {
            // expected
            string species = "lion";
            double dailyFood = 7.5;
            string nameM = "Боніфацій";
            string male = "m";
            string nameF = "Надя";
            string female = "f";

            // actual
            Animal maleLion = new Lion(nameM, "ч");
            Animal femaleLion = new Lion(nameF, "ж");

            Assert.AreEqual(species, maleLion.species);
            Assert.AreEqual(nameM, maleLion.name);
            Assert.AreEqual(male, maleLion.sex);
            Assert.AreEqual(dailyFood, maleLion.dailyFood);

            Assert.AreEqual(species, femaleLion.species);
            Assert.AreEqual(nameF, femaleLion.name);
            Assert.AreEqual(female, femaleLion.sex);
            Assert.AreEqual(dailyFood, femaleLion.dailyFood);
        }

        [TestMethod]
        public void LionVoice()
        {
            // expected
            string nameM = "Боніфацій";
            string nameF = "Надя";
            string maleVoice = "РРА! Мене звуть Боніфацій, я лев!";
            string femaleVoice = "РРА! Мене звуть Надя, я левиця!";

            // actual
            Animal maleLion = new Lion(nameM, "ч");
            Animal femaleLion = new Lion(nameF, "ж");

            Assert.AreEqual(maleVoice, maleLion.Voice());
            Assert.AreEqual(femaleVoice, femaleLion.Voice());
        }
    }
}
