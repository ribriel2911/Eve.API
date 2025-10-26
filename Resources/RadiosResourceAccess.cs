using AutoMapper;
using Cross.Logic;
using Microsoft.EntityFrameworkCore;
using Resources.Abstractions;
using Resources.Abstractions.Entities.Parameters;
using Resources.Abstractions.Entities.Samples;
using Resources.DataContexts;
using Resources.Entities.DTOs;
using Resources.Entities.Parameters;
using Resources.Entities.Samples;

namespace Resources
{
    /// <inheritdoc cref="IRadiosResourceAccess"/>
    public class RadiosResourceAccess : BaseEntityManager, IRadiosResourceAccess
    {
        #region Fields
        private readonly RadiosDbContext _context;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"><inheritdoc cref="RadiosDbContext" path="/summary"/></param>
        public RadiosResourceAccess(
            IMapper mapper,
            RadiosDbContext context) : base(mapper)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        /// <inheritdoc cref="IMediaUrlsResourceAccess{ITMedia, TParam}.GetByParameterAsync(TParam)"/>
        public async Task<IRadioSample> GetByParameterAsync(IGetByRadioParameter param)
        {
            this.Validate<IGetByNameParameter, GetByNameParameter>(param);

            var media = await _context.Medias
                .Include(m => m.Radio).ThenInclude(r => r.Wave)
                .FirstAsync(m => (param.Frequency == null && m.Name == param.Name)
                              || (m.Radio.Frequency == param.Frequency && m.Radio.Wave.Name == param.Wave.ToString("g")));

            return this.Mapper.Map<RadioSample>(media);
        }

        /// <inheritdoc cref="IRadiosResourceAccess.GetRadiosAsync()"/>
        public async Task<IEnumerable<IRadioSample>> GetRadiosAsync()
        {
            var radios = _context.Radios
                .Include(r => r.Wave)
                .Include(r => r.Medias)
                .Where(r => r.Medias.Any(m => m.Status))
                .OrderBy(r => r.WaveId).ThenBy(r => r.Frequency);

            return await radios.Select(r => this.Mapper.Map<RadioSample>(r)).ToListAsync();
        }

        public async Task<IRadioSample> GetByParameterAsync(IGetByIdParameter param)
        {
            this.Validate<IGetByIdParameter, GetByIdParameter>(param);

            var media = await _context.Medias
                .Include(m => m.Radio).ThenInclude(r => r.Wave)
                .FirstOrDefaultAsync(m => m.Id == param.Id);

            return this.Mapper.Map<RadioSample>(media);
        }

        public async Task SetStatusAsync(ISetStatusParameter param)
        {
            this.Validate<ISetStatusParameter, SetStatusParameter>(param);

            var media = await _context.Medias
                .FirstOrDefaultAsync(m => m.Id == param.Id);

            media.Status = param.Status;

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
