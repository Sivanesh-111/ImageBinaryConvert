using ImageBinaryConvert.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImageBinaryConvert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageService _imageService;

        public HomeController(ImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowImage(short customerId)
        {
            var image = _imageService.GetImage(customerId);

            if (image == null)
                return NotFound();

            return File(image, "image/png");
        }

        public async Task<IActionResult> Download()
        {
            await _imageService.DownloadImages();

            return Content("Images Downloaded Successfully");
        }
    }
}