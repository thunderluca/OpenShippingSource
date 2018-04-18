using System;

namespace OpenShippingSource
{
    public interface ITrackingItem : IEntity
    {
        DateTime SentTime { get; set; }

        DateTime? DeliveredTime { get; set; }

        DateTime? LastUpdateTime { get; set; }

        string ShippingAddress { get; set; }

        ICourier Courier { get; set; }
    }
}
