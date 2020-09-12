using AutoMapper;
using Brka.Bank.Contas.Domain;

namespace Brka.Bank.Contas.Repository.Transacoes.Profiles
{
    public class TransacoesProfile : Profile
    {
        public TransacoesProfile()
        {
            MapModelParaEntity();
            MapEntityParaModel();
        }

        private void MapModelParaEntity()
        {
            CreateMap<TransacaoModel, Domain.Transacao>()
                .ForMember(dest => dest.TipoTransacao, opt => opt.MapFrom(x => (TipoTransacao) x.TipoTransacao));
        }

        private void MapEntityParaModel()
        {
            CreateMap<Domain.Transacao, TransacaoModel>()
                .ForMember(dest => dest.TipoTransacao, opt => opt.MapFrom(x => (int) x.TipoTransacao));
        }
    }
}