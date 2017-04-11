using CES_BLL;
using CES_DAL.Enteties;
using CES_DAL;
using System;
using Xunit;

namespace CES.Tests.Unit
{
    public class MongoDB_Tests
    {
        [Fact]
        public void PushToTheDB_RemainsThere()
        {
            // arrange
            var wu = new UnitOfWork();
            Topic t = new Topic() { TopicTitle = "John" };

            // act
            wu.TopicRepo.Add(t);

            // assert
            Assert.Contains<Topic>(t, wu.TopicRepo.GetAll());
        }
    }
}
