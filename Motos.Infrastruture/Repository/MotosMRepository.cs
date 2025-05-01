using Motos.Domain.Entities;
using Motos.Domain.Interfaces;
using Motos.Infrastruture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Infrastruture.Repository
{
    public class MotosMRepository : Repository<MotosM>, IMotosRepository
    {
        public MotosMRepository(AppDbContext context) : base(context)
        {
        }
    }
}
