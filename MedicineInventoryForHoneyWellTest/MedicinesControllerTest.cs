using MedicineInventory.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models = MedicineInventory.Store.Models;
using System;
using AutoMapper;
using MedicineInventroyForHoneyWell.Controllers;
using MedicineInventroyForHoneyWell.Domain;
using FluentAssertions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MedicineInventoryForHoneyWellTest
{
    [TestClass]
    public class MedicinesControllerTest
    {
        public  MedicineInventoryContext DBSetup(string dbName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedicineInventoryContext>().UseInMemoryDatabase(dbName);
            MedicineInventoryContext context =new  MedicineInventoryContext(optionsBuilder.Options);
            context.Add(new Models.Medicine() { Name = "Dolopar", Brand = "Cipla", Strength = "500 mg" });
            context.Add(new Models.Medicine() { Name = "Fenak Plus", Brand = "Cipla", Strength = "200 mg" });
            context.Add(new Models.Inventory() { MedicineId = 1, BatchIdentifier = "122020", Price = 100.00f, Quantity = 50 });
            context.SaveChanges();
            return context;
        }

        public  MapperConfiguration MapperSetup()
        {
            return  new MapperConfiguration(maps =>
            {
                maps.AddProfile(new MapperProfile());
            });


        }

        [TestMethod]
        public void TestIfMedicinesAreFetchedFromDb()
        {
            var context = DBSetup("testdb_"+DateTime.Now.ToString("MMddyyyyhhmmss"));
            var controller = new MedicinesController(context, new Mapper(MapperSetup()));
            var lstMedicines = new List<Medicine>() {
                new Medicine()
                {
                    Id=1,
                    Name ="Dolopar",
                    Brand="Cipla",
                    Strength="500 mg",
                    Inventory = new List<Inventory>() {new Inventory()
                    { MedicineId = 1, BatchIdentifier = "122020", Price = 100.00f, Quantity = 50, Id=1 } }
                },
                  new Medicine()
                {
                    Id=2,
                    Name ="Fenak Plus",
                    Brand="Cipla",
                    Strength="200 mg",
                    Inventory = new List<Inventory>()
                }
            };
            controller.GetData().Should().BeEquivalentTo(lstMedicines);
            context.Dispose();
        }

        [TestMethod]
        public void TestIfMedicinesAreAddedToDb()
        {
            var context = DBSetup("testdb_" + DateTime.Now.ToString("MMddyyyyhhmmss"));
            var controller = new MedicinesController(context, new Mapper(MapperSetup()));
            var postObj = new Medicine()
            {
                Name = "GlimPride",
                Brand = "Sanofi",
                Strength = "50 mg"
            };
            controller.AddData(postObj).Should().BeEquivalentTo(new StatusCodeResult(200));
            context.Medicines.FirstOrDefault(med => med.Id == 3).Should().BeEquivalentTo(new Models.Medicine
            {
                Id = 3,
                Name = "GlimPride",
                Brand = "Sanofi",
                Strength = "50 mg",
                Inventory = new List<Models.Inventory>()
            });
            context.Dispose();
        }

    }
}
