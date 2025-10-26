using AutoMapper;
using Cross.Abstractions;
using Cross.Exceptions;
using System.Runtime.CompilerServices;

namespace Cross.Logic
{
    /// <summary>
    /// Logica base de gestor de entidades
    /// </summary>
    public class BaseEntityManager
    {
        #region Properties
        protected readonly IMapper Mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"><see cref="IMapper"/></param>
        public BaseEntityManager(IMapper mapper)
        {
            Mapper = mapper;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Valida una <typeparamref name="TEntity"/>
        /// en base su implementacion de <typeparamref name="TValidatableEntity"/>
        /// </summary>
        /// <typeparam name="TValidatableEntity">
        ///     <see cref="IValidatable"/>
        /// </typeparam>
        /// <param name="entity">Entidad a mapear</param>
        /// <param name="method">
        ///     <inheritdoc cref="Validate(IValidatable, string)"
        ///                 path="/param[@name='method']"/>
        /// </param>
        protected void Validate<TEntity, TValidatableEntity>(TEntity entity, [CallerMemberName] string method = null)
            where TValidatableEntity : class, IValidatable
        {
            try
            {
                this.Validate(this.Mapper.Map<TEntity, TValidatableEntity>(entity), method);
            }
            catch(ValidationException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new MappingException<TEntity, TValidatableEntity>(ex);
            }
        }

        /// <summary>
        /// Valida una <inheritdoc cref="IValidatable" path="/summary"/>
        /// </summary>
        /// <param name="entity"><inheritdoc cref="IValidatable" path="/summary"/></param>
        /// <param name="callerMemberName">Nombre de metodo en el que se valida la entidad</param>
        /// <exception cref="ValidationException"></exception>
        protected void Validate(IValidatable entity, [CallerMemberName] string callerMemberName = null)
        {
            if(entity == null)
                throw new ValidationException(callerMemberName,
                    new ArgumentNullException(nameof(entity)));

            var result = entity.Validate();

            if (!result.IsValid)
                throw new ValidationException(callerMemberName,
                    string.Join("|", result.Errors));
        }
        #endregion
    }
}
