namespace Resources.Abstractions.DbContexts
{
    /// <summary>
    /// Contexto base de la aplicacion
    /// </summary>
    public interface IBaseDbContext
    {
        /// <summary>
        /// Guarda los cambios del contexto
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
