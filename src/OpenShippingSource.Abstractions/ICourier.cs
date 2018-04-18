namespace OpenShippingSource
{
    public interface ICourier : IEntity
    {
        string WebSite { get; set; }

        string Logo { get; set; }
    }
}
