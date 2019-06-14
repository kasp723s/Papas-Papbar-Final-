using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapasPapbar.Domain
{
    public class GameStats
    {
        public string DateScanned;
        public int CountScanned;

        public GameStats(string dateScanned, int countScanned)
        {
            DateScanned = dateScanned;
            CountScanned = countScanned;
        }
    }
}
