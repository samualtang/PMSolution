using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace General
{
    public class Loading
    {
        /// <summary>
        /// 设置完成提示
        /// </summary>
        private static string finshiInfo;
        /// <summary>
        /// 提示信息
        /// </summary>
        private static string titleInfo; 

        /// <summary>
        /// 设置完成提示
        /// </summary>
        public static string FinshiInfo
        {
            get
            {
                return "运行完成!";
            }

            set
            {
                finshiInfo = value;
            }
        }
        /// <summary>
        /// 提示信息
        /// </summary>
        public static string TitleInfo
        {
            get
            {
                return "载入中...";
            }

            set
            {
                titleInfo = value;
            }
        }

        /// <summary>
        /// 传入一个窗体，触发遮罩层的时候所有控件都禁止
        /// 
        /// </summary>
        /// <param name="f1">窗体</param>
        /// <param name="action">delegate () { 方法名(); }</param>
        public static async void Masklayer(Form f1, System.Action action)
        {

            //传入函数分支运行
            IAsyncResult result =  action.BeginInvoke(null, null); 
            //函数分支创建一个遮罩层  
            await MaskControls(f1, result);
         
        }
      
        /// <summary>
        /// 传入一个窗体，触发遮罩层的时候控件被禁止
        /// </summary>
        /// <param name="f1">窗体</param>
        /// <param name="control">控件</param>
        /// <param name="action">delegate () { 方法名(); }</param>
        public static async void Masklayer(Form f1,Control control, Action action)
        {

            //传入函数分支运行
            IAsyncResult result = action.BeginInvoke(null, null);
            //函数分支创建一个遮罩层  
            await Task.Run(()=> MaskControls(f1, result, control));

        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="result"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private static void MaskControls(Form f1, IAsyncResult result, Control control)
        {
            try
            {
                Label lb = new Label();
                lb.AutoSize = true;
                lb.Font = new System.Drawing.Font("宋体", 11F);
                lb.Location = new System.Drawing.Point(184, 14);
                lb.Name = "label_by_Mask";
                lb.Size = new System.Drawing.Size(115, 15);
                lb.Text = TitleInfo;

              

                Panel pl = new Panel();
                pl.Size = new System.Drawing.Size(497, 89);
                pl.Location = new System.Drawing.Point(f1.Size.Height / 2 - pl.Size.Height - 100, f1.Size.Width / 2 - pl.Size.Width / 2);
                pl.Name = "panel_By_Mask";
                pl.Controls.Add(lb);
                pl.BorderStyle = BorderStyle.Fixed3D;
                ProgressBar progressBar1 = new ProgressBar();
                progressBar1.Name = "probr_by_Mask";
                progressBar1.Size = new System.Drawing.Size(441, 23);
                progressBar1.TabIndex = 0;
                progressBar1.Visible = true;
               
                int x = (int)(0.5 * (f1.Width - progressBar1.Width));
                int y = progressBar1.Location.Y;
                progressBar1.Location = new System.Drawing.Point(x, y);
           
                pl.Controls.Add(progressBar1);
                pl.Visible = true;
                pl.Show();
                pl.BringToFront();
                f1.Controls.Add(pl);
            
                    control.Enabled = false;
           
       
                Control cn = f1.Controls.Find("panel_By_Mask", true)[0];
                cn.BringToFront();
                for (int i = 0; i <= progressBar1.Maximum; i++)
                {
                    progressBar1.Value = i;
                    if (i == progressBar1.Maximum)
                    {
                        progressBar1.Value = 0;
                        i = 0;
                    }
                    if (result.IsCompleted)
                    {
                        control.Enabled = true;
                        pl.Visible = false;
                        f1.Controls.Remove(pl);
                        MessageBox.Show(FinshiInfo, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 

        /// <summary>
        /// 遮罩层 
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static async Task   MaskControls(Form f1, IAsyncResult result)
        {
            try
            {
                int x = f1.Width / 2;
                int y = f1.Height / 2;
                Label lb = new Label();
                lb.AutoSize = true; 
                lb.Font = new System.Drawing.Font("微软雅黑", 11F);
                lb.Location = new System.Drawing.Point( x-200, y +10);
                lb.Name = "label_by_Mask";
                lb.Size = new System.Drawing.Size(115, 15);
                lb.Text = TitleInfo;
                
                ProgressBar progressBar1 = new ProgressBar();
             
                progressBar1.Location = new System.Drawing.Point(x - 441, y -23);
                progressBar1.Name = "probr_by_Mask";
                progressBar1.Size = new System.Drawing.Size(441, 23);
                progressBar1.TabIndex = 0;
                progressBar1.Visible = true; ;

                Panel pl = new Panel();
                pl.Size = new System.Drawing.Size(f1.Size.Width, f1.Size.Height);
              //  pl.Location = new System.Drawing.Point(f1.Size.Height / 2 - pl.Size.Height - 100, f1.Size.Width / 2 - pl.Size.Width / 2);
                 pl.Location = new System.Drawing.Point(0, 0);
                pl.Name = "panel_By_Mask";
                pl.Controls.Add(lb);
                pl.BorderStyle = BorderStyle.Fixed3D;
                pl.Controls.Add(progressBar1);
                pl.Visible = true;
                pl.Show();
                pl.BringToFront();
                f1.Controls.Add(pl);
                foreach (Control item in f1.Controls)
                {
                    item.Enabled = false;
                }
                Control cn = f1.Controls.Find("panel_By_Mask", true)[0];
                cn.BringToFront();
                for (int i = 0; i <= progressBar1.Maximum; i++)
                {
                    progressBar1.Value = i;
                    if (i == progressBar1.Maximum)
                    {
                        progressBar1.Value = 0;
                        i = 0;
                    }
                    if (result.IsCompleted)
                    {
                        foreach (Control item in f1.Controls)
                        {
                            item.Enabled = true;
                        }
                        pl.Visible = false;
                        f1.Controls.Remove(pl);
                       // MessageBox.Show( FinshiInfo, "提示",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                        break;
                    }
                    await Task.Delay(10);
                } 
            }
            catch (Exception ex )
            { 
                throw ex;
            }
        }
     
    }
}
