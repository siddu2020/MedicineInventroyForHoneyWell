using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicineInventory.Store.Models
{
    public class Medicine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Strength { get; set; }

        [MaxLength(50)]
        public string Brand { get; set; }

        public List<Inventory> Inventory { get; set; }

    }
}
