using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using UserCrud.Domain.Cryptography;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain.UnitTest
{
    [TestClass]
    public class AuthenticationDomainTest
    {
        private Mock<IRepository<User>> _repository;
        private Mock<IHasher> _hasher;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IRepository<User>>();
            _hasher = new Mock<IHasher>();
        }

        [TestMethod]
        public void When_LoginUserWithCorrectPassword_Then_ReturnUser()
        {
            //Arrange
            var userEmail = "d@d.com";
            var password = "1234";
            var passwordHased = password + "hased";
            var mockedUsers = new List<User> {
                new User() { Id = Guid.NewGuid(), UserEmail = "a@a.com", PasswordHash = "" },
                new User() { Id = Guid.NewGuid(), UserEmail = userEmail, PasswordHash = passwordHased },
                new User() { Id = Guid.NewGuid(), UserEmail = "c@c.com", PasswordHash = ""  }
            };

            _hasher.Setup(e => e.CalculateHash(password)).Returns(passwordHased);
            _repository.Setup(e => e.List()).Returns(mockedUsers);

            IAuthenticationDomain sut = new AuthenticationDomain(_repository.Object, _hasher.Object);

            //Action
            var user = sut.LogInUser(userEmail, password);

            //Assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void When_LoginUserWithIncorrectPassword_Then_ReturnNull()
        {
            //Arrange
            var userEmail = "d@d.com";
            var password = "1234";
            var passwordHased = password + "hased";
            var mockedUsers = new List<User> {
                new User() { Id = Guid.NewGuid(), UserEmail = userEmail, PasswordHash = passwordHased }
            };

            _hasher.Setup(e => e.CalculateHash(password)).Returns(passwordHased + "old");
            _repository.Setup(e => e.List()).Returns(mockedUsers);

            IAuthenticationDomain sut = new AuthenticationDomain(_repository.Object, _hasher.Object);

            //Action
            var user = sut.LogInUser(userEmail, password);

            //Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void When_EmailIsEmpty_Then_ReturnNull()
        {
            //Arrange
            var userEmail = "";
            var password = "1234";

            IAuthenticationDomain sut = new AuthenticationDomain(_repository.Object, _hasher.Object);

            //Action
            var user = sut.LogInUser(userEmail, password);

            //Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void When_PasswordIsEmpty_Then_ReturnNull()
        {
            //Arrange
            var userEmail = "d@d.com";
            var password = "";

            IAuthenticationDomain sut = new AuthenticationDomain(_repository.Object, _hasher.Object);

            //Action
            var user = sut.LogInUser(userEmail, password);

            //Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void When_LoginUserDoesntExist_Then_ReturnNull()
        {
            //Arrange
            var userEmail = "d@d.com";
            var password = "1234";
            var passwordHased = password + "hased";
            var mockedUsers = new List<User>();

            _hasher.Setup(e => e.CalculateHash(password)).Returns(passwordHased + "old");
            _repository.Setup(e => e.List()).Returns(mockedUsers);

            IAuthenticationDomain sut = new AuthenticationDomain(_repository.Object, _hasher.Object);

            //Action
            var user = sut.LogInUser(userEmail, password);

            //Assert
            Assert.IsNull(user);
        }
    }
}