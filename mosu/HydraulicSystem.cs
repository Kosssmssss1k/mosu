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
            public double alpha_out = alpha_in_1 * (Math.Pow(0.04, 2)*Math.Sqrt(p_in_1_0))/(Math.Pow(0.02, 2)* Math.Sqrt(z0 - p_out_0));

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
    }

}
