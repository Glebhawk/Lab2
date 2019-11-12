// What is better? To use switch or seven constructor classes?
// Anyway, now your work begins.
using System;
using System.Collections.Generic;

namespace Suitcase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск програми.");                
            Console.InputEncoding = System.Text.Encoding.Unicode; // We use this to get access to ukraianian "і"
            bool execute;                                         // for the glory of Ukraine!
            do {                             // This is main cycle of program.
                PrintOptoins();
                Console.WriteLine("");
                execute = GetKey();
            } while (execute);               // It ends only when we press esc.
            }

        public static void PrintOptoins() //We print options for our biologist.
        {
            Console.WriteLine("");
            Console.WriteLine(Case.dayTime.GetTime());
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

        public static bool GetKey() //This method gets key and tells other classes what to do.
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Завершення роботи."); // When escape is pressed, we have to stop the main cycle.
                return false;                            // That's why we return bool.
            }
            char key = cki.KeyChar;
            switch (key)            //We use switch to decide, what to do.
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
                        // We have to collect data about animal we want to create.
                        Console.WriteLine("Введiть вид нової тварини. Використовуйте слова \"лев\", \"тигр\", \"вовк\", \"собака\", \"кiт\", \"олень\", \"кiнь\".");
                        string species = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine("Введiть стать нової тварини. Будь ласка, використовуйте букви \"ч\" або \"ж\".");
                        string sex = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine("Введiть iм'я нової тварини.");
                        string name = Console.ReadLine();
                        Console.WriteLine(Biologist.AddAnimal(name, species, sex));
                        // In case of sucess biologist returns string "Animal added".
                        // Else long chain of objects passes to him string from object, where mistake appeared.
                        break;
                    }
                case '5':
                    {
                        Console.WriteLine(Case.dayTime.Change());
                        break;
                    }
                case '6':
                    {
                        Console.WriteLine("Введiть iм'я тварини, яку хочете покликати.");
                        string name = Console.ReadLine().Trim();
                        List<string> list = Biologist.CallByName(name);
                        foreach (string str in list)
                        {
                            Console.WriteLine(str);
                        }
                        break;
                    }
                case '7':
                    {
                        List<string> list = Biologist.CallEveryone();
                        foreach (string str in list)
                        {
                            Console.WriteLine(str);
                        }
                        break;
                    }
                case '8':
                    {
                        Console.WriteLine("Загальне добове споживання їжi: "+ Biologist.CalculateAllFood() + " кг на день.");
                        break;
                    }
                case '9':
                    {
                        Console.WriteLine("Середнє добове споживання їжi на тварину: " + Biologist.CalculateAvgFood() + " кг на день.");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return true;
        }
    }
}
