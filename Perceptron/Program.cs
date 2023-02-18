namespace Perceptron
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] weights = { .75, -1.25 };
            Perceptron perceptron = new Perceptron(weights, .5);

            double[][] inputs =
            {
                new double[] {0, 0},
                new double[] {.3, -.7},
                new double[] {1, 1},
                new double[] {-1, -1},
                new double[] {-.5, .5}

            };

            double[] values = perceptron.Compute(inputs);

            ;





        }
    }
}