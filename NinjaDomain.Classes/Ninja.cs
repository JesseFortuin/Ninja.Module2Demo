using NinjaDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomain.Classes
{
    public class Ninja : IModificationHistory
    {
        //when adding equipement it doesn't need to be manually instantiated first to add items 
        public Ninja()
        {
            EquipmentOwned = new List<NinjaEquipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInOniwaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public List<NinjaEquipment> EquipmentOwned { get; set; }
        public System.DateTime DateOfBirth { get; set; }

        public DateTime DateModified { get ; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
