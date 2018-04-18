using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenShippingSource.Serialization.NewtonsoftJson
{
    public class Serializer : ISerializer
    {
        private readonly Encoding Encoding;
        private readonly JsonSerializerSettings Settings;

        public Serializer() : this(Encoding.UTF8, new JsonSerializerSettings()) { }

        public Serializer(Encoding encoding, JsonSerializerSettings settings)
        {
            this.Encoding = encoding;
            this.Settings = settings;
        }

        public byte[] SerializeMultipleObjectsToByteArray<T>(IEnumerable<T> items)
        {
            var content = JsonConvert.SerializeObject(items, this.Settings);

            return this.Encoding.GetBytes(content);
        }

        public Stream SerializeMultipleObjectsToStream<T>(IEnumerable<T> items)
        {
            var content = JsonConvert.SerializeObject(items, this.Settings);

            var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream, this.Encoding))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                memoryStream.Seek(0, SeekOrigin.Begin);
            }

            return memoryStream;
        }

        public string SerializeMultipleObjectsToString<T>(IEnumerable<T> items)
        {
            return JsonConvert.SerializeObject(items, this.Settings);
        }

        public byte[] SerializeObjectToByteArray<T>(T item)
        {
            var content = JsonConvert.SerializeObject(item, this.Settings);

            return this.Encoding.GetBytes(content);
        }

        public Stream SerializeObjectToStream<T>(T item)
        {
            var content = JsonConvert.SerializeObject(item, this.Settings);

            var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream, this.Encoding))
            {
                streamWriter.Write(content);
                streamWriter.Flush();
                memoryStream.Seek(0, SeekOrigin.Begin);
            }

            return memoryStream;
        }

        public string SerializeObjectToString<T>(T item)
        {
            return JsonConvert.SerializeObject(item, this.Settings);
        }
    }
}
