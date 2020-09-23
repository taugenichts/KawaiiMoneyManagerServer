using System;
using NUnit.Framework;
using Shouldly;

namespace KawaiiMoneyManager.Data.Tests
{
    [TestFixture]
    internal class EntityTests
    {
        [Test]
        public void EntityBase_Should_Generate_Id()
        {
            // Set Up
            var entity = new EntityMock();

            // Act

            // Assert
            entity.Id.ShouldNotBeNull();
            entity.Id.ShouldNotBe(Guid.Empty);
        }
    }
}
