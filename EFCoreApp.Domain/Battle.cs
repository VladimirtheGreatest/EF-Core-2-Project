using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }
}
