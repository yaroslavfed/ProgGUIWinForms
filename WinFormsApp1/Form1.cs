using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Appccelerate.StateMachine;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private SimpleStateMachine? _fsm;
        private EState? _currentState;

        private List<DataFile> _dataFiles;
        private int _currentDataFileIndex;


        public List<List<Data>> Points { get; set; }
        BindingSource _sourceDataFile = new BindingSource();

        public Form1()
        {
            Points = new List<List<Data>>();
            _dataFiles = new List<DataFile>();

            BindingSource _bs = new BindingSource();

            InitializeFsm();
            InitializeComponent();
            dataGridView1.DataSource = Points;
            dataGridView2.Show();
            dataGridView2.DataSource = _sourceDataFile;

            comboBox1.Items.AddRange(
                Enumerable.Range(0, _clientEvents.Count)
                    .Select(i => (object)_clientEvents
                        .ElementAtOrDefault(i).Key)
                    .ToArray());
        }

// TODO: Убрать методы
        private void AddButton_Click(object sender, EventArgs e)
        {
        }

        private void DrawAsLines_Click(object sender, EventArgs e)
        {
            DrawGraphics(SeriesChartType.Line);
        }

        private void DrawAsSpline_Click(object sender, EventArgs e)
        {
            DrawGraphics(SeriesChartType.Spline);
        }


        private void DrawGraphics(SeriesChartType chartType)
        {
            chart1.DataSource = null;
            chart1.Series.Clear();
            chart1.Legends.Clear();
            chart1.Legends.Add(new Legend());
            for (int i = 0; i < Points.Count; i++)
            {               
                chart1.Series.Add(String.Format("graphic {0}", i + 1));
           //     chart1.Titles.Add(String.Format("graphic {0}", i + 1));
                foreach (var point in Points[i])                
                    chart1.Series[i].Points.AddXY(point.X,point.Y);
                
               
                chart1.Series[i].ChartType = chartType;
            }
            
        }

// TODO: Убрать переменную
        private int _actionIndex;

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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            WriteCsvFile(saveFileDialog1.FileName);
        }

        void WriteCsvFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
                foreach (var data in Points[_currentDataFileIndex])
                    sw.WriteLine(((Data)data).ToCsv());
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            DataFile dataFile = DataFile.CsvFileToDataFile(openFileDialog1.FileName);

            _dataFiles.Add(dataFile);                        

            Points.Add(dataFile.Data);

            _sourceDataFile.Add(dataFile);
            _currentDataFileIndex = Points.Count - 1;
            dataGridView1.DataSource = Points[_currentDataFileIndex];
        }

   

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _currentDataFileIndex = dataGridView2.CurrentCell.RowIndex;
            dataGridView1.DataSource = Points[_currentDataFileIndex];
        }
    }
}