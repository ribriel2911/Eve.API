using AutoMapper;
using Cross.Entities;

namespace Cross.Tests
{
    public static class MapperTest
    {
        private static IMapper? _mapper;

        public static IMapper GetMapper(Profile profile)
        {
            return GetMapper(new List<Profile> { profile });
        }

        public static IMapper GetMapper(IEnumerable<Profile> profiles = null)
        {
            if (_mapper is null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    if (profiles is not null)
                        foreach (Profile p in profiles)
                            mc.AddProfile(p);

                    mc.AddProfile(new CrossProfile());
                });

                _mapper = new Mapper(mappingConfig);
            }

            return _mapper;
        }
    }
}