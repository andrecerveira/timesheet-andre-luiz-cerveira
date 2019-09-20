using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Domain.Entities;
using TimeSheet.Infra.Data.Repositories;

namespace TimeSheet.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepository _usuarioRepository;

        //[HttpGet]
        public ActionResult Index()
        {
            _usuarioRepository = new UsuarioRepository();
            ModelState.Clear();
            return View(_usuarioRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                {
                    _usuarioRepository = new UsuarioRepository();
                    if (_usuarioRepository.Add(usuario))
                    {
                        ViewBag.Mensagem = "Usuário cadastrado com Sucesso";
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
            List<Departamento> departamentos = new DepartamentoRepository().GetAll().ToList();
            SelectList listaDeDepartamentos = new SelectList(departamentos, "DepartamentoId", "Nome");
            ViewBag.DepartamentosListName = listaDeDepartamentos;

            _usuarioRepository = new UsuarioRepository();
            return View(_usuarioRepository.GetAll().FirstOrDefault(c => c.UsuarioId == id));
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                _usuarioRepository = new UsuarioRepository();
                _usuarioRepository.Update(usuario);

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
                _usuarioRepository = new UsuarioRepository();
                _usuarioRepository.Delete(id);
                //ViewBag.Mensagem = "Usuário excluído com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
