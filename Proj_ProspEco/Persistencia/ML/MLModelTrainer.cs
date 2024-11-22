using Microsoft.ML;
using System;
using System.IO;
using Proj_ProspEco.Models;

namespace Proj_ProspEco.Persistencia.ML
{
    public class UsuarioPrediction
    {
        public string Nome { get; set; }
        public string PredictedEmail { get; set; }
    }

    public class MLModelTrainer
    {
        public void TreinarModelo()
        {
            MLContext mlContext = new MLContext();

            // Caminho para o arquivo CSV com dados dos usuários
            string dataPath = "Data/dados_modelo.csv";

            // Verifica se o arquivo CSV existe
            if (!File.Exists(dataPath))
            {
                throw new FileNotFoundException($"Arquivo CSV não encontrado: {dataPath}");
            }

            // Carrega os dados do CSV
            IDataView dataView = mlContext.Data.LoadFromTextFile<Usuario>(
                dataPath,
                hasHeader: true,
                separatorChar: ',');

            // Pipeline para treinar o modelo
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "Nome") // Convertendo o Nome para chave
                .Append(mlContext.Transforms.Text.FeaturizeText("Nome", "NomeTextFeatures")) // Transformando texto de "Nome" em características
                .Append(mlContext.Transforms.Concatenate("Features", "NomeTextFeatures")) // Concatenando as features
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Label", featureColumnName: "Features")); // Usando o SDCA para regressão

            // Treina o modelo
            var model = pipeline.Fit(dataView);

            // Caminho para salvar o modelo treinado
            string modelPath = "Data/ModeloUsuario.zip";

            // Verifica se o diretório de destino existe, caso contrário, cria
            var directoryPath = Path.GetDirectoryName(modelPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Salva o modelo treinado
            mlContext.Model.Save(model, dataView.Schema, modelPath);

            Console.WriteLine($"Modelo treinado e salvo em: {modelPath}");
        }
    }
}
