using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            CheckForIllegalCrossThreadCalls = false;
         
          
            
            listBtn.Add(bt5);
            listBtn.Add(bt4);
            listBtn.Add(bt3);
            listBtn.Add(bt2);
            listBtn.Add(bt1);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
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
        List<Button> listBtn = new List<Button>();
        Queue queue = new Queue();
       async void AutoTxtChang()
        {
            while (true)
            {
                textBox2.Clear();
            

                textBox2.Text = "随机写入数字" + rd.Next(0, 1000);
                await    Task.Delay(5000);
            }
        }
        void get(Queue queue)
        {
            int index = queue.Count;
            var newque = queue.ToArray();
            for (int i = index -1; i >= 0; i--)
            {
                listBtn[i].Text = newque[i].ToString();
            }
        }
        private    void button2_ClickAsync(object sender, EventArgs e)
        {

        //try
        //{
        //FuncTest()
         if (true)
            {
                MessageBox.Show(";;");
            }

          
            MessageBox.Show("" + func("哈哈哈"));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //} 


        }
        public Func<string  , int> func;

        int getFuncTest(string a )
        {

            return 0;
        }
      void FuncTest()
        {
         
            Task<int> task = new Task<int>(() =>
            {
                int sum = 0;
                listBox1.Items.Add("使用Task执行异步操作."); 
                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                    listBox1.Items.Add(sum);
                }
                return sum;
            });

            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
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
                Task.Run(() => TaskAsync(tx));
              
            }
        }
        async Task TaskAsync(TextBox tx)
        { 
            listBox1.Items.Add(DateTime.Now.ToString() + ":事件开始");
            Thread.Sleep(10000);
            WritToTxt(tx.Text);
            listBox1.Items.Add(DateTime.Now.ToString() + ":Textchange:" + tx.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.TextChanged -= textBox2_TextChanged;
            listBox1.Items.Add("停止文本改变事件");
        }

        private void FmTest_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            get(queue);
        }
    }
}
