using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicineInventroyForHoneyWell.Domain
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public string BatchIdentifier { get; set; }
        public float Price { get; set; }
        public long Quantity { get; set; }
        public int MedicineId { get; set; }
    }
}
