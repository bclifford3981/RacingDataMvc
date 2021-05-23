using Racing.Data;
using Racing.Model;
using Racing.Model.Vehicle;
using RacingDataMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace Racing.Service
{
    public class VehicleService
    {
        private readonly Guid _userId;

        public VehicleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVehicle(VehicleCreate model)
        {
            var entity =
                new Vehicle()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Class = model.Class,
                    Series = model.Series,
                    HP = model.HP,
                    Weight = model.Weight,
                    
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vehicles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<VehicleList> GetVehicle()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vehicles
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new VehicleList
                                {
                                    VehicleId = e.VehicleId,
                                    Name = e.Name,
                                    Class = e.Class,            
                                    
                                    CreatedUtc = e.CreatedUtc
                                }
                                );
                return query.ToArray();
            }
        }
        public VehicleDetail GetVehicleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == id && e.OwnerId == _userId);
                return
                    new VehicleDetail
                    {
                        VehicleId = entity.VehicleId,
                        Name = entity.Name,
                        Class = entity.Class,
                        Series = entity.Series,
                        HP = entity.HP,
                        Weight = entity.Weight,
                        
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateVehicle(VehicleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == model.VehicleId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Class = model.Class;
                entity.Series = model.Series;
                entity.HP = model.HP;
                entity.Weight = model.Weight;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
                    
            }
        }
        public bool DeleteVehicle(int vehicleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Vehicles
                        .Single(e => e.VehicleId == vehicleId && e.OwnerId == _userId);
                ctx.Vehicles.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
