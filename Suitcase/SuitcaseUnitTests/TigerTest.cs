using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class TigerTest
    {
        [TestMethod]
        public void TigerConstructor()
        {
            // expected
            string species = "tiger";
            double dailyFood = 11.0;
            string nameM = "Шерхан";
            string male = "m";
            string nameF = "Багіра";
            string female = "f";

            // actual
            Animal maleTiger = new Tiger(nameM, "ч");
            Animal femaleTiger = new Tiger(nameF, "ж");

            Assert.AreEqual(species, maleTiger.species);
            Assert.AreEqual(nameM, maleTiger.name);
            Assert.AreEqual(male, maleTiger.sex);
            Assert.AreEqual(dailyFood, maleTiger.dailyFood);

            Assert.AreEqual(species, femaleTiger.species);
            Assert.AreEqual(nameF, femaleTiger.name);
            Assert.AreEqual(female, femaleTiger.sex);
            Assert.AreEqual(dailyFood, femaleTiger.dailyFood);
        }

        [TestMethod]
        public void TigerVoice()
        {
            // expected
            string nameM = "Шерхан";
            string nameF = "Багіра";
            string maleVoice = "РРА! Мене звуть Шерхан, я тигр!";
            string femaleVoice = "РРА! Мене звуть Багіра, я тигриця!";

            // actual
            Animal maleTiger = new Tiger(nameM, "ч");
            Animal femaleTiger = new Tiger(nameF, "ж");

            Assert.AreEqual(maleVoice, maleTiger.Voice());
            Assert.AreEqual(femaleVoice, femaleTiger.Voice());
        }
    }
}
