using AutoMapper;

namespace Cross.Abstractions
{
    public interface IMapFrom<TFrom>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TFrom), GetType());
    }

    public interface IMapTo<TTo>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(TTo));
    }
}
