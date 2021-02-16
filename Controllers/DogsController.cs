using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.db;
using petshop.Models;

namespace petshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DogsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Dog>> Get()
        {
            try
            {
                return Ok(FAKEDB.Dogs);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Dog> GetDogById(string id)
        {
            try
            {
                Dog dogToReturn = FAKEDB.Dogs.Find(d => d.Id == id);
                return Ok(dogToReturn);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Dog> Create([FromBody] Dog newDog)
        {
            try
            {
                FAKEDB.Dogs.Add(newDog);
                return Ok(newDog);

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{dogId}")]
        public ActionResult<string> BuyDog(string dogId)
        {
            try
            {
                Dog dogToRemove = FAKEDB.Dogs.Find(d => d.Id == dogId);
                if (FAKEDB.Dogs.Remove(dogToRemove))
                {
                    return Ok("Dog has left the building!");
                };
                throw new System.Exception("Dog does not exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


    }
}