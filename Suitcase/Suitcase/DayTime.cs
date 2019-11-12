// This is class for day/night state.
using System.Collections.Generic;

namespace Suitcase
{
    class DayTime // Basic class contains only virtual methods
    {
        public virtual string Change() // To change day/night state.
        {
            return "";
        }

        public virtual void CallEveryone(List<string> list) // To call animals.
        {
        }

        public virtual string GetTime() { return ""; } // To show current time.
    }

    class Day : DayTime
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

    class Night : DayTime
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
