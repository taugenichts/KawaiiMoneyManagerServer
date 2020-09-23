using System;

namespace KawaiiMoneyManager.Data
{
    public abstract class EntityBase : INamedEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }
}
