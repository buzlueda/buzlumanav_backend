using AutoMapper;
using BuzluManav.Core.Application.Features.Auth.Commands.Login;
using BuzluManav.Core.Application.Features.Auth.Commands.Register;
using BuzluManav.Core.Application.Features.Auth.Models;
using BuzluManav.Core.Domain.Entities;

namespace BuzluManav.Core.Application.Services.UserService.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, RegisterModel>().ReverseMap();
        CreateMap<User, RegisteredResponse>().ReverseMap();

        CreateMap<User, LoggedResponse>().ReverseMap();
    }
}