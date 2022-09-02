using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MVCAPIDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {

        private string _connection = "Server=localhost; Database=cruddapper; Uid=root; password=Melocoton123";


        [HttpGet]

        public IActionResult Get()
        {
            IEnumerable<Models.Thing> listaThings = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT id, name, description FROM thing";

                listaThings = db.Query<Models.Thing>(sql);

            }

            return Ok(listaThings);
  
        }

        [HttpPost]

        public IActionResult Insert(Models.Thing model)  
        {
            int result = 0;            
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "INSERT INTO thing(name,description)"+
                        " values (@name, @description)";

                result = db.Execute(sql, model);

                

             }
             return Ok(result);
        }

        [HttpPut]

        public IActionResult Edit(Models.Thing model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "UPDATE thing SET name=@name, description=@description" +
                        " WHERE id=@id";

                result = db.Execute(sql, model);



            }
            return Ok(result);
        }

        [HttpDelete]

        public IActionResult Delete(Models.Thing model)
        {
            int result = 0;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "DELETE FROM thing WHERE id=@id";

                result = db.Execute(sql, model);



            }
            return Ok(result);
        }


    }
}
