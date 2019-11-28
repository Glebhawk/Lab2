using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class WolfTest
    {
        [TestMethod]
        public void LionConstructor()
        {
            // expected
            string species = "wolf";
            double dailyFood = 4.0;
            string nameM = "Вова";
            string male = "m";
            string nameF = "Варвара";
            string female = "f";

            // actual
            Animal maleWolf = new Wolf(nameM, "ч");
            Animal femaleWolf = new Wolf(nameF, "ж");

            Assert.AreEqual(species, maleWolf.species);
            Assert.AreEqual(nameM, maleWolf.name);
            Assert.AreEqual(male, maleWolf.sex);
            Assert.AreEqual(dailyFood, maleWolf.dailyFood);

            Assert.AreEqual(species, femaleWolf.species);
            Assert.AreEqual(nameF, femaleWolf.name);
            Assert.AreEqual(female, femaleWolf.sex);
            Assert.AreEqual(dailyFood, femaleWolf.dailyFood);
        }

        [TestMethod]
        public void WolfVoice()
        {
            // expected
            string nameM = "Вова";
            string nameF = "Варвара";
            string maleVoice = "Грр! Мене звуть Вова, я вовк!";
            string femaleVoice = "Грр! Мене звуть Варвара, я вовчиця!";

            // actual
            Animal maleWolf = new Wolf(nameM, "ч");
            Animal femaleWolf = new Wolf(nameF, "ж");

            Assert.AreEqual(maleVoice, maleWolf.Voice());
            Assert.AreEqual(femaleVoice, femaleWolf.Voice());
        }
    }
}
