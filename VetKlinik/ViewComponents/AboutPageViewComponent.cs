using Microsoft.AspNetCore.Mvc;
using VetKlinik.Models;

namespace VetKlinik.ViewComponents
{
    public class AboutPageViewComponent : ViewComponent
    {
        //TODO View Component oluşturulması
        public IViewComponentResult Invoke()
        {
            List<About> datas = new List<About>
            {
                new About{AboutTxt = "Bu bir about sayfası için oluşturulmuş hakkında yazısıdır", ContactEmail = "ferraridownshift@gmail.com", ContactPhone = "0542 542 42 42"},
                new About{AboutTxt = "Bu bir about sayfası için oluşturulmuş ikinci bir hakkında yazısıdır", ContactEmail = "ferraridownshift@gmail.com", ContactPhone = "0542 542 42 42"}
            };
            return View(datas);
        }
    }
}
