using System.Collections.Generic;

namespace Suitcase
{
    class Habitat // is a basic class for all habitats. It contains mostly virtual methods.
    {
        public List<Animal> animals = new List<Animal>();

        public virtual string Add(Animal animal) // We use this once to decide, where we will put newly created animal.
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

        public virtual double GetFood() // We use this to count, how much food the animals in rooms and on pastures eat.
        {
            double food = 0.0;
            food += Case.room.GetFood();
            food += Case.pasture.GetFood();
            return food;
        }

        public virtual int CountAnimals() // We use this to count all the animals in rooms and on pastures.
        {
            int counter = 0;
            counter += Case.room.CountAnimals();
            counter += Case.pasture.CountAnimals();
            return counter;
        }

        public double GetAvgFood() // We use this to count, how much food per animal we spend.
        {
            double food = GetFood();
            return food / CountAnimals();
        }
    }
}
