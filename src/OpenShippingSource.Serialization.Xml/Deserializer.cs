using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace OpenShippingSource.Serialization.Xml
{
    public class Deserializer : IDeserializer
    {
        public IEnumerable<T> DeserializeBytesAsMultipleObjects<T>(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var xmlSerializer = new XmlSerializer(typeof(T[]));

                return (T[])xmlSerializer.Deserialize(memoryStream);
            }
        }

        public T DeserializeBytesAsObject<T>(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream(bytes))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }

        public IEnumerable<T> DeserializeStreamAsMultipleObjects<T>(Stream stream)
        {
            var xmlSerializer = new XmlSerializer(typeof(T[]));

            return (T[])xmlSerializer.Deserialize(stream);
        }

        public T DeserializeStreamAsObject<T>(Stream stream)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            return (T)xmlSerializer.Deserialize(stream);
        }

        public IEnumerable<T> DeserializeStringAsMultipleObjects<T>(string content)
        {
            using (TextReader textReader = new StringReader(content))
            {
                var xmlSerializer = new XmlSerializer(typeof(T[]));

                return (T[])xmlSerializer.Deserialize(textReader);
            }
        }

        public T DeserializeStringAsObject<T>(string content)
        {
            using (TextReader textReader = new StringReader(content))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
    }
}
