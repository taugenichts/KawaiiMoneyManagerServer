using System;
using System.Collections.Generic;
using KawaiiMoneyManager.Data.Accounting;

namespace KawaiiMoneyManager.Services.Accounting
{
    public interface IAccountsService
    {
        Account Get(Guid id);
        IEnumerable<Account> GetAll();
        Account Create(Account entity);
        Account Update(Account entity);
        void Delete(Account entity);
    }
}
