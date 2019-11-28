using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class HorseTest
    {
        [TestMethod]
        public void HorseConstructor()
        {
            // expected
            string species = "horse";
            double dailyFood = 7.0;
            string nameM = "Буцефал";
            string male = "m";
            string nameF = "Плотва";
            string female = "f";

            // actual
            Animal maleHorse = new Horse(nameM, "ч");
            Animal femaleHorse = new Horse(nameF, "ж");

            Assert.AreEqual(species, maleHorse.species);
            Assert.AreEqual(nameM, maleHorse.name);
            Assert.AreEqual(male, maleHorse.sex);
            Assert.AreEqual(dailyFood, maleHorse.dailyFood);

            Assert.AreEqual(species, femaleHorse.species);
            Assert.AreEqual(nameF, femaleHorse.name);
            Assert.AreEqual(female, femaleHorse.sex);
            Assert.AreEqual(dailyFood, femaleHorse.dailyFood);
        }

        [TestMethod]
        public void HorseVoice()
        {
            // expected
            string nameM = "Буцефал";
            string nameF = "Плотва";
            string maleVoice = "Ігого! Мене звуть Буцефал, я кiнь!";
            string femaleVoice = "Ігого! Мене звуть Плотва, я кобила!";

            // actual
            Animal maleHorse = new Horse(nameM, "ч");
            Animal femaleHorse = new Horse(nameF, "ж");

            Assert.AreEqual(maleVoice, maleHorse.Voice());
            Assert.AreEqual(femaleVoice, femaleHorse.Voice());
        }
    }
}
