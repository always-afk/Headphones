#nullable disable

namespace HeadphonesShop.PresentationWebAPI.Models.LogicModels
{
    public partial class Headphones
    {
        public string Name { get; set; }
        public double? MinFrequency { get; set; }
        public double? MaxFrequency { get; set; }
        public string Picture { get; set; }

        public Company Company { get; set; }
        public Design Design { get; set; }
    }
}
