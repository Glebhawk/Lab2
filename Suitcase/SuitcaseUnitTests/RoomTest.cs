using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Suitcase;

namespace SuitcaseUnitTests
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void AddTest()
        {
            // expected
            int expectedCarnivores = 3;
            int expectedDog = 1;
            int expectedCat = 1;
            string expectedHorse = "Цю тварину неможливо заселити у кімнату!";
            Lion lion = new Lion("Боніфацій", "ч");
            Tiger tiger = new Tiger("Шерхан", "ч");
            Wolf wolf = new Wolf("Вова", "ч");
            Dog dog = new Dog("Сірко", "ч");
            Cat cat = new Cat("Мурзик", "ч");
            Horse horse = new Horse("Ромашка", "ж");
            Room room = new Room();

            int actualCarnivores = 0;
            int actualCat = 0;
            int actualDog = 0;
            Mock.NonPublic.Arrange(room, "AddCarnivore", new object[1] { lion }).DoInstead(() => ++actualCarnivores);
            Mock.NonPublic.Arrange(room, "AddCarnivore", new object[1] { tiger }).DoInstead(() => ++actualCarnivores);
            Mock.NonPublic.Arrange(room, "AddCarnivore", new object[1] { wolf }).DoInstead(() => ++actualCarnivores);
            Mock.NonPublic.Arrange(room, "AddDog", new object[1] { dog }).DoInstead(() => ++actualDog);
            Mock.NonPublic.Arrange(room, "AddCat", new object[1] { cat }).DoInstead(() => ++actualCat);

            //actual
            room.Add(lion);
            room.Add(tiger);
            room.Add(wolf);
            room.Add(cat);
            room.Add(dog);
            string actualHorse = room.Add(horse);

            Assert.AreEqual(expectedCarnivores, actualCarnivores);
            Assert.AreEqual(expectedCat, actualCat);
            Assert.AreEqual(expectedDog, actualDog);
            Assert.AreEqual(expectedHorse, actualHorse);
        }

        [TestMethod]
        public void BuildVolaryTest()
        {
            // Кімната з чотирма вольєрами
            Room Room1 = new Room();
            Room1.volary = new Volary();
            for (int i = 0; i < 3; i++)
            {
                Room1.volary.buildVolary();
            }
            string Room1expected = "Неможливо збудувати вольєр! Немає вiльної кімнати!";

            string Room1actual = Room1.BuildVolary();

            Assert.AreEqual(Room1expected, Room1actual);

            //Кімната з чотирма вольєрами і іншою кімнатою

            bool room2expected = false;
            Room room2 = new Room();
            RoomStub roomStub2 = new RoomStub();
            room2.room = roomStub2;
            Mock.Arrange(() => roomStub2.BuildVolary()).DoInstead(() => room2expected = true);
            room2.volary = new Volary();
            for (int i = 0; i < 3; i++)
            {
                room2.volary.buildVolary();
            }

            room2.BuildVolary();

            Assert.IsTrue(room2expected);

            // Зайнята кімната
            string Room3expected = "Неможливо збудувати вольєр! Немає вiльної кімнати!";
            Room room3 = new Room();
            Cat cat = new Cat("Мурзик", "ч");
            room3.animals.Add(cat);

            string room3actual = room3.BuildVolary();

            Assert.AreEqual(Room3expected, room3actual);

            // Зайнята кімната з іншою кімнатою

            bool room4expected = false;
            Room room4 = new Room();
            RoomStub roomStub4 = new RoomStub();
            room4.room = roomStub4;
            Mock.Arrange(() => roomStub4.BuildVolary()).DoInstead(() => room4expected = true);
            room4.volary = new Volary();
            for (int i = 0; i < 3; i++)
            {
                room4.volary.buildVolary();
            }
            Cat cat2 = new Cat("Пиріжок", "ч");
            room4.animals.Add(cat2);

            room4.BuildVolary();

            Assert.IsTrue(room4expected);

            // Кімната з менш ніж чотирма вольєрами

            Room room5 = new Room();
            room5.volary = new Volary();
            string room5expected = "Новий вольер збудовано.";
            string room5actual = "";
            Mock.Arrange(() => room5.volary.buildVolary()).DoInstead(() => room5actual = room5expected);

            room5.BuildVolary();

            Assert.AreEqual(room5expected, room5actual);

            // Пуста кімната

            Room room6 = new Room();
            string room6expected = "Новий вольер збудовано.";

            string room6actual = room6.BuildVolary();

            Assert.AreEqual(room6expected, room6actual);
        }

        [TestMethod]
        public void RoomBuildTest()
        {
            //expected
            bool called = false;
            bool redirected = false;

            Room room = new Room();
            Mock.Arrange(() => new Room()).DoInstead(() => called = true);
            room.BuildRoom();
            RoomStub roomStub = new RoomStub();
            room.room = roomStub;
            Mock.Arrange(() => roomStub.BuildRoom()).DoInstead(() => redirected = true);
            room.BuildRoom();

            Assert.IsTrue(called);
            Assert.IsTrue(redirected);
        }

        [TestMethod]
        public void CallTest()
        {
            //expected
            Room room = new Room();
            room.BuildVolary();
            RoomStub roomStub = new RoomStub();
            room.room = roomStub;
            List<string> expectedVolary = new List<string> { "expectedVolary" };
            List<string> expectedList = new List<string>() { "expectedList" };

            Mock.Arrange(() => room.volary.Call()).Returns(expectedVolary);
            Mock.Arrange(() => roomStub.Call()).Returns(expectedList);

            // actual
            List<string> list = room.Call();

            Assert.AreEqual(expectedList[0], list[0]);
            Assert.AreEqual(expectedVolary[0], list[1]);

            // Інша кімната без вольєрів.

            string expected = "expected";
            Room room1 = new Room();
            Dog dog = new Dog("Джекпот", "ч");
            room1.Add(dog);

            Mock.Arrange(() => dog.Voice()).Returns(expected);

            List<string> list1 = room1.Call();

            Assert.AreEqual(expected, list1[0]);
        }

        [TestMethod]
        public void CallByNameTest()
        {
            //expected
            Dog dog = new Dog("Вовкодав", "ч");
            Dog dog1 = new Dog("Диктатор", "ч");
            Dog dog2 = new Dog("Диктатор", "ч");
            Room room = new Room();
            room.Add(dog);
            room.Add(dog1);
            room.Add(dog2);
            RoomStub roomStub = new RoomStub();
            room.room = roomStub;
            string expexted = "expexted";
            List<string> expectedList = new List<string>() { "expectedList" };

            Mock.Arrange(() => dog1.Voice()).Returns(expexted);
            Mock.Arrange(() => dog2.Voice()).Returns(expexted);
            Mock.Arrange(() => roomStub.Call(Arg.IsAny<string>())).Returns(expectedList);

            // actual
            List<string> list = room.Call("Диктатор");

            Assert.AreEqual(expexted, list[0]);
            Assert.AreEqual(expexted, list[1]);
            Assert.AreEqual(expectedList[0], list[2]);
            Assert.AreEqual(3, list.Count);

            // Кімната для тестування виклику з вольєра.

            Room room1 = new Room();
            Volary volary = new Volary();
            room1.volary = volary;
            List<string> expectedVolary = new List<string>() { "expectedVolary" };

            Mock.Arrange(() => volary.Call(Arg.IsAny<string>())).Returns(expectedVolary);

            List<string> actualList = room1.Call("AnyName");

            Assert.AreEqual(expectedVolary[0], actualList[0]);
        }

        [TestMethod]
        public void GetFoodTest()
        {
            //expected
            Dog dog = new Dog("Вовкодав", "ч");
            Room room = new Room();
            room.Add(dog);
            RoomStub roomStub = new RoomStub();
            room.room = roomStub;
            double expexted = 9.0;

            Mock.Arrange(() => dog.dailyFood).Returns(0.9);
            Mock.Arrange(() => roomStub.GetFood()).Returns(8.1);

            // actual
            double actual = room.GetFood();

            Assert.AreEqual(expexted, actual);

            // Кімната для тестування виклику з вольєра.

            double expectedVolary = 11.0;
            Room room1 = new Room();
            Volary volary = new Volary();
            room1.volary = volary;

            Mock.Arrange(() => volary.GetFood()).Returns(expectedVolary);

            double actualVolary = room1.GetFood();

            Assert.AreEqual(expectedVolary, actualVolary);
        }

        [TestMethod]
        public void CountAnimalsTest()
        {
            //expected
            Room room = new Room();
            RoomStub roomStub = new RoomStub();
            Volary volary = new Volary();
            room.volary = volary;
            room.room = roomStub;
            int expexted = 2;

            Mock.Arrange(() => roomStub.CountAnimals()).Returns(1);
            Mock.Arrange(() => volary.CountAnimals()).Returns(1);

            // actual
            int actual = room.CountAnimals();

            Assert.AreEqual(expexted, actual);
        }
    }

    class RoomStub : Room
    {

    }
}
