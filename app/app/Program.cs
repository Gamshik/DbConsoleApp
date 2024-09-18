using app.Entities;
using app.Repository;

DbRepository repository = new DbRepository();

var cars = repository.GetAllCars();
Console.WriteLine("Cars:");
foreach (Car car in cars)
{
    Console.WriteLine($"Id: {car.Id}; Brand: {car.Brand}; LoadCapacity: {car.LoadCapacity}; RegistrationNumber: {car.RegistrationNumber}");
}

Console.WriteLine("\n\n");

var cargosByWeight = repository.GetCargoByWeight(100);
Console.WriteLine("Cargos:");
foreach (Cargo cargo in cargosByWeight)
{
    Console.WriteLine($"Id: {cargo.Id}; Title: {cargo.Title}; Weight: {cargo.Weight}; RegistrationNumber: {cargo.RegistrationNumber}");
}

Console.WriteLine("\n\n");

var countCustomerOrders = repository.GetCountCustomerOrders();
Console.WriteLine("Count customers orders:");
foreach (var item in countCustomerOrders)
{
    Console.WriteLine($"Customer: {item.CustomerId}; Count orders: {item.OrdersCount}");
}

Console.WriteLine("\n\n");

var routesInfo = repository.GetRoutesWithSettlementsInfo();
Console.WriteLine("Routes info:");
foreach (Route route in routesInfo)
{
    Console.WriteLine($"Route id: {route.Id}; Start settlement id: {route.StartSettlement.Id}; Start settlement title: '{route.StartSettlement.Title}'; " +
        $"End settlement id: {route.EndSettlement.Id}; End settlement title: '{route.EndSettlement.Title}';");
}

Console.WriteLine("\n\n");

var routesInfoForThirdStartSettlement = repository.GetRoutesInfoByStartSettlementId(3);
Console.WriteLine("Routes info for third start settlement:");
foreach (Route route in routesInfoForThirdStartSettlement)
{
    Console.WriteLine($"Route id: {route.Id}; Start settlement id: {route.StartSettlement.Id}; Start settlement title: '{route.StartSettlement.Title}'; " +
        $"End settlement id: {route.EndSettlement.Id}; End settlement title: '{route.EndSettlement.Title}';");
}

Console.WriteLine("\n\n");

var newCar = new Car
{
    Brand = "Mercedes",
    LoadCapacity = 1000,
    RegistrationNumber = "AT-304-4"
};

var newCarFromDb = repository.CreateCar(newCar);

Console.WriteLine("New car:");
Console.WriteLine($"New car id: {newCarFromDb.Id}; Brand: {newCarFromDb.Brand}; LoadCapacity: {newCarFromDb.LoadCapacity}; RegistrationNumber: {newCarFromDb.RegistrationNumber}");

Console.WriteLine("\n\n");

var newCargosTransport = new CargosTransport
{
    DocumentNumber = "My docs 123213132",
    StartDate = new DateOnly(2024, 9, 21),
    EndDate = new DateOnly(2024, 9, 21),
    Info = "Something infoo",
    DriverId = 20,
    CarId = 24,
    TariffId = 25,
    RouteId = 10,
    CargoId = 11,
    CustomerId = 40,
    PaymentAmount = 140000
};

var newCargosTransportFromDb = repository.CreateCargosTransport(newCargosTransport);

Console.WriteLine("New cargos transport:");
Console.WriteLine($"New cargos transport id: {newCargosTransportFromDb.Id}; DocumentNumber: {newCargosTransportFromDb.DocumentNumber}; StartDate: {newCargosTransportFromDb.StartDate}; EndDate: {newCargosTransportFromDb.EndDate}; " +
    $"Info: {newCargosTransportFromDb.Info}; DriverId: {newCargosTransportFromDb.DriverId}; CarId: {newCargosTransportFromDb.CarId}; TariffId: {newCargosTransportFromDb.TariffId}; RouteId: {newCargosTransportFromDb.RouteId}; " +
    $"CargoId: {newCargosTransportFromDb.CargoId}; CustomerId: {newCargosTransportFromDb.CustomerId}; PaymentAmount: {newCargosTransportFromDb.PaymentAmount};");


repository.DeleteDriver(d => d.Id == 3);

repository.DeleteCargosTransport(ct => ct.Id == 3);

repository.UpdateCargosWeight(c => c.Id == 2 || c.Id == 5, 28);


