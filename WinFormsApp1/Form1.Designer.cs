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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dataGridView1 = new DataGridView();
            addButton = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBox1 = new ComboBox();
            button3 = new Button();
            WarningBlock = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(374, 66);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(280, 173);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
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
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(14, 18);
            chart1.Margin = new Padding(4, 3, 4, 3);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueMember = "X";
            series2.YValueMembers = "Y";
            chart1.Series.Add(series2);
            chart1.Size = new Size(350, 346);
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
            ClientSize = new Size(679, 458);
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
            ResumeLayout(false);
        }

#endregion

        private DataGridView dataGridView1;
        private Button addButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private ComboBox comboBox1;
        private Button button3;
        private Label WarningBlock;
    }
}