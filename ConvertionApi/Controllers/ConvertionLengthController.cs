using ConvertionDAL;
using ConvertionDAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace ConvertionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertionLengthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConvertionLengthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public string GetConvert(ConvertionInput convertionInput)
        {
            try
            {
                DLConvertionConfig config = new DLConvertionConfig(_configuration);
                var convertionConfigDB = config.GetConvertionConfig(ConvertionType.Length, convertionInput);
                if (convertionConfigDB != null)
                {
                    decimal converted = convertionConfigDB.ToValue * convertionInput.FromValue;
                    string responseMessage = "Convertion from " + convertionInput.FromValue + " " + convertionInput.FromUnit + " to " + convertionInput.ToUnit + " is " + converted;
                    return responseMessage;
                }
                else
                {
                    return "Configuration not found for convertion";
                }
            }
            catch(Exception e)
            {
                return "Error occured while executing Get";
            }
        }
    }
}
