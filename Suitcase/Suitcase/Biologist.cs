// Це клас для того, щоб проводити всі запити і операції з тваринами.
using System.Collections.Generic;

namespace Suitcase
{
    public static class Biologist
    {
        public static Habitat habitat { get; private set; } = new Habitat();
        public static List<string> CallEveryone()
        {
            List<string> list = new List<string>(); // Кожна тварина відповідає на заклик текстовим рядком. Ми збираємо всі рядки в список.
            Case.dayTime.CallEveryone(list);        // Вночі тварини сплять. Тому ми використовуємо метод у класі DayTime замість того,
            return list;                            // щоб кликати тварин.
        }

        public static List<string> CallByName(string name)
        {
            List<string> list = Case.room.Call(name); // Тварини, що були покликані по імені, відповідають навіть уночі.
            list.AddRange(Case.pasture.Call(name));   // Тому ми можемо кликати їх напряму.
            if (list.Count == 0)
            {
                list.Add("На жаль, такої тварини немає.");
            }
            return list;                              // Ми повертаємо список, бо у нас можуть бути тварини з однаковими іменами.
        }

        public static void Change()
        {
            Case.dayTime.Change(); // Міняє день на ніч, або навпаки.
        }

        public static double CalculateAllFood()
        {
            return habitat.GetFood();
        }

        public static double CalculateAvgFood()
        {
            return habitat.GetAvgFood();
        }

        public static string AddAnimal(string name, string species, string sex)
        {
            Animal animal;
            if (sex != "ч" && sex != "ж")
            {
                return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
            }
            switch(species)
            {
                case ("лев"):
                    {
                        animal = new Lion(name, sex);
                        break;
                    }
                case ("тигр"):
                    {
                        animal = new Tiger(name, sex);
                        break;
                    }
                case ("вовк"):
                    {
                        animal = new Wolf(name, sex);
                        break;
                    }
                case ("кіт"):
                    {
                        animal = new Cat(name, sex);
                        break;
                    }
                case ("собака"):
                    {
                        animal = new Dog(name, sex);
                        break;
                    }
                case ("олень"):
                    {
                        animal = new Deer(name, sex);
                        break;
                    }
                case ("кінь"):
                    {
                        animal = new Horse(name, sex);
                        break;
                    }
                default:
                    {
                        animal = new Animal("animal", "m");
                        return "Неможливо визначити вид. Будь ласка, використовуйте слова \"лев\", \"тигр\", \"вовк\", \"собака\", \"кiт\", \"олень\", \"кiнь\".";
                    }
            }
            return habitat.Add(animal);
        }
    }
}
