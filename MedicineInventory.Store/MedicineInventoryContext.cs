using MedicineInventory.Store.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicineInventory.Store
{
    public class MedicineInventoryContext: DbContext
    {
        public MedicineInventoryContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Medicine> Medicines { get; set;  }

        public DbSet<Inventory> Inventory { get; set; }
    }
}
