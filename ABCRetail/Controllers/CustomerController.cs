﻿namespace ABCRetail.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IAzureStorageService _storageService;

        public CustomerController(IAzureStorageService azureStorageService)
        {
            _storageService = azureStorageService;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _storageService.GetAllEntitiesAsync<Customer>();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _storageService.AddEntityAsync(customer);
                    TempData["Success"] = $"Customer {customer.Name} created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating customer: {ex.Message}");
                }
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var customer = await _storageService.GetEntityAsync<Customer>("Customer", id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var originalCustomer = await _storageService.GetEntityAsync<Customer>("Customer", customer.RowKey);
                    if(originalCustomer == null)
                    {
                        return NotFound();
                    } 
                    
                    originalCustomer.Name = customer.Name;
                    originalCustomer.Surname = customer.Surname;
                    originalCustomer.Email = customer.Email;
                    originalCustomer.Username = customer.Username;
                    originalCustomer.ShippingAddress = customer.ShippingAddress;

                    await _storageService.UpdateEntityAsync(originalCustomer);
                    TempData["Success"] = $"Customer '{originalCustomer.Name}' upddated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error Updating customer: {ex.Message}");
                }
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _storageService.DeleteEntityAsync<Customer>("Customer", id);
                TempData["Success"] = $"Customer created successfully";

            }
            catch(Exception ex) 
            {
                TempData["Error"] = $"Error deleteing customer: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
