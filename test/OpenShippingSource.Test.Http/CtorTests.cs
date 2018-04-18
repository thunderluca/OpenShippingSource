using OpenShippingSource.Http;
using OpenShippingSource.Test.Http.Clients;
using OpenShippingSource.Test.Http.Models;
using System;
using Xunit;

namespace OpenShippingSource.Test.Http
{
    public class CtorTests
    {
        [Fact]
        public void Assert_That_Devs_Could_Extend_IClient()
        {
            var testClient = new TestClient();

            Assert.True(testClient is IClient);
        }

        [Fact]
        public void Assert_That_IClient_GetTrackingItem_Does_Not_Throw()
        {
            var testClient = new TestClient();

            var testTrackingItem = new TestTrackingItem();

            var item = testClient.GetTrackingItem<TestTrackingItem>(testTrackingItem.Courier, testTrackingItem.Id);
        }

        [Fact]
        public void Assert_That_IClient_GetTrackingItem_Item_Is_Not_Null()
        {
            var testClient = new TestClient();

            var testTrackingItem = new TestTrackingItem();

            var item = testClient.GetTrackingItem<TestTrackingItem>(testTrackingItem.Courier, testTrackingItem.Id);
            
            Assert.NotNull(item);
        }

        [Fact]
        public void Assert_That_IClient_GetTrackingItem_Item_Has_Same_Generic_Type()
        {
            var testClient = new TestClient();

            var testTrackingItem = new TestTrackingItem();

            var item = testClient.GetTrackingItem<TestTrackingItem>(testTrackingItem.Courier, testTrackingItem.Id);
            
            Assert.True(item is TestTrackingItem);
        }
    }
}
