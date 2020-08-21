using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class Badges
    {
        public Badges() { }

        public Badges(int badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
