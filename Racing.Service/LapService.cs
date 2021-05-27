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
                    SessionId = model.SessionId,
                    LapMinutes = model.LapMinutes,
                    LapSeconds = model.LapSeconds,
                    LapTenthSeconds = model.LapTenthSeconds,
                    LapHundrethSeconds = model.LapHundrethSeconds,
                    LapMilliseconds = model.LapMilliseconds,
                    SectorOneMinutes = model.SectorOneMinutes,
                    SectorOneSeconds = model.SectorOneSeconds,
                    SectorOneTenthSeconds = model.SectorOneTenthSeconds,
                    SectorOneHundrethSeconds = model.SectorOneHundrethSeconds,
                    SectorOneMilliseconds = model.SectorOneMilliseconds,
                    SectorTwoMinutes = model.SectorTwoMinutes,
                    SectorTwoSeconds = model.SectorTwoSeconds,
                    SectorTwoTenthSeconds = model.SectorTwoTenthSeconds,
                    SectorTwoHundrethSeconds = model.SectorTwoHundrethSeconds,
                    SectorTwoMilliseconds = model.SectorTwoMilliseconds,
                    SectorThreeMinutes = model.SectorThreeMinutes,
                    SectorThreeSeconds = model.SectorThreeSeconds,
                    SectorThreeTenthSeconds = model.SectorThreeTenthSeconds,
                    SectorThreeHundrethSeconds = model.SectorThreeHundrethSeconds,
                    SectorThreeMilliseconds = model.SectorThreeMilliseconds,
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
                        .ToList()
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
        public IEnumerable<LapList> GetSessionLaps(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Laps
                        .Where(e => e.SessionId == id && e.OwnerId == _userId)
                        .ToList()
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
                                });
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
                entity.LapMinutes = model.LapMinutes;
                entity.LapSeconds = model.LapSeconds;
                entity.LapTenthSeconds = model.LapTenthSeconds;
                entity.LapHundrethSeconds = model.LapHundrethSeconds;
                entity.LapMilliseconds = model.LapMilliseconds;
                entity.SectorOneMinutes = model.SectorOneMinutes;
                entity.SectorOneSeconds = model.SectorOneSeconds;
                entity.SectorOneTenthSeconds = model.SectorOneTenthSeconds;
                entity.SectorOneHundrethSeconds = model.SectorOneHundrethSeconds;
                entity.SectorOneMilliseconds = model.SectorOneMilliseconds;
                entity.SectorTwoMinutes = model.SectorTwoMinutes;
                entity.SectorTwoSeconds = model.SectorTwoSeconds;
                entity.SectorTwoTenthSeconds = model.SectorTwoTenthSeconds;
                entity.SectorTwoHundrethSeconds = model.SectorTwoHundrethSeconds;
                entity.SectorTwoMilliseconds = model.SectorTwoMilliseconds;
                entity.SectorThreeMinutes = model.SectorThreeMinutes;
                entity.SectorThreeSeconds = model.SectorThreeSeconds;
                entity.SectorThreeTenthSeconds = model.SectorThreeTenthSeconds;
                entity.SectorThreeHundrethSeconds = model.SectorThreeHundrethSeconds;
                entity.SectorThreeMilliseconds = model.SectorThreeMilliseconds;
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
