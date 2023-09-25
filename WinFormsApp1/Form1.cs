using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Appccelerate.StateMachine;
using System.Reflection.Emit;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public BindingSource Data { get; set; }

        public Form1()
        {
            Data = new BindingSource();
            Data.Add(new Data() { X = 0, Y = 0 });
            Data.Add(new Data() { X = 1, Y = 1 });
            Data.Add(new Data() { X = 2, Y = 4 });
            InitializeFsm();
            InitializeComponent();
            dataGridView1.DataSource = Data;
            comboBox1.Items.AddRange(new object[]
            {
                defaultTextLabel,
                "Draw as lines",
                "Draw as spline"
            });
            comboBox1.SelectedIndex = 0;
        }

        private string defaultTextLabel = "Select draw sprite";

        private void AddButton_Click(object sender, EventArgs e)
        {
            Data.Add(new Data() { X = 4, Y = 16 });
        }

        private void DrawAsLines_Click(object sender, EventArgs e)
        {
            chart1.DataSource = null;
            chart1.Series[0].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.DataSource = Data;
        }

        private void DrawAsSpline_Click(object sender, EventArgs e)
        {
            chart1.DataSource = null;
            chart1.Series[0].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.DataSource = Data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _targetState = _clientTargetList[comboBox1.SelectedIndex];

            _fsm?.Fire(EEvent.ChangeDrawSprite);

#if AutoBinding
            _fsm?.Fire(EEvent.DrawEvent); 
#endif
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _fsm?.Fire(EEvent.DrawEvent);
        }

        private void dataGridView1_DataBindingComplete(object sender, EventArgs e)
        {
#if AutoBinding
            _fsm?.Fire(EEvent.DrawEvent); 
#endif
        }
    }
    public class Data
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}