using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserCrud.Domain.Cryptography;

namespace UserCrud.Domain.UnitTest
{
    [TestClass]
    public class HasherTest
    {
        [TestMethod]
        public void When_CalculateHash_Then_RetunFilledHashedString()
        {
            //Arrange
            var password = "1234";

            IHasher sut = new Hasher();

            //Action
            var hash = sut.CalculateHash(password);

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(hash));
        }

        [TestMethod]
        public void When_CalculateHash_Then_RetunHashedString()
        {
            //Arrange
            var password = "1234";

            IHasher sut = new Hasher();

            //Action
            var hash = sut.CalculateHash(password);

            //Assert
            Assert.AreNotEqual(password, hash);
        }

        [TestMethod]
        public void When_CalculateHashWasCalledTwice_Then_RetunSameHash()
        {
            //Arrange
            var password = "1234";

            IHasher sut = new Hasher();

            //Action
            var hash1 = sut.CalculateHash(password);
            var hash2 = sut.CalculateHash(password);

            //Assert
            Assert.AreEqual(hash1, hash2);
        }
    }
}