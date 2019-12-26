using System.Collections;
using System.Collections.Generic;
using FluentValidator;

namespace SaitamaStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(
            Product product,
            decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
            {
                AddNotification("Quantity", "Produto fora de estoque");
            }
            product.DecreaseQuantity(quantity);
        }
        
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        public IDictionary<string, string> Notifications { get; private set; }
    }
}