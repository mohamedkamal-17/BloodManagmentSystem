using MediatR;

namespace BloodManagment.Application.features.ThalassemiaPatientfeat.Queries.GetThalassemiaPatientByIdQuery
{


    public class GetThalassemiaPatientByIdQuery
        : IRequest<ThalassemiaPatientDto>
    {
        public int Id { get; set; }

        public GetThalassemiaPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
