using Host.Models;
using Host.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/predict")]
    public class WinPredictorController : Controller
    {
        WinPredictorService winPredictorService;

        public WinPredictorController()
        {
            winPredictorService = new WinPredictorService();
        }

        [HttpPost]
        public double GetResult([FromBody]PredictionRequest predictionRequest)
        {
            return winPredictorService.GetResult(predictionRequest);
        }
    }
}
