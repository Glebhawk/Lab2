using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suitcase
{
    class Biologist
    {
        public List<string> CallEveryone()
        {
            List<string> list = new List<string>();
            Case.dayTime.CallEveryone(list);
            return list;
        }

        public List<string> CallByName(string name)
        {
            List<string> list = Case.room.Call(name);
            list.AddRange(Case.pasture.Call(name));
            return list;
        }

        public void Change()
        {
            Case.dayTime.Change();
        }

        public double CalculateAllFood()
        {
            double food = 0.0;
            food += Case.room.GetFood();
            food += Case.pasture.GetFood();
            return food;
        }

        public double CalculateAvgFood()
        {
            double avgFood = 0.0;
            avgFood += Case.room.GetAvgFood();
            avgFood += Case.pasture.GetAvgFood();
            return avgFood;
        }

        public string AddAnimal(string name, string species, string sex)
        {
            Animal animal;
            switch(species)
            {
                case ("лев"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Lion(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Lion(name, "s");
                            break;
                        } 
                        else
                        {
                            return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                case ("тигр"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Tiger(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Tiger(name, "s");
                            break;
                        }
                        else
                        {
                            return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                case ("вовк"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Wolf(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Wolf(name, "s");
                            break;
                        }
                        else
                        {
                            return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                case ("кіт"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Cat(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Cat(name, "s");
                            break;
                        }
                        else
                        {
                            return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                case ("собака"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Dog(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Dog(name, "s");
                            break;
                        }
                        else
                        {
                            return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                case ("олень"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Deer(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Deer(name, "s");
                            break;
                        }
                        else
                        {
                            return "Неможливо визначити стать, будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                case ("кінь"):
                    {
                        if (sex == "ч")
                        {
                            animal = new Horse(name, "m");
                            break;
                        }
                        else if (sex == "ж")
                        {
                            animal = new Horse(name, "s");
                            break;
                        }
                        else
                        {
                            return "Неможливо визначити стать. Будь ласка, використовуйте букви \"ч\" або \"ж\".";
                        }
                    }
                default:
                    {
                        animal = new Animal("animal", "m");
                        return "Неможливо визначити вид. Будь ласка, використовуйте слова \"лев\", \"тигр\", \"вовк\", \"собака\", \"кiт\", \"олень\", \"кiнь\".";
                    }
            }
            Habitat habitat = new Habitat();
            return habitat.Add(animal);
        }
    }
}
