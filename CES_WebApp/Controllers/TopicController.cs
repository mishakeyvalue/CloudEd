//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using CES_BLL;
//using CES_BLL.Services;
//using CES_DAL.Models;
//using CES_DAL.Interfaces;

//namespace CES_WebApp.Controllers
//{
//    public class TopicController : Controller
//    {
//        private TopicService topicService = new TopicService();

//        // GET: Topic
//        public ActionResult Index()
//        {
//            return View(topicService.GetAll());
//        }

//        //////GET: Topic/Details/5
//        ////public ActionResult Details(int id)
//        ////{
//        ////    return View();
//        ////}

//        // GET: Topic/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Topic/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind("TopicTitle")] Topic newTopic)
//        {
//            try
//            {

//                topicService.Add(newTopic);
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Topic/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Topic/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Topic/Delete/5
//        public ActionResult Delete(string title)
//        {
//            Topic toDelete =  topicService.Get(title);
//            return View(toDelete);
//        }

//        // POST: Topic/Delete/5]
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(string title, int id)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}