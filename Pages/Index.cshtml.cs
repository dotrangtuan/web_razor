using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace EF_RazorPage.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly MyBlogContext _myBlogContext;

    public IndexModel(ILogger<IndexModel> logger, MyBlogContext myBlogContext)
    {
        _myBlogContext = myBlogContext;
        _logger = logger;
    }

    public void OnGet()
    {
        var articles = (from a in _myBlogContext.articles 
            select a).ToList();
        ViewData["articles"] = articles; 
    }
}
