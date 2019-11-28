// Пасовище це середовище проживання для коней і оленів.
using System.Collections.Generic;

namespace Suitcase
{
    public class Pasture : Habitat
    {
        public Pasture pasture { get; set; }

        public override string Add(Animal animal)
        {
            if (animals.Count >= 20) // На одному пасовищі живе до 20 тварин.
            {                        // Інших обмежень немає. Коні і олені ж не їдять один одного, так?
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

        public virtual void BuildPasture()
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

        public override int CountAnimals()
        {
            int counter = 0;
            foreach (Animal animal in animals)
            {
                ++counter;
            }
            if (pasture != null)
            {
                counter += pasture.CountAnimals();
            }
            return counter;
        }
    }
}
