using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenShippingSource.Http.Clients
{
    public class SimpleClient : IClient
    {
        private readonly string BaseGetUrlFormat;
        private readonly bool RenewClientEachRequest;
        private HttpClient _httpClient;

        public SimpleClient(string baseGetUrlFormat, bool renewClientEachRequest)
        {
            this.BaseGetUrlFormat = baseGetUrlFormat;
            this.RenewClientEachRequest = renewClientEachRequest;
        }

        private void InitializeClient()
        {
            if (this.RenewClientEachRequest || _httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }

        public T GetTrackingItem<T>(ICourier courier, string id) where T : ITrackingItem
        {
            this.InitializeClient();

            var requestUrl = string.Format(this.BaseGetUrlFormat, id);

            var responseTask = this._httpClient.GetAsync(this.BaseGetUrlFormat);

            responseTask.Wait();

            return this.ManageSingleTrackingItemResult<T>(responseTask.Result);
        }

        public async Task<T> GetTrackingItemAsync<T>(ICourier courier, string id) where T : ITrackingItem
        {
            this.InitializeClient();

            var requestUrl = string.Format(this.BaseGetUrlFormat, id);

            var responseMessage = await this._httpClient.GetAsync(this.BaseGetUrlFormat);

            return this.ManageSingleTrackingItemResult<T>(responseMessage);
        }

        private T ManageSingleTrackingItemResult<T>(HttpResponseMessage responseMessage) where T : ITrackingItem
        {

        }

        public IEnumerable<T> UpdateTrackingItems<T>(IEnumerable<T> trackingItems) where T : ITrackingItem
        {
            this.InitializeClient();

            var responseTask = this._httpClient.GetAsync(this.BaseGetUrlFormat);

            responseTask.Wait();

            return this.ManageMultipleTrackingItemsResult<T>(responseTask.Result);
        }

        public async Task<IEnumerable<T>> UpdateTrackingItemsAsync<T>(IEnumerable<T> trackingItems) where T : ITrackingItem
        {
            this.InitializeClient();

            var responseMessage = await this._httpClient.GetAsync(this.BaseGetUrlFormat);

            return this.ManageMultipleTrackingItemsResult<T>(responseMessage);
        }

        private IEnumerable<T> ManageMultipleTrackingItemsResult<T>(HttpResponseMessage responseMessage) where T : ITrackingItem
        {

        }
    }
}
