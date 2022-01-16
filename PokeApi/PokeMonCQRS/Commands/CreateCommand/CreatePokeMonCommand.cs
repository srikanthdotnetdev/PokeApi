using MediatR;
using PokeApi.DDD;

namespace PokeApi.PokeMonCQRS.Commands
{
    public class CreatePokeMonCommand:IRequest<PokeMon>
    {
        public PokeMon PokeMonModel { get; }
        public CreatePokeMonCommand(PokeMon pokeMonModel)
        {
            PokeMonModel = pokeMonModel;
        }

         
      
    }
}
