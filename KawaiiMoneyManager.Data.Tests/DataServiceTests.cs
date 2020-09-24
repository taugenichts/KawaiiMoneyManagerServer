using System;
using KawaiiMoneyManager.Data.LiteDb;
using KawaiiMoneyManager.Data.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace KawaiiMoneyManager.Data.Tests
{
    [TestFixture]
    internal class DataServiceTests
    {
        private readonly IDataService<EntityMock> dataService = new LiteDbDataService<EntityMock>("UnitTest.db");

        [Test]
        public void LiteDbDataService_Can_Create_And_Read_Entity()
        {
            // Set up
            var entity = new EntityMock { Name = Randomize.String() };

            // Act
            this.dataService.Insert(entity);
            var readEntity = this.dataService.Get(entity.Id);

            // Assert
            readEntity.ShouldNotBeNull();
            readEntity.Id.ShouldBe(entity.Id);
            readEntity.Name.ShouldBe(entity.Name);
        }

        [Test]
        public void LiteDbDataService_Can_Update_Entity()
        {
            // Set up
            var entity = new EntityMock { Name = Randomize.String() };
            this.dataService.Insert(entity);

            // Act
            var updateEntity = this.dataService.Get(entity.Id);
            updateEntity.Name = Randomize.String();
            this.dataService.Update(updateEntity);
            var updatedEntity = this.dataService.Get(entity.Id);

            // Assert
            updatedEntity.Name.ShouldBe(updateEntity.Name);
            updatedEntity.Name.ShouldNotBe(entity.Name);
        }

        [Test]
        public void LiteDbDataService_Can_Delete_Entity()
        {
            // Set up
            var entity = new EntityMock { Name = Randomize.String() };
            this.dataService.Insert(entity);

            // Act
            this.dataService.Delete(entity);

            // Assert
            var deletedEntity = this.dataService.Get(entity.Id);
            deletedEntity.ShouldBeNull();
        }

        [Test]
        public void LiteDbDataService_Cannot_Update_Nonexistent_Entity()
        {
            // Set up
            var entity = new EntityMock { Name = Randomize.String() };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => this.dataService.Update(entity));
        }
    }
}
