// Кімната це багатофункціональне середовище проживання для тварин.
using System.Collections.Generic;
using System.Linq;

namespace Suitcase
{
    public class Room : Habitat
    {
        public Volary volary { get; set; }  // Кімната може містити до 4 вольєрів. Насправді, це теж список.
        public Room room { get; set; }     // Кімната містить посилання на наступну кімнату в "списку".

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
                default: // Кінь або олень не можуть жити в кімнаті.
                    {
                        return "Цю тварину неможливо заселити у кімнату!";
                    }
            }
        }

        public string BuildVolary()
        {
            if (volary != null)
            {
                if (volary.Count() < 4)
                {
                    volary.buildVolary(); // Ми не можемо збудувати більше чотирьох вольєрів у кімнаті.
                    return "Новий вольер збудовано.";
                }
                else if (room != null)
                {
                    room.BuildVolary();   // Ми передаємо заадвння збудувати вольєр іншій кімнаті, якщо вона існує.
                    return "Новий вольер збудовано.";
                }
                else
                {
                    return "Неможливо збудувати вольєр! Немає вiльної кімнати!";
                }
            }
            else if (animals.Count() > 0) // Також кімната не повинна бути вже зайнята.
            {
                if (room != null)
                {
                    room.BuildVolary();
                    return "Новий вольер збудовано.";
                }
                else
                {
                    return "Неможливо збудувати вольєр! Немає вiльної кімнати!";
                }
            }
            else
            {
                Volary volary = new Volary(); // Якщо у кімнаті ще немає вольєрів, ми можемо збудувати один.
                return "Новий вольер збудовано.";
            }
        }

        public void BuildRoom()
        {
            if (room != null)
            {
                room.BuildRoom(); // Якщо наступна кімната у "списку" вже існує, ми наказуємо їй створити нову кімнату.
            }
            else
            {
                room = new Room(); // Якщо ця кімната остання, ми створюємо нову кімнату тут.
            }
        }

        private string AddCarnivore(Animal animal)
        {
            if (volary == null)
            {
                return RedirectCarnivore(animal);
            }
            else
            {
                string result = volary.Add(animal); // Ми намагаємося додати тварину у вольєр.
                if (result == "Неможливо заселити тварину! Всi вольєри зайнятi!")
                {
                    return RedirectCarnivore(animal);
                }
                else
                {
                    return result; // Вільний вольєр був знайдений і ми успішно додали тварину.
                }
            }
        }

        private string RedirectCarnivore(Animal animal)
        {
            if (room == null)
            {
                return "Неможливо заселити тварину! Немає спецiального вольєра!"; // Якщо ще одної вільної кімнати немає.
            }
            else
            {
                return room.Add(animal); // Якщо є, передаємо тварину туди.
            }
        }

        private string AddCat(Animal animal)
        {
            if (volary != null)
            {   // Для котів не треба вольєрів, вле вони мають жити в кімнатах без вольєрів, бо дикі звірі їх лякають.
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
            {   // Ще коти не можуть жити разом з собаками.
                foreach (Animal an in animals)
                {
                    if (an.species == "dog")
                    {
                        return "Неможливо заселити кота! Немає вiльної кімнати!";
                    }
                }
                if (animals.Count >= 10) // Ми не можемо заселити більше 10 котів.
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
        {   // Всі правила для котів поширюються і на собак.
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

        public override List<string> Call() // Тут ми кличемо всіх тварин.
        {
            List<string> list = new List<string>();
            foreach (Animal animal in animals)
            {
                list.Add(animal.Voice()); // Усі тварини з кімнати по черзі подають голос.
            }
            if (room != null)
            {
                list.AddRange(room.Call()); // Потім подають голос тварини з наступної кімнати.
            }
            if (volary != null)
            {
                list.AddRange(volary.Call()); // І нарешті тварини з вольєрів.
            }
            return list;
        }

        public override List<string> Call(string name) // Ми кличемо тварину по імені.
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

        public override double GetFood() // Нам потрібно знати, як багато тварини їдять.
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

        public override int CountAnimals() // Скільки тварин живе в кімнатах.
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
