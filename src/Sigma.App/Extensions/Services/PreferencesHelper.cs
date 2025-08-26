using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.App.Extensions.Services
{
    public class PreferencesHelper
    {
        public T Get<T>(string key, T defaultValue = default)
        {
            try
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)Preferences.Get(key, (string)(object)defaultValue);
                }
                else if (typeof(T) == typeof(int))
                {
                    return (T)(object)Preferences.Get(key, (int)(object)defaultValue);
                }

                else if (typeof(T) == typeof(bool))
                {
                    return (T)(object)Preferences.Get(key, (bool)(object)defaultValue);
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)Preferences.Get(key, (double)(object)defaultValue);
                }

                else if (typeof(T) == typeof(float))
                {
                    return (T)(object)Preferences.Get(key, (float)(object)defaultValue);
                }

                else if (typeof(T) == typeof(long))
                {
                    return (T)(object)Preferences.Get(key, (long)(object)defaultValue);
                }

                else if (typeof(T) == typeof(DateTime))
                {
                    return (T)(object)Preferences.Get(key, (DateTime)(object)defaultValue);
                }
                // For complex types, use JSON serialization
                else
                {
                    var json = Preferences.Get(key, string.Empty);
                    return string.IsNullOrEmpty(json) ? defaultValue : System.Text.Json.JsonSerializer.Deserialize<T>(json);
                }
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
                if (typeof(T) == typeof(string))
                {
                    Preferences.Set(key, (string)(object)value);
                }
                else if (typeof(T) == typeof(int))
                {
                    Preferences.Set(key, (int)(object)value);
                }

                else if (typeof(T) == typeof(bool))
                {
                    Preferences.Set(key, (bool)(object)value);
                }
                else if (typeof(T) == typeof(double))
                {
                    Preferences.Set(key, (double)(object)value);
                }

                else if (typeof(T) == typeof(float))
                {
                    Preferences.Set(key, (float)(object)value);
                }

                else if (typeof(T) == typeof(long))
                {
                    Preferences.Set(key, (long)(object)value);
                }

                else if (typeof(T) == typeof(DateTime))
                {
                    Preferences.Set(key, (DateTime)(object)value);
                }
                else
                {
                    // For complex types, use JSON serialization
                    var json = System.Text.Json.JsonSerializer.Serialize(value);
                    Preferences.Set(key, json);
                }
            }
            catch (Exception)
            {
                throw;
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
                throw;
            }
        }

        public bool ContainsKey(string key)
        {
            return Preferences.ContainsKey(key);
        }
    }
}
