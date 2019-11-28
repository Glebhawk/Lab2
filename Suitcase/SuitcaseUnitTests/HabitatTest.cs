using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class HabitatTest
    {
        [TestMethod]
        public void AddAnimalTest()
        {
            // expected
            Mock.SetupStatic(typeof(Case));
            string nameCat = "Кузьма";
            string nameHorse = "Буцефал";
            Cat cat = new Cat(nameCat, "ч");
            Horse horse = new Horse(nameHorse, "ч");
            string catAdded = "You added a cat.";
            string horseAdded = "You added a horse.";
            Mock.Arrange(() => Case.room.Add(cat)).Returns(catAdded);
            Mock.Arrange(() => Case.pasture.Add(horse)).Returns(horseAdded);

            //actual
            Habitat habitat = new Habitat();
            string actualCat = habitat.Add(cat);
            string actualHorse = habitat.Add(horse);

            Assert.AreEqual(catAdded, actualCat);
            Assert.AreEqual(horseAdded, actualHorse);
        }

        [TestMethod]
        public void GetFoodTest()
        {
            // expected
            Mock.SetupStatic(typeof(Case));
            double expected = 10.0;
            Mock.Arrange(() => Case.room.GetFood()).Returns(5.0);
            Mock.Arrange(() => Case.pasture.GetFood()).Returns(5.0);

            //actual
            Habitat habitat = new Habitat();
            double actualFood = habitat.GetFood();

            Assert.AreEqual(expected, actualFood);
        }

        [TestMethod]
        public void CountAnimalsTest()
        {
            // expected
            Mock.SetupStatic(typeof(Case));
            int expected = 10;
            Mock.Arrange(() => Case.room.CountAnimals()).Returns(5);
            Mock.Arrange(() => Case.pasture.CountAnimals()).Returns(5);

            //actual
            Habitat habitat = new Habitat();
            int actualAnimals = habitat.CountAnimals();

            Assert.AreEqual(expected, actualAnimals);
        }

        [TestMethod]
        public void GetAvgFoodTest()
        {
            // expected
            Mock.SetupStatic(typeof(Case));
            double expected = 9.0;
            Mock.Arrange(() => Case.room.CountAnimals()).Returns(1);
            Mock.Arrange(() => Case.pasture.CountAnimals()).Returns(1);
            Mock.Arrange(() => Case.room.GetFood()).Returns(11.0);
            Mock.Arrange(() => Case.pasture.GetFood()).Returns(7.0);

            //actual
            Habitat habitat = new Habitat();
            double actualAvgFood = habitat.GetAvgFood();

            Assert.AreEqual(expected, actualAvgFood);
        }
    }
}
