using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineInventroyForHoneyWell.Domain
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Medicine, MedicineInventory.Store.Models.Medicine>().ReverseMap();
            CreateMap<Inventory, MedicineInventory.Store.Models.Inventory>().ReverseMap();  
        }
    }
}
