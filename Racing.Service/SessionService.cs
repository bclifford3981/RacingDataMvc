using Racing.Data;
using Racing.Model.Session;
using RacingDataMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Service
{
    public class SessionService
    {
        private readonly Guid _userId;

        public SessionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSession(SessionCreate model)
        {
            var entity =
                new Session()
                {
                    OwnerId = _userId,
                    VehicleId = model.VehicleId,
                    Track = model.Track,
                  
                    CreatedUtc = DateTimeOffset.UtcNow
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sessions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SessionList> GetSession()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sessions
                        .Where(e => e.OwnerId == _userId)
                        .ToList()
                        .Select(
                            e =>
                                new SessionList
                                {
                                    VehicleId = e.VehicleId,
                                    SessionId = e.SessionId,
                                    Track = e.Track,
                                    LapList = e.LapList,
                                    AverageLapTime =  ConvertThing(e.AverageLapTime),
                                    BestLapTime =  ConvertThing(e.BestLapTime),
                                    BestSectorOne =  ConvertThing(e.BestSectorOne),
                                    BestSectorTwo =  ConvertThing(e.BestSectorTwo),
                                    BestSectorThree = ConvertThing(e.BestSectorThree),
                                    OptimalLap = ConvertThing(e.OptimalLap),
                                    CreatedUtc = e.CreatedUtc
                                }
                                );
                    return query.ToArray();
            }
        }
        public SessionDetail GetSessionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == id && e.OwnerId == _userId);
                return
            new SessionDetail
            {
                VehicleId = entity.VehicleId,
                SessionId = entity.SessionId,
                Track = entity.Track,
                LapList = entity.LapList,
                AverageLapTime = ConvertThing(entity.AverageLapTime),
                BestLapTime = ConvertThing(entity.BestLapTime),
                BestSectorOne = ConvertThing(entity.BestSectorOne),
                BestSectorTwo = ConvertThing(entity.BestSectorTwo),
                BestSectorThree = ConvertThing(entity.BestSectorThree),
                OptimalLap = ConvertThing(entity.OptimalLap),
                CreatedUtc = entity.CreatedUtc
            };
            }
        }
        public SessionLapList GetSessionLap(int id)
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == id && e.OwnerId == _userId);
                return
                    new SessionLapList
                    {
                        SessionId = entity.SessionId,
                        AverageLapTime = ConvertThing(entity.AverageLapTime),
                        BestLapTime = ConvertThing(entity.BestLapTime),
                        BestSectorOne = ConvertThing(entity.BestSectorOne),
                        BestSectorTwo = ConvertThing(entity.BestSectorTwo),
                        BestSectorThree = ConvertThing(entity.BestSectorThree),
                        OptimalLap = ConvertThing(entity.OptimalLap),
                        CreatedUtc = entity.CreatedUtc


                    };
            }
        }
        public bool UpdateSession(SessionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == model.SessionId && e.OwnerId == _userId);
                entity.Track = model.Track;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSession(int sessionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sessions
                        .Single(e => e.SessionId == sessionId && e.OwnerId ==_userId);
                ctx.Sessions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        static string ConvertThing(string timeInMs)
        {
            var timespan = TimeSpan.FromMilliseconds(Convert.ToInt32(timeInMs));

            return string.Format("{0:D2}:{1:D2}.{2:D3}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
        }
        
    }
}
