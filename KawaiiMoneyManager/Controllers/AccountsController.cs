using System;
using System.Collections.Generic;
using KawaiiMoneyManager.Data.Accounting;
using KawaiiMoneyManager.Services.Accounting;
using Microsoft.AspNetCore.Mvc;

namespace KawaiMoneyManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService service;
        public AccountsController(IAccountsService service) =>        
            this.service = service;

        [HttpGet]
        [Route("{id}")]
        public Account Get(Guid id) =>
            this.service.Get(id);

        [HttpGet]
        public IEnumerable<Account> Get() =>
            this.service.GetAll();

        [HttpPost]
        public Account Post(Account entity) =>
            this.service.Create(entity);


    }
}
