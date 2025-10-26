using AutoMapper;
using Cross.Abstractions;
using Cross.Exceptions;
using Cross.Logic;
using System.Runtime.CompilerServices;

namespace Business
{
    /// <summary>
    /// Logica base de la capa de negocio
    /// </summary>
    public class BaseBusiness : BaseEntityManager
    {
        #region Fields
        private const string _errorBusiness = "@ERROR_BUSINESS";
        #endregion

        #region Constructors
        /// <summary>
        /// <inheritdoc cref="BaseEntityManager(IMapper)" path="/summary"/>
        /// </summary>
        /// <param name="mapper">
        ///     <inheritdoc cref="BaseEntityManager(IMapper)"
        ///                 path="/param[@name='mapper']"/>
        /// </param>
        public BaseBusiness(IMapper mapper) : base(mapper) { }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Ejecucion controlada de un metodo realizando las validaciones de criterio
        /// </summary>
        /// <typeparam name="ToMapCriteria"><inheritdoc cref="IValidatable" path="/summary"/></typeparam>
        /// <param name="func">Metodo a ejecutar</param>
        /// <param name="criteria">Criterio para la ejecucion</param>
        /// <param name="method">Nombre de metodo</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        protected async Task TryAsync<ToMapCriteria, TCriteria>(
            Func<TCriteria, Task> func, TCriteria criteria, [CallerMemberName] string method = null)
            where ToMapCriteria : IValidatable
        {
            try
            {
                var mappedCriteria = Mapper.Map<ToMapCriteria>(criteria);

                Validate(mappedCriteria);

                await func(criteria);
            }
            catch (BusinessException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (ValidationException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException(method, _errorBusiness, ex);
            }
        }

        /// <summary>
        /// Ejecucion controlada de un metodo con respuesta
        /// realizando las validaciones de criterio
        /// </summary>
        /// <typeparam name="ToMapCriteria"><inheritdoc cref="IValidatable" path="/summary"/></typeparam>
        /// <typeparam name="TCriteria"><inheritdoc cref="IBaseCriteria" path="/summary"/></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">Metodo a ejecutar</param>
        /// <param name="criteria">Criterio para la ejecucion</param>
        /// <param name="method">Nombre de metodo</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        protected async Task<TResult> TryAsync<ToMapCriteria, TCriteria, TResult>(
            Func<TCriteria, Task<TResult>> func, TCriteria criteria, [CallerMemberName] string method = null)
            where ToMapCriteria : IValidatable
        {
            try
            {
                var mappedCriteria = Mapper.Map<ToMapCriteria>(criteria);

                Validate(mappedCriteria);

                return await func(criteria);
            }
            catch (BusinessException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (ValidationException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException(method, _errorBusiness, ex);
            }
        }

        /// <summary>
        /// Ejecucion controlada de un metodo asincrono con respuesta
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">Metodo a ejecutar</param>
        /// <param name="method">Nombre de metodo</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        protected async Task<TResult> TryAsync<TResult>(Func<Task<TResult>> func, [CallerMemberName] string method = null)
        {
            try
            {
                return await func();
            }
            catch (BusinessException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (ValidationException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException(method, _errorBusiness, ex);
            }
        }

        /// <summary>
        /// Ejecucion controlada de un metodo con respuesta
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">Metodo a ejecutar</param>
        /// <param name="method">Nombre de metodo</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        protected TResult Try<TResult>(Func<TResult> func, [CallerMemberName] string method = null)
        {
            try
            {
                return func();
            }
            catch (BusinessException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (ValidationException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException(method, _errorBusiness, ex);
            }
        }

        /// <summary>
        /// Ejecucion controlada de un metodo asincrono sin respuesta
        /// </summary>
        /// <param name="func">Metodo a ejecutar</param>
        /// <param name="method">Nombre de metodo</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        protected async Task TryAsync(Func<Task> func, [CallerMemberName] string method = null)
        {
            try
            {
                await func();
            }
            catch (BusinessException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (ValidationException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException(method, _errorBusiness, ex);
            }
        }

        /// <summary>
        /// Ejecucion controlada de un metodo sin respuesta
        /// </summary>
        /// <param name="func">Metodo a ejecutar</param>
        /// <param name="method">Nombre de metodo</param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        protected void Try(Action act, [CallerMemberName] string method = null)
        {
            try
            {
                act();
            }
            catch (BusinessException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (ValidationException ex)
            {
                ex.Tracker.Prepend(method);

                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException(method, _errorBusiness, ex);
            }
        }
        #endregion
    }
}
