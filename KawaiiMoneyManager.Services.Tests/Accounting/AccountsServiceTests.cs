using System;
using System.Linq.Expressions;
using KawaiiMoneyManager.Data;
using KawaiiMoneyManager.Data.Accounting;
using KawaiiMoneyManager.Services.Accounting;
using Moq;
using NUnit.Framework;

namespace KawaiiMoneyManager.Services.Tests.Accounting
{
    [TestFixture]
    public class AccountsServiceTests
    {
        [Test]
        public void AccountsService_Can_Create_Account()
        {
            // Set-up
            var entity = new Account();
            var mock = new Mock<IDataService<Account>>();
            mock.Setup(s => s.Insert(It.IsAny<Account>()));


            // Act
            new AccountsService(mock.Object).Create(entity);

            // Assert
            mock.Verify(s => s.Insert(It.Is<Account>(a => a.Id == entity.Id)));
        }

        [Test]
        public void AccountsService_Can_Get_Account()
        {
            // Set-up       
            var id = Guid.NewGuid();
            var mock = new Mock<IDataService<Account>>();
            mock.Setup(s => s.Get(It.IsAny<Guid>()));


            // Act
            new AccountsService(mock.Object).Get(id);

            // Assert
            mock.Verify(s => s.Get(It.Is<Guid>(x => x == id)));
        }

        [Test]
        public void AccountsService_Can_GetAll_Account()
        {
            // Set-up
            var mock = new Mock<IDataService<Account>>();
            mock.Setup(s => s.GetMany(It.IsAny<Expression<Func<Account, bool>>>()));

            // Act
            new AccountsService(mock.Object).GetAll();

            // Assert
            mock.Verify(s => s.GetMany(It.Is<Expression<Func<Account, bool>>>(x => x == null)));
        }

        [Test]
        public void AccountsService_Can_Update_Account()
        {
            // Set-up
            var entity = new Account();
            var mock = new Mock<IDataService<Account>>();
            mock.Setup(s => s.Update(It.IsAny<Account>()));

            // Act
            new AccountsService(mock.Object).Update(entity);

            // Assert
            mock.Verify(s => s.Update(It.Is<Account>(a => a.Id == entity.Id)));
        }

        [Test]
        public void AccountsService_Can_Delete_Account()
        {
            // Set-up
            var entity = new Account();
            var mock = new Mock<IDataService<Account>>();
            mock.Setup(s => s.Delete(It.IsAny<Account>()));

            // Act
            new AccountsService(mock.Object).Delete(entity);

            // Assert
            mock.Verify(s => s.Delete(It.Is<Account>(a => a.Id == entity.Id)));
        }
    }
}
