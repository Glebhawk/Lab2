using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suitcase
{
    class Habitat
    {
        public List<Animal> animals = new List<Animal>();

        public virtual string Add(Animal animal)
        {
            if(animal.species == "horse" | animal.species == "deer")
            {
                return Case.pasture.Add(animal);
            }
            else
            {
                return Case.room.Add(animal);
            }
        }

        public virtual List<string> Call()
        {
            List<string> list = new List<string>();
            return list;
        }

        public virtual List<string> Call(string name)
        {
            List<string> list = new List<string>();
            return list;
        }

        public virtual double GetFood()
        {
            double food = 0.0;
            return food;
        }

        public virtual double GetAvgFood()
        {
            double food = 0.0;
            return food;
        }
    }

    class Room : Habitat
    {
        Volary volary;
        Room room;

        public override string Add(Animal animal)
        {
            switch (animal.species)
            {
                case ("lion"):
                    {
                        return AddCarnivore(animal);
                    }
                case ("tiger"):
                    {
                        return AddCarnivore(animal);
                    }
                case ("wolf"):
                    {
                        return AddCarnivore(animal);
                    }
                case ("cat"):
                    {
                        return AddCat(animal);
                    }
                case ("dog"):
                    {
                        return AddDog(animal);
                    }
                default:
                    {
                        return "Цю тварину неможливо заселити у кімнату!";
                    }
            }
        }

        public string buildVolary()
        {
            if (volary != null)
            {
                int count = 0;
                count = volary.Count();
                Console.WriteLine(count);
                if (count < 4)
                {
                    volary.buildVolary();
                    Console.WriteLine("vbt");
                }
                else
                {
                    room.buildVolary();
                    Console.WriteLine("vbior");
                }
            }
            else
            {
                volary = new Volary();
            }
            return "Новий вольер збудовано.";
        }

        public void buildRoom()
        {
            if (room != null)
            {
                room.buildRoom();
            }
            else
            {
                room = new Room();
            }
        }

        private string AddCarnivore(Animal animal)
        {
            if (volary == null)
            {
                if (room == null)
                {
                    return "Неможливо заселити тварину! Немає спецiального вольєра!";
                }
                else
                {
                    return room.Add(animal);
                }
            }
            else
            {
                string result = volary.Add(animal);
                if (result == "Неможливо заселити тварину! Всi вольєри зайнятi!")
                {
                    if (room == null)
                    {
                        return result;
                    }
                    else
                    {
                        return room.Add(animal);
                    }
                }
                else
                {
                    return result;
                }
            }
        }

        private string AddCat(Animal animal)
        {
            if (volary != null)
            {
                if (room != null)
                {
                    return room.Add(animal);
                }
                else
                {
                    return "Неможливо заселити кота! Немає вiльної кімнати!";
                }
            }
            else
            {
                foreach(Animal an in animals)
                {
                    if (an.species == "dog")
                    {
                        return "Неможливо заселити кота! Немає вiльної кімнати!";
                    }
                }
                if (animals.Count > 11)
                {
                    return room.Add(animal);
                }
                else
                {
                    animals.Add(animal);
                    return "Кота додано.";
                }
            }
        }

        private string AddDog(Animal animal)
        {
            if (volary != null)
            {
                if (room != null)
                {
                    return room.Add(animal);
                }
                else
                {
                    return "Неможливо заселити собаку! Немає вiльної кімнати!";
                }
            }
            else
            {
                foreach (Animal an in animals)
                {
                    if (an.species == "cat")
                    {
                        return "Неможливо заселити собаку! Немає вiльної кімнати!";
                    }
                }
                if (animals.Count > 11)
                {
                    return room.Add(animal);
                }
                else
                {
                    animals.Add(animal);
                    return "Собаку додано.";
                }
            }
        }

        public override List<string> Call()
        {
            List<string> list = new List<string>();
            foreach(Animal animal in animals)
            {
                list.Add(animal.Voice());
            }
            if (room != null)
            {
                list.AddRange(room.Call());
            }
            if (volary != null)
            {
                list.AddRange(volary.Call());
            }
            return list;
        }

        public override List<string> Call(string name)
        {
            List<string> list = new List<string>();
            foreach(Animal animal in animals)
            {
                if(animal.name == name)
                {
                    list.Add(animal.Voice());
                }
            }
            if (room != null)
            {
                list.AddRange(room.Call(name));
            }
            if (volary != null)
            {
                list.AddRange(volary.Call(name));
            }
            return list;
        }

        public override double GetFood()
        {
            double food = 0.0;
            foreach (Animal animal in animals)
            {
                food += animal.dailyFood;
            }
            if (room != null)
            {
                food += room.GetFood();
            }
            if (volary != null)
            {
                food += volary.GetFood();
            }
            return food;
        }

        public override double GetAvgFood()
        {
            double food = 0.0;
            if (animals.Count() != 0)
            {
                foreach (Animal animal in animals)
                {
                    food += animal.dailyFood;
                }
                food = food / animals.Count();
            }
            if (room != null)
            {
                food += room.GetAvgFood();
                food = food / 2;
            }
            if (volary != null)
            {
                food += volary.GetAvgFood();
                food = food / 2;
            }
            return food;
        }
    }

    class Volary : Habitat
    {
        Volary volary;

        public override string Add(Animal animal)
        {
            if (animal.sex == "m")
            {
                foreach (Animal an in animals)
                {
                    if (an.sex == "m")
                    {
                        if (volary != null)
                        {
                            return volary.Add(animal);
                        }
                        else
                        {
                            return "Неможливо заселити тварину! Всi вольєри зайнятi!";
                        }
                    }
                }
            }
            if (volary != null)
            {
                if (volary.animals.Count() >= 4)
                {
                    return volary.Add(animal);
                }
                else
                {
                    return "Неможливо заселити тварину! Всi вольєри зайнятi!";
                }
            }
            else
            {
                animals.Add(animal);
                return "Тварину додано.";
            }
        }

        public void buildVolary()
        {
            if (volary != null)
            {
                volary.buildVolary();
            }
            else
            {
                volary = new Volary();
            }
        }

        public override List<string> Call()
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                list.Add(animal.Voice());
            }
            if (volary != null)
            {
                list.AddRange(volary.Call());
            }
            return list;
        }

        public override List<string> Call(string name)
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                if (animal.name == name)
                {
                    list.Add(animal.Voice());
                }
            }
            if (volary != null)
            {
                list.AddRange(volary.Call(name));
            }
            return list;
        }

        public override double GetFood()
        {
            double food = 0.0;
            foreach (Animal animal in animals)
            {
                food += animal.dailyFood;
            }
            if (volary != null)
            {
                food += volary.GetFood();
            }
            return food;
        }

        public override double GetAvgFood()
        {
            double food = 0.0;
            if (animals.Count() != 0)
            {
                foreach (Animal animal in animals)
                {
                    food += animal.dailyFood;
                }
                food = food / animals.Count();
            }
            if (volary != null)
            {
                food += volary.GetAvgFood();
                food = food / 2;
            }
            return food;
        }

        public int Count()
        {
            int count = 1;
            if(volary != null)
            {
                count += volary.Count();
            }
            return count;
        }
    }

    class Pasture : Habitat
    {
        Pasture pasture;

        public override string Add(Animal animal)
        {
            if (animals.Count >= 20)
            {
                if (pasture == null)
                {
                    return "Неможливо заселити тварину! Немає вiльних пасовиськ!";
                }
                else
                {
                    return pasture.Add(animal);
                }
            }
            else
            {
                animals.Add(animal);
                return "Тварину заселено.";
            }
        }

        public void BuildPasture()
        {
            if (pasture != null)
            {
                pasture.BuildPasture();
            }
            else
            {
                pasture = new Pasture();
            }
        }

        public override List<string> Call()
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                list.Add(animal.Voice());
            }
            if (pasture != null)
            {
                list.AddRange(pasture.Call());
            }
            return list;
        }

        public override List<string> Call(string name)
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                if (animal.name == name)
                {
                    list.Add(animal.Voice());
                }
            }
            if (pasture != null)
            {
                list.AddRange(pasture.Call(name));
            }
            return list;
        }

        public override double GetFood()
        {
            double food = 0.0;
            foreach (Animal animal in animals)
            {
                food += animal.dailyFood;
            }
            if (pasture != null)
            {
                food += pasture.GetFood();
            }
            return food;
        }

        public override double GetAvgFood()
        {
            double food = 0.0;
            if (animals.Count() != 0)
            {
                foreach (Animal animal in animals)
                {
                    food += animal.dailyFood;
                }
                food = food / animals.Count();
            }
            if (pasture != null)
            {
                food += pasture.GetAvgFood();
                food = food / 2;
            }
            return food;
        }
    }
}
