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
            //Okay so basically, I'm pretty sure the problem is that the error function
            //is not right for an and function. Just multiplying each number by a weight
            //will never allow the computer to distinguish between 1 and 0s, so it is just
            //choosing the mid point which in this case is just .25 and -.25 which would
            //be the 1:3 ratio of desired outputs of 1 and 0.
            ;

        }
    }
}