using System;
using System.Windows.Forms;

namespace _10m_stat
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.l_number = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_save = new System.Windows.Forms.Button();
            this.b_load = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.cb_graphtypes = new System.Windows.Forms.ComboBox();
            this.b_zed = new System.Windows.Forms.Button();
            this.b_graph = new System.Windows.Forms.Button();
            this.l_report = new System.Windows.Forms.Label();
            this.tb_val = new System.Windows.Forms.TextBox();
            this.tb_sig = new System.Windows.Forms.TextBox();
            this.tb_M = new System.Windows.Forms.TextBox();
            this.tb_MS = new System.Windows.Forms.TextBox();
            this.tb_M2S = new System.Windows.Forms.TextBox();
            this.tb_M3S = new System.Windows.Forms.TextBox();
            this.l_min_max = new System.Windows.Forms.Label();
            this.l_mato = new System.Windows.Forms.Label();
            this.l_sig = new System.Windows.Forms.Label();
            this.l_M3S = new System.Windows.Forms.Label();
            this.l_M2S = new System.Windows.Forms.Label();
            this.l_MS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // l_number
            // 
            this.l_number.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_number.AutoSize = true;
            this.l_number.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_number.Location = new System.Drawing.Point(491, 16);
            this.l_number.Name = "l_number";
            this.l_number.Size = new System.Drawing.Size(113, 17);
            this.l_number.TabIndex = 2;
            this.l_number.Text = "Зав. № --------";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(247, 55);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(698, 87);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(15, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 225);
            this.listBox1.TabIndex = 6;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // button_save
            // 
            this.button_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_save.Location = new System.Drawing.Point(15, 361);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(188, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Импортировать в .xls";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.Button_save_Click);
            // 
            // b_load
            // 
            this.b_load.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_load.Location = new System.Drawing.Point(15, 314);
            this.b_load.Name = "b_load";
            this.b_load.Size = new System.Drawing.Size(188, 23);
            this.b_load.TabIndex = 8;
            this.b_load.Text = "Загрузить приборы";
            this.b_load.UseVisualStyleBackColor = true;
            this.b_load.Click += new System.EventHandler(this.B_load_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.zedGraphControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zedGraphControl1.Font = new System.Drawing.Font("GOST type A", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(247, 201);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.Size = new System.Drawing.Size(698, 381);
            this.zedGraphControl1.TabIndex = 9;
            // 
            // cb_graphtypes
            // 
            this.cb_graphtypes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_graphtypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_graphtypes.FormattingEnabled = true;
            this.cb_graphtypes.Location = new System.Drawing.Point(406, 160);
            this.cb_graphtypes.Name = "cb_graphtypes";
            this.cb_graphtypes.Size = new System.Drawing.Size(539, 21);
            this.cb_graphtypes.TabIndex = 10;
            // 
            // b_zed
            // 
            this.b_zed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_zed.Location = new System.Drawing.Point(467, 599);
            this.b_zed.Name = "b_zed";
            this.b_zed.Size = new System.Drawing.Size(289, 23);
            this.b_zed.TabIndex = 11;
            this.b_zed.Text = "Импортировать график в .png";
            this.b_zed.UseVisualStyleBackColor = true;
            this.b_zed.Click += new System.EventHandler(this.B_zed_Click);
            // 
            // b_graph
            // 
            this.b_graph.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_graph.Location = new System.Drawing.Point(247, 158);
            this.b_graph.Name = "b_graph";
            this.b_graph.Size = new System.Drawing.Size(143, 23);
            this.b_graph.TabIndex = 12;
            this.b_graph.Text = "Построить график";
            this.b_graph.UseVisualStyleBackColor = true;
            this.b_graph.Click += new System.EventHandler(this.B_graph_Click);
            // 
            // l_report
            // 
            this.l_report.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_report.AutoSize = true;
            this.l_report.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_report.Location = new System.Drawing.Point(51, 411);
            this.l_report.Name = "l_report";
            this.l_report.Size = new System.Drawing.Size(0, 17);
            this.l_report.TabIndex = 13;
            // 
            // tb_val
            // 
            this.tb_val.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_val.Location = new System.Drawing.Point(103, 411);
            this.tb_val.Name = "tb_val";
            this.tb_val.Size = new System.Drawing.Size(100, 20);
            this.tb_val.TabIndex = 14;
            this.tb_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_sig
            // 
            this.tb_sig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_sig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_sig.Location = new System.Drawing.Point(103, 463);
            this.tb_sig.Name = "tb_sig";
            this.tb_sig.Size = new System.Drawing.Size(100, 20);
            this.tb_sig.TabIndex = 15;
            this.tb_sig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_M
            // 
            this.tb_M.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_M.Location = new System.Drawing.Point(103, 437);
            this.tb_M.Name = "tb_M";
            this.tb_M.Size = new System.Drawing.Size(100, 20);
            this.tb_M.TabIndex = 16;
            this.tb_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_MS
            // 
            this.tb_MS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_MS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_MS.Location = new System.Drawing.Point(103, 541);
            this.tb_MS.Name = "tb_MS";
            this.tb_MS.Size = new System.Drawing.Size(100, 20);
            this.tb_MS.TabIndex = 17;
            this.tb_MS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_M2S
            // 
            this.tb_M2S.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_M2S.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_M2S.Location = new System.Drawing.Point(103, 515);
            this.tb_M2S.Name = "tb_M2S";
            this.tb_M2S.Size = new System.Drawing.Size(100, 20);
            this.tb_M2S.TabIndex = 18;
            this.tb_M2S.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_M3S
            // 
            this.tb_M3S.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_M3S.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_M3S.Location = new System.Drawing.Point(103, 489);
            this.tb_M3S.Name = "tb_M3S";
            this.tb_M3S.Size = new System.Drawing.Size(100, 20);
            this.tb_M3S.TabIndex = 19;
            this.tb_M3S.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_min_max
            // 
            this.l_min_max.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_min_max.AutoSize = true;
            this.l_min_max.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_min_max.Location = new System.Drawing.Point(31, 412);
            this.l_min_max.Name = "l_min_max";
            this.l_min_max.Size = new System.Drawing.Size(66, 17);
            this.l_min_max.TabIndex = 20;
            this.l_min_max.Text = "Диапазон";
            // 
            // l_mato
            // 
            this.l_mato.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_mato.AutoSize = true;
            this.l_mato.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_mato.Location = new System.Drawing.Point(34, 440);
            this.l_mato.Name = "l_mato";
            this.l_mato.Size = new System.Drawing.Size(63, 17);
            this.l_mato.TabIndex = 21;
            this.l_mato.Text = "Мат. ож.";
            // 
            // l_sig
            // 
            this.l_sig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_sig.AutoSize = true;
            this.l_sig.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_sig.Location = new System.Drawing.Point(81, 466);
            this.l_sig.Name = "l_sig";
            this.l_sig.Size = new System.Drawing.Size(16, 17);
            this.l_sig.TabIndex = 22;
            this.l_sig.Text = "σ";
            // 
            // l_M3S
            // 
            this.l_M3S.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_M3S.AutoSize = true;
            this.l_M3S.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_M3S.Location = new System.Drawing.Point(57, 492);
            this.l_M3S.Name = "l_M3S";
            this.l_M3S.Size = new System.Drawing.Size(40, 17);
            this.l_M3S.TabIndex = 23;
            this.l_M3S.Text = "M±3σ";
            // 
            // l_M2S
            // 
            this.l_M2S.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_M2S.AutoSize = true;
            this.l_M2S.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_M2S.Location = new System.Drawing.Point(56, 518);
            this.l_M2S.Name = "l_M2S";
            this.l_M2S.Size = new System.Drawing.Size(41, 17);
            this.l_M2S.TabIndex = 24;
            this.l_M2S.Text = "M±2σ";
            // 
            // l_MS
            // 
            this.l_MS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.l_MS.AutoSize = true;
            this.l_MS.Font = new System.Drawing.Font("GOST type A", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_MS.Location = new System.Drawing.Point(56, 544);
            this.l_MS.Name = "l_MS";
            this.l_MS.Size = new System.Drawing.Size(33, 17);
            this.l_MS.TabIndex = 25;
            this.l_MS.Text = "M±σ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.l_MS);
            this.Controls.Add(this.l_M2S);
            this.Controls.Add(this.l_M3S);
            this.Controls.Add(this.l_sig);
            this.Controls.Add(this.l_mato);
            this.Controls.Add(this.l_min_max);
            this.Controls.Add(this.tb_M3S);
            this.Controls.Add(this.tb_M2S);
            this.Controls.Add(this.tb_MS);
            this.Controls.Add(this.tb_M);
            this.Controls.Add(this.tb_sig);
            this.Controls.Add(this.tb_val);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.l_report);
            this.Controls.Add(this.b_graph);
            this.Controls.Add(this.b_zed);
            this.Controls.Add(this.cb_graphtypes);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.b_load);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.l_number);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика КХ97-010М";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Label l_number;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button b_load;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox cb_graphtypes;
        private System.Windows.Forms.Button b_zed;
        private System.Windows.Forms.Button b_graph;
        private System.Windows.Forms.Label l_report;
        private TextBox tb_val;
        private TextBox tb_sig;
        private TextBox tb_M;
        private TextBox tb_MS;
        private TextBox tb_M2S;
        private TextBox tb_M3S;
        private Label l_min_max;
        private Label l_mato;
        private Label l_sig;
        private Label l_M3S;
        private Label l_M2S;
        private Label l_MS;
    }
}

