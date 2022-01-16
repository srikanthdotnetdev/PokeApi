using MediatR;
using PokeApi.DDD;
using PokeApi.Repository;

namespace PokeApi.PokeMonCQRS.Commands
{
    public class DeletePokeMonHandler:IRequestHandler<DeletePokeMonCommand,string>
    {
        public  async Task<string> Handle(DeletePokeMonCommand request, CancellationToken cancellationToken)
        {
            using var repo = new RepositoryAccessService(new DbContext(false));
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
