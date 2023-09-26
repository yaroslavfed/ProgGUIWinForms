using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly List<DataFile> _dataFiles;
    private int _currentDataFileIndex;
    private readonly BindingSource _sourceDataFile = new();

    public List<List<Data>> Points { get; }

    public Form1()
    {
        Points = new List<List<Data>>();
        _dataFiles = new List<DataFile>();

        InitializeComponent();
        
        comboBox1.Items.AddRange(
            Enumerable.Range(0, _clientEvents.Count)
                .Select(i => (object)_clientEvents
                    .ElementAtOrDefault(i).Key)
                .ToArray());
        comboBox1.SelectedIndex = 0;
        
        dataGridView1.DataSource = Points;
        dataGridView2.Show();
        dataGridView2.DataSource = _sourceDataFile;
        
        InitializeFsm();
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        Points[_currentDataFileIndex].Add(new Data { X = 0, Y = 0 });
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = Points[_currentDataFileIndex];
    }

    private void DrawGraphics(SeriesChartType chartType)
    {
        chart1.DataSource = null;
        chart1.Series.Clear();
        chart1.Legends.Clear();
        chart1.Legends.Add(new Legend());
        for (var i = 0; i < Points.Count; i++)
        {
            chart1.Series.Add(string.Format("graphic {0}", i + 1));
            foreach (var point in Points[i])
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
        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;

        WriteCsvFile(saveFileDialog1.FileName);
    }

    private void WriteCsvFile(string fileName)
    {
        using (var sw = new StreamWriter(fileName))
        {
            foreach (var data in Points[_currentDataFileIndex])
                sw.WriteLine(((Data)data).ToCsv());
        }
    }

    private void UploadButton_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;


        var dataFile = DataFile.CsvFileToDataFile(openFileDialog1.FileName);

        _dataFiles.Add(dataFile);

        Points.Add(dataFile.Data);

        _sourceDataFile.Add(dataFile);
        _currentDataFileIndex = Points.Count - 1;
        dataGridView1.DataSource = Points[_currentDataFileIndex];
    }

    private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        _currentDataFileIndex = dataGridView2.CurrentCell.RowIndex;
        dataGridView1.DataSource = Points[_currentDataFileIndex];
    }
}