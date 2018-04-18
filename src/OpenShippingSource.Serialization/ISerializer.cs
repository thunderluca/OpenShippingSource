using System.Collections.Generic;
using System.IO;

namespace OpenShippingSource.Serialization
{
    public interface ISerializer
    {
        byte[] SerializeMultipleObjectsToByteArray<T>(IEnumerable<T> items);

        Stream SerializeMultipleObjectsToStream<T>(IEnumerable<T> items);

        string SerializeMultipleObjectsToString<T>(IEnumerable<T> items);

        byte[] SerializeObjectToByteArray<T>(T item);

        Stream SerializeObjectToStream<T>(T item);

        string SerializeObjectToString<T>(T item);
    }
}
