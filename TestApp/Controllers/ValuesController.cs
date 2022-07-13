using Microsoft.AspNetCore.Mvc;
using TestApp.Context;
using TestApp.EFCore;
using TestApp.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DbRepository _db;
        public ValuesController(DataContext dataContext)
        {
            _db = new DbRepository(dataContext);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("getusers")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<User> data = _db.GetUsers();
                return Ok(data);   
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("user/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                IEnumerable<User> data = _db.GetUserById(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("saveuser")]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _db.SaveUser(user);
                return Ok("Added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("updateuser")]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                _db.UpdateUser(user);
                return Ok("Updated!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("deleteuser/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _db.DeleteUser(id);
                return Ok("Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("assignpermission")]
        public IActionResult Post([FromBody] UserPermission userPermission)
        {
            try
            {
                _db.AssignPermission(userPermission);
                return Ok("Added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("deletepermission/{uid}/{pid}")]
        public IActionResult RemovePermission(int uid, int pid)
        {
            try
            {
                _db.RemovePermission(uid, pid);
                return Ok("Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
        
}
