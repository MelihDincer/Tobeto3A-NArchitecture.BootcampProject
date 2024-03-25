using Application.Features.BlackLists.Commands.Create;
using Application.Features.BlackLists.Commands.Delete;
using Application.Features.BlackLists.Commands.Update;
using Application.Features.BlackLists.Queries.GetById;
using Application.Features.BlackLists.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BlackLists.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BlackList, CreateBlackListCommand>().ReverseMap();
        CreateMap<BlackList, CreatedBlackListResponse>().ReverseMap();
        CreateMap<BlackList, UpdateBlackListCommand>().ReverseMap();
        CreateMap<BlackList, UpdatedBlackListResponse>().ReverseMap();
        CreateMap<BlackList, DeleteBlackListCommand>().ReverseMap();
        CreateMap<BlackList, DeletedBlackListResponse>().ReverseMap();
        CreateMap<BlackList, GetByIdBlackListResponse>().ReverseMap();
        CreateMap<BlackList, GetListBlackListListItemDto>().ReverseMap();
        CreateMap<IPaginate<BlackList>, GetListResponse<GetListBlackListListItemDto>>().ReverseMap();
    }
}