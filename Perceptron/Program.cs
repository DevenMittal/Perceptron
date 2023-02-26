namespace Perceptron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] weights = { .5, .5 };
            Random rand = new Random();
            Func<double, double, double> errorFunc  = (x, y) =>  Math.Pow(x - y, 2);

            Perceptron perceptron = new Perceptron(weights, .5, .05, rand, errorFunc);

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
                0,
                0,
            };
            for (int i = 0; i < 1000; i++)
            {
                perceptron.TrainWithHillClimbing(trainInputs, outputs);
            }


            double[][] inputs =
            {
                new double[] {0, 0},
                new double[] {1, 0},
            };
            double[] values = perceptron.Compute(inputs);

            ;

        }
    }
}