using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class SeedUserTest
    {
        private FakeRepository<User> _repository;
        private Hasher _hasher;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new FakeRepository<User>();
            _hasher = new Hasher();
        }

        [TestMethod]
        public void When_Seed_Then_RetunFillRepositoryWithDefaultUsers()
        {
            //Arrange
            ISeedUser sut = new SeedUser(_hasher);

            //Action
            sut.Seed(_repository);

            //Assert
            var users = _repository.List();
            Assert.AreNotEqual(users.Count(), 0);
        }

        [TestMethod]
        public void When_Seed_Then_RetunFillWithAdminUser()
        {
            //Arrange
            ISeedUser sut = new SeedUser(_hasher);

            //Action
            sut.Seed(_repository);

            //Assert
            var users = _repository.List();
            var adminUser = users.Where(e => e.UserEmail == "admin@user.com");
            Assert.IsNotNull(adminUser);
        }

        private class FakeRepository<T> : IRepository<T> where T : ISearchable
        {
            private List<T> _fakeStore;

            public FakeRepository()
            {
                _fakeStore = new List<T>();
            }

            public IEnumerable<T> List()
            {
                return _fakeStore;
            }

            public void Save(T item)
            {
                _fakeStore.Add(item);
            }

            public void Delete(Guid id)
            {
                throw new NotImplementedException();
            }

            public T FindById(Guid id)
            {
                throw new NotImplementedException();
            }
        }
    }
}