using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TblDemoApi.Models;

namespace TblDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCrudController : ControllerBase
    {
        public readonly DatabaseContext _context;

        public TblCrudController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("GetAllData")]
        [HttpGet]
        public ActionResult<IEnumerable<TblDemoModel>> GetAllData()
        {
            var res = (from s in _context.TblDemoModels select s).ToList();
            return res;
        }

        [Route("GetDateByGender")]
        [HttpGet]
        public IEnumerable<TblDemoModel> GetDateByGender(string gender)
        {
            var res = from s in _context.TblDemoModels where s.Gender == gender select s;
            return res;
        }

        [Route("Login")]
        [HttpGet]
        public IEnumerable<TblDemoModel> Login(string email, string password)
        {
            var res = from s in _context.TblDemoModels where s.Email == email && s.Password == password select s;
            return res;
        }

        [Route("Insert")]
        [HttpPost]
        public ActionResult<TblDemoModel> Insert(TblDemoModel obj)
        {
            if(obj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("GetAllData", new {id = obj.Id, obj});
            }
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(TblDemoModel obj)
        {
            if(obj == null)
            {
                return false;
            }
            else
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            return true;
        }

        [HttpDelete]
        [Route("Delete")]
        public int Delete(int? id)
        {
            if(id == null)
            {
                return 0;
            }
            else
            {
                var res = _context.TblDemoModels.Find(id);
                var output = _context.Remove(res);
                _context.SaveChanges();
                return 1;
            }
        }
    }
}
