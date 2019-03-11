using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
          
                AutoTxtChang();

          
          //  MessageBox.Show("");
            
            ////Functions.BLL.StackTypeCalculation.GetInfos();
            //int a = b % 36;
            //MessageBox.Show("a=" + a);
            //FmInfo.AutoRefreshShow( int.Parse(textBox1.Text),  int.Parse(textBox2.Text));  
        }
       async void AutoTxtChang()
        {
            while (true)
            {
                textBox2.Clear();
            

                textBox2.Text = "随机写入数字" + rd.Next(0, 1000);
                await    Task.Delay(5000);
            }
        }
        private    void button2_ClickAsync(object sender, EventArgs e)
        {
            try
            {

               GetTask() ;

                
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
          
         
        }

        async Task<int>GetTask()
        {
            var  a =   GET1() ;//等待这个方法执行完毕，才会往下执行，如果没有await 标记，就相当于同步方法，
            var b =    Get2() ;
            return a + b;
        }

        int GET1()
        {
            Thread.Sleep(2000);
            MessageBox.Show("get1");
            return 1;
        }

        int Get2()
        {
            Thread.Sleep(5000);
            MessageBox.Show("get2");
            return 2;
        }
        Random rd = new Random();
        async  void WritToTxt(string text)
        {
            await Task.Delay(5000);
            textBox1.Text  = text ;
       
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        
            TextBox tx = (TextBox)sender;
            if (tx.Text.Any())
            {
                listBox1.Items.Add(DateTime.Now.ToString() + ":事件开始");
                WritToTxt(tx.Text);
                listBox1.Items.Add(DateTime.Now.ToString()+ ":Textchange:"+tx.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.TextChanged -= textBox2_TextChanged;
            listBox1.Items.Add("停止文本改变事件");
        }
    }
}
