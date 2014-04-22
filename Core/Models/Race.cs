using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Models
{
    public class Race : IEntity
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        //[ForeignKey("RaceTypeId")]
        public virtual RaceType RaceType { get; set; }

        public decimal RaceLength { get; set; }

        public virtual ICollection<User> Users { get; set;} 

        public DateTime CreatedDate { get; set; }

        public Race()
        {
            Users = new HashSet<User>();
        }
    }
}
