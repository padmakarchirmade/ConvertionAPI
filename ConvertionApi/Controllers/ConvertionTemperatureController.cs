using ConvertionDAL;
using ConvertionDAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace ConvertionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertionTemperatureController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConvertionTemperatureController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public string GetConvert(ConvertionInput convertionInput)
        {
            try
            {
                DLConvertionConfig config = new DLConvertionConfig(_configuration);
                
                decimal converted = 0;
                decimal Kelvin = 273.15M;
                decimal Fahrenheit = 32.0M;
                decimal ninebyfive = 9.0M / 5.0M;
                decimal fivebynine = 5.0M/9.0M ;
                switch (convertionInput.FromUnit)
                {
                    case ConvertionTemperatureUnit.Celsius:
                        switch (convertionInput.ToUnit)
                        {
                            case ConvertionTemperatureUnit.Fahrenheit:
                                converted = (convertionInput.FromValue * (ninebyfive)) + Fahrenheit;
                                break;
                            case ConvertionTemperatureUnit.Kelvin:
                                converted = convertionInput.FromValue + Kelvin;
                                break;
                        }
                        break;
                    case ConvertionTemperatureUnit.Fahrenheit:
                        switch (convertionInput.ToUnit)
                        {
                            case ConvertionTemperatureUnit.Celsius:
                                converted = (convertionInput.FromValue - Fahrenheit) * (fivebynine);
                                break;
                            case ConvertionTemperatureUnit.Kelvin:
                                converted = ((convertionInput.FromValue - Fahrenheit) * (fivebynine)) + Kelvin;
                                break;
                        }
                        break;
                    case ConvertionTemperatureUnit.Kelvin:
                        switch (convertionInput.ToUnit)
                        {
                            case ConvertionTemperatureUnit.Fahrenheit:
                                converted = ((convertionInput.FromValue - Kelvin) * (ninebyfive)) + Fahrenheit;
                                break;
                            case ConvertionTemperatureUnit.Celsius:
                                converted = convertionInput.FromValue - Kelvin;
                                break;
                        }
                        break;
                }

                string responseMessage = "Temparature Convertion from " + convertionInput.FromValue + " " + convertionInput.FromUnit + " to " + convertionInput.ToUnit + " is " + converted;
                return responseMessage;
            }
            catch (Exception e)
            {
                return "Error occured while executing Get";
            }
        }
    }
}
