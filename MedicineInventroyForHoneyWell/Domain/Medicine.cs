using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicineInventroyForHoneyWell.Domain
{
    public class Medicine
    {
      
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public string Strength { get; set; }

      
        public string Brand { get; set; }

        public List<Inventory> Inventory { get; set; }

    }
}
