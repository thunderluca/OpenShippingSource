using System.Collections.Generic;
using System.IO;

namespace OpenShippingSource.Serialization
{
    public interface IDeserializer
    {
        IEnumerable<T> DeserializeBytesAsMultipleObjects<T>(byte[] bytes);

        T DeserializeBytesAsObject<T>(byte[] bytes);

        IEnumerable<T> DeserializeStreamAsMultipleObjects<T>(Stream stream);

        T DeserializeStreamAsObject<T>(Stream stream);

        IEnumerable<T> DeserializeStringAsMultipleObjects<T>(string content);

        T DeserializeStringAsObject<T>(string content);
    }
}
