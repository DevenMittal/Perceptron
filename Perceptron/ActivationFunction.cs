namespace Perceptron
{
        public class ActivationFunction
        {
            Func<double, double> function;
            Func<double, double> derivative;
            public ActivationFunction(Func<double, double> function, Func<double, double> derivative)
            {
                this.function = function;
                this.derivative = derivative;
            }

            public double Function(double input)
            {
                return function(input);
            }

            public double Derivative(double input)
            {
                return derivative(input);
            }
        }
        

        public class ErrorFunction
        {
            Func<double, double, double> function;
            Func<double, double, double> derivative;
            public ErrorFunction(Func<double, double, double> function, Func<double, double, double> derivative)
            {
                this.function = function;
                this.derivative = derivative;
            }

            public double Function(double output, double desiredOutput)
            { 
                 return function(output, desiredOutput);  
            }
            public double Derivative(double output, double desiredOutput)
            {
                return function(output, desiredOutput);
    
            }
        }
}