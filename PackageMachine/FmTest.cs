using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackageMachine
{
    public partial class FmTest : Form
    {
        public FmTest()
        {
            InitializeComponent();
        }
       static  string OpcServer = "S7[UNCIONCONNCETION1]";
        private void button1_Click(object sender, EventArgs e)
        {
            GetRpyItem();

            FmInfo.AutoRefreshShow( int.Parse(textBox1.Text),  int.Parse(textBox2.Text));  
        }

        public static List<string> GetRpyItem()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(OpcServer + "DB30,REAL" + (i * 16));
                list.Add(OpcServer + "DB30,W" + (4 + (i * 16)));//X
                list.Add(OpcServer + "DB30,W" + (6 + (i * 16)));//Y
                list.Add(OpcServer + "DB30,W" +( 8 + (i * 16)));//Z
                list.Add(OpcServer + "DB30,W" + (10 + (i * 16)));//RX
                list.Add(OpcServer + "DB30,W" + (12 + (i * 16)));//RY
                list.Add(OpcServer + "DB30,W" + (14 + (i * 16)));//RY
            }
            list.Add(OpcServer + "DB30,W80");
            return list;
        }
    }
}
