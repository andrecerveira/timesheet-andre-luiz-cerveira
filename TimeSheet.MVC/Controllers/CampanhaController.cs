using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Domain.Entities;
using TimeSheet.Infra.Data.Repositories;

namespace TimeSheet.MVC.Controllers
{
    public class CampanhaController : Controller
    {
        private CampanhaRepository _campanhaRepository;

        //[HttpGet]
        public ActionResult Index()
        {
            _campanhaRepository = new CampanhaRepository();
            ModelState.Clear();
            return View(_campanhaRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Campanha campanha)
        {
            try
            {
                {
                    _campanhaRepository = new CampanhaRepository();
                    if (_campanhaRepository.Add(campanha))
                    {
                        ViewBag.Mensagem = "Campanha cadastrada com Sucesso";
                    }
                }
                //return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {

                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Produto> produtos = new ProdutoRepository().GetAll().ToList();
            SelectList listaDeProdutos = new SelectList(produtos, "ProdutoId", "Nome");
            ViewBag.ProdutosListName = listaDeProdutos;

            _campanhaRepository = new CampanhaRepository();
            return View(_campanhaRepository.GetAll().FirstOrDefault(c => c.CampanhaId == id));
        }

        [HttpPost]
        public ActionResult Edit(Campanha campanha)
        {
            try
            {
                _campanhaRepository = new CampanhaRepository();
                _campanhaRepository.Update(campanha);

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
                _campanhaRepository = new CampanhaRepository();
                _campanhaRepository.Delete(id);
                //ViewBag.Mensagem = "Campanha excluída com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
