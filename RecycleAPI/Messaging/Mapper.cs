using RecycleAPI.Models;

namespace RecycleAPI.Messaging
{
    public static class Mapper
    {
        public static void Map(Order order, SimpleOrder simpleOrder)
        {
            simpleOrder.OrderId = order.OrderId;
            simpleOrder.ItemId = order.ItemId;
            simpleOrder.OrderNumber = order.OrderNumber;
            simpleOrder.OrderDate = order.OrderDate;
            simpleOrder.AccountName = order.AccountName;
            simpleOrder.ContactLastName = order.ContactLastName;
            simpleOrder.ContactFirstName = order.ContactFirstName;
            simpleOrder.ContactEmail = order.ContactEmail;
            simpleOrder.ContactPhone = order.ContactPhone;
            simpleOrder.Address1 = order.Address1;
            simpleOrder.Address2 = order.Address2;
            simpleOrder.City = order.City;
            simpleOrder.State = order.State;
            simpleOrder.PostalCode = order.PostalCode;
            simpleOrder.Country = order.Country;
            simpleOrder.Reference1 = order.Reference1;
            simpleOrder.Reference2 = order.Reference2;
            simpleOrder.ProgramInfoId = order.ProgramInfoId;
            simpleOrder.NumberOfBatteries = order.NumberOfBatteries;
            simpleOrder.KitQuantity = order.KitQuantity;
            simpleOrder.OrderStatus = order.OrderStatus;
            simpleOrder.OrderStatusDate = order.OrderStatusDate;
            simpleOrder.OrderTrackingNumber = order.OrderTrackingNumber;
            simpleOrder.ReciptTrackingNumber = order.ReciptTrackingNumber;

            if (order.Vendor != null)
                simpleOrder.VendorId = order.Vendor.VendorId.ToString();


        }
    }
}