using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Domain.Entities;
using TimeSheet.Infra.Data.Repositories;

namespace TimeSheet.MVC.Controllers
{
    public class JobController : Controller
    {
        private JobRepository _jobRepository;

        //[HttpGet]
        public ActionResult Index()
        {
            _jobRepository = new JobRepository();
            ModelState.Clear();
            return View(_jobRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Job job)
        {
            try
            {
                {
                    _jobRepository = new JobRepository();
                    if (_jobRepository.Add(job))
                    {
                        ViewBag.Mensagem = "Job cadastrado com Sucesso";
                    }
                }
                //return RedirectToAction("Index");
                return View();
            }
            catch (Exception)
            {

                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Campanha> campanhas = new CampanhaRepository().GetAll().ToList();
            SelectList listaDeCampanhas = new SelectList(campanhas, "CampanhaId", "Nome");
            ViewBag.CampanhasListName = listaDeCampanhas;

            _jobRepository = new JobRepository();
            return View(_jobRepository.GetAll().FirstOrDefault(c => c.JobId == id));
        }

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            try
            {
                _jobRepository = new JobRepository();
                _jobRepository.Update(job);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }

        //[HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _jobRepository = new JobRepository();
                _jobRepository.Delete(id);
                //ViewBag.Mensagem = "Job excluído com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
