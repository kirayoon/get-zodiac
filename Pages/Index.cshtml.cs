using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab01_zodiac_kira.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int Year { get; set; }
    public string? Zodiac { get; set; }
    public string? Error { get; set; }
    public string? ImagePath => $"~/images/{Zodiac!.ToLower()}.png";

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        int currentYear = DateTime.Now.Year;
        if (Year < 1900 || Year > currentYear + 1)
        {
            Error = "Invalid year";
        }
        else
        {
            Zodiac = Utils.GetZodiac(Year);
        }
    }
}
