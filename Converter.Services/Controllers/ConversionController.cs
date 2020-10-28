using Converter.Common.Representation;
using Converter.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace Converter.Services.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        #region Members
        private readonly IConverterService _converterService;
        #endregion

        #region Constructors
        public ConversionController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        #endregion

        #region Public Methods
        [HttpPost()]
        public Result<ConversorCoin> ConvertCoin(ConversorCoin coin)
            => _converterService.ConvertCoin(coin);
        #endregion
    }
}
