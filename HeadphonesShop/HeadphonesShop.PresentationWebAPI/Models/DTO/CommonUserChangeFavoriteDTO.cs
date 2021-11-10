using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadphonesShop.PresentationWebAPI.Models.DTO
{
    public class CommonUserChangeFavoriteDTO
    {
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
    }
}
