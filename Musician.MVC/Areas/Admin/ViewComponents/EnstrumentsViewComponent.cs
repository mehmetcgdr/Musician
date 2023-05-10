using Microsoft.AspNetCore.Mvc;
using Musician.Business.Abstract;
using Musician.Entity.Concrete;
using Musician.MVC.Models.ViewModels;

namespace Musician.MVC.Areas.Admin.ViewComponents
{
    public class EnstrumentsViewComponent : ViewComponent
    {
        private IEnstrumentService _enstrumentService;
        public EnstrumentsViewComponent(IEnstrumentService enstrumentService)
        {
            _enstrumentService = enstrumentService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Enstrument> enstruments = await _enstrumentService.GetAllAsync();
            List<EnstrumentViewModel> enstrumentViewModel = new List<EnstrumentViewModel>();
            foreach (var enstrument in enstruments)
            {
                enstrumentViewModel.Add(new EnstrumentViewModel
                {
                    Id = enstrument.Id,
                    Name = enstrument.Name,
                    Url = enstrument.Url,
                    IsApproved = enstrument.IsApproved,
                    NormalizedEnstrumentName=enstrument.NormalizedEnstrumentName,
                });
            }
            
            return View(enstrumentViewModel);
        }

    }
}
