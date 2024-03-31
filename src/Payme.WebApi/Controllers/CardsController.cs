using Microsoft.AspNetCore.Mvc;
using Payme.Service.DTOs.Cards;
using Payme.Service.Services.CardServices;
using Payme.WebApi.Models;

namespace Payme.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private ICardService cardService;

    public CardsController(ICardService cardService)
    {
        this.cardService = cardService;
    }

    // GET: api/<CardsController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await cardService.GetAllAsync()
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
            Data = await cardService.GetByIdAsync(id)
        });
    }

    // POST api/<CardsController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CardCreationModel card)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await cardService.CreateAsync(card)
        });
    }

    // PUT api/<CardsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutASync(long id, [FromBody] CardUpdateModel card)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await cardService.UpdateAsync(id, card)
        });
    }

    // DELETE api/<CardsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await cardService.DeleteAsync(id)
        });
    }
}