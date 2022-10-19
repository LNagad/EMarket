using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.AdvertisePhotos;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.MiddleWares;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class AdvertisesController : Controller
    {
        private readonly IAdvertisesService _adService;
        private readonly IAdvertisePhotosService _adPhotosService;
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;

        public AdvertisesController(IAdvertisesService adService, ICategoryService categoryService,
            ValidateUserSession validateUserSession, IAdvertisePhotosService adPhotosService)
        {
            _adService = adService;
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
            _adPhotosService = adPhotosService;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View(await _adService.GetAllViewModel());
        }

        public async Task<IActionResult> AdvertiseDetails(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.AdPhotos = await _adPhotosService.GetAsync(id);

            return View(await _adService.GetViewModelById(id));
        }


        public async Task<IActionResult> Create()
        {
            var emptyAd = new SaveAdvertisesViewModel();
            emptyAd.Categories = await _categoryService.GetAllViewModel();

            return View("SaveAdvertise", emptyAd);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAdvertisesViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                return View("SaveAdvertise", vm);

            }

            SaveAdvertisesViewModel adVM = await _adService.AddAsync(vm);
            SaveAdPhoto adPhotosVM = new();

            if (adVM != null && adVM.Id != 0)
            {

                adVM.ImageUrl = UploadFile(vm.File1, adVM.Id);

                await _adService.UpdateAsync(adVM);

                try
                {
                    adPhotosVM.AdvertiseID = adVM.Id;
                    adPhotosVM.Image1 = UploadFile(vm.File1, adVM.Id);
                    adPhotosVM.Image2 = UploadFile(vm.File2, adVM.Id);
                    adPhotosVM.Image3 = UploadFile(vm.File3, adVM.Id);

                    await _adPhotosService.AddAsync(adPhotosVM);

                }
                catch ( Exception ex)
                {

                }


            }

            return RedirectToRoute(new { controller = "Advertises", action = "Index" });
        }

        public async Task<IActionResult> Edit(int Id)
        {

            var value = await _adService.GetViewModelById(Id);
            value.Categories = await _categoryService.GetAllViewModel();

            return View("SaveAdvertise", value);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAdvertisesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                return View("SaveAdvertise", vm);
            }

            SaveAdvertisesViewModel adVM = await _adService.GetViewModelById(vm.Id);
            vm.ImageUrl = UploadFile(vm.File1, vm.Id, true, adVM.ImageUrl);

            await _adService.UpdateAsync(vm);

            return RedirectToRoute(new { controller = "Advertises", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var value = await _adService.GetViewModelById(Id);

            return View("Delete", value);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaveAdvertisesViewModel vm)
        {

            await _adService.DeleteAsync(vm);

            //--------------------Delete Image

            //get directory path
            string basePath = $"/x/{vm.Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true); // borrado recursivo, borrado completo
                }

                Directory.Delete(path);

            }

            return RedirectToRoute(new { controller = "Advertises", action = "Index" });
        }


        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imageUrl = "")
        {
            if (isEditMode && file == null)
            {
                return imageUrl;
            }

            //get directory path
            string basePath = $"/x/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //get file extension
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePath = imageUrl.Split("/");
                string oldImageName = oldImagePath[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{fileName}";
        }
    }
}
