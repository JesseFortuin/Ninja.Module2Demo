﻿using NinjaDomain.Classes.Enums;
using NinjaDomain.Classes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace NinjaDomain.Classes
{


    public class Clan : IModificationHistory
    {
        public Clan()
        {
            Ninjas = new List<Ninja>();
        }

        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }

        public DateTime DateModified { get ; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }

}