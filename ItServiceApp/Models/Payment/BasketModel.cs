using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp.Models.Payment
{
    public class BasketModel
    {
        public int Id { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string ItemType { get; set; }
    }
}
