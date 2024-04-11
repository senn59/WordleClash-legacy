using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exception = System.Exception;

namespace WordleClash.Web.Pages;

public class SingleplayerModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public const string GameSessionKey = "Game";
    private GameService _gameService;

    [BindProperty] public string Guess { get; set; }
    
    public SingleplayerModel(ILogger<IndexModel> logger, GameService gameService)
    {
        _logger = logger;
        _gameService = gameService;
    }

    public void OnGet()
    {
        var wordle = _gameService.GetOrCreate(GetGameId());
        _logger.LogInformation("Got the game instance");
    }

    public void OnPost()
    {
        var wordle = _gameService.GetOrCreate(GetGameId());
        _logger.LogInformation("Got the game instance");
        try
        {
            wordle.MakeMove(Guess);
            _logger.LogInformation($"user guesses {Guess}");
        }
        catch (Exception e)
        {
            _logger.LogWarning($"{e.GetType()} thrown while trying to make move.");
        }
        _logger.LogInformation($"{wordle.Tries}");
    }

    private string GetGameId()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(GameSessionKey)))
        {
            HttpContext.Session.SetString(GameSessionKey, Guid.NewGuid().ToString());
        }
        return HttpContext.Session.GetString(GameSessionKey) ?? throw new NullReferenceException("Couldnt find gameId");
    }
}