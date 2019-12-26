using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using SaitamaStore.Domain.StoreContext.Enums;

namespace SaitamaStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
        
        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
            {
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");
            }
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }
        
        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
            {
                AddNotification("Order", "Este pedido não possui itens");
            }
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            var deliveries = new List<Delivery>();
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }

                count++;
            }

            deliveries.ForEach(delivery => delivery.Ship());
            deliveries.ForEach(delivery => _deliveries.Add(delivery));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(delivery => delivery.Cancel());
        }
    }
}