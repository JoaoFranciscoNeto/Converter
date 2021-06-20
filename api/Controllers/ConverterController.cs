namespace api.Controllers
{
    using Converter.Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ConverterController : ControllerBase
    {
        [HttpGet]
        public double Get([FromQuery] double value, [FromQuery] string source, [FromQuery] string target) =>
            UnitConverter.Convert(value, source, target, out var converted) ? converted : double.NaN;
    }
}