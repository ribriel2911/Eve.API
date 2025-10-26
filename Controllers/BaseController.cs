using AutoMapper;
using Cross.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        #region Properties
        protected abstract string Flow { get; }
        #endregion

        #region Fields
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        #endregion

        #region Constructors
        public BaseController(
            IMapper mapper,
            ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Methods
        protected async Task<ActionResult> ExecuteAsync<TCriteria, TInput>(Func<TCriteria, Task> func, TInput input)
        {
            try
            {
                var criteria = _mapper.Map<TCriteria>(input);

                return await ExecuteAsync<TCriteria>(func, criteria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.Flow} : ", ex.Message);

                return BadRequest();
            }
        }

        protected async Task<ActionResult> ExecuteAsync<TCriteria>(Func<TCriteria, Task> func, TCriteria criteria)
        {
            try
            {
                await func(criteria);

                return Ok();
            }
            catch (BusinessException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return NotFound();
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.Flow} : ", ex.Message);
                return NotFound();
            }
        }

        protected async Task<ActionResult<TResult>> ExecuteAsync<TCriteria, TInput, TResult>
            (Func<TCriteria, Task<TResult>> func, TInput input)
        {
            try
            {
                var criteria = _mapper.Map<TCriteria>(input);

                return await ExecuteAsync<TCriteria, TResult>(func, criteria);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.Flow} : ", ex.Message);

                return BadRequest();
            }
        }

        protected async Task<ActionResult<TResult>> ExecuteAsync<TCriteria, TResult>
            (Func<TCriteria, Task<TResult>> func, TCriteria criteria)
        {
            try
            {
                return Ok(await func(criteria));
            }
            catch (BusinessException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return NotFound();
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.Flow} : ", ex.Message);
                return NotFound();
            }
        }

        protected async Task<ActionResult<TResult>> ExecuteAsync<TResult> (Func<Task<TResult>> func)
        {
            try
            {
                return Ok(await func());
            }
            catch (BusinessException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return NotFound();
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.Flow} : ", ex.Message);
                return NotFound();
            }
        }

        protected async Task<ActionResult> ExecuteAsync(Func<Task> func)
        {
            try
            {
                await func();

                return Ok();
            }
            catch (BusinessException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return NotFound();
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"{this.Flow + " => "} " +
                    $"{string.Join(" => ", ex.Tracker)} : {ex.DescriptionError}");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.Flow} : ", ex.Message);
                return NotFound();
            }
        }
        #endregion
    }
}
