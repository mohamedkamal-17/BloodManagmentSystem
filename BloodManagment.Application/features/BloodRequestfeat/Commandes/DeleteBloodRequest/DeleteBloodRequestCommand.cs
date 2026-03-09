namespace BloodManagment.Application.features.BloodRequestfeat.Commandes.DeleteBloodRequest
{
    using MediatR;

    public class DeleteBloodRequestCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBloodRequestCommand(int id)
        {
            Id = id;
        }
    }
}
