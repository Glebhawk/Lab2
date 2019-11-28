using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class DogTest
    {
        [TestMethod]
        public void DogConstructor()
        {
            // expected
            string species = "dog";
            double dailyFood = 0.9;
            string nameM = "Сірко";
            string male = "m";
            string nameF = "Моська";
            string female = "f";

            // actual
            Animal maleDog = new Dog(nameM, "ч");
            Animal femaleDog = new Dog(nameF, "ж");

            Assert.AreEqual(species, maleDog.species);
            Assert.AreEqual(nameM, maleDog.name);
            Assert.AreEqual(male, maleDog.sex);
            Assert.AreEqual(dailyFood, maleDog.dailyFood);

            Assert.AreEqual(species, femaleDog.species);
            Assert.AreEqual(nameF, femaleDog.name);
            Assert.AreEqual(female, femaleDog.sex);
            Assert.AreEqual(dailyFood, femaleDog.dailyFood);
        }

        [TestMethod]
        public void DogVoice()
        {
            // expected
            string nameM = "Сірко";
            string nameF = "Моська";
            string maleVoice = "Гав! Мене звуть Сірко, я пес!";
            string femaleVoice = "Гав! Мене звуть Моська, я собака!";

            // actual
            Animal maleDog = new Dog(nameM, "ч");
            Animal femaleDog = new Dog(nameF, "ж");

            Assert.AreEqual(maleVoice, maleDog.Voice());
            Assert.AreEqual(femaleVoice, femaleDog.Voice());
        }
    }
}
