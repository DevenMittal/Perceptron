﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    internal class Perceptron
    {
        double[] weights;
        double bias;
        double mutationAmount;
        Random random;
        Func<double, double, double> errorFunc;

        public Perceptron(double[] initialWeightValues, double initialBiasValue, double mutationAmount, Random random, Func<double, double, double> errorFunc)
        {
            weights = initialWeightValues;
            bias = initialBiasValue;
            this.mutationAmount = mutationAmount;
            this.random = random;   
        }

        public Perceptron(int amountOfInputs, double mutationAmount, Random random, Func<double, double, double> errorFunc)
        {
            weights = new double[amountOfInputs];
            this.mutationAmount = mutationAmount;
            this.random = random;
            /*Initializes the weights array given the amount of inputs*/
        }

        public void Randomize(Random random, double min, double max)
        {
            Random rand = new Random();

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = rand.NextDouble() * (max - min) + min;
            }
            bias = rand.NextDouble() * (max - min) + min;
            /*Randomly generates values for every weight including the bias*/
        }

        public double Compute(double[] inputs)
        {
            double sum = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }
            return sum + bias;
            /*computes the output with given input*/
        }

        public double[] Compute(double[][] inputs)
        {
            double[] sums = new double[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
            {
                sums[i] = Compute(inputs[i]);
            }
            return sums;
            /*computes the output for each row of inputs*/
        }

        public double GetError(double[][] inputs, double[] desiredOutputs)
        {
            double sum = 0;
            double[] results = Compute(inputs);
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += Math.Pow((desiredOutputs[i] - results[i]), 2);
            }
            return sum / inputs.Length;
            /*computes the output using the inputs returns the average error between each output row and each desired output row using errorFunc*/
        }
    
        public double TrainWithHillClimbing(double[][] inputs, double[] desiredOutputs, double currentError)
        {
            currentError = GetError(inputs, desiredOutputs);
            MutateSomething(weights);
            double newError = GetError(inputs, desiredOutputs);
            if (newError < currentError)
            {
                currentError = newError;
                //right here you need to continue from step 4 on the wiki
            }

            /*attempts one hill climbing training iteration and returns the new current error*/
        }
        public double[] MutateSomething(double[] weights)
        {
            int r = random.Next(0, 2);

            if (r == 0) weights[random.Next(0, weights.Length + 1)] += random.Next(1, 3);
            else weights[random.Next(0, weights.Length + 1)] -= random.Next(1, 3);

            return weights;
        }

    }
}
