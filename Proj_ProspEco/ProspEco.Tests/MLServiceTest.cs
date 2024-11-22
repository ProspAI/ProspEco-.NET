using Moq;
using Xunit;
using Proj_ProspEco.Services;
using Proj_ProspEco.Persistencia.ML;
using System.IO;

namespace Proj_ProspEco.Tests
{
    public class MLServiceTests
    {
        private readonly Mock<MLModelTrainer> _modelTrainerMock;
        private readonly MLService _mlService;

        public MLServiceTests()
        {
            _modelTrainerMock = new Mock<MLModelTrainer>();
            _mlService = new MLService();
        }

        [Fact]
        public void TreinarModelo_DeveInvocarTreinamento()
        {
            // Arrange
            _modelTrainerMock.Setup(m => m.TreinarModelo());

            // Act
            _mlService.TreinarModelo();

            // Assert
            _modelTrainerMock.Verify(m => m.TreinarModelo(), Times.Once);
        }

        [Fact]
        public void TreinarModelo_DeveLancarExcecaoParaArquivoInexistente()
        {
            // Arrange
            var modelTrainer = new MLModelTrainer();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => modelTrainer.TreinarModelo());
        }
    }
}
