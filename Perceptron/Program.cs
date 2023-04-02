namespace Perceptron
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[] weights = { .5, .5 };
            Random rand = new Random();



            Func<double, double> function = (input) => 1/(1+Math.Pow(Math.E, -input));
            Func<double, double> derivative = (input) => function(input)*(1-function(input));
            Func<double, double, double> errorFunc  = (x, y) =>  Math.Pow(x - y, 2);
            Func<double, double, double> errorFunctionDerivative = (input, desired) => 2 * input - 2 * desired;

            ActivationFunction activationFunction = new ActivationFunction(function, derivative);
            ErrorFunction errorFunction = new ErrorFunction(errorFunc, errorFunctionDerivative);

            Perceptron perceptron = new Perceptron(activationFunction, weights, .5, .05, rand, errorFunction);

            double[][] trainInputs =
            {
                new double[] {1, 1},
                new double[] {0, 0},
                new double[] {1, 0},
                new double[] {0, 1},

            };
            double[] outputs =
            {
                1,
                0,
                1,
                1,
            };
            for (int i = 0; i < 1000; i++)
            {
                perceptron.TrainWithHillClimbingGate(trainInputs, outputs);
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