using System;
using System.Collections.Generic;
using KawaiiMoneyManager.Data;
using KawaiiMoneyManager.Data.Accounting;

namespace KawaiiMoneyManager.Services.Accounting
{
    public class AccountsService : ServiceBase<Account>, IAccountsService
    {
        public AccountsService(IDataService<Account> dataService) : base(dataService) { }

        public Account Get(Guid id) =>
            this.dataService.Get(id);

        public IEnumerable<Account> GetAll() =>
            this.dataService.GetMany();

        public Account Create(Account entity) =>
            this.dataService.Insert(entity);

        public Account Update(Account entity) =>
            this.dataService.Update(entity);

        public void Delete(Account entity) =>
            this.dataService.Delete(entity);
    }
}
