using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace GUI_luan_van
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label9.Text = "GRADUATE THESIS: OBJECT CLASSIFYING ARM ROBOT  USING DIGITAL IMAGE PROCESSING";
            label9.ForeColor = Color.Black;
            label11.Text = "Sinh viên: TRẦN ĐẶNG MẠNH HOÀNG   -    MSSV: 1511148";
            label11.ForeColor = Color.Black;
            label10.Text = "CONNECT";
            label10.ForeColor = Color.Red;
            label8.Text = "INFORMATION";
            label8.ForeColor = Color.Red;
            label12.Text = "STATISTIC";
            label12.ForeColor = Color.Red;
        }
        int intlen = 0;
        int so_vang_ngan = 0, so_vang_dai = 0, so_xanh_ngan = 0, so_xanh_dai = 0;


        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if(intlen!= ports.Length)
            {
                intlen = ports.Length;
                cbb_Select_Com.Items.Clear();
                for(int j=0;j< intlen;j++)
                {
                    cbb_Select_Com.Items.Add(ports[j]);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lb_Status.Text == "DISCONNECT")
            {
                Com.PortName = cbb_Select_Com.Text;
                Com.Open();
                lb_Status.Text = "CONNECT";
                button1.Text = "DISCONNECT";
            }
            else
            {
                Com.Close();
                lb_Status.Text = "DISCONNECT";
                button1.Text = "CONNECT";
            }
        }

        private void OnCom(object sender, SerialDataReceivedEventArgs e)
        {
            string s;
            s = Com.ReadExisting();
            
            Display(s);
            string[] arrListStr = s.Split('.');
            Display_chieu_dai(arrListStr[0]);
            Display_chieu_rong(arrListStr[1]);
            Display_tilexanh(arrListStr[2]);
            Display_tilevang(arrListStr[3]);
            Display_tileden(arrListStr[4]);
            if (arrListStr[5] == "1") { Display_phanloai("GREEN - LONG"); so_xanh_dai = so_xanh_dai + 1; }
            if (arrListStr[5] == "2") { Display_phanloai("GREEN - SHORT"); so_xanh_ngan = so_xanh_ngan + 1; }
            if (arrListStr[5] == "3") { Display_phanloai("YELLOW - LONG"); so_vang_dai = so_vang_dai + 1; }
            if (arrListStr[5] == "4") { Display_phanloai("YELLOW - SHORT"); so_vang_ngan = so_vang_ngan + 1; }
            Display_vang_ngan( so_vang_ngan.ToString());
            Display_vang_dai(so_vang_dai.ToString());
            Display_xanh_ngan(so_xanh_ngan.ToString());
            Display_xanh_dai(so_xanh_dai.ToString());
        }
        private delegate void DlDisplay(string s);
        private void Display(string s)
        {
            if(textBox1.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display);
                textBox1.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox1.Text = s; 
            }        
        }

        private void Display_chieu_dai(string s)
        {
            if (textBox2.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_chieu_dai);
                textBox2.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox2.Text ="             " + s;
            }
        }
        private void Display_chieu_rong(string s)
        {
            if (textBox2.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_chieu_rong);
                textBox3.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox3.Text = "             " + s;
            }
        }
        private void Display_tilevang(string s)
        {
            if (textBox4.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_tilevang);
                textBox4.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox4.Text = "             " + s;
            }
        }
        private void Display_tilexanh(string s)
        {
            if (textBox5.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_tilexanh);
                textBox5.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox5.Text = "             " + s;
            }
        }
        private void Display_tileden(string s)
        {
            if (textBox6.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_tileden);
                textBox6.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox6.Text = "             " + s;
            }
        }

        private void Display_phanloai(string s)
        {
            if (textBox11.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_phanloai);
                textBox11.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox11.Text = s;
            }
        }

        private void Display_vang_ngan(string s)
        {
            if (textBox7.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_vang_ngan);
                textBox7.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox7.Text = s;
            }
        }
        private void Display_vang_dai(string s)
        {
            if (textBox8.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_vang_dai);
                textBox8.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox8.Text = s;
            }
        }

        private void Display_xanh_ngan(string s)
        {
            if (textBox9.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_xanh_ngan);
                textBox9.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox9.Text = s;
            }
        }

        private void Display_xanh_dai(string s)
        {
            if (textBox10.InvokeRequired)
            {
                DlDisplay sd = new DlDisplay(Display_xanh_dai);
                textBox10.Invoke(sd, new object[] { s });
            }
            else
            {
                textBox10.Text = s;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
