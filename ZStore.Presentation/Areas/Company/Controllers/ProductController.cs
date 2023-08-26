using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZStore.Domain.Common;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Domain.ViewModels;
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Check if the current company owns the product
            var companyUser = await _userManager.GetUserAsync(User);
            if (companyUser == null)
                return Forbid();

            var products = await _unitOfWork.Product.GetAsync(p => p.CompanyId == companyUser.Id);
            if (products == null)
                return NotFound();

            var listOfProducts = products.Select(p => new ProductVM
            {
                ProductId = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
            }).ToList();

            return View(listOfProducts) ;
        }

        public async Task<IActionResult> Create()
        {
            var companyUser = await _userManager.GetUserAsync(User);
            if (companyUser == null)
                return Forbid();

            var categories = await _unitOfWork.Category.GetAllAsync();
            var productVM = new ProductVM
            {
                CompanyId = companyUser.Id,
                Categories = categories.Select(c => new CategoryVM
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),
            };
            ViewBag.Categories = categories.ToList();

            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var companyUser = await _userManager.GetUserAsync(User);
                if (companyUser == null)
                    return Forbid();

                var productToSave = new Product
                {
                    Title = productVM.Title,
                    Description = productVM.Description,
                    Price = productVM.Price,
                    CategoryId = productVM.CategoryId,
                    CompanyId = companyUser.Id,
                };

                await _unitOfWork.Product.InsertAsync(productToSave);
                await _unitOfWork.SaveAsync();

                return RedirectToAction(nameof(Index));
            } 
            // If ModelState is not valid, populate the Categories dropdown again
            productVM.Categories = _unitOfWork.Category.GetAll().Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return View(productVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
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

            var productVm = new ProductVM
            {
                ProductId = id,
                Title= product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CompanyId = companyUser.Id,
            };

            return View(productVm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var companyUser = await _userManager.GetUserAsync(User);

            if (companyUser == null || product.CompanyId != companyUser.Id)
            {
                return Forbid();
            }

            var productToDisplay = new ProductVM
            {
                ProductId = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CompanyId = companyUser.Id,
            };

            var categories = await _unitOfWork.Category.GetAllAsync();
            ViewBag.Categories = categories; // Populate ViewBag with categories

            return View(productToDisplay);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] ProductVM productVm)
        {

            var product = await _unitOfWork.Product.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var companyUser = await _userManager.GetUserAsync(User);

            if (companyUser == null || product.CompanyId != companyUser.Id)
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    try
                    {
                        product.Title = productVm.Title;
                        product.Description = productVm.Description;
                        product.Price = productVm.Price;
                        product.CategoryId = productVm.CategoryId;

                        _unitOfWork.Product.Update(product);
                        await _unitOfWork.SaveAsync();

                        await transaction.CommitAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        // Handle the exception, such as logging it
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
            }
            var categories = await _unitOfWork.Category.GetAllAsync();
            ViewBag.Categories = categories; // Populate ViewBag with categories

            // If ModelState is not valid, return the view with validation errors
            return View(nameof(Details), productVm);
        }
        // Add other actions...

        private bool ProductExists(int id)
        {
            return _unitOfWork.Product.AnyAsync(p => p.Id == id).Result;
        }
    }
}