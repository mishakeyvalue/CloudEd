using CES_DAL;
using CES_DAL.Models;
using CES_DAL.Interfaces;
using CES_DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CES_BLL.Services
{
    public class TopicService
    {
        private IRepository<Topic> _repo;

        public TopicService()
        {
            _repo = TopicRepository.GetRepository();
        }
        public IEnumerable<Topic> GetAll()
        {
            return _repo.GetAll();
        }

        public Topic Get(string title)
        {
            return _repo.Get(title);
        }

        public void Add(Topic t)
        {
            t.Questions = new List<Question>();
            _repo.Add(t);
        }

        
    }
}
