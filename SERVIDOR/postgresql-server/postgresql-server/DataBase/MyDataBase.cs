using PostgreSqlServer.Controllers;

namespace postgresql_server.DataBase;

public class MyDataBase
{
    private List<Car> cars;

    public MyDataBase()
    {
        cars = new List<Car>();
    }

    public IEnumerable<Car> GetAll()
    {
        return cars;
    }

    public void Add(Car newcar)
    {
        cars.Add(newcar);
    }
}
