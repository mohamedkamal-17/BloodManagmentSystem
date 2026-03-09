using BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetCreateBloodRequestData
{
    public class CreateBloodRequestVM
    {
        public CreatBloodRequestCommand Command { get; set; } = new();

        public List<SelectListItem> Hospitals { get; set; } = new();

        public List<SelectListItem> Recipients { get; set; } = new();

        public List<SelectListItem> LabTechnicians { get; set; } = new();

        public List<SelectListItem> BloodGroups { get; set; } = new();
    }
}