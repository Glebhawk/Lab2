// Це клас-стан для циклу день/ніч.
using System.Collections.Generic;

namespace Suitcase
{
    public class DayTime // Базовий клас, містить лише віртуальні методи.
    {
        public virtual string Change() // Метод для зміни стану.
        {
            return "";
        }

        public virtual void CallEveryone(List<string> list) // Метод, щоб кликати тварин.
        {
        }

        public virtual string GetTime() { return ""; } // Метод, що повертає час доби.
    }

    public class Day : DayTime
    {
        public override string Change()
        {
            Case.dayTime = new Night();
            return "У валiзi настала нiч!";
        }

        public override void CallEveryone(List<string> list)
        {
            list.AddRange(Case.room.Call());
            list.AddRange(Case.pasture.Call());
        }

        public override string GetTime()
        {
            return "У валiзi зараз день. Що ви хочете зробити?";
        }
    }

    public class Night : DayTime
    {
        public override string Change()
        {
            Case.dayTime = new Day();
            return "У валiзi настав день!";
        }

        public override void CallEveryone(List<string> list)
        {
            list.Add("Усi тварини зараз сплять.");
        }

        public override string GetTime()
        {
            return "У валiзi зараз нiч. Що ви хочете зробити?";
        }
    }
}
