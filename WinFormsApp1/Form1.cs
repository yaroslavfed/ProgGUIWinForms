using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Appccelerate.StateMachine;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private SimpleStateMachine? _fsm;
        private EState? _currentState;

        public BindingSource Data { get; set; }
        public Form1()
        {
            Data = new BindingSource();
            Data.Add(new Data() { X = 0, Y = 0 });
            Data.Add(new Data() { X = 1, Y = 1 });
            Data.Add(new Data() { X = 2, Y = 4 });
            InitializeComponent();
            dataGridView1.DataSource = Data;
        }
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

        private int _actionIndex;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _actionIndex = comboBox1.SelectedIndex;
            switch (_actionIndex)
            {
                case 0:
                    _currentState = EState.Line;
                    break;
                case 1:
                    _currentState = EState.Spline;
                    break;
                default:
                    _currentState = EState.Line;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // TODO: доделать вызов ивента на текущее состояние
        }
    }
    public class Data
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}