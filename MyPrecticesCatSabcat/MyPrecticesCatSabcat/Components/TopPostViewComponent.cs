using Microsoft.AspNetCore.Mvc;

namespace MyPrecticesCatSabcat.Components
{
    public class TopPostViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
