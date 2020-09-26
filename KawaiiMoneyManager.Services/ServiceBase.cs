using KawaiiMoneyManager.Data;

namespace KawaiiMoneyManager.Services
{
    public abstract class ServiceBase<T>
        where T : EntityBase
    {
        protected readonly IDataService<T> dataService;

        public ServiceBase(IDataService<T> dataService)
        {
            this.dataService = dataService;
        }
    }
}
