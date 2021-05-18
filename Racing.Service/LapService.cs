using Racing.Data;
using Racing.Model.Laps;
using RacingDataMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Service
{
    public class LapService
    {
        private readonly Guid _userId;

        public LapService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLap(LapCreate model)
        {
            var entity =
                new Lap()
                {
                    OwnerId = _userId,
                    SessionId=model.SessionId,
                    LapTime = model.LapTime,
                    SectorOne = model.SectorOne,
                    SectorTwo = model.SectorTwo,
                    SectorThree = model.SectorThree,
                    CreatedUtc = DateTimeOffset.UtcNow
                };
            using (var ctx = new ApplicationDbContext())
            {
                var session = ctx.Sessions.SingleOrDefault(s => s.SessionId == entity.SessionId);
                session.LapList.Add(entity);
                ctx.Laps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LapList> GetLap()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Laps
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LapList
                                {
                                    SessionId = e.SessionId,
                                    LapId = e.LapId,
                                    LapTime = e.LapTime,
                                    SectorOne = e.SectorOne,
                                    SectorTwo = e.SectorTwo,
                                    SectorThree = e.SectorThree,
                                    CreatedUtc = e.CreatedUtc
                                }
                                );
                return query.ToArray();
            }
        }
        public LapDetail GetLapById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Laps
                        .Single(e => e.LapId == id && e.OwnerId == _userId);
                return
                    new LapDetail
                    {
                        SessionId = entity.SessionId,
                        LapId = entity.LapId,
                        LapTime = entity.LapTime,
                        SectorOne = entity.SectorOne,
                        SectorTwo = entity.SectorTwo,
                        SectorThree = entity.SectorThree,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }
        public bool UpdateLap(LapEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Laps
                        .Single(e => e.LapId == model.LapId && e.OwnerId == _userId);
                entity.LapTime = model.LapTime;
                entity.SectorOne = model.SectorOne;
                entity.SectorTwo = model.SectorTwo;
                entity.SectorThree = model.SectorThree;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLap(int lapId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Laps
                        .Single(e => e.LapId == lapId && e.OwnerId == _userId);
                ctx.Laps.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
