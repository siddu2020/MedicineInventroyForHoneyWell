using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using MedicineInventory.Store;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicineInventroyForHoneyWell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<DBEntity, Model> : ControllerBase where DBEntity : class where Model : class
    {
        protected IMapper mapper;
        protected readonly MedicineInventoryContext db;
        protected abstract DbSet<DBEntity> DbSet { get; }

        public BaseController(MedicineInventoryContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        [HttpGet, EnableQuery]
        public virtual IEnumerable<Model> GetData()
        {
            return (IEnumerable<Model>)mapper.Map(DbSet.ToList(), typeof(IEnumerable<DBEntity>), typeof(IEnumerable<Model>));
        }


        [HttpPost]
        public virtual StatusCodeResult AddData(Model modelToAdd)
        {

            var entityToAdd = mapper.Map<DBEntity>(modelToAdd);
            try
            {
                db.Add(entityToAdd);
                db.SaveChanges();
                return new StatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
