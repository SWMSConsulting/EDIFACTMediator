
namespace EDIFACTMediator
{
    public class OrdersD96A
    {
        public InterchangeHeader Header { get; set; } = new InterchangeHeader();
        public List<Order> Orders { get; set; } = new List<Order>();
        public InterchangeTrailer Trailer { get; set; } = new InterchangeTrailer();
    }
    
    public class Order
    {
        public OrderHeader Header { get; set; } = new OrderHeader();
        public List<OrderLine> Lines { get; set; } = new List<OrderLine>();
        public OrderTrailer Trailer { get; set; } = new OrderTrailer();
    }
    
    public class OrderHeader
    {
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string BuyerReference { get; set; }
        public string BuyerGLN { get; set; }
        public string SellerGLN { get; set; }
    }
    
    public class OrderLine
    {
        public string LineNumber { get; set; }
        public string ProductCode { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
    
    public class OrderTrailer
    {
        public string NumberOfLines { get; set; }
    }
    
    public class InterchangeHeader
    {
        public string SenderGLN { get; set; }
        public string ReceiverGLN { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ControlNumber { get; set; }
    }
    
    public class InterchangeTrailer
    {
        public string NumberOfMessages { get; set; }
    }
}
