using Microsoft.AspNetCore.Mvc;
using Payme.Service.DTOs.Payments;
using Payme.Service.Services.PaymentServices;
using Payme.WebApi.Models;

namespace Payme.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PaymentsController : Controller
{
    private readonly IPaymentService paymentService;

    public PaymentsController(IPaymentService service)
    {
        this.paymentService = service;
    }

    // GET: api/<PaymentsController>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PaymentCreationModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentService.CreateAsync(model)
        });
    }

    //DELETE: api/<PaymentsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentService.DeleteAsync(id)
        });
    }

    //UPDATE: api/<PaymentsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] PaymentUpdateModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentService.UpdateAsync(id, model)
        });
    }

    //GET: api<PaymentsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentService.GetByIdAsync(id)
        });
    }

    //GET: api<PaymentsController>/
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await paymentService.GetAllAsync()
        });
    }
}