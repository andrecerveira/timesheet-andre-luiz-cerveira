using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Domain.Entities;
using TimeSheet.Infra.Data.Repositories;

namespace TimeSheet.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository _clienteRepository;

        //[HttpGet]
        public ActionResult Index()
        {
            _clienteRepository = new ClienteRepository();
            ModelState.Clear();
            return View(_clienteRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                {
                    _clienteRepository = new ClienteRepository();
                    if (_clienteRepository.Add(cliente))
                    {
                        ViewBag.Mensagem = "Cliente cadastrado com Sucesso";
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
            _clienteRepository = new ClienteRepository();
            return View(_clienteRepository.GetAll().FirstOrDefault(c => c.ClienteId == id));
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                _clienteRepository = new ClienteRepository();
                _clienteRepository.Update(cliente);

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
                _clienteRepository = new ClienteRepository();
                _clienteRepository.Delete(id);
                //ViewBag.Mensagem = "Cliente excluído com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
