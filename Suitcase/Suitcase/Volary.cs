// Вольєри це середовище проживання для хижих звірів: левів, тигрів і слабкіших вовків.
using System.Collections.Generic;
using System.Linq;

namespace Suitcase
{
    public class Volary : Habitat
    {
        public Volary volary { get; set; }

        public override string Add(Animal animal)
        {
            if (animal.sex == "m")                     // Ми не можемо додати у вольєр двох самців, інакше вони поб'ються.
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
                if (an.species != animal.species)  // Ми не можемо тримати в одному вольєрі тварин разних видів.
                {
                    return RedirectAnimal(animal);  
                }
            }
            if (animals.Count() >= 4)       // Ми не можемо поселити у один вольєр більше чотирьох тварин.
            {
                return RedirectAnimal(animal);
            }
            else
            {
                animals.Add(animal);
                return "Тварину додано.";
            }
        }

        private string RedirectAnimal(Animal animal) // Метод для передачі тварин у інший вольєр,
        {                                            // якщо цей вольєр не може її вмістити.
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

        public int Count() // Поведінка кімнати залежить від того, скільки вольєрів вона містить.
        {                  // Цей метод дозволяє кімнаті рахувати вольєри так, типу вони у списку.
            int count = 1;
            if (volary != null)
            {
                count += volary.Count();
            }
            return count;
        }
    }
}
