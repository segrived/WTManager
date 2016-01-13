using System.IO;

namespace WTManager.Helpers
{
    public static class SerializationHelpers
    {
        public static T DeserializeFile<T>(string fileName) {
            using (var stream = File.OpenRead(fileName))
            using (var reader = new StreamReader(stream)) {
                var des = new YamlDotNet.Serialization.Deserializer(ignoreUnmatched: true);
                return des.Deserialize<T>(reader);
            }
        }
    }
}
