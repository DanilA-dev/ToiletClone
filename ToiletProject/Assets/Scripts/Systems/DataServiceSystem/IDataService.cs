namespace Systems.DataServiceSystem
{
    public interface IDataService
    {
        public bool Save<T>(string path, T data);
        public T Load<T>(string path);
    }
}