using Microsoft.AspNetCore.Mvc;
using Payme.Service.DTOs.UserPayments;
using Payme.Service.Services.UserPaymentServices;
using Payme.WebApi.Models;

namespace Payme.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPaymentController : ControllerBase
{
    private readonly IUserPaymentService userPaymentService;

    public UserPaymentController(IUserPaymentService userPaymentService)
    {
        this.userPaymentService = userPaymentService;
    }

    //POST: api<UserPaymentController>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserPaymentCreationModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await userPaymentService.CreateAsync(model)
        });
    }

    //GET: api<UserPaymentController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await userPaymentService.GetAllAsync()
        });
    }

    //GET: api<UserPaymentController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await userPaymentService.GetByIdAsync(id)
        });
    }
}
