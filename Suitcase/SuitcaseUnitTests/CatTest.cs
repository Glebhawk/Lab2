using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class CatTest
    {
        [TestMethod]
        public void CatConstructor()
        {
            // expected
            string species = "cat";
            double dailyFood = 0.1;
            string nameM = "Кузьма";
            string male = "m";
            string nameF = "Мурка";
            string female = "f";

            // actual
            Animal maleCat = new Cat(nameM, "ч");
            Animal femaleCat = new Cat(nameF, "ж");

            Assert.AreEqual(species, maleCat.species);
            Assert.AreEqual(nameM, maleCat.name);
            Assert.AreEqual(male, maleCat.sex);
            Assert.AreEqual(dailyFood, maleCat.dailyFood);

            Assert.AreEqual(species, femaleCat.species);
            Assert.AreEqual(nameF, femaleCat.name);
            Assert.AreEqual(female, femaleCat.sex);
            Assert.AreEqual(dailyFood, femaleCat.dailyFood);
        }

        [TestMethod]
        public void CatVoice()
        {
            // expected
            string nameM = "Кузьма";
            string nameF = "Мурка";
            string catMaleVoice = "Мяу! Мене звуть Кузьма, я кiт!";
            string catFemaleVoice = "Мяу! Мене звуть Мурка, я кiшка!";

            // actual
            Animal maleCat = new Cat(nameM, "ч");
            Animal femaleCat = new Cat(nameF, "ж");

            Assert.AreEqual(catMaleVoice, maleCat.Voice());
            Assert.AreEqual(catFemaleVoice, femaleCat.Voice());
        }
    }
}
