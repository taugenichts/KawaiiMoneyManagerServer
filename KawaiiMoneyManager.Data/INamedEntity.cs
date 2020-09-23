using System;

namespace KawaiiMoneyManager.Data
{
    public interface INamedEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
