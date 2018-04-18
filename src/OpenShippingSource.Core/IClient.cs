using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenShippingSource.Http
{
    public interface IClient
    {
        T GetTrackingItem<T>(ICourier courier, string id) where T : ITrackingItem;

        Task<T> GetTrackingItemAsync<T>(ICourier courier, string id) where T : ITrackingItem;

        IEnumerable<T> UpdateTrackingItems<T>(IEnumerable<T> trackingItems) where T : ITrackingItem;

        Task<IEnumerable<T>> UpdateTrackingItemsAsync<T>(IEnumerable<T> trackingItems) where T : ITrackingItem;
    }
}
