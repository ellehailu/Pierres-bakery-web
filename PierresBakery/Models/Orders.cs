using System;
using System.Collections.Generic;

namespace PierresBakery.Models
{
    public class Order
    {
        public string OrderTitle { get; set; }
        public string OrderDescription { get; set; }
        public decimal OrderPrice { get; set; }
        public string OrderDate { get; set; }

        public int Id { get; }

        private static List<Order> _orderList = new List<Order> { };

        public Order(string orderTitle, string orderDescription, decimal orderPrice, string orderDate)
        {
            OrderTitle = orderTitle;
            OrderDescription = orderDescription;
            OrderPrice = orderPrice;
            OrderDate = orderDate;
            _orderList.Add(this);
            Id = _orderList.Count;
        }

        public static void ClearAll()
        {
            _orderList.Clear();
        }

        public static List<Order> GetAll()
        {
            return _orderList;
        }

        public static Order Find(int searchId)
        {
            Order thisOrder = Order._orderList[searchId - 1];
            return thisOrder;
        }
    }
}