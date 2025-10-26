using Cross.Tests.Abstractions;

namespace Cross.Tests.Mocks
{
    public static class SetupErrorExtensions
    {
        public static void SetupError<TInput>(this ISetupError<TInput> setup)
        {
            setup.SetupError(new Exception());
        }

        public static void SetupError(this ISetupError setup)
        {
            setup.SetupError(new Exception());
        }
        public static void SetupError<TInput>(this ISetupError<TInput> setup, Exception ex)
        {
            setup.SetupError(c => true, ex);
        }

        public static void SetupError(this ISetupError setup, Exception ex)
        {
            setup.SetupError(() => true, ex);
        }
    }
}
