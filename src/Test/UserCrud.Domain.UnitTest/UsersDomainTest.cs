using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using UserCrud.Domain.Cryptography;
using UserCrud.Domain.DefaultData;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain.UnitTest
{
    [TestClass]
    public class UsersDomainTest
    {
        private Mock<IRepository<User>> _repository;
        private Mock<ISeedUser> _seeder;
        private Mock<IHasher> _hasher;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IRepository<User>>();
            _seeder = new Mock<ISeedUser>();
            _hasher = new Mock<IHasher>();
        }

        [TestMethod]
        public void When_GetAllWithZeroUsers_Then_RetunAnEmptyResult()
        {
            //Arrange
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Action
            var users = sut.GetAll();

            //Assert
            Assert.AreEqual(0, users.Count());
        }

        [TestMethod]
        public void When_GetAllWith2Users_Then_Retun2Users()
        {
            //Arrange
            var mockedUsers = new List<User> {
                new User() { Id = Guid.NewGuid() },
                new User() { Id = Guid.NewGuid() }
            };

            _repository.Setup(x => x.List()).Returns(mockedUsers);
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Action
            var users = sut.GetAll();

            //Assert
            Assert.AreEqual(2, users.Count());
        }

        [TestMethod]
        public void When_GetWithExistUser_Then_RetunCorrectUser()
        {
            //Arrange
            var userMocked = new User() { Id = Guid.NewGuid() };
            _repository.Setup(x => x.FindById(userMocked.Id)).Returns(userMocked);
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Action
            var user = sut.Get(userMocked.Id);

            //Assert
            Assert.AreEqual(userMocked.Id, user?.Id);
        }

        [TestMethod]
        public void When_GetWithInexistenUser_Then_RetunNull()
        {
            //Arrange
            var userMocked = new User() { Id = Guid.NewGuid() };
            _repository.Setup(x => x.FindById(userMocked.Id)).Returns(userMocked);
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Action
            var user = sut.Get(userMocked.Id);

            //Assert
            Assert.AreEqual(userMocked.Id, user?.Id);
        }

        [TestMethod]
        public void When_DeleteUser_Then_RemoveFromStore()
        {
            //Arrange
            var userMocked = new User() { Id = Guid.NewGuid() };
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Action
            sut.Delete(userMocked.Id);

            //Assert
            _repository.Verify(e => e.Delete(userMocked.Id), Times.Once());
        }

        [TestMethod]
        public void When_CreateUser_Then_CallToSaveInStore()
        {
            //Arrange
            var userMocked = new User() { Id = Guid.NewGuid() };
            _repository.Setup(x => x.Save(userMocked));
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);
            var passwordHased = "xksdn";
            _hasher.Setup(e => e.CalculateHash(null)).Returns(passwordHased);

            //Action
            sut.Create(userMocked);

            //Assert
            _repository.Verify(e => e.Save(userMocked), Times.Once());
        }

        [TestMethod]
        public void When_Update_Then_CallToSaveInStore()
        {
            //Arrange
            var userMocked = new User() { Id = Guid.NewGuid() };
            _repository.Setup(x => x.Save(userMocked));
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Action
            sut.Update(userMocked);

            //Assert
            _repository.Verify(e => e.Save(userMocked), Times.Once());
        }

        [TestMethod]
        public void When_Constructor_Then_CallSeeder()
        {
            //Arrange

            //Action
            IUsersDomain sut = new UsersDomain(_repository.Object, _seeder.Object, _hasher.Object);

            //Assert
            _seeder.Verify(e => e.Seed(_repository.Object), Times.Once());
        }
    }
}