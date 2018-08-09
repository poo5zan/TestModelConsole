using MachineLearningServices.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System;

namespace MachineLearningServices
{
    public class IrisDataService
    {
        public IrisPrediction PredictIris(IrisData irisData)
        {
            // Step 2: Create a pipeline and load your data
            var pipeline = new LearningPipeline();

            // If working in Visual Studio, make sure the
            // 'Copy to Output Directory' property of
            // iris-data.txt is set to 'Copy always'
            string dataPath = "iris-data.txt";
            pipeline.Add(new TextLoader(dataPath).CreateFrom<IrisData>(separator: ','));

            // Step 3: Transform your data
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training
            pipeline.Add(new Dictionarizer("Label"));

            // Step 4: Add learner
            // Add a learning algorithm to the pipeline
            // This is a classification scenario (what type of iris is this?)
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            // Convert the Label back into original text (after converting to number in step 3)
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() {
                PredictedLabelColumn = "PredictedLabel"
            });

            // Step 5: Train your model based on the data set
            var model = pipeline.Train<IrisData, IrisPrediction>();

            // Step 6: Use your model to make a prediction
            // You can change these numbers to test different predictions
            var prediction = model.Predict(irisData);
            return prediction;
        }
    }
}

