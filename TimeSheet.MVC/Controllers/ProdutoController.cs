using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Domain.Entities;
using TimeSheet.Infra.Data.Repositories;

namespace TimeSheet.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepository _produtoRepository;

        //[HttpGet]
        public ActionResult Index()
        {
            _produtoRepository = new ProdutoRepository();
            ModelState.Clear();
            return View(_produtoRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                {
                    _produtoRepository = new ProdutoRepository();
                    if (_produtoRepository.Add(produto))
                    {
                        ViewBag.Mensagem = "Produto cadastrado com Sucesso";
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
            List<Cliente> clientes = new ClienteRepository().GetAll().ToList();
            SelectList listaDeClientes = new SelectList(clientes, "ClienteId", "Nome");
            ViewBag.ClientesListName = listaDeClientes;

            _produtoRepository = new ProdutoRepository();
            return View(_produtoRepository.GetAll().FirstOrDefault(c => c.ProdutoId == id));
        }

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                _produtoRepository = new ProdutoRepository();
                _produtoRepository.Update(produto);

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
                _produtoRepository = new ProdutoRepository();
                _produtoRepository.Delete(id);
                //ViewBag.Mensagem = "Produto excluído com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
