using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Windows.Forms;

namespace _10m_stat
{
    public class GBuilder
    {
        //поиск стандартного отклонения массива значений 
        public static double find_sigma(double[] val)
        {
            double[] tmp_r = new double[val.Length];
            for (int i = 0; i < val.Length; i++)
            {
                tmp_r[i] = (val[i] - val.Average())* (val[i] - val.Average());
            }
            return Math.Sqrt(tmp_r.Sum() / (val.Length - 1));
        }

        //получение списка точек (параметр прибора - нормальное распределение)        
        public static List<KeyValuePair<double, double>> GetPairs(List<Pribor> pribors, string param_type) 
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";

            double[] values = new double [pribors.Count * 3]; //массив для данных с прибора
            double[] result = new double[pribors.Count * 3]; //массив для рассчитанного распределения для каждого значения из values
            List<KeyValuePair<double, double>> d_res = new List<KeyValuePair<double, double>>(values.Length); //выходной список пар точек (значение-распределение)            
            

            //заполнение массива values
            for (int i = 0, j=0, k=0; i < values.Length; i++)
            {
                try
                {
                    string s = "";
                    switch (param_type)
                    {
                        case "Pog_km":
                            s = pribors[k].Pog_km[j];
                            break;
                        case "Nel_km":
                            s = pribors[k].Nel_km[j];
                            break;
                        case "W":
                            s = pribors[k].W[j];
                            break;
                        case "Dw":
                            s = pribors[k].Dw[j];
                            break;
                        case "Wzzap":
                            s = pribors[k].Wzzap[j];
                            break;
                        case "Wr1":
                            s = pribors[k].Wr1[j];
                            break;
                        case "Wr2":
                            s = pribors[k].Wr2[j];
                            break;
                    }
                    
                    values[i] = Convert.ToDouble(s);
                    ++j;
                    if (j == 3)
                    {
                        j = 0;
                        ++k;
                    }
                }
                catch 
                {
                    switch (j)
                    {
                        case 0:
                            MessageBox.Show("Отсутствуют данные у прибора Зав.№" + pribors[k].Number + "по каналу Х");
                            ++j;
                            break;
                        case 1:
                            MessageBox.Show("Отсутствуют данные у прибора Зав.№" + pribors[k].Number + "по каналу Y");
                            ++j;
                            break;
                        case 2:
                            MessageBox.Show("Отсутствуют данные у прибора Зав.№" + pribors[k].Number + "по каналу Z");
                            ++j;
                            break;
                    }
                    
                }
                
            }

            Array.Sort(values); //сортируем по возрастанию
            Array.Reverse(values); //сортируем по убыванию
            double sigma = find_sigma(values); //вычисляем сигму
                        
            //заполняем массив результатов
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = (1 / (Math.Exp(((values[i] - values.Average()) * (values[i] - values.Average())) / (2 * sigma * sigma)))) * (1 / ((Math.Sqrt(2 * Math.PI)) * sigma));
            }
            
            //заполняем список парами точек
            for (int i = 0; i < values.Length; i++)
            {
                KeyValuePair<double, double> tmp = new KeyValuePair<double, double>(values[i], result[i]);                
                d_res.Add(tmp);
            }     

