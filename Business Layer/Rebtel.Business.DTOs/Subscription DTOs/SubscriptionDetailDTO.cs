using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebtel.Business.DTOs
{
    public class SubscriptionDetailDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public double PriceIncVat { get; set; }

        public int CallMinutes { get; set; }
    }
}
