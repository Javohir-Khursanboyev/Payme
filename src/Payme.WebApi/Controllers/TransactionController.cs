using Microsoft.AspNetCore.Mvc;
using Payme.Service.DTOs.Transactions;
using Payme.Service.Services.TransactionServices;
using Payme.WebApi.Models;

namespace Payme.WebApi.Controllers;

public class TransactionController : ControllerBase
{
    private ITransactionService transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

    // GET: api/<CardsController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await transactionService.GetAllAsync()
        });
    }

    // GET api/<CardsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await transactionService.GetByIdAsync(id)
        });
    }

    // POST api/<CardsController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] TransactionCreationModel transaction)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await transactionService.CreateAsync(transaction)
        });
    }
}
