using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace OpenShippingSource.Serialization.Xml
{
    public class Serializer : ISerializer
    {
        public byte[] SerializeMultipleObjectsToByteArray<T>(IEnumerable<T> items)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(items.GetType());

                xmlSerializer.Serialize(memoryStream, items);

                return memoryStream.ToArray();
            }
        }

        public Stream SerializeMultipleObjectsToStream<T>(IEnumerable<T> items)
        {
            var memoryStream = new MemoryStream();

            var xmlSerializer = new XmlSerializer(items.GetType());

            xmlSerializer.Serialize(memoryStream, items);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        public string SerializeMultipleObjectsToString<T>(IEnumerable<T> items)
        {
            using (TextWriter textWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(items.GetType());

                xmlSerializer.Serialize(textWriter, items);

                return textWriter.ToString();
            }
        }

        public byte[] SerializeObjectToByteArray<T>(T item)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(item.GetType());

                xmlSerializer.Serialize(memoryStream, item);

                return memoryStream.ToArray();
            }
        }

        public Stream SerializeObjectToStream<T>(T item)
        {
            var memoryStream = new MemoryStream();

            var xmlSerializer = new XmlSerializer(item.GetType());

            xmlSerializer.Serialize(memoryStream, item);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        public string SerializeObjectToString<T>(T item)
        {
            using (TextWriter textWriter = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(item.GetType());

                xmlSerializer.Serialize(textWriter, item);

                return textWriter.ToString();
            }
        }
    }
}
