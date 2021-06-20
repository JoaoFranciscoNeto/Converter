namespace client.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using Converter.Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ConverterController : ControllerBase
    {
        [HttpGet]
        public double Get(
            [Required] [FromQuery] double value,
            [Required] [FromQuery] string source,
            [Required] [FromQuery] string target) =>
            UnitConverter.Convert(value, source, target, out var converted) ? converted : double.NaN;
    }
}