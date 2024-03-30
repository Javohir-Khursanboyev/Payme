using Microsoft.AspNetCore.Mvc;
using Payme.Domain.Entities.PaymentCategories;
using Payme.Service.DTOs.PaymentCategories;
using Payme.Service.Services.PaymentCategoryServices;
using Payme.WebApi.Models;

namespace Payme.WebApi.Controllers;
  
[Route("api/[controller]")]
[ApiController]

public class PaymentCategoryController : ControllerBase
{
    private readonly PaymentCategoryService service;

    public PaymentCategoryController(PaymentCategoryService service)
    {
        this.service = service;
    }

    // GET: api/<PaymentCategoryController>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PaymentCategoryCreationModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.CreateAsync(model)
        });
    }

    //DELETE: api/<PaymentCategoryController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message ="OK",
            Data = await service.DeleteAsync(id)
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
            Data = await service.UpdateAsync(id, model)
        });
    }

    //GET: api<PaymentCategoryController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message ="OK",
            Data = await service.GetByIdAsync(id)
        });
    }

    //GET: api<PaymentCategoryController>/
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode =200,
            Message="OK",
            Data = await service.GetAllAsync()
        });
    }

}
