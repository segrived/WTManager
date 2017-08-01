using System.IO;
using System.Xml.Serialization;

namespace WTManager.Helpers
{
    public static class SerializationHelpers
    {
        public static void SerializeFile<T>(string fileName, T obj)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var writer = new StreamWriter(fileName))
                serializer.Serialize(writer, obj);
        }

        public static T DeserializeFile<T>(string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StreamReader(fileName))
                return (T)serializer.Deserialize(reader);
        }
    }
}
