using System;
using System.Collections.Generic;
using System.Text;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private DistrictListContext db;
        private CitizenRepository citizenRepository;
        private DistrictRepository districtRepository;

        public EFUnitOfWork(DistrictListContext context)
        {
            db = context;
        }
        public ICitizenRepository Citizens
        {
            get
            {
                if (citizenRepository == null)
                    citizenRepository = new CitizenRepository(db);
                return citizenRepository;
            }
        }

        public IDistrictRepository Districts
        {
            get
            {
                if (districtRepository == null)
                    districtRepository = new DistrictRepository(db);
                return districtRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
