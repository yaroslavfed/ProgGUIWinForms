using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dataGridView1 = new DataGridView();
            addButton = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBox1 = new ComboBox();
            button3 = new Button();

            SaveButton = new Button();
            UploadButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            dataGridView2 = new DataGridView();

            WarningBlock = new Label();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(374, 50);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(280, 173);
            dataGridView1.TabIndex = 0;

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

            // 
            // addButton
            // 
            addButton.Location = new Point(566, 250);
            addButton.Margin = new Padding(4, 3, 4, 3);
            addButton.Name = "addButton";
            addButton.Size = new Size(88, 23);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(14, 18);
            chart1.Margin = new Padding(4, 3, 4, 3);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "X";
            series1.YValueMembers = "Y";
            chart1.Series.Add(series1);
            chart1.Size = new Size(350, 350);
            chart1.TabIndex = 2;
            chart1.Text = "chart1";
            // 
            // comboBox1
            // 
            comboBox1.Cursor = Cursors.Hand;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(374, 250);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(374, 279);
            button3.Name = "button3";
            button3.Size = new Size(134, 23);
            button3.TabIndex = 6;
            button3.Text = "Draw";
            button3.UseVisualStyleBackColor = true;
#if AutoBinding
            button3.Visible = false;
#else
            button3.Visible = true;
#endif
            button3.Click += button3_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(567, 389);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(87, 23);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // UploadButton
            // 
            UploadButton.Location = new Point(568, 423);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(87, 23);
            UploadButton.TabIndex = 8;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "(*.csv)|*.csv";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(679, 50);
            dataGridView2.Margin = new Padding(4, 3, 4, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(700, 173);
            dataGridView2.TabIndex = 9;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            //
            // WarningBlock
            // 
            WarningBlock.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            WarningBlock.ForeColor = Color.DarkRed;
            WarningBlock.Location = new Point(14, 426);
            WarningBlock.Name = "WarningBlock";
            WarningBlock.Size = new Size(640, 23);
            WarningBlock.TabIndex = 7;
            WarningBlock.Text = "Auto binding enabled";
#if AutoBinding
            WarningBlock.Visible = true;
#else
            WarningBlock.Visible = false;
#endif
            WarningBlock.TextAlign = ContentAlignment.BottomCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1500, 638);
            Controls.Add(dataGridView2);
            Controls.Add(UploadButton);
            Controls.Add(SaveButton);
            Controls.Add(WarningBlock);

            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(chart1);
            Controls.Add(addButton);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

#endregion

        private DataGridView dataGridView1;
        private Button addButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox comboBox1;
        private Button button3;
        private Button SaveButton;
        private Button UploadButton;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private DataGridView dataGridView2;
        private Label WarningBlock;
    }
}