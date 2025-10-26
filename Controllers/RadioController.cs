using API.Entities.Criterias;
using API.Entities.Inputs;
using AutoMapper;
using Business.Abstractions;
using Business.Abstractions.Entities.Views;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RadioController : BaseController
    {
        private readonly IPlayerBusiness _playerBusiness;

        protected override string Flow => "Radio";

        public RadioController(
            IMapper mapper,
            ILogger<RadioController> logger,
            IPlayerBusiness radioBusiness) : base(mapper, logger)
        {
            _playerBusiness = radioBusiness;
        }

        [HttpPost("Play")]
        public async Task<ActionResult<IMediaView>> Play([FromBody] PlayInput data)
        {
            return await this.ExecuteAsync<PlayCriteria, PlayInput, IMediaView>
                (_playerBusiness.PlayAsync, data);
        }

        [HttpPost("Next")]
        public async Task<ActionResult<IMediaView>> Next([FromBody] ChangeInput data)
        {
            return await this.ExecuteAsync<ChangeCriteria, ChangeInput, IMediaView>
                (_playerBusiness.NextAsync, data);
        }

        [HttpPost("Previous")]
        public async Task<ActionResult<IMediaView>> Previous([FromBody] ChangeInput data)
        {
            return await this.ExecuteAsync<ChangeCriteria, ChangeInput, IMediaView>
                (_playerBusiness.PreviousAsync, data);
        }

        [HttpGet("Stop")]
        public async Task<ActionResult> Stop()
        {
            return await this.ExecuteAsync(_playerBusiness.StopAsync);
        }

        [HttpGet("Pause")]
        public async Task<ActionResult> Pause()
        {
            return await this.ExecuteAsync(_playerBusiness.PauseAsync);
        }

        [HttpGet("GetPlaying")]
        public async Task<ActionResult<IPlayerStateView>> GetPlaying()
        {
            return await this.ExecuteAsync(_playerBusiness.GetPlaying);
        }

        [HttpPost("SetVolume")]
        public async Task<ActionResult> SetVolume([FromBody] VolumeInput data)
        {
            return await this.ExecuteAsync<VolumeCriteria, VolumeInput>
                (_playerBusiness.SetVolumeAsync, data);
        }
    }
}