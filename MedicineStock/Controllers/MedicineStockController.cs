using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MedicineStock.Models;
using LINQtoCSV;
using MedicineStock.MedicineStockRepository;
namespace MedicineStock.Controllers
{
    [ApiController]
    public class MedicineStockController : ControllerBase
    {
     
        private IConfiguration configuration;
        public IMedicineStockRepository repo;
        public MedicineStockController(IConfiguration config, IMedicineStockRepository repo)
        {
            configuration = config;
            this.repo = repo;
        }
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MedicineStockController));
        [HttpGet]
        [Route("MedicineStockInformation")]
        public IActionResult MedicineStockInformation()
        {
            _log4net.Info("Get Api Initiated");
            var MedicineData = repo.MedicineStockInformation();
            if (MedicineData == null)
            {
                return BadRequest();
            }
            return Ok(MedicineData);

        }
    }
}
