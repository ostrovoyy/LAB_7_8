using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        internal DistrictRepository(DistrictListContext context)
            : base(context)
        {
        }
    }
}
