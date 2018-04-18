namespace OpenShippingSource.Test.Abstractions.Models
{
    public class TestCourier : ICourier
    {
        public string WebSite { get; set; }

        public string Logo { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool TestFlag { get; set; }
    }
}
