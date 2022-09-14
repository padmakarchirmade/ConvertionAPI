using ConvertionDAL;
using ConvertionDAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace ConvertionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertionWeightController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConvertionWeightController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public string GetConvert(ConvertionInput convertionInput)
        {
            try
            {
                DLConvertionConfig config = new DLConvertionConfig(_configuration);
                var convertionConfigDB = config.GetConvertionConfig(ConvertionType.Weight, convertionInput);
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
