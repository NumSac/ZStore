using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZStore.Domain.Common;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Presentation.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = SD.Role_Admin)]
    public class IdentityController : Controller
    {
        public readonly UserManager<AccountBaseEntity> _companyUserManager;
        public readonly UserManager<AccountBaseEntity> _applicationUserManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IUnitOfWork _unitOfWork;

        public IdentityController(UserManager<AccountBaseEntity> companyUserManager, 
            UserManager<AccountBaseEntity> applicationUserManager, 
            RoleManager<IdentityRole> roleManager, 
            IUnitOfWork unitOfWork
            )
        {
            _companyUserManager = companyUserManager;
            _applicationUserManager = applicationUserManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        // GET: IdentityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IdentityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IdentityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IdentityController/Create
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

        // GET: IdentityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IdentityController/Edit/5
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

        // GET: IdentityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IdentityController/Delete/5
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
    }
}
