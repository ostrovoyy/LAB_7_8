using System;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.Entities;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputDistrictInstance_CalledAddMethodOfDBSetWithDistrictInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DistrictListContext>()
                .Options;
            var mockContext = new Mock<DistrictListContext>(opt);
            var mockDbSet = new Mock<DbSet<District>>();
            mockContext
                .Setup(context =>
                    context.Set<District>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestDistrictRepository(mockContext.Object);

            District expectedDistrict = new Mock<District>().Object;

            //Act
            repository.Create(expectedDistrict);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedDistrict
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DistrictListContext>()
                .Options;
            var mockContext = new Mock<DistrictListContext>(opt);
            var mockDbSet = new Mock<DbSet<District>>();    
            mockContext
                .Setup(context =>
                    context.Set<District>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestDistrictRepository(mockContext.Object);

            District expectedDistrict = new District() { idDistrict = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedDistrict.idDistrict)).Returns(expectedDistrict);

            //Act
            repository.Delete(expectedDistrict.idDistrict);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedDistrict.idDistrict
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedDistrict
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DistrictListContext>()
                .Options;
            var mockContext = new Mock<DistrictListContext>(opt);
            var mockDbSet = new Mock<DbSet<District>>();
            mockContext
                .Setup(context =>
                    context.Set<District>(
                        ))
                .Returns(mockDbSet.Object);

            District expectedDistrict = new District() { idDistrict = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedDistrict.idDistrict))
                    .Returns(expectedDistrict);
            var repository = new TestDistrictRepository(mockContext.Object);

            //Act
            var actualDistrict = repository.Get(expectedDistrict.idDistrict);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedDistrict.idDistrict
                    ), Times.Once());
            Assert.Equal(expectedDistrict, actualDistrict);
        }
    }
}
