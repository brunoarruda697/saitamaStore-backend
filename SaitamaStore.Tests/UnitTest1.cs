using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;
using SaitamaStore.Domain.StoreContext.Entities;
using SaitamaStore.Domain.StoreContext.ValueObjects;

namespace SaitamaStore.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var name = new Name("Bruno", "Costa");
            var document = new Document("123456789");
            var email = new Email("bruno@test.com");
            var customer = new Customer(name, email, "123456789", document);
            var mouse = new Product("Mouse", "Test", "image.png", 10.90M, 5);
            var keyboard = new Product("Keyboard", "Test1", "image.png", 10.90M, 5);
            var headset = new Product("Headset", "Test2", "image.png", 10.90M, 5);
            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(keyboard, 2));
            order.AddItem(new OrderItem(headset, 3));
            
            order.Place();
        }
    }
}