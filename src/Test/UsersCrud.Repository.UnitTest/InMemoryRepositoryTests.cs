using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UsersCrud.Repository.UnitTest
{
    [TestClass]
    public class InMemoryRepositoryTests
    {
        [TestMethod]
        public void When_List_Then_ReturnsIEnumerableOfCorrectType()
        {
            //Arrange
            IRepository<SearchableEntity> repository = new InMemoryRepository<SearchableEntity>();

            //Action
            var result = repository.List();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<SearchableEntity>));
        }

        [TestMethod]
        public void When_Save_Then_WillAddNewItem()
        {
            //Arrange
            IRepository<SearchableEntity> repository = new InMemoryRepository<SearchableEntity>();
            var itemToBeSaved = new SearchableEntity { Id = Guid.NewGuid(), Name = "ItemToBeSaved" };

            //Action
            repository.Save(itemToBeSaved);

            //Assert
            var result = repository.List();
            Assert.IsTrue(result.Contains(itemToBeSaved));
        }

        [TestMethod]
        public void When_Save_Then_WillUpdateExistingItem()
        {
            //Arrange
            IRepository<SearchableEntity> repository = new InMemoryRepository<SearchableEntity>();
            var existingItem = new SearchableEntity { Id = Guid.NewGuid(), Name = "ExistingItem" };
            repository.Save(existingItem);

            var itemToBeSaved = new SearchableEntity { Id = existingItem.Id, Name = "ItemToBeSaved" };

            //Action
            repository.Save(itemToBeSaved);

            //Assert
            var result = repository.List();
            Assert.IsTrue(result.Contains(itemToBeSaved));
        }

        [TestMethod]
        public void When_SaveWithOutID_Then_SetIDAndSave()
        {
            //Arrange
            IRepository<SearchableEntity> repository = new InMemoryRepository<SearchableEntity>();

            var itemToBeSaved = new SearchableEntity { Id = Guid.Empty, Name = "ItemToBeSaved" };

            //Action
            repository.Save(itemToBeSaved);

            //Assert
            var result = repository.List();
            Assert.AreNotEqual(Guid.Empty, result.FirstOrDefault().Id);
        }

        [TestMethod]
        public void When_Delete_Then_WillRemoveExistingItem()
        {
            //Arrange
            IRepository<SearchableEntity> repository = new InMemoryRepository<SearchableEntity>();
            var existingItem = new SearchableEntity { Id = Guid.NewGuid(), Name = "ExistingItem" };
            repository.Save(existingItem);

            //Action
            repository.Delete(existingItem.Id);

            //Assert
            var result = repository.List();
            Assert.IsFalse(result.Contains(existingItem));
        }

        [TestMethod]
        public void When_FindById_Then_ReturnsCorrectItem()
        {
            //Arrange
            IRepository<SearchableEntity> repository = new InMemoryRepository<SearchableEntity>();
            var existingItem = new SearchableEntity { Id = Guid.NewGuid(), Name = "ExistingItem" };
            repository.Save(existingItem);

            var anotherItem = new SearchableEntity { Id = Guid.NewGuid(), Name = "AnotherItem" };
            repository.Save(anotherItem);

            //Action
            var result = repository.FindById(anotherItem.Id);

            //Assert
            Assert.AreEqual(anotherItem, result);
        }

        public class SearchableEntity : ISearchable
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
        }
    }
}