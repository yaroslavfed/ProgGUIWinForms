using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly List<DataFile> _dataFiles;
    private int _currentDataFileIndex = -1;
    private readonly BindingSource _sourceDataFile = new();

    public List<List<Data>> GraphicsPoints { get; }

    public Form1()
    {
        GraphicsPoints = new List<List<Data>>();
        _dataFiles = new List<DataFile>();

        InitializeComponent();

        comboBox1.Items.AddRange(
            Enumerable.Range(0, _clientEvents.Count)
                .Select(i => (object)_clientEvents
                    .ElementAtOrDefault(i).Key)
                .ToArray());
        comboBox1.SelectedIndex = 0;

        dataGridView2.Show();
        dataGridView2.DataSource = _sourceDataFile;

        InitializeFsm();
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        if (GraphicsPoints.Count > 0)
        {
            Data data = new Data { X = 0, Y = 0 };
            _dataFiles[_currentDataFileIndex].Data.Add(data);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GraphicsPoints[_currentDataFileIndex];
    
        }
        else
            MessageBox.Show("Не выбран ни один файл!");
    }

    private void DrawGraphics(SeriesChartType chartType)
    {
        chart1.DataSource = null;
        chart1.Series.Clear();
        chart1.Legends.Clear();
        chart1.Legends.Add(new Legend());
        for (var i = 0; i < GraphicsPoints.Count; i++)
        {
            chart1.Series.Add(string.Format("graphic {0}", i + 1));
            foreach (var point in GraphicsPoints[i])
                chart1.Series[i].Points.AddXY(point.X, point.Y);

            chart1.Series[i].ChartType = chartType;
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        _targetState = _clientEvents.FirstOrDefault(x => x.Key == comboBox1.SelectedItem.ToString()).Value
            .contextState;
        _fsm?.Fire(EEvent.ChangeDrawSprite);

#if AutoBinding
        _fsm?.Fire(EEvent.DrawEvent);
#endif
    }

    private void button3_Click(object sender, EventArgs e)
    {
        _fsm?.Fire(EEvent.DrawEvent);
    }

    private void dataGridView1_CellEndEdit(object sender, EventArgs e)
    {
#if AutoBinding
        _fsm?.Fire(EEvent.DrawEvent);
#endif
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        if (_currentDataFileIndex == -1)
        {
            MessageBox.Show("Не выбран файл!");
            return;
        }

        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;

        WriteCsvFile(saveFileDialog1.FileName);
    }



    private void WriteCsvFile(string fileName)
    {
        using (var sw = new StreamWriter(fileName))
        {
            foreach (var data in GraphicsPoints[_currentDataFileIndex])
                sw.WriteLine(((Data)data).ToCsv());
        }
    }

    private void UploadButton_Click(object sender, EventArgs e)
    {     
        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;

        if (_dataFiles.Select(x => x.FileName).Contains(openFileDialog1.FileName))
        {
            MessageBox.Show("Данный файл уже был загружен!");
            return;
        }
        var dataFile = DataFile.CsvFileToDataFile(openFileDialog1.FileName);

        _dataFiles.Add(dataFile);

        GraphicsPoints.Add(dataFile.Data);

        _sourceDataFile.Add(dataFile);
        _currentDataFileIndex = GraphicsPoints.Count - 1;
        dataGridView1.DataSource = GraphicsPoints[_currentDataFileIndex];

    }

    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _currentDataFileIndex = dataGridView2.CurrentCell.RowIndex;
        dataGridView1.DataSource = GraphicsPoints[_currentDataFileIndex];
    }
}