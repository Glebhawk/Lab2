using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void AnimalConstructor()
        {
            // expected
            string nameM = "Рак";
            string male = "m";
            string nameF = "Щука";
            string female = "f";

            // actual
            Animal maleAnimal = new Animal(nameM, "ч");
            Animal femaleAnimal = new Animal(nameF, "ж");

            Assert.AreEqual(nameM, maleAnimal.name);
            Assert.AreEqual(male, maleAnimal.sex);
            Assert.AreEqual(nameF, femaleAnimal.name);
            Assert.AreEqual(female, femaleAnimal.sex);
        }
    }
}
