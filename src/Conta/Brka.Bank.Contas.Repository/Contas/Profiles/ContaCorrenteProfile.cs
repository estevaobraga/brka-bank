using AutoMapper;
using Brka.Bank.Contas.Domain;

namespace Brka.Bank.Contas.Repository.Contas.Profiles
{
    public class ContaCorrenteProfile : Profile
    {
        public ContaCorrenteProfile()
        {
            MapModelParaEntity();
            MapEntityParaModel();
        }

        private void MapModelParaEntity()
        {
            CreateMap<ContaModel, ContaCorrente>();
        }

        private void MapEntityParaModel()
        {
            CreateMap<ContaCorrente, ContaModel>();
        }
    }
}