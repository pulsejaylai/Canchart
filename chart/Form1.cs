using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Runtime.InteropServices;

namespace chart
{
    public partial class Form1 : Form
    {
        delegate void mydelegate();
        public Form1()
        {
            InitializeComponent();
        }
        public Thread thread1, thread2;
        private void Form1_Load(object sender, EventArgs e)
        {

            Ecan.OpenDevice(4, 0, 0);
            Ecan.INIT_CONFIG init_config = new Ecan.INIT_CONFIG();
            init_config.AccCode = 0;
            init_config.AccMask = 0xffffffff;
            init_config.Filter = 0;
            init_config.Timing0 = 0x01;
            init_config.Timing1 = 0x1C;
            init_config.Mode = 0;
            init_config.Reserved = 0x00;
            Ecan.InitCAN(4, 0, 0, ref init_config);
            Ecan.InitCAN(4, 0, 1, ref init_config);
            Ecan.StartCAN(4, 0, 0);
            Ecan.StartCAN(4, 0, 1);
            //图表的背景色
            chart1.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            chart1.BackGradientStyle = GradientStyle.None;
            //图表的边框颜色、
            chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            chart1.BorderlineWidth = 2;
            //图表边框的皮肤
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.None;

            Title title = new Title();
            //标题内容
            title.Text = "ADx Voltage";
            //标题的字体
            title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            //标题字体颜色
            //title.ForeColor = Color.FromArgb(26, 59, 105);
            //标题阴影颜色
            //title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            //标题阴影偏移量
            //title.ShadowOffset = 3;

            chart1.Titles.Add(title);


            //图表区的名字

            ChartArea chartArea = new ChartArea("Default");

            //y轴刻度
            chartArea.AxisY.Interval = 10;
            //y轴范围
            chartArea.AxisY.Maximum = 5000;
            chartArea.AxisY.Minimum = 3600;


            //背景色

            chartArea.BackColor = Color.White;// Color.FromArgb(64, 165, 191, 228);

            //背景渐变方式

            chartArea.BackGradientStyle = GradientStyle.None;

            //渐变和阴影的辅助背景色

            chartArea.BackSecondaryColor = Color.White;

            //边框颜色

            chartArea.BorderColor = Color.Blue;

            //边框线条宽度

            chartArea.BorderWidth = 2;

            //边框线条样式

            chartArea.BorderDashStyle = ChartDashStyle.Solid;
            //阴影颜色

            //chartArea.ShadowColor = Color.Transparent;



            //设置X轴和Y轴线条的颜色和宽度

            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);

            chartArea.AxisX.LineWidth = 1;

            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);

            chartArea.AxisY.LineWidth = 1;



            //设置X轴和Y轴的标题

            //chartArea.AxisX.Title = "time";

            //chartArea.AxisY.Title = "count";

            //chartArea.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            //chartArea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular);



