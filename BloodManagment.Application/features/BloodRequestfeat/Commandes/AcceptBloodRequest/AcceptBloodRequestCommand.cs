namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.AcceptBloodRequest
{
    using MediatR;

    public class AcceptBloodRequestCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public AcceptBloodRequestCommand(int id)
        {
            Id = id;
        }
    }
}
