using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICitizenRepository Citizens { get; }
        IDistrictRepository Districts { get; }
        void Save();
    }
}
