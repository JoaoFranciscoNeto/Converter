namespace client.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Converter.Core;
    using Converter.Core.Model;
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

        [HttpGet("quantities")]
        public string[] GetQuantities() => Enum.GetValues<Quantity>().Select(Enum.GetName).ToArray();

        [HttpGet("units")]
        public UnitInfo[] GetUnits([Required] [FromQuery] string quantity) => UnitConverter.GetUnitsForQuantity(quantity);
    }
}