using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class BadgesRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        public void AddBadgesToDirectory(int badgeID, List<string> doorName)
        {
            
            _badgeDictionary.Add(badgeID, doorName);
            
        }
        public Dictionary<int, List<string>> GetBadgeDirectory()
        {
            return _badgeDictionary;
        }
    }
}
