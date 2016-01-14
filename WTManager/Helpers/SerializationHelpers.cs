using System.IO;
using static YamlDotNet.Serialization.SerializationOptions;

namespace WTManager.Helpers
{
    public static class SerializationHelpers
    {
        public static void SerializeFile<T>(string fileName, T obj) {
            using (var writer = File.CreateText(fileName)) {
                var s = new YamlDotNet.Serialization.Serializer(EmitDefaults);
                s.Serialize(writer, obj, typeof(T));
            }
        }

        public static T DeserializeFile<T>(string fileName) {
            using (var stream = File.OpenRead(fileName))
            using (var reader = new StreamReader(stream)) {
                var des = new YamlDotNet.Serialization.Deserializer(ignoreUnmatched: true);
                return des.Deserialize<T>(reader);
            }
        }
    }
}
