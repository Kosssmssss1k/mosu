using System;

namespace mosu
{
    public class GaussSeidelOptimizer
    {
        private const double Epsilon = 1e-6;
        private const int MaxIterations = 1000;

        private double I(double u1, double u2)
        {
            return 1 - (u1 * u1 - u2 * u2) + u1 * u2 - 10 * u2 * u2;
        }

        public (double u1, double u2, int iterations) Minimize(double u1, double u2)
        {
            int iter = 0;
            const double learningRate = 0.01;

            while (iter < MaxIterations)
            {
                double prevU1 = u1;
                double prevU2 = u2;

                double gradU1 = -2 * u1 + u2;
                u1 -= learningRate * gradU1;

                double gradU2 = u1 - 18 * u2;
                u2 -= learningRate * gradU2;

                if (Math.Abs(u1 - prevU1) < Epsilon && Math.Abs(u2 - prevU2) < Epsilon)
                    break;

                iter++;
            }

            return (u1, u2, iter);
        }
    }
}
