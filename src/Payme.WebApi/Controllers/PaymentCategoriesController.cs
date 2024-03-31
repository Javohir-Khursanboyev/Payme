using Microsoft.AspNetCore.Mvc;
using Payme.Service.DTOs.PaymentCategories;
using Payme.Service.Services.PaymentCategoryServices;
using Payme.WebApi.Models;

namespace Payme.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentCategoriesController : ControllerBase
{
    private readonly IPaymentCategoryService paymentCategoryService;

    public PaymentCategoriesController(IPaymentCategoryService service)
    {
        this.paymentCategoryService = service;
    }

    // GET: api/<PaymentCategoryController>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PaymentCategoryCreationModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentCategoryService.CreateAsync(model)
        });
    }

    //DELETE: api/<PaymentCategoryController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentCategoryService.DeleteAsync(id)
        });
    }

    //UPDATE: api/<PaymentCategoryController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] PaymentCategoryUpdateModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentCategoryService.UpdateAsync(id, model)
        });
    }

    //GET: api<PaymentCategoryController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentCategoryService.GetByIdAsync(id)
        });
    }

    //GET: api<PaymentCategoryController>/
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentCategoryService.GetAllAsync()
        });
    }
}