namespace PolymorphismInWebApi.Models.Abstract
{
    public abstract class Device
    {
        public string SerialNumber { get; set; }
        public string Brand { get; set; }
        public string ScreenSize { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public double Price { get; set; }
    }
}
