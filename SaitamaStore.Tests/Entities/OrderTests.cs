using NUnit.Framework;
using SaitamaStore.Domain.StoreContext.Entities;
using SaitamaStore.Domain.StoreContext.Enums;
using SaitamaStore.Domain.StoreContext.ValueObjects;

namespace SaitamaStore.Tests.Entities
{
    [TestFixture]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        public OrderTests()
        {
            var name = new Name("Bruno", "Arruda");
            var document = new Document("47993624886");
            var email = new Email("bruno@test.com");
            _customer = new Customer(name, email, "44999358090", document);
            _mouse = new Product("Mouse Gamer", "Nice product", "mouse.png", 100M, 10);
            _keyboard = new Product("Keyboard Gamer", "Nice product", "keyboard.png", 100M, 10);
            _chair = new Product("Chair Gamer", "Nice product", "chair.png", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Nice product", "monitor.png", 100M, 10);
        }
        
        [Test]
        public void ShouldCreateOrderWhenValid()
        {
            var order = new Order(_customer);
            Assert.AreEqual(true, order.Valid);
        }
        
        [Test]
        public void StatusShouldBeCreatedWhenCreateAnOrder()
        {
            var order = new Order(_customer);
            Assert.AreEqual(EOrderStatus.Created, order.Status);
        }
        
        [Test]
        public void ShouldReturnTwoWhenAddTwoValidItems()
        {
            var order = new Order(_customer);
            order.AddItem(_monitor, 5);
            order.AddItem(_mouse, 5);
            Assert.AreEqual(2, order.Items.Count);
        }

        [Test]
        public void ShouldReturnFiveWhenPurchasedFiveItemOfTen()
        {
            var order = new Order(_customer);
            order.AddItem(_keyboard, 5);
            Assert.AreEqual(_keyboard.QuantityOnHand, 5);
        }
        
        [Test]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            var order = new Order(_customer);
            order.Place();
            Assert.AreNotEqual("", order.Number);
        }
        
        [Test]
        public void ShouldReturnPaidWhenOrderBePayed()
        {
            var order = new Order(_customer);
            order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, order.Status);
        }
        
        [Test]
        public void ShouldReturnTwoShippingWhenPurchasedTenProducts()
        {
            var order = new Order(_customer);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.Ship();
            Assert.AreEqual(2, order.Deliveries.Count);
        }
        
        [Test]
        public void StatusShouldBeCanceledWhenCancelAnOrder()
        {
            var order = new Order(_customer);
            order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, order.Status);
        }
        
        [Test]
        public void ShouldCancelShippingWhenCancelAnOrder()
        {
            var order = new Order(_customer);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.AddItem(_chair, 1);
            order.Ship();
            order.Cancel();
            foreach (var delivery in order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, delivery.Status);
            }
        }
    }
}