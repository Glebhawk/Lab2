// This is class to perform all oprations and requests with animals.
using System.Collections.Generic;

namespace Suitcase
{
    static class Biologist
    {
        static Habitat habitat = new Habitat();
        public static List<string> CallEveryone()
        {
            List<string> list = new List<string>(); // Each animal returns string when called. We collect all strings to list.
            Case.dayTime.CallEveryone(list);        // Animals sleep at night. That`s why we use method of DayTime instead of
            return list;                            // calling them directly.
        }

        public static List<string> CallByName(string name)
        {
            List<string> list = Case.room.Call(name); // Animals called by name answer even at night.
            list.AddRange(Case.pasture.Call(name));   // That`s why we can call them directly.
            if (list.Count == 0)
            {
                list.Add("На жаль, такої тварини немає.");
            }
            return list;                              // We return list, because there can be many animals with same names.
        }

        public static void Change()
        {
            Case.dayTime.Change(); // This changes day for night or vice versa.
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
