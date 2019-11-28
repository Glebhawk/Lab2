using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Telerik.JustMock;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class BiologistTest
    {
        [TestMethod]
        public void CallEveryoneTest()
        {
            //expected
            bool called = false;

            Mock.SetupStatic(typeof(Case));
            Mock.Arrange(() => Case.dayTime.CallEveryone(Arg.IsAny<List<string>>())).DoInstead(() => called = true);

            // actual
            Biologist.CallEveryone();

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void CallByNameTest()
        {
            //expected
            bool called = false;
            List<string> expectedList = new List<string> {"Кузьма"};
            string nameCat = "Кузьма";
            string nameHorse = "Буцефал";

            Mock.SetupStatic(typeof(Case));
            Mock.Arrange(() => Case.room.Call(nameCat)).Returns(expectedList);         // Припустимо, що у нас є кіт Кузьма.
            Mock.Arrange(() => Case.room.Call(nameHorse)).Returns(new List<string>()); // А коня в нас немає.
            Mock.Arrange(() => Case.pasture.Call(Arg.AnyString)).Returns(new List<string>());

            // actual
            List<string> actualList1 = Biologist.CallByName(nameCat);
            List<string> actualList2 = Biologist.CallByName(nameHorse);

            Assert.AreEqual(expectedList[0], actualList1[0]);
            Assert.AreEqual("На жаль, такої тварини немає.", actualList2[0]);
        }

        [TestMethod]
        public void TimeChangeTest()
        {
            bool called = false;

            Mock.SetupStatic(typeof(Case));
            Mock.Arrange(() => Case.dayTime.Change()).DoInstead(() => called = true);
            
            Biologist.Change();

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void CalculateAllFoodTest()
        {
            double expected = 10.0;
            
            Mock.Arrange(() => Biologist.habitat.GetFood()).Returns(expected);

            double actual = Biologist.CalculateAllFood();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateAvgFoodTest()
        {
            double expected = 2.0;

            Mock.Arrange(() => Biologist.habitat.GetAvgFood()).Returns(expected);

            double actual = Biologist.CalculateAvgFood();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAnimalTest()
        {
            // expected
            List<string> reports = new List<string>();

            Mock.Arrange(() => Biologist.habitat.Add(Arg.IsAny<Animal>())).Returns("Тварину заселено.");

            // actual
            reports.Add(Biologist.AddAnimal("Щось", "xenomorph", "середнє"));
            reports.Add(Biologist.AddAnimal("Боніфацій", "лев", "ч"));
            reports.Add(Biologist.AddAnimal("Шерхан", "тигр", "ч"));
            reports.Add(Biologist.AddAnimal("Вова", "вовк", "ч"));
            reports.Add(Biologist.AddAnimal("Моська", "кіт", "ж"));
            reports.Add(Biologist.AddAnimal("Мурка", "собака", "ж"));
            reports.Add(Biologist.AddAnimal("Ромашка", "кінь", "ж"));
            reports.Add(Biologist.AddAnimal("Олень", "олень", "ч"));
            reports.Add(Biologist.AddAnimal("Щось", "xenomorph", "ч"));

            Assert.AreEqual("Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".", reports[0]);
            for(int i = 1; i < 8; i++)
            {
                Assert.AreEqual("Тварину заселено.", reports[i]);
            }
            Assert.AreEqual("Неможливо визначити вид. Будь ласка, використовуйте слова \"лев\", " +
                "\"тигр\", \"вовк\", \"собака\", \"кiт\", \"олень\", \"кiнь\".", reports[8]);
        }
    }
}
