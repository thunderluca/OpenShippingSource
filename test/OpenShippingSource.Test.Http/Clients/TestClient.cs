using OpenShippingSource.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenShippingSource.Test.Http.Clients
{
    public class TestClient : IClient
    {
        public T GetTrackingItem<T>(ICourier courier, string id) where T : ITrackingItem
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public Task<T> GetTrackingItemAsync<T>(ICourier courier, string id) where T : ITrackingItem
        {
            return Task.FromResult((T)Activator.CreateInstance(typeof(T)));
        }

        public IEnumerable<T> UpdateTrackingItems<T>(IEnumerable<T> trackingItems) where T : ITrackingItem
        {
            return trackingItems;
        }

        public Task<IEnumerable<T>> UpdateTrackingItemsAsync<T>(IEnumerable<T> trackingItems) where T : ITrackingItem
        {
            return Task.FromResult(trackingItems);
        }
    }
}
