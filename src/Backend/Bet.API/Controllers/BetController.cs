using Bet.Application.DTOs;
using Bet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BetController : ControllerBase
{
    private readonly IBetService _betService;

    public BetController(IBetService betService)
    {
        _betService = betService;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceBet([FromBody] PlaceBetDTO dto)
    {
        var result = await _betService.PlaceBet(dto);

        return result.Match<IActionResult>(
            bet => Ok(bet),
            error => BadRequest(new { error.ErrorCode, error.ErrorMessage })
        );
    }

}
