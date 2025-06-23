using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mosu
{
    namespace mosu.HydraulicSystem
    {
        public class HydraulicSystemModel
        {
            public double z1 = 0.23;
            public static double z0 = 0.23;

            public static double alpha_in_1 = 0.03;
            public double alpha_out = alpha_in_1 * (Math.Pow(0.04, 2) * Math.Sqrt(p_in_1_0)) / (Math.Pow(0.02, 2) * Math.Sqrt(z0 - p_out_0));

            public static double p_in_1_0 = 2, p_out_0 = 0;

            public double x_in_1_0 = Math.PI * Math.Pow(0.04, 2) / 4;
            public double x_out_0 = Math.PI * Math.Pow(0.02, 2) / 4;

            public double F1 = Math.PI * Math.Pow(0.2, 2) / 4;

            public void IncreaseOutlet() => x_out_0 *= 1.5;
            public void DecreaseOutlet() => x_out_0 *= 0.5;

            public void IncreaseIn1() => x_in_1_0 *= 1.5;
            public void DecreaseIn1() => x_in_1_0 *= 0.5;

            public void UpdateLevels(double dt)
            {
                double Q_in1 = 0;
                if (p_in_1_0 > z1)
                    Q_in1 = alpha_in_1 * x_in_1_0 * Math.Sqrt(p_in_1_0 - z1);

                double Q_out = 0;
                if (z1 > p_out_0)
                    Q_out = alpha_out * x_out_0 * Math.Sqrt(z1 - p_out_0);

                z1 += dt * (Q_in1 - Q_out) / F1;

                if (z1 < 0) z1 = 0;
            }

        }

            public class PIRegulatorOptimizer
            {
                public double Kp { get; private set; } = 1.17;
                public double Ti { get; private set; } = 70.0;

                public List<double> Time = new List<double>();
                public List<double> Response = new List<double>();
                public List<double> Error = new List<double>();

                private const double dt = 0.01;
                private const double simTime = 10.0;

                private const double delay = 0.1;
                private readonly int delaySteps = (int)(delay / dt);

                private double CalculateISE(List<double> errors)
                {
                    return errors.Sum(e => e * e * dt);
                }

                private double CalculateMaxDeviation(List<double> errors)
                {
                    return errors.Max(e => Math.Abs(e));
                }

                public (double ISE, double MaxDev) Simulate(double kp, double ti)
                {
                    Queue<double> delayBuffer = new Queue<double>(Enumerable.Repeat(0.0, delaySteps));

                    double integral = 0;
                    double plant = 0;

                    Time.Clear();
                    Response.Clear();
                    Error.Clear();

                    for (double t = 0; t <= simTime; t += dt)
                    {
                        double setpoint = 1.0;
                        double error = setpoint - plant;
                        integral += error * dt;
                        double control = kp * (error + integral / ti);

                        delayBuffer.Enqueue(control);
                        double delayedInput = delayBuffer.Dequeue();

                        double dPlant = (-plant + 0.302 * delayedInput);
                        plant += dt * dPlant;

                        Time.Add(t);
                        Response.Add(plant);
                        Error.Add(error);
                    }

                    double ise = CalculateISE(Error);
                    double maxDev = CalculateMaxDeviation(Error);
                    return (ise, maxDev);
                }

                public (double Kp, double Ti, double BestISE, double BestDev) Optimize()
                {
                    var optimizer = new GaussOptimizer((kp, ti) =>
                    {
                        var result = Simulate(kp, ti);
                        return result.ISE;
                    });

                    (double bestKp, double bestTi, double bestISE, int _) = optimizer.Optimize(1.0, 70.0);

                    Kp = bestKp;
                    Ti = bestTi;
                    double bestDev = Simulate(bestKp, bestTi).MaxDev;

                    return (bestKp, bestTi, bestISE, bestDev);
                }
            }

        }
    }

