using MediatR;
using PokeApi.DDD;
using PokeApi.Repository;

namespace PokeApi.PokeMonCQRS.Commands
{
    public class DeletePokeMonTranslatedHandler : IRequestHandler<DeletePokeMonTranslatedCommand,string>
    {
        public  async Task<string> Handle(DeletePokeMonTranslatedCommand request, CancellationToken cancellationToken)
        {
            using var repo = new RepositoryAccessService(new DbContext(true));
             if(repo.PokeMonRepository.DeleteAllPokeMons())
             {
                 return "Successfully Deleted the data";
             }
             else
             {
                return "ClearingLocalStore Failed";
             }

        }
    }
}
