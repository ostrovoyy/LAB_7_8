using System;
using System.Collections.Generic;
using System.Text;
using DAL.UnitOfWork;
using BLL.Services.Interfaces;
using BLL.DTO;
using CCL.Security;
using AutoMapper;
using DAL.Entities;

namespace BLL.Services.Impl
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public DistrictService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<DistrictDto> GetDistricts(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            var IdUser = user.idCitizen;
            var districtsEntities =
                _database
                    .Districts
                    .Find(z => z.idDistrict == IdUser, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<District, DistrictDto>()
                    ).CreateMapper();
            var districtsDto =
                mapper
                    .Map<IEnumerable<District>, List<DistrictDto>>(
                        districtsEntities);
            return districtsDto;
        }

    }
}
