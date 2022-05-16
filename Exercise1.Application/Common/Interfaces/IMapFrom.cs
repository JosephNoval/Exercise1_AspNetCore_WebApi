using AutoMapper;

namespace Exercise1.Application.Common.Interfaces;
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
}
