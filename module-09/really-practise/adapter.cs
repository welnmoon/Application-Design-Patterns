using System;

namespace LogisticsSystem
{
    public interface IInternalDeliveryService
    {
        void DeliverOrder(string orderId);
        string GetDeliveryStatus(string orderId);
    }

    public class InternalDeliveryService : IInternalDeliveryService
    {
        public void DeliverOrder(string orderId) => Console.WriteLine($"Delivering order {orderId} via internal service.");
        public string GetDeliveryStatus(string orderId) => $"Status of order {orderId} from internal service";
    }

    public class ExternalLogisticsServiceA
    {
        public void ShipItem(int itemId) => Console.WriteLine($"Shipping item {itemId} with ExternalLogisticsServiceA.");
        public string TrackShipment(int shipmentId) => $"Tracking shipment {shipmentId} from ExternalLogisticsServiceA";
    }

    public class LogisticsAdapterA : IInternalDeliveryService
    {
        private ExternalLogisticsServiceA _externalService;
        public LogisticsAdapterA(ExternalLogisticsServiceA externalService) => _externalService = externalService;
        public void DeliverOrder(string orderId) => _externalService.ShipItem(int.Parse(orderId));
        public string GetDeliveryStatus(string orderId) => _externalService.TrackShipment(int.Parse(orderId));
    }

    public class ExternalLogisticsServiceB
    {
        public void SendPackage(string packageInfo) => Console.WriteLine($"Sending package {packageInfo} with ExternalLogisticsServiceB.");
        public string CheckPackageStatus(string trackingCode) => $"Status of package {trackingCode} from ExternalLogisticsServiceB";
    }

    public class LogisticsAdapterB : IInternalDeliveryService
    {
        private ExternalLogisticsServiceB _externalService;
        public LogisticsAdapterB(ExternalLogisticsServiceB externalService) => _externalService = externalService;
        public void DeliverOrder(string orderId) => _externalService.SendPackage(orderId);
        public string GetDeliveryStatus(string orderId) => _externalService.CheckPackageStatus(orderId);
    }

    public static class DeliveryServiceFactory
    {
        public static IInternalDeliveryService GetDeliveryService(string serviceType)
        {
            return serviceType switch
            {
                "Internal" => new InternalDeliveryService(),
                "ExternalA" => new LogisticsAdapterA(new ExternalLogisticsServiceA()),
                "ExternalB" => new LogisticsAdapterB(new ExternalLogisticsServiceB()),
                _ => throw new ArgumentException("Invalid service type")
            };
        }
    }

    class Program
    {
        static void Main()
        {
            var deliveryService = DeliveryServiceFactory.GetDeliveryService("ExternalA");
            deliveryService.DeliverOrder("101");
            Console.WriteLine(deliveryService.GetDeliveryStatus("101"));
        }
    }
}
