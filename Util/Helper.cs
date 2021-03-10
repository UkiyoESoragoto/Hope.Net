using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using static System.IO.Directory;

namespace Hope.Util
{
    internal static class Helper
    {
        public static TValue JsonDeepCopy<TValue>(TValue obj)
        {
            var jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            return JsonSerializer.Deserialize<TValue>(readOnlySpan);
        }

        public static void PropertiesTransfer<T>(T from, T to)
        {
            var oType = typeof(T);
            var properties = oType.GetProperties();
            foreach (var property in properties)
                try
                {
                    property.SetValue(to, property.GetValue(@from));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);
                }
        }

        public static string GetConfFile()
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var directory = CreateDirectory(Path.Join(home, "hope.net"));
            var configFile = Path.Join(directory.FullName, "config.json");
            if (!File.Exists(configFile))
            {
                File.Create(configFile);
            }

            return configFile;
        }
    }
}