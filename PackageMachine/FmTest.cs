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
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            //string b =  textBox1.Text ;
            //bool result = true;
             
            //result = (b == "1");
            
            MessageBox.Show("");
            
            ////Functions.BLL.StackTypeCalculation.GetInfos();
            //int a = b % 36;
            //MessageBox.Show("a=" + a);
            //FmInfo.AutoRefreshShow( int.Parse(textBox1.Text),  int.Parse(textBox2.Text));  
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int a = await GetTask();
                MessageBox.Show("1" + a);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
         
        }

        async Task<int> GetTask()
        {
           
              await GetTask(); 
            return 1;
        }
    }
}
