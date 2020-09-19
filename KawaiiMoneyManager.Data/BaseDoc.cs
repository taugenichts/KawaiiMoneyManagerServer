using System;
using System.Collections.Generic;
using System.Text;

namespace KawaiiMoneyManager.Data
{
    public class BaseDoc : IIdentifiableNamedDoc
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
