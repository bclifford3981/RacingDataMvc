using Racing.Data;
using Racing.Model.Session;
using RacingDataMvc.Models;
using System;
using System.Collections.Generic;
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
                        .Select(
                            e =>
                                new SessionList
                                {
                                    VehicleId = e.VehicleId,
                                    SessionId = e.SessionId,
                                    Track = e.Track,
                                    LapList = e.LapList,
                                    AverageLapTime = e.AverageLapTime,
                                    BestLapTime = e.BestLapTime,
                                    BestSectorOne = e.BestSectorOne,
                                    BestSectorTwo = e.BestSectorTwo,
                                    BestSectorThree = e.BestSectorThree,
                                    OptimalLap = e.OptimalLap,
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
                //AverageLapTime = entity.AverageLapTime,
                BestLapTime = entity.BestLapTime,
                BestSectorOne = entity.BestSectorOne,
                BestSectorTwo = entity.BestSectorTwo,
                BestSectorThree = entity.BestSectorThree,
                OptimalLap = entity.OptimalLap,
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
    }
}
