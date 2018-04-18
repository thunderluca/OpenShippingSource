using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenShippingSource.Serialization.NewtonsoftJson
{
    public class Deserializer : IDeserializer
    {
        private readonly Encoding Encoding;
        private readonly JsonSerializerSettings Settings;

        public Deserializer() : this(Encoding.UTF8, new JsonSerializerSettings()) { }

        public Deserializer(Encoding encoding, JsonSerializerSettings settings)
        {
            this.Encoding = encoding;
            this.Settings = settings;
        }

        public IEnumerable<T> DeserializeBytesAsMultipleObjects<T>(byte[] bytes)
        {
            var content = this.Encoding.GetString(bytes);

            return JsonConvert.DeserializeObject<T[]>(content, this.Settings);
        }

        public T DeserializeBytesAsObject<T>(byte[] bytes)
        {
            var content = this.Encoding.GetString(bytes);

            return JsonConvert.DeserializeObject<T>(content, this.Settings);
        }

        public IEnumerable<T> DeserializeStreamAsMultipleObjects<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, this.Encoding))
            {
                var content = streamReader.ReadToEnd();

                return JsonConvert.DeserializeObject<T[]>(content, this.Settings);
            }
        }

        public T DeserializeStreamAsObject<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, this.Encoding))
            {
                var content = streamReader.ReadToEnd();

                return JsonConvert.DeserializeObject<T>(content, this.Settings);
            }
        }

        public IEnumerable<T> DeserializeStringAsMultipleObjects<T>(string content)
        {
            return JsonConvert.DeserializeObject<T[]>(content, this.Settings);
        }

        public T DeserializeStringAsObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, this.Settings);
        }
    }
}
