using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suitcase
{
    class DayTime
    {
        public virtual void Change()
        {
        }

        public virtual void CallEveryone(List<string> list)
        {
        }
    }

    class Day : DayTime
    {
        public override void Change()
        {
            Case.dayTime = new Night();
        }

        public override void CallEveryone(List<string> list)
        {
            list.AddRange(Case.room.Call());
            list.AddRange(Case.pasture.Call());
        }
    }

    class Night : DayTime
    {
        public override void Change()
        {
            Case.dayTime = new Day();
        }

        public override void CallEveryone(List<string> list)
        {
            list.Add("Усi тварини зараз сплять.");
        }
    }
}
