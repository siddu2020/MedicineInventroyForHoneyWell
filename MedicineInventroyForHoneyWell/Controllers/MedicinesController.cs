using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicineInventory.Store;
using MedicineInventroyForHoneyWell.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models = MedicineInventory.Store.Models;

namespace MedicineInventroyForHoneyWell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : BaseController<Models.Medicine, Domain.Medicine>
    {
        public MedicinesController(MedicineInventoryContext context, IMapper mapper):base(context, mapper)
        {
           
        }

        protected override DbSet<Models.Medicine> DbSet => db.Medicines;

    }
}
