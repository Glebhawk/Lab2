using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class DeerTest
    {
        [TestMethod]
        public void DeerConstructor()
        {
            // expected
            string species = "deer";
            double dailyFood = 1.0;
            string nameM = "Олень";
            string male = "m";
            string nameF = "Оленуха";
            string female = "f";

            // actual
            Animal maleLion = new Deer(nameM, "ч");
            Animal femaleLion = new Deer(nameF, "ж");

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
        public void DeerVoice()
        {
            // expected
            string nameM = "Олень";
            string nameF = "Оленуха";
            string deerMaleVoice = "ООЕЕ! Мене звуть Олень, я олень!";
            string deerFemaleVoice = "ООЕЕ! Мене звуть Оленуха, я олениха!";

            // actual
            Animal maleDeer = new Deer(nameM, "ч");
            Animal femaleDeer = new Deer(nameF, "ж");

            Assert.AreEqual(deerMaleVoice, maleDeer.Voice());
            Assert.AreEqual(deerFemaleVoice, femaleDeer.Voice());
        }
    }
}
