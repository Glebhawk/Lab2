// Room is one of habitats for animals.
using System.Collections.Generic;
using System.Linq;

namespace Suitcase
{
    class Room : Habitat
    {
        Volary volary; // Room can contain up to 4 volaries. Actually, this is list.
        Room room;     // Room contains reference for next room in "list".

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
                default: // If this animal is horse or deer, we can`t add it to room.
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
                if (count < 4)
                {
                    volary.buildVolary(); // We can`t have more than four volaries in one room.
                }
                else if (room != null)
                {
                    room.buildVolary();   // We delegate creation of volaries to another room, if it exists.
                }
                else
                {
                    return "Неможливо збудувати вольєр! Немає вiльної кімнати!";
                }
            }
            else if (animals.Count() > 0) // Also room should not be already occupied.
            {
                volary.buildVolary(); // If there are no volaries in this room, we can build it.
            }
            else
            {
                return "Неможливо збудувати вольєр! Немає вiльної кімнати!";
            }
            return "Новий вольер збудовано.";
        }

        public void buildRoom()
        {
            if (room != null)
            {
                room.buildRoom(); // If next room in "list" already exists, we delegate creation of new room.
            }
            else
            {
                room = new Room(); // If this room is last, we create it here.
            }
        }

        private string AddCarnivore(Animal animal)
        {
            if (volary == null)
            {
                return "Неможливо заселити тварину! Немає спецiального вольєра!";
                // If there are no volaries in this room, THERE CLEARLY will be no volaries in the next one.
                // So I don`t even bother asking.
            }
            else
            {
                string result = volary.Add(animal); // We try to add animal in volary.
                if (result == "Неможливо заселити тварину! Всi вольєри зайнятi!")
                {   // It is possible, that all volaries are occupied.
                    if (room == null)
                    {
                        return result; // If no more rooms left, we can`t do anything else.
                    }
                    else
                    {
                        return room.Add(animal); // We try to add animal into next room.
                    }
                }
                else
                {
                    return result; // There was free volary and we successfully added animal.
                }
            }
        }

        private string AddCat(Animal animal)
        {
            if (volary != null)
            {   // Cats don`t need volaries. They just live in rooms WITHOUT volaries, because beasts scare them.
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
            {   // Also cats can`t live together with dogs.
                foreach (Animal an in animals)
                {
                    if (an.species == "dog")
                    {
                        return "Неможливо заселити кота! Немає вiльної кімнати!";
                    }
                }
                if (animals.Count >= 10) // We can`t add more than ten cats.
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
        {   // All rules for cats also act for dogs.
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
                if (animals.Count >= 10)
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

        public override List<string> Call() // Here we call all animals.
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                list.Add(animal.Voice()); // All animals fron room.
            }
            if (room != null)
            {
                list.AddRange(room.Call()); // All animals from next rooms.
            }
            if (volary != null)
            {
                list.AddRange(volary.Call()); // All animals from volaries in this room.
            }
            return list;
        }

        public override List<string> Call(string name) // We call animal by name.
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                if (animal.name == name)
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

        public override double GetFood() // We have to know, how much food animals consume.
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

        public override int CountAnimals() // How many animals we settled.
        {
            int counter = 0;
            if (animals.Count() != 0)
            {
                foreach (Animal animal in animals)
                {
                    ++counter;
                }
            }
            if (room != null)
            {
                counter += room.CountAnimals();
            }
            if (volary != null)
            {
                counter += volary.CountAnimals();
            }
            return counter;
        }
    }
}
