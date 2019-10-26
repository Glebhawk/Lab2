using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suitcase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск програми.");
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Biologist biologist = new Biologist();
            bool execute = true;
            do {
                PrintOptoins();
                Console.WriteLine("");
                GetKey(biologist, execute);
            } while (execute);
            Console.ReadKey();
            }

        public static void PrintOptoins()
        {
            Console.WriteLine("");
            if (Case.dayTime.time == "day")
            {
                Console.WriteLine("У валiзi зараз день. Що ви хочете зробити?");
            }
            else
            {
                Console.WriteLine("У валiзi зараз нiч. Що ви хочете зробити?");
            }
            Console.WriteLine("1. Додати кiмнату.");
            Console.WriteLine("2. Додати вольєр.");
            Console.WriteLine("3. Додати пасовище.");
            Console.WriteLine("4. Додати тварину.");
            Console.WriteLine("5. Змiнити час доби.");
            Console.WriteLine("6. Покликати тварину.");
            Console.WriteLine("7. Покликати усiх тварин.");
            Console.WriteLine("8. Загальне добове споживання їжi.");
            Console.WriteLine("9. Середнє добове споживання їжi на тварину.");
            Console.WriteLine("Esc. Завершити роботу.");
        }

        public static void GetKey(Biologist biologist,  bool execute)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                execute = false;
                Console.WriteLine("Завершення роботи.");
            }
            char key = cki.KeyChar;
            switch (key)
            {
                case '1':
                    {
                        Case.room.buildRoom();
                        Console.WriteLine("Ви збудували нову кiмнату!");
                        break;
                    }
                case '2':
                    {
                        Case.room.buildVolary();
                        Console.WriteLine("Ви збудували новий вольєр!");
                        break;
                    }
                case '3':
                    {
                        Case.pasture.BuildPasture();
                        Console.WriteLine("Ви збудували нове пасовище!");
                        break;
                    }
                case '4':
                    {
                        Console.WriteLine("Введiть вид нової тварини. Використовуйте слова \"лев\", \"тигр\", \"вовк\", \"собака\", \"кiт\", \"олень\", \"кiнь\".");
                        string species = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine("Введiть стать нової тварини. Будь ласка, використовуйте букви \"ч\" або \"ж\".");
                        string sex = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine("Введiть iм'я нової тварини.");
                        string name = Console.ReadLine();
                        Console.WriteLine(biologist.AddAnimal(name, species, sex));
                        break;
                    }
                case '5':
                    {
                        Case.dayTime.Change();
                        if (Case.dayTime.time == "day")
                        {
                            Console.WriteLine("У валiзi настав день!");
                        }
                        else
                        {
                            Console.WriteLine("У валiзi настала нiч!");
                        }
                        break;
                    }
                case '6':
                    {
                        Console.WriteLine("Введiть iм'я тварини, яку хочете покликати.");
                        string name = Console.ReadLine().Trim();
                        List<string> list = biologist.CallByName(name);
                        if (list.Count == 0)
                        {
                            Console.WriteLine("На жаль, такої тварини немає.");
                        }
                        else
                        {
                            foreach (string str in list)
                            {
                                Console.WriteLine(str);
                            }
                        }
                        break;
                    }
                case '7':
                    {
                        List<string> list = biologist.CallEveryone();
                        foreach (string str in list)
                        {
                            Console.WriteLine(str);
                        }
                        break;
                    }
                case '8':
                    {
                        Console.WriteLine("Загальне добове споживання їжi: "+ biologist.CalculateAllFood() + " кг на день.");
                        break;
                    }
                case '9':
                    {
                        Console.WriteLine("Середнє добове споживання їжi на тварину: " + biologist.CalculateAvgFood() + " кг на день.");
                        break;
                    }
                default:
                    {
                        GetKey(biologist, execute);
                        break;
                    }
            }
        }
    }
}
