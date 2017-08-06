using CloudEd.BLL.Core.Quiz.Models;
using CloudEd.BLL.Core.Quiz.Services;
using CloudEd.DAL.Persistence;
using CloudEd.Tests.Mocks;
using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using CloudEd.DAL.Repositories;

namespace CloudEd.Tests
{
    public class Mocks_Tests
    {


        [Fact]
        public void MockRepository_AddItem_ContainsIt()
        {
            // arrange
            IRepository<DummyPersistenceEntity, Guid> repo = new InMemoryRepository<DummyPersistenceEntity>();
            var item = new DummyPersistenceEntity();

            // act
            repo.Add(item);

            // assert
            Assert.Contains(repo.GetAll(), ent => ent.Id == item.Id);
        }

        private class DummyPersistenceEntity : IEntity<Guid>
        {
            public Guid Id { get; set; }
        }
    }
}
