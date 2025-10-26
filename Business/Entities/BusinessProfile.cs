using Cross.Entities;
using System.Reflection;

namespace Business.Entities
{
    public class BusinessProfile : MappingBaseProfile
    {
        public BusinessProfile()
            : base(Assembly.GetExecutingAssembly())
        { }
    }

    public static class BusinessAssembly
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
