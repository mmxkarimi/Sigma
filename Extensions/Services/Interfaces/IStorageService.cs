
    public interface IStorageService
    {
        T Get<T>(string key, T defaultValue = default);
        void Set<T>(string key, T value);
        bool Remove(string key);
        void Clear();
        bool ContainsKey(string key);
    }