using AutoMapper;
using Business.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaseController : BaseController
    {
        #region Fields
        private readonly ICaseBusiness _caselogic;
        #endregion

        #region Properties
        protected override string Flow => "Case";
        #endregion

        public CaseController(
            IMapper mapper,
            ILogger<CaseController> logger,
            ICaseBusiness caseLogic) : base(mapper, logger)
        {
            _caselogic = caseLogic;
        }

        [HttpGet("GetState")]
        public async Task<ActionResult<bool>> GetState()
        {
            return await ExecuteAsync(_caselogic.GetStateAsync);
        }

        [HttpGet("TurnOn")]
        public async Task<ActionResult<bool>> TurnOn()
        {
            return await ExecuteAsync(_caselogic.TurnOnAsync);
        }

        [HttpGet("TurnOff")]
        public async Task<ActionResult<bool>> TurnOff()
        {
            return await ExecuteAsync(_caselogic.TurnOffAsync);
        }

        [HttpGet("Screen/GetState")]
        public async Task<ActionResult<bool>> GetStateScreen()
        {
            return await ExecuteAsync(_caselogic.GetStateScreenAsync);
        }

        [HttpGet("Screen/TurnOn")]
        public async Task<ActionResult<bool>> TurnOnScreen()
        {
            return await ExecuteAsync(_caselogic.TurnOnScreenAsync);
        }

        [HttpGet("Screen/TurnOff")]
        public async Task<ActionResult<bool>> TurnOffScreen()
        {
            return await ExecuteAsync(_caselogic.TurnOffScreenAsync);
        }

        [HttpGet("Lights/GetState")]
        public async Task<ActionResult<bool>> GetStateLights()
        {
            return await ExecuteAsync(_caselogic.GetStateLightsAsync);
        }

        [HttpGet("Lights/TurnOn")]
        public async Task<ActionResult<bool>> TurnOnLights()
        {
            return await ExecuteAsync(_caselogic.TurnOnLightsAsync);
        }

        [HttpGet("Lights/TurnOff")]
        public async Task<ActionResult<bool>> TurnOffLights()
        {
            return await ExecuteAsync(_caselogic.TurnOffLightsAsync);
        }

        [HttpGet("Fans/GetState")]
        public async Task<ActionResult<bool>> GetStateFans()
        {
            return await ExecuteAsync(_caselogic.GetStateFansAsync);
        }

        [HttpGet("Fans/TurnOn")]
        public async Task<ActionResult<bool>> TurnOnFans()
        {
            return await ExecuteAsync(_caselogic.TurnOnFansAsync);
        }

        [HttpGet("Fans/TurnOff")]
        public async Task<ActionResult<bool>> TurnOffFans()
        {
            return await ExecuteAsync(_caselogic.TurnOffFansAsync);
        }
    }
}