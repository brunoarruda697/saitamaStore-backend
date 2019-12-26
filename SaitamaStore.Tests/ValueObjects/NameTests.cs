using NUnit.Framework;
using SaitamaStore.Domain.StoreContext.ValueObjects;

namespace SaitamaStore.Tests.ValueObjects
{
    public class NameTests
    {
        private Name validName;
        private Name invalidName;

        public NameTests()
        {
            validName = new Name("Bruno", "Arruda");
            invalidName = new Name("", "Teste");
        }
        [Test]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            Assert.AreEqual(1, invalidName.Notifications.Count);
        }
        
        [Test]
        public void ShouldNotReturnNotificationWhenNameIsValid()
        {
            Assert.AreEqual(0, validName.Notifications.Count);
        }
    }
}