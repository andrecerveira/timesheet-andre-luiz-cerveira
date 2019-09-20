using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Domain.Entities;
using TimeSheet.Infra.Data.Repositories;

namespace TimeSheet.MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        private DepartamentoRepository _departamentoRepository;

        //[HttpGet]
        public ActionResult Index()
        {
            _departamentoRepository = new DepartamentoRepository();
            ModelState.Clear();
            return View(_departamentoRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                {
                    _departamentoRepository = new DepartamentoRepository();
                    if (_departamentoRepository.Add(departamento))
                    {
                        ViewBag.Mensagem = "Departamento cadastrado com Sucesso";
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
            _departamentoRepository = new DepartamentoRepository();
            return View(_departamentoRepository.GetAll().FirstOrDefault(c => c.DepartamentoId == id));
        }

        [HttpPost]
        public ActionResult Edit(Departamento departamento)
        {
            try
            {
                _departamentoRepository = new DepartamentoRepository();
                _departamentoRepository.Update(departamento);

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
                _departamentoRepository = new DepartamentoRepository();
                _departamentoRepository.Delete(id);
                //ViewBag.Mensagem = "Departamento excluído com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
