using Cross.Entities;
using System.Reflection;

namespace Resources.Entities
{
    public class MappingProfile : MappingBaseProfile
    {
        public MappingProfile()
            : base(Assembly.GetExecutingAssembly())
        { }
    }

    public static class ResourcesAssembly
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
