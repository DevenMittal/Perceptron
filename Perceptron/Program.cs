namespace Perceptron
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[] weights = { 0.25, 0.25 };
            Random rand = new Random();
            double LearningRate = .001;


            Func<double, double> function = (input) => 1/(1+Math.Pow(Math.E, -input));
            Func<double, double> derivative = (input) => function(input)*(1-function(input));
            Func<double, double> functionTan = (input) => Math.Tanh(input); 
            Func<double, double> derivativeTan = (input) => 1- Math.Pow(Math.Tanh(input),2);

            Func<double, double, double> errorFunc  = (output, desired) =>  Math.Pow(desired - output, 2);
            Func<double, double, double> errorFunctionDerivative = (input, desired) => -2 * (desired - input);
            Func<double, double, double> errorFuncAbs = (x, y) => Math.Abs(y-x);
            Func<double, double, double> errorFunctionDerivativeAbs = (input, desired) => input - desired >= 0 ? -1 : 1;


            ActivationFunction activationFunction = new ActivationFunction(functionTan, derivativeTan);
            ErrorFunction errorFunction = new ErrorFunction(errorFunc, errorFunctionDerivative);

            Perceptron perceptron = new Perceptron(LearningRate, activationFunction, weights, .5, .05, rand, errorFunction);

            double[][] trainInputs =
            {
                new double[] {1, 0},
                new double[] {0, 0},
                new double[] {1, 0},
                new double[] {1, 1},

            };
            double[] outputs =
            {
                1,
                0,
                1,
                0,
            };
            for (int i = 0; i < 5; i++)
            {
                perceptron.TrainGradientBatch(trainInputs, outputs);
            }


            double[][] inputs =
            {
                new double[] {0, 0},
                new double[] {1, 0},
                new double[] {0, 1},
                new double[] {1, 1}
            };
            double[] values = perceptron.Compute(inputs);
            ;
            
        }
    }
}