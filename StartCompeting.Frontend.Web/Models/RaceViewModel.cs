namespace StartCompeting.Frontend.Web.Models
{
    public class RaceViewModel
    {
        public string Name { get; set; }

        public int RaceTypeId { get; set; }

        public decimal RaceLength { get; set; }
    }

    public class RaceType
    {
        public int RaceTypeId { get; set; }

        public string Name { get; set; }
    }
}