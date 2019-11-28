// Що краще, використовувати світч чи сім классів-конструкторів?
// В будь-якому випадку, ваша робота починається тут.
using System;
using System.Collections.Generic;

namespace Suitcase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск програми.");                
            Console.InputEncoding = System.Text.Encoding.Unicode; // Це нам потрібно, щоб розблокувати українську "і". Слава Україні!
            bool execute;                                         // На виводі просто стоїть англійська "i".
            do {                             // Це головний цикл програми.
                PrintOptoins();              // Він друкує пункти меню
                execute = GetKey();          // і чекає, поки користувач натисне клавішу.
            } while (execute);               // Він переривається, коли ми натискаємо esc. "Ми". Користувач.
            }

        public static void PrintOptoins() // Ми друкуємо опції для біолога.
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

        public static bool GetKey() // Цей метод зчитує натиснуту клавішу і вирішує, що робити.
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Завершення роботи."); // Коли натиснуто esc, нам треба зупинити головний цикл.
                return false;                            // Тому ми і повертаємо bool.
            }
            char key = cki.KeyChar;
            switch (key)            // Ми використовуємо світч, щоб вирішити, що робити.
            {                       // Да-да, це той самий ІІ на світчах.
                case '1':
                    {
                        Case.room.BuildRoom();
                        Console.WriteLine("Ви збудували нову кiмнату!");
                        break;
                    }
                case '2':
                    {
                        Case.room.BuildVolary();
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
                        // Нам треба зібрати дані про тварину, яку ми хочемо створити.
                        Console.WriteLine("Введiть вид нової тварини. Використовуйте слова \"лев\", \"тигр\", \"вовк\", \"собака\", \"кiт\", \"олень\", \"кiнь\".");
                        string species = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine("Введiть стать нової тварини. Будь ласка, використовуйте букви \"ч\" або \"ж\".");
                        string sex = Console.ReadLine().ToLower().Trim();
                        Console.WriteLine("Введiть iм'я нової тварини.");
                        string name = Console.ReadLine();
                        Console.WriteLine(Biologist.AddAnimal(name, species, sex)); // Потім передати дані в потрібний метод.
                        // У випадку успіху Biologist поверне рядок "Тварину додано!".
                        // Інакше довгий ланцюг об'єктів передасть рядок, який вкаже користувачу, що не так.
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
