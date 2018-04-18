using System;

namespace OpenShippingSource.Test.Http.Models
{
    public class TestTrackingItem : ITrackingItem
    {
        public DateTime SentTime { get; set; }

        public DateTime? DeliveredTime { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        public string ShippingAddress { get; set; }

        public ICourier Courier { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool TestFlag { get; set; }
    }
}
