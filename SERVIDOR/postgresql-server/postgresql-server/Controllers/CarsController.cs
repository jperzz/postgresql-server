using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgresql_server.DataBase;
using postgresql_server.DataBase.Entities;

namespace PostgreSqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly MyDataBase _dataBase;

        public CarsController(MyDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        [HttpGet]
        public IEnumerable<Car> GetAllCars()
        {
            return _dataBase.Cars;
        }

        [HttpGet("byname/{name}")]

        public IEnumerable<Car> GetAllCarsByName(string name)
        {
            retunr _dataBase.Cars.Where(Car => Car.Name.ToLower().Contains(name.ToLower()));
        }

        [HttpGet("{id}")]

        public Car? GetCar(int id)
        {
            retunr _dataBase.Cars.Find(id);
        }

        [HttpPost]
        public ActionResult<Car> AddCar([FromBody] Car newCar)
        {
            _dataBase.Cars.Add(newCar);
            _dataBase.SaveChanges();

            return Created($"cars/{newCar.Id}", newCar);
        }

        /*
        [HttpDelete]
        public ActionResult DeleteCar(int id)
        {
            cars.RemoveAll(car => car.Id == id);
            return NoContent();
        }
        */
    }

}