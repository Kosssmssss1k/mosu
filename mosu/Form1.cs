using mosu.mosu.HydraulicSystem;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mosu
{
    public partial class Form1 : Form
    {
        private HydraulicSystemModel model;
        private Timer timer;

        private PIDController pid = new PIDController(10, 0.5, 1);
        private bool isAutoMode = false;

        private double optimizedKp;
        private double optimizedTi;
        private bool hasOptimizedValues = false;

        private NumericUpDown numKp;
        private NumericUpDown numKi;
        private NumericUpDown numKd;

        public Form1(HydraulicSystemModel sharedModel)
        {
            InitializeComponent();
            model = sharedModel;
            InitializeTimer();
            InitializeControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void InitializeTimer()
        {
            timer = new Timer { Interval = 100 }; // 100 мс
            timer.Tick += (s, e) =>
            {
                double dt = timer.Interval / 1000.0;

                if (isAutoMode)
                {
                    double setpoint = 1;
                    double error = setpoint - model.z1;
                    double control = pid.Update(error, dt);
                    double valveAdjustmentSpeed = 1;


                    model.x_in_1_0 += control * valveAdjustmentSpeed * dt;
                    model.x_in_1_0 = Clamp(model.x_in_1_0, 0, 1);

                    model.x_out_0 -= control * valveAdjustmentSpeed * dt;
                    model.x_out_0 = Clamp(model.x_out_0, 0, 1);
                }

                    model.UpdateLevels(dt);
                Console.WriteLine($"Z1 = {model.z1:F3}");
            };
            timer.Start();
        }

        private void InitializeControls()
        {
            // NumericUpDown для Kp
            numKp = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                DecimalPlaces = 2,
                Increment = 0.1M,
                Value = 1,
                Left = 10,
                Top = 40,
                Width = 80
            };
            numKp.ValueChanged += (s, e) => pid.Kp = (double)numKp.Value;
            Controls.Add(numKp);
            Controls.Add(new Label() { Text = "Kp", Left = 95, Top = 42, Width = 30 });

            // NumericUpDown для Ki
            numKi = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                DecimalPlaces = 3,
                Increment = 0.01M,
                Value = 0,
                Left = 130,
                Top = 40,
                Width = 80
            };
            numKi.ValueChanged += (s, e) => pid.Ki = (double)numKi.Value;
            Controls.Add(numKi);
            Controls.Add(new Label() { Text = "Ki", Left = 215, Top = 42, Width = 30 });

            // NumericUpDown для Kd
            numKd = new NumericUpDown()
            {
                Minimum = 0,
                Maximum = 100,
                DecimalPlaces = 3,
                Increment = 0.01M,
                Value = 0,
                Left = 250,
                Top = 40,
                Width = 80
            };
            numKd.ValueChanged += (s, e) => pid.Kd = (double)numKd.Value;
            Controls.Add(numKd);
            Controls.Add(new Label() { Text = "Kd", Left = 335, Top = 42, Width = 30 });
        }

        // Функція Clamp для обмеження значень (альтернатива Math.Clamp)
        private double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            else if (value > max) return max;
            else return value;
        }

        private void btnIncreaseOut_Click(object sender, EventArgs e)
        {
            model.IncreaseOutlet();
            LogValveState("Outlet", model.x_out_0);
        }

        private void btnDecreaseOut_Click(object sender, EventArgs e)
        {
            model.DecreaseOutlet();
            LogValveState("Outlet", model.x_out_0);
        }

        private void btnIncreaseIn1_Click(object sender, EventArgs e)
        {
            model.IncreaseIn1();
            LogValveState("Inlet 1", model.x_in_1_0);
        }

        private void btnDecreaseIn1_Click(object sender, EventArgs e)
        {
            model.DecreaseIn1();
            LogValveState("Inlet 1", model.x_in_1_0);
        }

        private void LogValveState(string label, double value)
        {
            Console.WriteLine($"{label} adjusted: {value:F5}");
            Console.WriteLine($"Z1 = {model.z1:F3}");
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            isAutoMode = !isAutoMode;
            if (isAutoMode)
            {
                btnMode.Text = "Переключити на Ручний";
                lblMode.Text = "Режим: Авто";
                pid.Reset(); // скидання інтегралу для уникнення насичення

                if (hasOptimizedValues)
                {
                    pid.Kp = optimizedKp;
                    pid.Ki = optimizedKp / optimizedTi;
                    pid.Kd = 0; // PI

                    numKp.Value = (decimal)optimizedKp;
                    numKi.Value = (decimal)(optimizedKp / optimizedTi);
                    numKd.Value = 0;
                }

            }
            else
            {
                btnMode.Text = "Переключити на Авто";
                lblMode.Text = "Режим: Ручний";
            }
        }

        private void btnGauss_Click(object sender, EventArgs e)
        {
            var optimizer = new GaussOptimizer((kp, ti) =>
            {
                var piSim = new mosu.HydraulicSystem.PIRegulatorOptimizer();
                var (ise, _) = piSim.Simulate(kp, ti);
                return ise;
            });

            (double bestKp, double bestTi, double bestISE, int iterations) = optimizer.Optimize(1.0, 70.0);


            optimizedKp = bestKp;
            optimizedTi = bestTi;
            hasOptimizedValues = true;

            MessageBox.Show($"[Gauss Optimizer Result]\nKp = {bestKp:F3}, Ti = {bestTi:F1}\nISE = {bestISE:F5}\nIterations = {iterations}", "Gauss Optimization");

        }

        private void btnPIoptimize_Click(object sender, EventArgs e)
        {
            var optimizer = new mosu.HydraulicSystem.PIRegulatorOptimizer();
            var (bestKp, bestTi, bestISE, bestDev) = optimizer.Optimize();

            optimizedKp = bestKp;
            optimizedTi = bestTi;
            hasOptimizedValues = true;

            MessageBox.Show($"Optimal Kp = {bestKp:F3}\nOptimal Ti = {bestTi:F1}\nISE = {bestISE:F5}\nMax Dev = {bestDev:F5}", "Optimization Result");
        }

   
    }
}

