using Systems.DataServiceSystem;
using Zenject;

namespace Systems
{
    public class SaveDataController
    {
        private IDataService _dataService;

        [Inject]
        private void Construct(IDataService dataService)
        {
            _dataService = dataService;
        }

        public bool Save<T>(string path, T data)
        {
           return _dataService.Save(path, data);
        }

        public T Load<T>(string path)
        {
            return _dataService.Load<T>(path);
        }
    }
}