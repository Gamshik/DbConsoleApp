using app.Context;
using app.Entities;
using DbConsoleApp.dto;
using Microsoft.EntityFrameworkCore;

namespace app.Repository
{
    public class DbRepository
    {
        private LogisticCenterContext context;

        public DbRepository()
        {
            context = new LogisticCenterContext();
        }

        public IQueryable<Car> GetAllCars() => context.Cars.AsNoTracking();

        public IQueryable<Cargo> GetCargoByWeight(int minWeight) => context.Cargos.AsNoTracking().Where(c => c.Weight >= minWeight);

        public IEnumerable<CountCustomerOrdersDto> GetCountCustomerOrders() => context.CargosTransports.AsNoTracking().GroupBy(ct => ct.CustomerId).Select(g => new CountCustomerOrdersDto
        {
            CustomerId = g.Key,
            OrdersCount = g.Count()
        });

        public IQueryable<Route> GetRoutesWithSettlementsInfo() => context.Routes.AsNoTracking().Include(d => d.StartSettlement).Include(d => d.EndSettlement);

        public IQueryable<Route> GetRoutesInfoByStartSettlementId(int startSettlementId) => context.Routes.AsNoTracking()
            .Include(d => d.StartSettlement).Include(d => d.EndSettlement).Where(d => d.StartSettlementId == startSettlementId);

        public Car CreateCar(Car newCar)
        {
            context.Cars.Add(newCar);
            SaveChanges();
            return newCar;
        }

        public CargosTransport CreateCargosTransport(CargosTransport newCargosTransport)
        {
            context.CargosTransports.Add(newCargosTransport);
            SaveChanges();
            return newCargosTransport;
        }

        public void DeleteDriver(Func<Driver, bool> predicate)
        {
            var driversForRemove = context.Drivers.Where(predicate);
            if (driversForRemove != null)
            {
                context.Drivers.RemoveRange(driversForRemove);
                SaveChanges();
            }
        }

        public void DeleteCargosTransport(Func<CargosTransport, bool> predicate)
        {
            var cargosTransportsForRemove = context.CargosTransports.Where(predicate);
            if (cargosTransportsForRemove != null)
            {
                context.CargosTransports.RemoveRange(cargosTransportsForRemove);
                SaveChanges();
            }
        }

        public Cargo[]? UpdateCargosWeight(Func<Cargo, bool> predicate, int newWeight)
        {
            var cargosForUpdate = context.Cargos.Where(predicate).ToArray();
            if (cargosForUpdate == null) return null;

            for (int i = 0; i < cargosForUpdate.Length; i++) cargosForUpdate[i].Weight = newWeight;
            context.Cargos.UpdateRange(cargosForUpdate);
            SaveChanges();
            return cargosForUpdate;
        }

        private void SaveChanges() => context.SaveChanges();
    }
}
