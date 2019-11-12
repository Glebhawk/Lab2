// Volary is a habitat for carnivorous beasts: lions, tigers, and somewhat weaker wolves.
using System.Collections.Generic;
using System.Linq;

namespace Suitcase
{
    class Volary : Habitat
    {
        Volary volary;

        public override string Add(Animal animal)
        {
            if (animal.sex == "m")                     // We can`t add two males in one volary, or they will start to fight.
            {
                foreach (Animal an in animals)
                {
                    if (an.sex == "m")
                    {
                        return RedirectAnimal(animal);
                    }
                }
            }
            foreach (Animal an in animals)                
            {
                if (an.species != animal.species)  // We can`t move tiger to lions or wolf to tigers.
                {
                    return RedirectAnimal(animal);  
                }
            }
            if (volary.animals.Count() >= 4)       // We can`t have more than four carnivores in one volary.
            {
                return RedirectAnimal(animal);
            }
            else
            {
                animals.Add(animal);
                return "Тварину додано.";
            }
        }

        private string RedirectAnimal(Animal animal) // Private method for redirecting animal to other volaries
        {                                            // when this volary can`t handle it.
            if (volary != null)
            {
                return volary.Add(animal);
            }
            else
            {
                return "Неможливо заселити тварину! Всi вольєри зайнятi!";
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

        public override int CountAnimals()
        {
            int counter = 0;
            foreach (Animal animal in animals)
            {
                ++counter;
            }
            if (volary != null)
            {
                counter += volary.CountAnimals();
            }
            return counter;
        }

        public int Count() // Behaviour of room depends on how many volaries it contains.
        {                  // This method allows us to count volaries like if they were in list.
            int count = 1;
            if (volary != null)
            {
                count += volary.Count();
            }
            return count;
        }
    }
}
