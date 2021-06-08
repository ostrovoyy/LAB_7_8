using System;
using Xunit;
using DAL.UnitOfWork;
using BLL.Services.Impl;
using CCL.Security.Identity;
using CCL.Security;
using BLL.Services.Interfaces;
using Moq;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Tests
{
    public class DistrictServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new DistrictService(nullUnitOfWork));
        }

        [Fact]
        public void GetDistricts_DistrictFromDAL_CorrectMappingToDistrictDTO()
        {
            // Arrange
            CCL.Security.Identity.User user = new Director(1, "test", 1);
            SecurityContext.SetUser(user);
            var DistrictService = GetDistrictService();

            // Act
            var actualDistrictDto = DistrictService.GetDistricts(0).First();

            // Assert
            Assert.True(
                actualDistrictDto.idDistrict == 1
                && actualDistrictDto.DamageState == 12000
                && actualDistrictDto.Name == "Kyiv"
                );
        }

        IDistrictService GetDistrictService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedDistrict = new DAL.Entities.District() { idDistrict = 1, DamageState = 12000, Name = "Kyiv" };
            var mockDbSet = new Mock<IDistrictRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<DAL.Entities.District, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<DAL.Entities.District>() { expectedDistrict }
                    );
            mockContext
                .Setup(context =>
                    context.Districts)
                .Returns(mockDbSet.Object);

            IDistrictService DistrictService = new DistrictService(mockContext.Object);

            return DistrictService;
        }
    }
}
