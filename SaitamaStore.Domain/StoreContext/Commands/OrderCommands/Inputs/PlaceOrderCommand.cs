using System;
using System.Collections.Generic;

namespace SaitamaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand
    {
        public Guid CustomerId { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }

    public class OrderItemCommand
    {
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}