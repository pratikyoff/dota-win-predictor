using Host.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Host.Controllers
{
    [Route("api/predict")]
    public class WinPredictorController : Controller
    {
        [HttpPost]
        public Guid GenerateStatusIdOfRequest([FromBody]PredictionRequest predictionRequest)
        {
            return Guid.NewGuid();
        }

        [HttpGet("result/{reqId}")]
        public AlgoOutput GetResponseStatusFromRequestId([FromRoute]string reqId)
        {
            return new AlgoOutput();
        }
    }
}
