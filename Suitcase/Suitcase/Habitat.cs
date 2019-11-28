using System.Collections.Generic;

namespace Suitcase
{
    public class Habitat // Це базовий клас для усіх середовищ проживання. Він містить переважно віртуальні методи.
    {
        public List<Animal> animals = new List<Animal>();

        public virtual string Add(Animal animal) // Конкретно цей метод ми використовуємо для того, щоб вирішити, куди ми відправимо тварину.
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

        public virtual double GetFood() // Ми хочемо знати, скільки тварини в кімнатах і на пасовищах їдять.
        {
            double food = 0.0;
            food += Case.room.GetFood();
            food += Case.pasture.GetFood();
            return food;
        }

        public virtual int CountAnimals() // Ми рахуємо, скільки у нас є тварин.
        {
            int counter = 0;
            counter += Case.room.CountAnimals();
            counter += Case.pasture.CountAnimals();
            return counter;
        }

        public double GetAvgFood() // Цей метод потрібен для того, щоб дізнатися, скільки в середньому їсть одна тварина.
        {
            double food = GetFood();
            return food / CountAnimals();
        }
    }
}
