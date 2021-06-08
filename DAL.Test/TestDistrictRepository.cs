using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    class TestDistrictRepository : BaseRepository<District>
    {
        public TestDistrictRepository(DbContext context) : base(context)
        { }
    }
}