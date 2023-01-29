using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainStationAndmebaasid.Models;

namespace TrainStationAndmebaasid.Data
{
    public class TrainStationAndmebaasidContext : DbContext
    {
        public TrainStationAndmebaasidContext (DbContextOptions<TrainStationAndmebaasidContext> options)
            : base(options)
        {
        }

        public DbSet<TrainStationAndmebaasid.Models.Train> Train { get; set; } = default!;
    }
}
