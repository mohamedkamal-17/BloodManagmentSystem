using BloodManagment.Application.features.BloodInventoryfeat.Queries;

namespace BloodManagment.Mvc.ViewModels.BloodInvintory
{
    public class BloodInventoryViewModel
    {
        public List<BloodInentoriesDto> Inventories { get; set; } = new();
    }
}
