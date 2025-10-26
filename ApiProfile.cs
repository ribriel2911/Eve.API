using Cross.Entities;
using System.Reflection;

namespace Business.Entities
{
    public class ApiProfile : MappingBaseProfile
    {
        public ApiProfile()
            : base(Assembly.GetExecutingAssembly())
        { }
    }

    public static class ApiAssembly
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
