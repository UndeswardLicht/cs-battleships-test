namespace Battleship.Utils
{
    public static class Store
    {
        private static readonly ThreadLocal<Dictionary<string, object>> storage = new ThreadLocal<Dictionary<string, object>>(() => new Dictionary<string, object>());

        public static void Put<T>(string key, ref T value) => storage.Value.Add(key, value);

        public static T Get<T>(string key)
        {
            storage.Value.TryGetValue(key, out object result);
            return (T)result;
        }

        public static void Update<T>(string key, ref T newValue) => storage.Value[key] = newValue;

        public static void CleanStore() => storage.Value.Clear();

        public static void Delete(string key) => storage.Value.Remove(key);
    }
}
