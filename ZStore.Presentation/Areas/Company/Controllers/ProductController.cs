using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZStore.Domain.Common;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Presentation.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = SD.Role_Company)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AccountBaseEntity> _userManager;

        public ProductController(IUnitOfWork unitOfWork, UserManager<AccountBaseEntity> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Check if the current company owns the product
            var companyUser = await _userManager.GetUserAsync(User);
            if (companyUser == null)
                return Forbid();

            var products = await _unitOfWork.Product.GetAsync(p => p.CompanyId == companyUser.Id);
            if (products == null)
                return NotFound();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _unitOfWork.Category.GetAllAsync();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(product);
                var companyUser = await _userManager.GetUserAsync(User);
                if (companyUser == null)
                    return Forbid();

                var productToSave = new Product
                {
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    ProductDetail = new ProductDetail(),
                    ProductImages = new List<ProductImage>(),
                    CategoryId = product.CategoryId,
                    CompanyId = companyUser.Id
                };


                await _unitOfWork.Product.InsertAsync(productToSave);
                await _unitOfWork.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("Something went wrong");
            // ModelState is invalid, return the view with validation errors
            var categories = await _unitOfWork.Category.GetAllAsync();
            ViewBag.Categories = categories;

            return View(product);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            // Check if the current company owns the product
            var companyUser = await _userManager.GetUserAsync(User);
            if (companyUser == null)
                return Forbid();

            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            
            if (product.CompanyId != companyUser.Id)
            {
                return Forbid();
            }


            return View(product);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            var companyUser = await _unitOfWork.ApplicationUser.GetByIdAsync(id);
            if (companyUser == null)
                return Forbid();
            // Check if the current company owns the product
            if (product.CompanyId != companyUser.Id)
            {
                return Forbid();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the current company owns the product
                    var companyUser = await _unitOfWork.ApplicationUser.GetByIdAsync(id);
                    if (companyUser == null)
                        return Forbid();
                    // Check if the current company owns the product
                    if (product.CompanyId != companyUser.Id)
                    {
                        return Forbid();
                    }


                    _unitOfWork.Product.Update(product);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Add other actions...

        private bool ProductExists(int id)
        {
            return _unitOfWork.Product.AnyAsync(p => p.Id == id).Result;
        }
    }
}