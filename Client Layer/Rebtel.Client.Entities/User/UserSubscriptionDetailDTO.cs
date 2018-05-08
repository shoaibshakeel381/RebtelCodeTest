namespace Rebtel.Client.Entities
{
    public class UserSubscriptionDetailDTO
    {
        public string Id { get; set; }

        public double Price { get; set; }

        public double PriceIncVat { get; set; }

        public int CallMinutes { get; set; }
    }
}
