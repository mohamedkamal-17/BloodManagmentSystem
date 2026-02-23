using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByUserId
{
    public class GetThalassemiaPatientByUserIdQuery
      : IRequest<ThalassemiaPatientDto>
    {
        public string UserId { get; set; } = null!;
    }
}
