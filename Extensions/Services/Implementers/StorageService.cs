using Microsoft.Maui.Storage;

namespace Sigma.App.Services
{

    public class StorageService : IStorageService
    {
        public T Get<T>(string key, T defaultValue = default)
        {
            try
            {
                if (typeof(T) == typeof(string))
                    return (T)(object)Preferences.Get(key, (string)(object)defaultValue);
                if (typeof(T) == typeof(int))
                    return (T)(object)Preferences.Get(key, (int)(object)defaultValue);
                if (typeof(T) == typeof(bool))
                    return (T)(object)Preferences.Get(key, (bool)(object)defaultValue);
                if (typeof(T) == typeof(double))
                    return (T)(object)Preferences.Get(key, (double)(object)defaultValue);
                if (typeof(T) == typeof(float))
                    return (T)(object)Preferences.Get(key, (float)(object)defaultValue);
                if (typeof(T) == typeof(long))
                    return (T)(object)Preferences.Get(key, (long)(object)defaultValue);
                if (typeof(T) == typeof(DateTime))
                    return (T)(object)Preferences.Get(key, (DateTime)(object)defaultValue);

                // For complex types, use JSON serialization
                var json = Preferences.Get(key, string.Empty);
                return string.IsNullOrEmpty(json) ? defaultValue : System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public void Set<T>(string key, T value)
        {
            try
            {
                if (value == null)
                {
                    Remove(key);
                    return;
                }

                if (typeof(T) == typeof(string))
                    Preferences.Set(key, (string)(object)value);
                else if (typeof(T) == typeof(int))
                    Preferences.Set(key, (int)(object)value);
                else if (typeof(T) == typeof(bool))
                    Preferences.Set(key, (bool)(object)value);
                else if (typeof(T) == typeof(double))
                    Preferences.Set(key, (double)(object)value);
                else if (typeof(T) == typeof(float))
                    Preferences.Set(key, (float)(object)value);
                else if (typeof(T) == typeof(long))
                    Preferences.Set(key, (long)(object)value);
                else if (typeof(T) == typeof(DateTime))
                    Preferences.Set(key, (DateTime)(object)value);
                else
                {
                    // For complex types, use JSON serialization
                    var json = System.Text.Json.JsonSerializer.Serialize(value);
                    Preferences.Set(key, json);
                }
            }
            catch (Exception)
            {
                // Log error or handle as needed
            }
        }

        public bool Remove(string key)
        {
            try
            {
                if (ContainsKey(key))
                {
                    Preferences.Remove(key);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Clear()
        {
            try
            {
                Preferences.Clear();
            }
            catch (Exception)
            {
                // Log error or handle as needed
            }
        }

        public bool ContainsKey(string key)
        {
            return Preferences.ContainsKey(key);
        }
    }
} 