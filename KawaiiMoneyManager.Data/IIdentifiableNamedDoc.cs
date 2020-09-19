using System;

namespace KawaiiMoneyManager.Data
{
    public interface IIdentifiableNamedDoc
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
