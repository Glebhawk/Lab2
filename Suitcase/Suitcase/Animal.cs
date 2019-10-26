using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suitcase
{
    class Animal
    {
        public string species { get; protected set; }
        public string name { get; protected set; }
        public string sex { get; protected set; }
        public double dailyFood { get; protected set; }

        public Animal(string n, string s)
        {
            name = n;
            sex = s;
        }

        public virtual string Voice()
        {
            return "";
        }
    }

    class Lion : Animal 
    {
        public Lion(string n, string s) : base(n, s)
        {
            species = "lion";
            dailyFood = 7.5;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "РРА! Мене звуть " + name + ", я лев!";
            }
            else
            {
                return "РРА! Мене звуть " + name + ", я левиця!";
            }
        }
    }

    class Tiger : Animal
    {
        public Tiger(string n, string s) : base(n, s)
        {
            species = "tiger";
            dailyFood = 11.0;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "РРА! Мене звуть " + name + ", я тигр!";
            }
            else
            {
                return "РРА! Мене звуть " + name + ", я тигриця!";
            }
        }
    }

    class Wolf : Animal
    {
        public Wolf(string n, string s) : base(n, s)
        {
            species = "wolf";
            dailyFood = 4.0;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "Грр! Мене звуть " + name + ", я вовк!";
            }
            else
            {
                return "Грр! Мене звуть " + name + ", я вовчиця!";
            }
        }
    }

    class Cat : Animal
    {
        public Cat(string n, string s) : base(n, s)
        {
            species = "cat";
            dailyFood = 0.1;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "Мяу! Мене звуть " + name + ", я кiт!";
            }
            else
            {
                return "Мяу! Мене звуть " + name + ", я кiшка!";
            }
        }
    }

    class Dog : Animal
    {
        public Dog(string n, string s) : base(n, s)
        {
            species = "dog";
            dailyFood = 0.9;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "Гав! Мене звуть " + name + ", я пес!";
            }
            else
            {
                return "Гав! Мене звуть " + name + ", я собака!";
            }
        }
    }

    class Deer : Animal
    {
        public Deer(string n, string s) : base(n, s)
        {
            species = "deer";
            dailyFood = 1.0;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "ООЕЕ! Мене звуть " + name + ", я олень!";
            }
            else
            {
                return "ООЕЕ! Мене звуть " + name + ", я олениха!";
            }
        }
    }

    class Horse : Animal
    {
        public Horse(string n, string s) : base(n, s)
        {
            species = "horse";
            dailyFood = 7.0;
        }

        public override string Voice()
        {
            if (sex == "m")
            {
                return "Ігого! Мене звуть " + name + ", я кiнь!";
            }
            else
            {
                return "Ігого! Мене звуть " + name + ", я кобила!";
            }
        }
    }
}
