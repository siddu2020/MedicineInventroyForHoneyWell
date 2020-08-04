using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicineInventory.Store.Models
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string BatchIdentifier { get; set; }
        public float Price { get; set; }
        public long Quantity { get; set; }
        public int MedicineId { get; set; }
    }
}
