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

        public Form1(HydraulicSystemModel sharedModel)
        {
            InitializeComponent();
            model = sharedModel;
            InitializeTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeTimer(); // Запуск таймера при завантаженні форми
        }

        private void InitializeTimer()
        {
            timer = new Timer { Interval = 100 }; // 100 мс
            timer.Tick += (s, e) =>
            {
                double dt = timer.Interval / 1000.0;
                model.UpdateLevels(dt);
                Console.WriteLine($"Z1 = {model.z1:F3}");
            };
            timer.Start();
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
    }
}

