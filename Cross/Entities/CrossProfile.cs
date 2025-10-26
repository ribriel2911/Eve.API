using System.Reflection;

namespace Cross.Entities
{
    public class CrossProfile : MappingBaseProfile
    {
        public CrossProfile() 
            : base(Assembly.GetExecutingAssembly())
        { }

    }

    public static class CrossAssembly
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
