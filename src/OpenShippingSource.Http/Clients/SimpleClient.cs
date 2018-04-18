using OpenShippingSource.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenShippingSource.Http.Clients
{
    public class SimpleClient : IClient
    {
        private readonly string BaseGetUrlFormat;
        private readonly bool RenewClientEveryRequest;
        private readonly IDeserializer Deserializer;
        private HttpClient _httpClient;
        
        public SimpleClient(string baseGetUrlFormat, bool renewClientEveryRequest, IDeserializer deserializer)
        {
            this.BaseGetUrlFormat = baseGetUrlFormat;
            this.RenewClientEveryRequest = renewClientEveryRequest;
            this.Deserializer = deserializer;
        }

        private void InitializeClient()
        {
            if (this.RenewClientEveryRequest || _httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }

        public T GetTrackingItem<T>(ICourier courier, string id) where T : ITrackingItem
        {
            this.InitializeClient();

            var requestUrl = string.Format(this.BaseGetUrlFormat, id);

            var responseMessageTask = this._httpClient.GetAsync(this.BaseGetUrlFormat);
            responseMessageTask.Wait();

            var responseContentTask = responseMessageTask.Result.Content.ReadAsStringAsync();
            responseContentTask.Wait();

            if (!responseMessageTask.Result.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContentTask.Result);
            }

            return this.Deserializer.DeserializeStringAsObject<T>(responseContentTask.Result);
        }

        public async Task<T> GetTrackingItemAsync<T>(ICourier courier, string id) where T : ITrackingItem
        {
            this.InitializeClient();

            var requestUrl = string.Format(this.BaseGetUrlFormat, id);

            var responseMessage = await this._httpClient.GetAsync(this.BaseGetUrlFormat);

            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContent);
            }

            return this.Deserializer.DeserializeStringAsObject<T>(responseContent);
        }

        public IEnumerable<T> UpdateTrackingItems<T>(IEnumerable<T> trackingItems) where T : ITrackingItem
        {
            this.InitializeClient();

            var updatedTrackingItems = new List<T>();

            foreach (var trackingItem in trackingItems)
            {
                var updatedTrackingItemTask = this.GetTrackingItemAsync<T>(trackingItem.Courier, trackingItem.Id);
                updatedTrackingItemTask.Wait();

                updatedTrackingItems.Add(updatedTrackingItemTask.Result);
            }

            return updatedTrackingItems;
        }

        public async Task<IEnumerable<T>> UpdateTrackingItemsAsync<T>(IEnumerable<T> trackingItems) where T : ITrackingItem
        {
            this.InitializeClient();

            var updatedTrackingItems = new List<T>();

            foreach (var trackingItem in trackingItems)
            {
                var updatedTrackingItem = await this.GetTrackingItemAsync<T>(trackingItem.Courier, trackingItem.Id);

                updatedTrackingItems.Add(updatedTrackingItem);
            }

            return updatedTrackingItems;
        }
    }
}
