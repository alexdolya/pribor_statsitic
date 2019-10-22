using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace _10m_stat
{
    public partial class Form1 : Form
    {

        //ФУНКЦИИ
        //
        //

        // проверка прибора на заполнение всех граф
        private bool pribor_check(Pribor p)

        {
            bool res = false; ;

            for (int i = 0; i < 3; i++)
            {
                if (p.Dus[i] == "" || p.Dus[i] == null || p.Pog_km[i] == "" || p.Pog_km[i] == null || p.Nel_km[i] == "" || p.Nel_km[i] == null || p.W[i] == "" || p.W[i] == null || p.Dw[i] == "" || p.Dw[i] == null || p.Wzzap[i] == "" || p.Wzzap[i] == null || p.Wr1[i] == "" || p.Wr1[i] == null || p.Wr2[i] == "" || p.Wr2[i] == null)
                {
                    res = true;
                    continue;
                }
                else
                    res = false;
            }
            return res;
        }

        //заполнение таблицы по результатам обработки папок с приборами
        private DataTable GetDataTable(List<Pribor> pribors)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";
            DataTable dtb = new DataTable();
            DataColumn[] cols = {
                new DataColumn("Канал",typeof(String)),
                new DataColumn("КХ79-060",typeof(String)),
                new DataColumn("Погр_Км",typeof(String)),
                new DataColumn("Нелин_Км",typeof(String)),
                new DataColumn("W",typeof(String)),
                new DataColumn("d_W",typeof(String)),
                new DataColumn("W_между_зап",typeof(String)),
                new DataColumn("Wр_1",typeof(String)),
                new DataColumn("Wр_2",typeof(String))
            };
            dtb.Columns.AddRange(cols);
            DataRow row1 = dtb.NewRow();
            row1["Канал"] = "Канал Х";
            dtb.Rows.Add(row1);
            DataRow row2 = dtb.NewRow();
            row2["Канал"] = "Канал Y";
            dtb.Rows.Add(row2);
            DataRow row3 = dtb.NewRow();
            row3["Канал"] = "Канал Z";
            dtb.Rows.Add(row3);
            string s;
            char[] ch = { 'X', 'Y', 'Z' };
            foreach (Pribor p in pribors)
            {

                for (int i = 0; i < 3; i++)
                {
                    var data_file = new FileInfo(p.Path + "\\ПСИ\\" + ch[i] + "\\25\\Res.ini");
                    if (data_file.Exists)
                    {
                        using (StreamReader sr = data_file.OpenText())
                        {
                            while ((s = sr.ReadLine()) != null)
                            {
                                switch (s)
                                {
                                    case "[PogrMashKoffDisIm]":
                                        for (int j = 0; j < 9; j++)
                                        {
                                            s = sr.ReadLine();
                                        }
                                        s = s.Remove(s.IndexOf("Sr="), 3);
                                        s = s.Replace('.', ',');
                                        if (p.Pog_km[i] == "" || p.Pog_km[i] == null)
                                            p.Pog_km[i] = s;
                                        break;
                                    case "[RaznMashKoffDisIm]":
                                        for (int j = 0; j < 5; j++)
                                        {
                                            s = sr.ReadLine();
                                        }
                                        s = s.Remove(s.IndexOf("Max="), 4);
                                        s = s.Replace('.', ',');
                                        if (p.Nel_km[i] == "" || p.Nel_km[i] == null)
                                            p.Nel_km[i] = s;
                                        break;
                                    case "[SistSostDis]":
                                        for (int j = 0; j < 5; j++)
                                        {
                                            s = sr.ReadLine();
                                        }
                                        s = s.Remove(s.IndexOf("Sr="), 3);
                                        s = s.Replace('.', ',');
                                        if (p.W[i] == "" || p.W[i] == null)
                                            p.W[i] = s;
                                        break;
                                    case "[SlSostDis]":
                                        double[] tmp = new double[3];

                                        for (int k = 0; k < 3; k++)
                                        {
                                            s = sr.ReadLine();
                                            s = s.Remove(0, 2);
                                            s = s.Replace('.', ',');
                                            tmp[k] = Math.Abs(Convert.ToDouble(s));
                                        }
                                        s = tmp.Max().ToString();
                                        s = s.Replace('.', ',');
                                        if (p.Dw[i] == "" || p.Dw[i] == null)
                                            p.Dw[i] = s;
                                        break;
                                    case "[SlSosZapZapDis]":
                                        s = sr.ReadLine();
                                        s = s.Remove(s.IndexOf("1="), 2);
                                        s = s.Replace('.', ',');
                                        if (p.Wzzap[i] == "" || p.Wzzap[i] == null)
                                            p.Wzzap[i] = s;
                                        break;
                                    case "[RazbDis]":
                                        s = sr.ReadLine();
                                        if (s[2]=='=')
                                        {
                                            s = s.Remove(s.IndexOf("II="), 3);
                                            s = s.Replace('.', ',');
                                            if (p.Wr1[i] == "" || p.Wr1[i] == null)
                                                p.Wr1[i] = s;
                                            s = sr.ReadLine();
                                            s = s.Remove(s.IndexOf("III="), 4);
                                            s = s.Replace('.', ',');
                                            if (p.Wr2[i] == "" || p.Wr2[i] == null)
                                                p.Wr2[i] = s;
                                        }
                                        else
                                        {
                                            s = s.Remove(s.IndexOf("III="), 4);
                                            s = s.Replace('.', ',');
                                            if (p.Wr2[i] == "" || p.Wr2[i] == null)
                                                p.Wr2[i] = s;
                                            s = sr.ReadLine();
                                            s = s.Remove(s.IndexOf("II="), 3);
                                            s = s.Replace('.', ',');
                                            if (p.Wr1[i] == "" || p.Wr1[i] == null)
                                                p.Wr1[i] = s;
                                        }                                        
                                        break;
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Отсутвует файл Res.ini в папке ПСИ канала " + ch[i] + " прибора Зав.№" + p.Number);
                    }


                }







            }
            return dtb;
        }                  
        
        //
        //
        //КОНЕЦ ФУНКЦИЙ

        //Конструктор
        public Form1()
        {
            pribors = new List<Pribor>();
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(Environment.CurrentDirectory));
            string tmps;
            var output_file = new FileInfo(Environment.CurrentDirectory + "\\Output.xls");

            if (output_file.Exists)
            {
                using (StreamReader sr = new StreamReader(new FileStream(output_file.FullName, FileMode.Open), System.Text.Encoding.Default))
                {
                    sr.ReadLine();
                    while ((tmps = sr.ReadLine()) != null)
                    {
                        string[] values = tmps.Split('\t');
                        pribors.Add(new Pribor(values));
                    }
                }
            }           
            
            foreach (string s in dirs)
            {
                bool n_exist=false;
                string number = s.Remove(0, Environment.CurrentDirectory.Length + 1);
                foreach (Pribor p in pribors)
                {
                    if (p.Number == number)
                    {
                        n_exist = true;
                        p.Path = s;
                        continue;
                    }
                }
                if (!n_exist)
                {
                    pribors.Add(new Pribor(s));
                }
            }
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_val.ReadOnly = true;
            tb_sig.ReadOnly = true;
            tb_M.ReadOnly = true;
            tb_MS.ReadOnly = true;
            tb_M2S.ReadOnly = true;
            tb_M3S.ReadOnly = true;
            dataGridView1.ReadOnly = true;
            zedGraphControl1.GraphPane.Legend.IsVisible = false;
            zedGraphControl1.GraphPane.XAxis.IsShowGrid = true;
            zedGraphControl1.GraphPane.YAxis.IsShowGrid = true;
            listBox1.Enabled = false;
            b_graph.Enabled = false;
            button_save.Enabled = false;
            b_zed.Enabled = false;
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            
        }


        //ОБРАБОТЧИКИ СОБЫТИЙ//
        //
        //
        //Редактирование ячейки 
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
            int ind = pribors.FindIndex(item => item.Number == listBox1.SelectedItem.ToString());
            pribors[ind].Dus[e.RowIndex] =  dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        //Сохранение данных в Output.xls
        private void Button_save_Click(object sender, EventArgs e)
        {
            try
            {
                char[] ch = { 'X', 'Y', 'Z' };
                FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Output.xls", FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {

                    sw.WriteLine("Номер прибора\tЗав.№ ДУС X\tЗав.№ ДУС Y\tЗав.№ ДУС Z\tПогрешность Км X\tПогрешность Км Y\tПогрешность Км Z\tНелин. Км X\tНелин. Км Y\tНелин. Км Z\tW X\tW Y\tW Z\tdW X\tdW Y\tdW Z\tW от зап. к зап. X\tW от зап. к зап. Y\tW от зап. к зап. Z\tWr1 X\tWr1 Y\tWr1 Z\tWr2 X\tWr2 Y\tWr2 Z");
                    foreach (Pribor p in pribors)
                    {

                        sw.WriteLine(p.Number + "\t" + p.Dus[0] + "\t" + p.Dus[1] + "\t" + p.Dus[2] + "\t" + p.Pog_km[0] + "\t" + p.Pog_km[1] + "\t" + p.Pog_km[2] + "\t" + p.Nel_km[0] + "\t" + p.Nel_km[1] + "\t" + p.Nel_km[2] + "\t" + p.W[0] + "\t" + p.W[1] + "\t" + p.W[2] + "\t" + p.Dw[0] + "\t" + p.Dw[1] + "\t" + p.Dw[2] + "\t" + p.Wzzap[0] + "\t" + p.Wzzap[1] + "\t" + p.Wzzap[2] + "\t" + p.Wr1[0] + "\t" + p.Wr1[1] + "\t" + p.Wr1[2] + "\t" + p.Wr2[0] + "\t" + p.Wr2[1] + "\t" + p.Wr2[2]);

                    }

                }
                MessageBox.Show("Файл Output.xls успешно создан!");

            }
            catch
            {
                MessageBox.Show("Ошибка создания файла Output.xls. Возможно файл в данный момент используется.");                
            }
        }

        //кастомная отрисовка листбокса с выделением красным
        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            string m = listBox1.Items[e.Index].ToString();
            foreach (Pribor p in pribors)
            {
                if (m == p.Number && pribor_check(p))
                    myBrush = Brushes.Red;
            }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
            e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();


        }

        //Перестроение таблицы в зависимости от выбора в ListBox
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            l_number.Text = "Зав. № " + listBox1.SelectedItem.ToString();

            foreach (Pribor p in pribors)
            {

                if (p.Number == listBox1.SelectedItem.ToString())
                {

                    for (int i = 0; i < 3; i++)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = p.Dus[i];
                        dataGridView1.Rows[i].Cells[2].Value = p.Pog_km[i];
                        dataGridView1.Rows[i].Cells[3].Value = p.Nel_km[i];
                        dataGridView1.Rows[i].Cells[4].Value = p.W[i];
                        dataGridView1.Rows[i].Cells[5].Value = p.Dw[i];
                        dataGridView1.Rows[i].Cells[6].Value = p.Wzzap[i];
                        dataGridView1.Rows[i].Cells[7].Value = p.Wr1[i];
                        dataGridView1.Rows[i].Cells[8].Value = p.Wr2[i];
                    }

                }
            }
        }

        //Загрузка приборов
        private void B_load_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataTable(pribors);
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;
            }            
            listBox1.Enabled = true;
            b_graph.Enabled = true;
            button_save.Enabled = true;
            b_zed.Enabled = true;            
            foreach (Pribor p in pribors)
            {
                listBox1.Items.Add(p.Number);
            }
            listBox1.SelectedIndex = 0;
            b_load.Enabled = false;
            cb_graphtypes.Items.Add("1. Погрешность масштабного коэффициента во всем диапазоне имитации угловых скоростей");
            cb_graphtypes.Items.Add("2. Максимальная разность масштабных коэффициентов при имитации угловых скоростей");
            cb_graphtypes.Items.Add("3. Среднее значение независящей от ускорения составляющей скорости дрейфа по трем запускам");
            cb_graphtypes.Items.Add("4. Изменение независящей от ускорения составляющей скорости дрейфа в запуске");
            cb_graphtypes.Items.Add("5. Изменение независящей от ускорения составляющей скорости дрейфа между запусками");
            cb_graphtypes.Items.Add("6. Зависящая от ускорения составляющая скорости  дрейфа Wr1");
            cb_graphtypes.Items.Add("7. Зависящая от ускорения составляющая скорости  дрейфа Wr2");
            cb_graphtypes.SelectedIndex = 0;
        }

        //Построение графика   
        private void B_graph_Click(object sender, EventArgs e)
        {
            double v_min=0, v_max=0, m=0, sig=0;
  
            switch (cb_graphtypes.SelectedItem.ToString())
            {
                case "1. Погрешность масштабного коэффициента во всем диапазоне имитации угловых скоростей":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "Pog_km", ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m-sig, 4).ToString()+"-"+ Math.Round(m+sig,4).ToString();
                    tb_M2S.Text = Math.Round(m - 2*sig, 4).ToString() + "-" + Math.Round(m + 2*sig,4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig,4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Погрешность масштабного коэффициента";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(916)+"Км, %";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";     
                    break;
                case "2. Максимальная разность масштабных коэффициентов при имитации угловых скоростей":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "Nel_km",ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m - sig, 4).ToString() + "-" + Math.Round(m + sig, 4).ToString();
                    tb_M2S.Text = Math.Round(m - 2 * sig, 4).ToString() + "-" + Math.Round(m + 2 * sig, 4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig, 4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Максимальная разность масштабных коэффициентов";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(963) + "Км, %";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";                 
                    break;
                case "3. Среднее значение независящей от ускорения составляющей скорости дрейфа по трем запускам":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "W", ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m - sig, 4).ToString() + "-" + Math.Round(m + sig, 4).ToString();
                    tb_M2S.Text = Math.Round(m - 2 * sig, 4).ToString() + "-" + Math.Round(m + 2 * sig, 4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig, 4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Среднее значение независящей от ускорения составляющей скорости дрейфа";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(969) + "н, " + Convert.ToChar(176) + "/ч";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";                    
                    break;
                case "4. Изменение независящей от ускорения составляющей скорости дрейфа в запуске":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "Dw", ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m - sig, 4).ToString() + "-" + Math.Round(m + sig, 4).ToString();
                    tb_M2S.Text = Math.Round(m - 2 * sig, 4).ToString() + "-" + Math.Round(m + 2 * sig, 4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig, 4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Изменение независящей от ускорения составляющей скорости дрейфа в запуске";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(916) + "" + Convert.ToChar(969) + ", " + Convert.ToChar(176) + "/ч";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";                   
                    break;
                case "5. Изменение независящей от ускорения составляющей скорости дрейфа между запусками":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "Wzzap", ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m - sig, 4).ToString() + "-" + Math.Round(m + sig, 4).ToString();
                    tb_M2S.Text = Math.Round(m - 2 * sig, 4).ToString() + "-" + Math.Round(m + 2 * sig, 4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig, 4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Изменение независящей от ускорения составляющей скорости дрейфа в запуске";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(916) + "" + Convert.ToChar(969) + "н, " + Convert.ToChar(176) + "/ч";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";                   
                    break;
                case "6. Зависящая от ускорения составляющая скорости  дрейфа Wr1":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "Wr1", ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m - sig, 4).ToString() + "-" + Math.Round(m + sig, 4).ToString();
                    tb_M2S.Text = Math.Round(m - 2 * sig, 4).ToString() + "-" + Math.Round(m + 2 * sig, 4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig, 4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Зависящая от ускорения составляющая скорости  дрейфа " + Convert.ToChar(969) + "р1";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(969) + "р1, " + Convert.ToChar(176) + "/ч";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";                  
                    break;
                case "7. Зависящая от ускорения составляющая скорости  дрейфа Wr2":
                    GBuilder.Build(pribors, zedGraphControl1.GraphPane, "Wr2", ref v_min, ref v_max, ref m, ref sig);
                    tb_val.Text = Math.Round(v_min, 4) + "-" + Math.Round(v_max, 4);
                    tb_sig.Text = Math.Round(sig, 4).ToString();
                    tb_M.Text = Math.Round(m, 4).ToString();
                    tb_MS.Text = Math.Round(m - sig, 4).ToString() + "-" + Math.Round(m + sig, 4).ToString();
                    tb_M2S.Text = Math.Round(m - 2 * sig, 4).ToString() + "-" + Math.Round(m + 2 * sig, 4).ToString();
                    tb_M3S.Text = Math.Round(m - 3 * sig, 4).ToString() + "-" + Math.Round(m + 3 * sig, 4).ToString();
                    zedGraphControl1.GraphPane.Title = "Зависящая от ускорения составляющая скорости  дрейфа " + Convert.ToChar(969) + "р2";
                    zedGraphControl1.GraphPane.XAxis.Title = Convert.ToChar(969) + "р2, " + Convert.ToChar(176) + "/ч";
                    zedGraphControl1.GraphPane.YAxis.Title = "Нормальное распределение";                   
                    break;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        //Сохранение графиков в png
        private void B_zed_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.png|*.png|*.jpg; *.jpeg|*.jpg;*.jpeg|*.bmp|*.bmp|Все файлы|*.*";
            switch (cb_graphtypes.SelectedItem.ToString())
            {
                case "1. Погрешность масштабного коэффициента во всем диапазоне имитации угловых скоростей":
                    dlg.FileName = "1.d_Km.png";
                    break;
                case "2. Максимальная разность масштабных коэффициентов при имитации угловых скоростей":
                    dlg.FileName = "2.s_Km.png";
                    break;
                case "3. Среднее значение независящей от ускорения составляющей скорости дрейфа по трем запускам":
                    dlg.FileName = "3.W.png";
                    break;
                case "4. Изменение независящей от ускорения составляющей скорости дрейфа в запуске":
                    dlg.FileName = "4.d_W.png";
                    break;
                case "5. Изменение независящей от ускорения составляющей скорости дрейфа между запусками":
                    dlg.FileName = "5.d_Wmz.png";
                    break;
                case "6. Зависящая от ускорения составляющая скорости  дрейфа Wr1":
                    dlg.FileName = "6.Wr1.png";
                    break;
                case "7. Зависящая от ускорения составляющая скорости  дрейфа Wr2":
                    dlg.FileName = "7.Wr2.png";
                    break;

            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = zedGraphControl1.Image;
                bmp.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        //
        //
        //КОНЕЦ ОБРАБОТЧИКОВ//



        //Поля
        private List<Pribor> pribors;

 
    }
}
