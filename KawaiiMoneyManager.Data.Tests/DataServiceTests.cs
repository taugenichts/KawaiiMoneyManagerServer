using System;
using System.Linq;
using KawaiiMoneyManager.Data.LiteDb;
using KawaiiMoneyManager.Data.Tests.Helpers;
using NUnit.Framework;
using Shouldly;

namespace KawaiiMoneyManager.Data.Tests
{
    [TestFixture]
    internal class DataServiceTests
    {
        private readonly LiteDbDataService<EntityMock> dataService = new LiteDbDataService<EntityMock>("UnitTest.db");

        [SetUp]
        public void TestSetUp() =>
            this.dataService.DeleteAll();

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
        public void LiteDbDataService_Can_Get_All_Entities()
        {
            // Set up
            var entity = new EntityMock { Name = Randomize.String() };
            var entity2 = new EntityMock { Name = Randomize.String() };

            this.dataService.Insert(entity);
            this.dataService.Insert(entity2);

            // Act
            var readEntities = this.dataService.GetMany();

            // Assert
            readEntities.Count().ShouldBe(2);
            readEntities.Select(e => e.Id).ShouldContain(entity.Id);
            readEntities.Select(e => e.Id).ShouldContain(entity2.Id);
        }

        [Test]
        public void LiteDbDataService_Can_Get_Entities_By_Predicate()
        {
            // Set up
            var entity = new EntityMock { Name = Randomize.String() };
            var entity2 = new EntityMock { Name = Randomize.String() };

            this.dataService.Insert(entity);
            this.dataService.Insert(entity2);

            // Act
            var readEntities = this.dataService.GetMany(e => e.Name == entity2.Name);

            // Assert
            readEntities.Count().ShouldBe(1);
            readEntities.Single().Id.ShouldBe(entity2.Id);
            readEntities.Single().Name.ShouldBe(entity2.Name);
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
