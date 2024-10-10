using AutoMapper;
using WKTechnology.Domain.Entities;
using WKTechnology.Shared.DTOs;

namespace WKTechnology.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>()
            .ForMember(dest => dest.CategoriaNome, opt => opt.MapFrom(src => src.Categoria.Nome));
        CreateMap<ProdutoDTO, Produto>();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
    }
}