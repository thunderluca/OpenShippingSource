using OpenShippingSource.Test.Abstractions.Models;
using Xunit;

namespace OpenShippingSource.Test.Abstractions
{
    public class CtorTests
    {
        [Fact]
        public void Assert_That_Devs_Could_Extend_ICourier()
        {
            var testCourier = new TestCourier();

            Assert.True(testCourier is ICourier);
        }

        [Fact]
        public void Assert_That_Devs_Could_Extend_ITrackingItem()
        {
            var testTrackingItem = new TestTrackingItem();

            Assert.True(testTrackingItem is ITrackingItem);
        }

        [Fact]
        public void Assert_That_ICourier_Extends_IEntity()
        {
            var testCourier = new TestCourier();

            Assert.True(testCourier is IEntity);
        }

        [Fact]
        public void Assert_That_ITrackingItem_Extends_IEntity()
        {
            var testTrackingItem = new TestTrackingItem();

            Assert.True(testTrackingItem is IEntity);
        }
    }
}