            //设置图表区网格横纵线条的颜色和宽度

            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);

            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineWidth = 1;
            chart1.ChartAreas.Add(chartArea);
            Legend legend = new Legend();
            legend.Alignment = StringAlignment.Center;
            legend.Docking = Docking.Bottom;
            legend.BackColor = Color.Transparent;
            this.chart1.Legends.Add(legend);
            // SetSeriesStyle(0);
               int seriesnum = 0;
             for (seriesnum = 0; seriesnum < 8; seriesnum++)
             { chart1.Series.Add(SetSeriesStyle(seriesnum)); }
         

        }

        private Series SetSeriesStyle(int i)

        {

            Series series = new Series(string.Format("AD{0}", i + 1));


            //Series的类型

            series.ChartType = SeriesChartType.Line;

            //Series的边框颜色

            series.BorderColor = Color.FromArgb(180, 26, 59, 105);

            //线条宽度

            series.BorderWidth = 1;

            //线条阴影颜色

            //series.ShadowColor = Color.Black;

            //阴影宽度

            //series.ShadowOffset = 2;

            //是否显示数据说明

            series.IsVisibleInLegend = true;

            //线条上数据点上是否有数据显示

            series.IsValueShownAsLabel = false;

            //线条上的数据点标志类型

            series.MarkerStyle = MarkerStyle.None;

            //线条数据点的大小

            //series.MarkerSize = 8;

            //线条颜色

            switch (i)

            {

                case 0:

                    series.Color = Color.FromArgb(220, 65, 140, 240);

                    break;

                case 1:

                    series.Color = Color.FromArgb(220, 40, 64, 10);

                    break;

                case 2:

                    series.Color = Color.FromArgb(220, 120, 150, 20);

                    break;

                case 3:

                    series.Color = Color.FromArgb(220, 250, 10, 10);

                    break;

                case 4:

                    series.Color = Color.FromArgb(220, 30, 240, 60);

                    break;

                case 5:

                    series.Color = Color.FromArgb(220, 190, 75, 200);

                    break;

                case 6:

                    series.Color = Color.FromArgb(220, 90, 224, 185);

                    break;

                case 7:

                    series.Color = Color.FromArgb(220, 50, 80, 110);

                    break;

            }

            return series;

        }
        bool flag = true;
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32.dll")]
        public static extern uint GetTickCount();
        public static void Delay(uint ms)
        {
            uint start = GetTickCount();
            while (GetTickCount() - start < ms)
            {
                Application.DoEvents();
            }
        }
       
        public class ChartTestData
        {
           
            public int value1 { get; set; }
            

            public ChartTestData()
            { }
            public ChartTestData( int value1)
            {
                
                this.value1 = value1;
              
            }
        }

        System.Diagnostics.Stopwatch sw;
        void Thread_Test()
        {
            //MessageBox.Show("start");
            Ecan.CAN_OBJ[] recbusinfo2, recbusinfo3;
            Ecan.CAN_OBJ sendbusinfo1 = new Ecan.CAN_OBJ();
            Ecan.CAN_OBJ sendbusinfo2 = new Ecan.CAN_OBJ();
            string ccdata="00";
            recbusinfo2 = new Ecan.CAN_OBJ[1];
            recbusinfo3 = new Ecan.CAN_OBJ[1];
            sendbusinfo1.SendType = 0; sendbusinfo1.data = new byte[8]; sendbusinfo1.Reserved = new byte[3]; sendbusinfo1.RemoteFlag = 0; sendbusinfo1.ExternFlag = 1;
            sendbusinfo1.DataLen = Convert.ToByte(0);
           int tlen = sendbusinfo1.DataLen - 1,ican;

            for (ican = 0; ican <= tlen; ican++)
            { sendbusinfo1.data[ican] = Convert.ToByte(ccdata.Substring(0 + ican * 2, 2), 0X10);  }
            sendbusinfo1.ID = Convert.ToUInt32("60C2010", 16);


            sendbusinfo2.SendType = 0; sendbusinfo2.data = new byte[8]; sendbusinfo2.Reserved = new byte[3]; sendbusinfo2.RemoteFlag = 0; sendbusinfo2.ExternFlag = 1;
            sendbusinfo2.DataLen = Convert.ToByte(0);
             tlen = sendbusinfo2.DataLen - 1;

            for (ican = 0; ican <= tlen; ican++)
            { sendbusinfo2.data[ican] = Convert.ToByte(ccdata.Substring(0 + ican * 2, 2), 0X10); }
            sendbusinfo2.ID = Convert.ToUInt32("60C2110", 16);

            int ibuf = 0;
            //MessageBox.Show("mid1");
            if (chart1.InvokeRequired == false)
            {
                Dictionary<string, CheckBox> checkboxList = new Dictionary<string, CheckBox>();
                foreach (Control item in this.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.CheckBox) && item.Name.StartsWith("checkBox"))
                        checkboxList.Add(item.Name, (CheckBox)item);

                }
                // List<int> txData2 = new List<int>();// { 2011, 2012, 2013, 2014, 2015, 2016 };
                // List<int> tyData2 = new List<int>();
                //  List<int> txData3 = new List<int>();// { 2011, 2012, 2013, 2014, 2015, 2016 };
                //  List<int> tyData3 = new List<int>();
                DataTable[] dataTable = null;
                dataTable = new DataTable[8];
                Dictionary<string, DataRow> rowList = new Dictionary<string, DataRow>();
                DataRow dataRow1 = null;
                DataRow dataRow2 = null;
                DataRow[] dataRowlist = new DataRow[8];
                DataRow dataRow3 = null;
                DataRow dataRow4 = null;
                DataRow dataRow5 = null;
                DataRow dataRow6 = null;
                DataColumn column = null;
                DataRow dataRow7 = null;
                DataRow dataRow8 = null;
                rowList.Add("datarow1",dataRow1);
                rowList.Add("datarow2", dataRow2);
                rowList.Add("datarow3", dataRow3);
                rowList.Add("datarow4", dataRow4);
                rowList.Add("datarow5", dataRow5);
                rowList.Add("datarow6", dataRow6);
                rowList.Add("datarow7", dataRow7);
                rowList.Add("datarow8", dataRow8);


                for (int tabnum = 0; tabnum < 8; tabnum++)
                {
                    
                    dataTable[tabnum] = new DataTable();
                    column = new DataColumn("Time", typeof(int));
                   //  MessageBox.Show("col1"+ tabnum.ToString());
                    dataTable[tabnum].Columns.Add(column);
                    //  MessageBox.Show("acol1");
                    column = new DataColumn("Voltage", typeof(int));
                      //MessageBox.Show("col2"+ tabnum.ToString());
                    dataTable[tabnum].Columns.Add(column);
                }
                    do
                {

                    cansend2(sendbusinfo1, out recbusinfo2, 1);
                    cansend2(sendbusinfo2, out recbusinfo3, 1);
              
                  /*  dataRow = dataTable.NewRow();
                    dataRow["Time"] = int.Parse(sw.ElapsedMilliseconds.ToString());
                  
                        dataRow["Voltage"] = hextodec(recbusinfo2[0].data[1].ToString("X2") + recbusinfo2[0].data[0].ToString("X2"));
                   
                    dataTable.Rows.Add(dataRow);
                    
                    chart1.Series[1].Points.DataBind(dataTable.AsEnumerable(), "Time", "Voltage", "");*/
                    for (ibuf = 1; ibuf < 9; ibuf++)
                        {
                        string actual_test = "checkBox" + ibuf.ToString();
                        if ((ibuf % 2 != 0)&&(ibuf!=7))
                            {
                            if (checkboxList[actual_test].Checked == true)
                            {
                                dataRowlist[ibuf - 1] = dataTable[ibuf - 1].NewRow();
                                dataRowlist[ibuf - 1]["Time"] = int.Parse(sw.ElapsedMilliseconds.ToString());
                                dataRowlist[ibuf - 1]["Voltage"] = hextodec(recbusinfo2[0].data[ibuf].ToString("X2") + recbusinfo2[0].data[ibuf - 1].ToString("X2"));
                                dataTable[ibuf - 1].Rows.Add(dataRowlist[ibuf - 1]);
                                //   MessageBox.Show(ibuf.ToString());
                                chart1.Series[ibuf - 1].Points.DataBind(dataTable[ibuf - 1].AsEnumerable(), "Time", "Voltage", "");
                            }
                            }
                            if ((ibuf % 2 == 0) && (ibuf != 8))
                            {
                            if (checkboxList[actual_test].Checked == true)
                            {
                                dataRowlist[ibuf - 1] = dataTable[ibuf - 1].NewRow();
                                dataRowlist[ibuf - 1]["Time"] = int.Parse(sw.ElapsedMilliseconds.ToString());
                                dataRowlist[ibuf - 1]["Voltage"] = hextodec(recbusinfo3[0].data[ibuf - 1].ToString("X2") + recbusinfo3[0].data[ibuf - 2].ToString("X2"));
                                dataTable[ibuf - 1].Rows.Add(dataRowlist[ibuf - 1]);
                                // MessageBox.Show(ibuf.ToString());
                                chart1.Series[ibuf - 1].Points.DataBind(dataTable[ibuf - 1].AsEnumerable(), "Time", "Voltage", "");
                            }
                            }

                        }

                    
                    //  txData.Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                    //    tyData.Add(hextodec(recbusinfo2[0].data[1].ToString("X2") + recbusinfo2[0].data[0].ToString("X2")));

                    //  chart1.Series[0].Points.DataBindXY(txData, tyData);


                    /*    txData[0].Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                    tyData[0].Add(hextodec(recbusinfo2[0].data[1].ToString("X2") + recbusinfo2[0].data[0].ToString("X2")));

                 chart1.Series[0].Points.DataBindXY(txData[0], tyData[0]);*/
                    //  txData3.Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                    // tyData3.Add(hextodec(recbusinfo3[0].data[1].ToString("X2") + recbusinfo3[0].data[0].ToString("X2")));
                    //chart1.Series[1].Points.DataBindXY(txData3, tyData3);



                    Delay(1);
                } while (flag == true);
            }
            else
            {
                // MessageBox.Show("Mid2");
                mydelegate mytest = new mydelegate(Thread_Test);
                chart1.BeginInvoke(mytest);

            }




        }

        void Thread2_Test()
        {
            MessageBox.Show("start2");
            Ecan.CAN_OBJ[] recbusinfo2, recbusinfo3;
            Ecan.CAN_OBJ sendbusinfo1 = new Ecan.CAN_OBJ();
            Ecan.CAN_OBJ sendbusinfo2 = new Ecan.CAN_OBJ();
            string ccdata = "00";
            recbusinfo2 = new Ecan.CAN_OBJ[1];
            recbusinfo3 = new Ecan.CAN_OBJ[1];
            sendbusinfo1.SendType = 0; sendbusinfo1.data = new byte[8]; sendbusinfo1.Reserved = new byte[3]; sendbusinfo1.RemoteFlag = 0; sendbusinfo1.ExternFlag = 1;
            sendbusinfo1.DataLen = Convert.ToByte(0);
            int tlen = sendbusinfo1.DataLen - 1, ican;

            for (ican = 0; ican <= tlen; ican++)
            { sendbusinfo1.data[ican] = Convert.ToByte(ccdata.Substring(0 + ican * 2, 2), 0X10); }
            sendbusinfo1.ID = Convert.ToUInt32("60C2110", 16);//1

            sendbusinfo2.SendType = 0; sendbusinfo2.data = new byte[8]; sendbusinfo2.Reserved = new byte[3]; sendbusinfo2.RemoteFlag = 0; sendbusinfo2.ExternFlag = 1;
            sendbusinfo2.DataLen = Convert.ToByte(0);
            tlen = sendbusinfo2.DataLen - 1;

            for (ican = 0; ican <= tlen; ican++)
            { sendbusinfo2.data[ican] = Convert.ToByte(ccdata.Substring(0 + ican * 2, 2), 0X10); }
            sendbusinfo2.ID = Convert.ToUInt32("60C2110", 16);

            if (chart1.InvokeRequired == false)
            {

                Dictionary<string, CheckBox> checkboxList = new Dictionary<string, CheckBox>();
                List<int> txData2 = new List<int>();// { 2011, 2012, 2013, 2014, 2015, 2016 };
                List<int> tyData2 = new List<int>();
                List<int> txData3 = new List<int>();// { 2011, 2012, 2013, 2014, 2015, 2016 };
                List<int> tyData3 = new List<int>();
                List<int> txData = new List<int>();
                List<int> tyData = new List<int>();
                int ibuf;
                foreach (Control item in this.Controls)
                {
                    if (item.GetType() == typeof(System.Windows.Forms.CheckBox) && item.Name.StartsWith("checkBox"))
                        checkboxList.Add(item.Name, (CheckBox)item);

                }
                do
                {
                    cansend2(sendbusinfo1, out recbusinfo2, 1);
                    cansend2(sendbusinfo2, out recbusinfo3, 1);
                    // this.chart1.DataSource = list;
                    // list.Add(new ChartTestData(i));
                    //list2.Add(new ChartTestData(i));
                    // { 9, 6, 7, 4, 5, 4 };
                      /*  for (ibuf = 1; ibuf < 9; ibuf++)
                        {
                        string actual_test = "checkBox" + ibuf.ToString();
                        if ((ibuf % 2 != 0) && (ibuf != 7))
                            {
                            if (checkboxList[actual_test].Checked == true)
                            {
                                txData[ibuf - 1].Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                                tyData[ibuf - 1].Add(hextodec(recbusinfo2[0].data[ibuf].ToString("X2") + recbusinfo2[0].data[ibuf - 1].ToString("X2")));
                                chart1.Series[ibuf - 1].Points.DataBindXY(txData[ibuf - 1], tyData[ibuf - 1]);
                            }
                            }
                            if ((ibuf % 2 == 0) && (ibuf != 8))
                            {
                                txData[ibuf - 1].Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                                tyData[ibuf - 1].Add(hextodec(recbusinfo3[0].data[ibuf - 1].ToString("X2") + recbusinfo3[0].data[ibuf - 2].ToString("X2")));
                                chart1.Series[ibuf - 1].Points.DataBindXY(txData[ibuf - 1], tyData[ibuf - 1]);
                            }

                        }
    
*/
                //    txData.Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                  //  tyData.Add(hextodec(recbusinfo2[0].data[1].ToString("X2") + recbusinfo2[0].data[0].ToString("X2")));
                    
                  //  chart1.Series[1].Points.DataBindXY(txData, tyData);//1
                 
                    //chart1.Series[1].Points.DataBind();

                    /*      txData2.Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                          tyData2.Add(hextodec(recbusinfo2[0].data[1].ToString("X2") + recbusinfo2[0].data[0].ToString("X2")));

                          chart1.Series[1].Points.DataBindXY(txData2, tyData2);//1

                          txData3.Add(int.Parse(sw.ElapsedMilliseconds.ToString()));
                             tyData3.Add(hextodec(recbusinfo3[0].data[1].ToString("X2") + recbusinfo3[0].data[0].ToString("X2")));

                            chart1.Series[0].Points.DataBindXY(txData3, tyData3);
                    */


                    Delay(1);
                } while (flag == true);
            }
            else
            {
                // MessageBox.Show("Mid2");
                mydelegate mytest = new mydelegate(Thread2_Test);
                chart1.BeginInvoke(mytest);

            }




        }


     







        private  UInt32 hextodec(string ss)//hex transform bin then bin transform dec can transform negative number
        {
            UInt32  shi, actdata = 0;
            int i;
            long ww;
            string er1;
            string[] er;
            int leng, ix = 0;
            string erx = "";
            string erx2, erx4 = "";
            string[] erx3;
            erx3 = new string[16];
            er = new string[16];
            ww = Int32.Parse(ss, System.Globalization.NumberStyles.HexNumber);
            er1 = Convert.ToString(ww, 2);
            leng = er1.Length;
            if (leng < 16)
            {
                for (i = 0; i < 16 - leng; i++)
                {
                    er[i] = "0";
                }


                for (i = 16 - leng; i < 16; i++)
                {
                    er[i] = er1.Substring(ix, 1);
                    ix = ix + 1;
                    // MessageBox.Show(er[i]);
                }
                // MessageBox.Show("33");
            }
            else
            {

                for (i = 0; i < 16; i++)
                {
                    er[i] = er1.Substring(i, 1);
                }
            }

            if (er[0] == "1")
            {
                for (i = 0; i < 16; i++)
                {
                    erx = erx + er[i];
                }
                // MessageBox.Show(erx);
                shi = Convert.ToUInt32(erx, 2);
                shi = shi - 1;
                erx2 = Convert.ToString(shi, 2);
                for (i = 0; i < 16; i++)
                {
                    if (erx2.Substring(i, 1) == "1")
                    {
                        erx3[i] = "0";
                    }
                    if (erx2.Substring(i, 1) == "0")
                    {
                        erx3[i] = "1";
                    }
                }
                for (i = 0; i < 16; i++)
                {
                    erx4 = erx4 + erx3[i];
                }
                actdata = Convert.ToUInt32(erx4, 2);
                actdata = 0 - actdata;


            }
            if (er[0] == "0")
            {
                for (i = 0; i < 16; i++)
                {
                    erx = erx + er[i];
                }
                actdata = Convert.ToUInt32(erx, 2);
            }
            return actdata;
        }

        private float StDev(float[] arrData) //计算标准偏差
        {
            float xSum = 0F;
            float xAvg = 0F;
            float sSum = 0F;
            float tmpStDev = 0F;
            int arrNum = arrData.Length;
            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }
            xAvg = xSum / arrNum;
            for (int j = 0; j < arrNum; j++)
            {
                sSum += ((arrData[j] - xAvg) * (arrData[j] - xAvg));
            }
            tmpStDev = Convert.ToSingle(Math.Sqrt((sSum / (arrNum - 1))).ToString());
            return tmpStDev;
        }

        private float Cp(float UpperLimit, float LowerLimit, float StDev)//计算cp
        {
            float tmpV = 0F;
            tmpV = UpperLimit - LowerLimit;
            return Math.Abs(tmpV / (6 * StDev));
        }
        private float Avage(float[] arrData)    //计算平均值
        {
            float tmpSum = 0F;
            for (int i = 0; i < arrData.Length; i++)
            {
                tmpSum += arrData[i];
            }
            return tmpSum / arrData.Length;
        }

        private float Max(float[] arrData)   //计算最大值
        {
            float tmpMax = 0;
            for (int i = 0; i < arrData.Length; i++)
            {
                if (tmpMax < arrData[i])
                {
                    tmpMax = arrData[i];
                }
            }
            return tmpMax;
        }

        private float Min(float[] arrData)  //计算最小值
        {
            float tmpMin = arrData[0];
            for (int i = 1; i < arrData.Length; i++)
            {
                if (tmpMin > arrData[i])
                {
                    tmpMin = arrData[i];
                }
            }
            return tmpMin;
        }

        private float CpkU(float UpperLimit, float Avage, float StDev)//计算CpkU
        {
            float tmpV = 0F;
            tmpV = UpperLimit - Avage;
            return tmpV / (3 * StDev);
        }
        private float CpkL(float LowerLimit, float Avage, float StDev) //计算CpkL
        {
            float tmpV = 0F;
            tmpV = Avage - LowerLimit;
            return tmpV / (3 * StDev);
        }
        private float Cpk(float CpkU, float CpkL)  //计算Cpk
        {
            return Math.Abs(Math.Min(CpkU, CpkL));
        }

        public float getR_value(float[] k_valuesTOO)
        {
            float min = k_valuesTOO[0];
            float max = k_valuesTOO[0];
            for (int i = 0; i < k_valuesTOO.Length; i++)
            {
                if (k_valuesTOO[i] < min){min = k_valuesTOO[i];}
                if (k_valuesTOO[i] > max){max = k_valuesTOO[i];}
            }
            return max - min;
        }


        private string canreceive2(out Ecan.CAN_OBJ[] resultobj, int count)
        {
            string canresult = "";
            Ecan.CAN_ERR_INFO errinfo;
            int workStationCount = count;
            int size = Marshal.SizeOf(typeof(Ecan.CAN_OBJ));
            IntPtr infosIntptr = Marshal.AllocHGlobal(size * workStationCount);
            resultobj = new Ecan.CAN_OBJ[workStationCount];

            //    MessageBox.Show(count.ToString());

            Delay(40);
            if (Ecan.Receive2(4, 0, 0, infosIntptr, (ushort)count, 10) == Ecan.ECANStatus.STATUS_OK) {/* MessageBox.Show(resultobj.ID.ToString("X"));*/ Delay(30); }
            else
            {
                Ecan.ReadErrInfo(4, 0, 0, out errinfo);
                canresult = "ReciveCanbus ErrCode:" + errinfo.ErrCode.ToString("X");
                //   for (int i = 0; i < 8; i++) { resultobj.data[i] = 0xFF; }
                // resultobj.ID = 268435455;
            }
            for (int inkIndex = 0; inkIndex < workStationCount; inkIndex++)
            {
                IntPtr ptr = (IntPtr)((UInt32)infosIntptr + inkIndex * size);
                resultobj[inkIndex] = (Ecan.CAN_OBJ)Marshal.PtrToStructure(ptr, typeof(Ecan.CAN_OBJ));
            }

            //   MessageBox.Show(resultobj[0].ID.ToString());
            // MessageBox.Show(resultobj[1].ID.ToString());
            Ecan.ClearCanbuf(4, 0, 0);
            Delay(30);
            return canresult;
        }

        private string cansend2(Ecan.CAN_OBJ caninfo, out Ecan.CAN_OBJ[] resultobj, int count)
        {
            string canresult = "";
            Ecan.CAN_ERR_INFO errinfo;
            int workStationCount = count;
            int size = Marshal.SizeOf(typeof(Ecan.CAN_OBJ));
            IntPtr infosIntptr = Marshal.AllocHGlobal(size * workStationCount);
            resultobj = new Ecan.CAN_OBJ[workStationCount];
            //resultobj = new Ecan.CAN_OBJ[count];
            try
            {
                if (Ecan.Transmit(4, 0, 0, ref caninfo, (ushort)1) != Ecan.ECANStatus.STATUS_OK)
                {
                    Ecan.ReadErrInfo(4, 0, 0, out errinfo);
                    canresult = "SendCanBus ErrCode:" + errinfo.ErrCode.ToString("X");
                    // for (int i = 0; i < 8; i++) { resultobj.data[i] = 0xFF; }
                    // resultobj.ID = 268435455;

                }
                else
                {
                    // if (canmodel == "HW Status") { Delay(13000); }
                    Delay(40);
                    if (Ecan.Receive2(4, 0, 0, infosIntptr, (ushort)count, 10) == Ecan.ECANStatus.STATUS_OK) {/* MessageBox.Show(resultobj.ID.ToString("X"));*/ Delay(30); }
                    else
                    {
                        Ecan.ReadErrInfo(4, 0, 0, out errinfo);
                        canresult = "ReciveCanbus ErrCode:" + errinfo.ErrCode.ToString("X");
                        //  for (int i = 0; i < 8; i++) { resultobj.data[i] = 0xFF; }
                        // resultobj.ID = 268435455;
                    }
                    for (int inkIndex = 0; inkIndex < workStationCount; inkIndex++)
                    {
                        IntPtr ptr = (IntPtr)((UInt32)infosIntptr + inkIndex * size);
                        resultobj[inkIndex] = (Ecan.CAN_OBJ)Marshal.PtrToStructure(ptr, typeof(Ecan.CAN_OBJ));
                    }

                }

            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
            Ecan.ClearCanbuf(4, 0, 0);







            return canresult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw = System.Diagnostics.Stopwatch.StartNew();
            flag = true;
            Delay(500);
            string ccdata;int tlen,ican;
            Ecan.CAN_OBJ[] recbusinfo2;
            Ecan.CAN_OBJ sendbusinfo = new Ecan.CAN_OBJ();
            recbusinfo2 = new Ecan.CAN_OBJ[2];
            canreceive2(out recbusinfo2, 2);
            sendbusinfo.SendType = 0; sendbusinfo.data = new byte[8]; sendbusinfo.Reserved = new byte[3]; sendbusinfo.RemoteFlag = 0; sendbusinfo.ExternFlag = 1;
            sendbusinfo.DataLen = Convert.ToByte(8);
            tlen = sendbusinfo.DataLen - 1;
            ccdata = "0000000000000000";
            for (ican = 0; ican <= tlen; ican++)
            { sendbusinfo.data[ican] = Convert.ToByte(ccdata.Substring(0 + ican * 2, 2), 0X10);  }
            sendbusinfo.ID = Convert.ToUInt32("4052010", 16);
            cansend2(sendbusinfo, out recbusinfo2, 1);
            Delay(300);
            sendbusinfo.ID = Convert.ToUInt32("4052110", 16);
            cansend2(sendbusinfo, out recbusinfo2, 1);
            Delay(300);
            ccdata = "1027102701010101";
            for (ican = 0; ican <= tlen; ican++)
            { sendbusinfo.data[ican] = Convert.ToByte(ccdata.Substring(0 + ican * 2, 2), 0X10); }
            sendbusinfo.ID = Convert.ToUInt32("4062110", 16);
            cansend2(sendbusinfo, out recbusinfo2, 1);
            Delay(300);
         //   thread1 = new Thread(new ThreadStart(Thread_Test));
          //  thread1.Start();
            thread1 = new Thread(Thread_Test);
            //   thread1 = new Thread(new ThreadStart(Thread_Test));              
            thread1.IsBackground = true;
            thread1.Start();
           // thread2 = new Thread(Thread2_Test);
            //   thread1 = new Thread(new ThreadStart(Thread_Test));              
         //   thread2.IsBackground = true;
           // thread2.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw.Stop();
            flag = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ChartImageFormat format = ChartImageFormat.Bmp;

                if (sfd.FileName.EndsWith("bmp"))
                {
                    format = ChartImageFormat.Bmp;
                }
                else if (sfd.FileName.EndsWith("jpg"))
                {
                    format = ChartImageFormat.Jpeg;
                }
                else if (sfd.FileName.EndsWith("emf"))
                {
                    format = ChartImageFormat.Emf;
                }
                else if (sfd.FileName.EndsWith("gif"))
                {
                    format = ChartImageFormat.Gif;
                }
                else if (sfd.FileName.EndsWith("png"))
                {
                    format = ChartImageFormat.Png;
                }
                else if (sfd.FileName.EndsWith("tif"))
                {
                    format = ChartImageFormat.Tiff;
                }
            

                // Save image
                chart1.SaveImage(sfd.FileName, format);
            }

        }

        

        public float getCPK(float[] k, float UpperLimit, float LowerLimit) //获取CPK值
        {

            if (k.Length <= 1 || UpperLimit <= LowerLimit)  {return -1;}
            float cpk = Cpk(CpkU(UpperLimit, Avage(k), StDev(k)), CpkL(LowerLimit, Avage(k), StDev(k)));
            return cpk;
        }

























    }
}
