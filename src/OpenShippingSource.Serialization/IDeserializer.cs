using System.Collections.Generic;
using System.IO;

namespace OpenShippingSource.Serialization
{
    public interface IDeserializer
    {
        T DeserializeStringAsObject<T>(string content);

        T DeserializeStreamAsObject<T>(Stream stream);

        T DeserializeBytesAsObject<T>(IEnumerable<byte> bytes);

        IEnumerable<T> DeserializeStringAsMultipleObjects<T>(string content);

        IEnumerable<T> DeserializeStreamAsMultipleObjects<T>(Stream stream);

        IEnumerable<T> DeserializeBytesAsMultipleObjects<T>(IEnumerable<byte> bytes);
    }
}
