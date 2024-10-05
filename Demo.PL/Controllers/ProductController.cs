using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepo;
        private readonly IMapper mapper;

        public ProductController(IProductRepository productRepom, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = productRepo.GetAll();
            //IEnumerable<Product> products = NewMethod();
            var viewModel = mapper.Map<IEnumerable<ProductVM>>(products);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var model = mapper.Map<Product>(viewModel);
            productRepo.Add(model);
            return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var product = productRepo.GetById(id.Value);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var product = productRepo.GetById(id.Value);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = mapper.Map<Product>(viewModel);
                productRepo.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var product = productRepo.GetById(id.Value);
            if (product is null)
            {
                return NotFound();
            }
            productRepo.Delete(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
    

