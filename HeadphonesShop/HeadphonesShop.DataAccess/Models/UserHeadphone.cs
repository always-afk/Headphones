using System;
using System.Collections.Generic;

#nullable disable

namespace HeadphonesShop.DataAccess.Models
{
    public partial class UserHeadphone
    {
        public int Id { get; set; }
        public int? HeadphonesId { get; set; }
        public int? UserId { get; set; }

        public virtual Headphone Headphones { get; set; }
        public virtual User User { get; set; }
    }
}
