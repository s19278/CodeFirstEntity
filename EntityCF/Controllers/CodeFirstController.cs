using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EntityCF.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class CodeFirstController : ControllerBase
    {
      private DAL.IDbService _dbService;
      public CodeFirstController(DAL.IDbService dbService)
        {
            
            _dbService = dbService;
        }

    [HttpGet("{Id}")]
    public IActionResult GetDoctor(int id) 
        {
            //metoda seedująca
            //new Seeds().seedMeSenpai();
            return _dbService.GetDoctor( id);
        }
    [HttpDelete("{Id}")]
    public IActionResult DeleteDoctor(int id)
        {

            return _dbService.DeleteDoctor(id);
        }
    [HttpPost]
    public IActionResult AddDoctor(Models.Doctor doc)
        {

            return _dbService.AddDoctor(doc);
        }
    [HttpPut]
    public IActionResult ModifyDoctor(Models.Doctor doc)
        {

            return _dbService.ModifyDoctor(doc);
        }

    }
    

}
