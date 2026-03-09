using BloodManagment.Application.Commane;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetCreateBloodRequestData
{
    public class CreateBloodRequestDataDto
    {
        public List<DropdownItemDto> Hospitals { get; set; }

        public List<DropdownItemDto> Recipients { get; set; }

        public List<DropdownItemDto> LabTechnicians { get; set; }

        public List<string> BloodGroups { get; set; }
    }
}