            //возвращаем список
            return d_res;
        }

        //построение графика по точкам 
        public static void Build (List<Pribor> pribors, GraphPane pane, string param_type, ref double v_min, ref double v_max, ref double m, ref double sig)
        {
            pane.CurveList.Clear();
            pane.GraphItemList.Clear();
            List<KeyValuePair<double,double>> l_kp =  GetPairs(pribors, param_type);
            double[] values = new double[l_kp.Count];
            double[] norm_rasp = new double[l_kp.Count];
            
            for (int i = 0; i < l_kp.Count; i++)
            {
                values[i] = l_kp[i].Key;
                norm_rasp[i] = l_kp[i].Value;
            }

            double mo = values.Average();
            Array.Sort(norm_rasp);
            double max_mo=norm_rasp[norm_rasp.Length-1]*1.1;
            double sigma = find_sigma(values);
            sig = sigma;
            m = mo;
            v_max = values[0];
            v_min = values[values.Length-1];

            PointPairList f1_list = new PointPairList();

            PointPairList f2_list = new PointPairList();
            f2_list.Add(mo, 0);
            f2_list.Add(mo, max_mo);
            TextItem text_M = new TextItem("M", (float)mo, (float)max_mo);
            pane.GraphItemList.Add(text_M);

            PointPairList f3_list = new PointPairList();
            f3_list.Add(mo + sigma, 0);
            f3_list.Add(mo + sigma, max_mo);
            TextItem text_MpS = new TextItem("M+" + Convert.ToChar(963), (float)(mo + sigma), (float)max_mo);
            pane.GraphItemList.Add(text_MpS);

            PointPairList f4_list = new PointPairList();
            f4_list.Add(mo + 2 * sigma, 0);
            f4_list.Add(mo + 2 * sigma, norm_rasp[(norm_rasp.Length - 1)] * 1.1);
            TextItem text_Mp2S = new TextItem("M+2" + Convert.ToChar(963), (float)f4_list[1].X, (float)f4_list[1].Y);
            pane.GraphItemList.Add(text_Mp2S);

            PointPairList f5_list = new PointPairList();
            f5_list.Add(mo + 3 * sigma, 0);
            f5_list.Add(mo + 3 * sigma, norm_rasp[(norm_rasp.Length - 1)] * 1.1);
            TextItem text_Mp3S = new TextItem("M+3" + Convert.ToChar(963), (float)f5_list[1].X, (float)f5_list[1].Y);
            pane.GraphItemList.Add(text_Mp3S);

            PointPairList f6_list = new PointPairList();
            f6_list.Add(mo - sigma, 0);
            f6_list.Add(mo - sigma, norm_rasp[(norm_rasp.Length - 1)] * 1.1);
            TextItem text_MmS = new TextItem("M-" + Convert.ToChar(963), (float)f6_list[1].X, (float)f6_list[1].Y);
            pane.GraphItemList.Add(text_MmS);

            PointPairList f7_list = new PointPairList();
            f7_list.Add(mo - 2 * sigma, 0);
            f7_list.Add(mo - 2 * sigma, norm_rasp[(norm_rasp.Length - 1)] * 1.1);
            TextItem text_Mm2S = new TextItem("M-2" + Convert.ToChar(963), (float)f7_list[1].X, (float)f7_list[1].Y);
            pane.GraphItemList.Add(text_Mm2S);

            PointPairList f8_list = new PointPairList();
            f8_list.Add(mo - 3 * sigma, 0);
            f8_list.Add(mo - 3 * sigma, norm_rasp[(norm_rasp.Length - 1)] * 1.1);
            TextItem text_Mm3S = new TextItem("M-3" + Convert.ToChar(963), (float)f8_list[1].X, (float)f8_list[1].Y);
            pane.GraphItemList.Add(text_Mm3S);

            foreach (KeyValuePair<double, double> kp in l_kp)
            {
                f1_list.Add(kp.Key, kp.Value);
            }
             
            LineItem f1_curve = pane.AddCurve(param_type, f1_list, Color.DarkOliveGreen, SymbolType.Plus);
            LineItem f2_curve = pane.AddCurve("M", f2_list, Color.Red, SymbolType.None);
            LineItem f3_curve = pane.AddCurve("M+"+Convert.ToChar(963), f3_list, Color.Blue, SymbolType.None);
            LineItem f4_curve = pane.AddCurve("M+2"+ Convert.ToChar(963), f4_list, Color.Black, SymbolType.None);
            LineItem f5_curve = pane.AddCurve("M+3"+Convert.ToChar(963), f5_list, Color.OrangeRed, SymbolType.None);
            LineItem f6_curve = pane.AddCurve("M-"+ Convert.ToChar(963), f6_list, Color.DarkViolet, SymbolType.None);
            LineItem f7_curve = pane.AddCurve("M-2" + Convert.ToChar(963), f7_list, Color.DimGray, SymbolType.None);
            LineItem f8_curve = pane.AddCurve("M-3" + Convert.ToChar(963), f8_list, Color.IndianRed, SymbolType.None);

            f1_curve.Line.Width = 2.0f;

        }
    }
}
