using CES_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CES_DAL;

namespace CES_BLL
{
    public class UnitOfWork
    {
        public IRepository<Topic> TopicRepo = TopicRepository.GetRepo();
    }
}
