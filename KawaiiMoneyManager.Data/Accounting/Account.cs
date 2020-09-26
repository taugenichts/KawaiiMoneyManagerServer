using System.Collections.Generic;

namespace KawaiiMoneyManager.Data.Accounting
{
    public class Account : EntityBase
    {
        public string Description { get; set; }
        public IEnumerable<string> DesignatedUses { get; set; } = new List<string>();
    }
}
