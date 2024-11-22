using Proj_ProspEco.Persistencia.ML;

namespace Proj_ProspEco.Services
{
    public class MLService
    {
        private readonly MLModelTrainer _modelTrainer;

        public MLService()
        {
            _modelTrainer = new MLModelTrainer();
        }

        public void TreinarModelo()
        {
            _modelTrainer.TreinarModelo();
        }
    }
}
