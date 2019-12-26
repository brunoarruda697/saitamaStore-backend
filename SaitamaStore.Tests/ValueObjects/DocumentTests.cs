using NUnit.Framework;
using SaitamaStore.Domain.StoreContext.ValueObjects;

namespace SaitamaStore.Tests.ValueObjects
{
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("47993624886");
            invalidDocument = new Document("12345678910");
        }
        [Test]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }
        
        [Test]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}