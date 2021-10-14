﻿using iSangue.DAO;
using iSangue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iSangue.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDao usuarioDao;
        private DoadorDao doadorDao;

        UsuarioDao Usuario
        {
            get
            {
                if (usuarioDao == null)
                {
                    usuarioDao = new UsuarioDao(Helper.DBConnectionSql);
                }
                return usuarioDao;
            }
            set
            {
                usuarioDao = value;
            }
        }

        DoadorDao Doador
        {
            get
            {
                if (doadorDao == null)
                {
                    doadorDao = new DoadorDao(Helper.DBConnectionSql);
                }
                return doadorDao;
            }
            set
            {
                doadorDao = value;
            }
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("email,senha")] Usuario usuario)
        {
            var login = await Usuario.LoginUsuario(usuario.email, usuario.senha);
            if (login != null)
            {
                //return RedirectToAction(nameof(LoginSucess));
                return  await LoginSucess(login);
            }
            else
            {
                return RedirectToAction(nameof(LoginError));
            }
        }



        public async Task<IActionResult> LoginError()
        {
            return View();
        }

        public async Task<IActionResult> LoginSucess(Usuario usuario)
        {
            var chavedoador = "chave";
            ViewBag.nome = "Indefinido";
            switch (usuario.tipoUsuario)
            {
                case "DOADOR":

                    var result = await Doador.GetDoadorByUserID(usuario.id);
                    HttpContext.Session.SetString(chavedoador, "DOADOR");
                   
                    ViewBag.nome = HttpContext.Session.GetString(chavedoador);     
                    return View("LoginSucess");
            }

           return View("LoginSucess");
        }



        public async Task<IActionResult> teste()
        {
            return View();
        }

        public async Task<IActionResult> Logado()
        {
            return View();
        }




    }
}
