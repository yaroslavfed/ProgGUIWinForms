using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Appccelerate.StateMachine;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;

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
            // Вызов действий от стейт машины
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            WriteCsvFile(saveFileDialog1.FileName);
        }

        void WriteCsvFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
                foreach (var data in Data)
                    sw.WriteLine(((Data)data).ToCsv());
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            Data.Clear();

            foreach (var item in CsvFileToDataList(openFileDialog1.FileName))
                Data.Add(item);

        }

        List<Data> CsvFileToDataList(string fileName)
        {
            var dataList = new List<Data>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    dataList.Add(new Data(line));
                }
            }
            return dataList;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}