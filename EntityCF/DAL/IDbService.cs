
using Microsoft.AspNetCore.Mvc;

namespace EntityCF.DAL
{
    public interface IDbService
    {

        public IActionResult GetDoctor(int id);
        public IActionResult ModifyDoctor(Models.Doctor doc);

        public IActionResult AddDoctor(Models.Doctor doc);
        public IActionResult DeleteDoctor(int id);
       
    }
}
