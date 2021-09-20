using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.DataAccess.Models
{
    public partial class Design
    {
        public Design()
        {
            Headphones = new HashSet<Headphone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Headphone> Headphones { get; set; }
    }
}
