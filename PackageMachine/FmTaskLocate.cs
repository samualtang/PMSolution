using Functions.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Functions.PubFunction;
using Functions.Model;
using System.Threading;

namespace PackageMachine
{
    public partial class FmTaskLocate : Form
    {
        public FmTaskLocate()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            rts = new RobotTaskService();
            lblinfo.Text = "提示：定位会从指定的任务重新开始下发任务\r\n并且清空电控（倍速链，翻版，机器人）已缓存的任务数据！ ";
        }

        Group G7;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shpG7">PLC清空与暂停组</param>
        public FmTaskLocate(Group  shpG7)
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            rts = new RobotTaskService();
            G7 = shpG7;
            lblinfo.Text = "提示：定位会从指定的任务重新开始下发任务\r\n并且清空电控（倍速链，翻版，机器人）已缓存的任务数据！ ";
        }
        private delegate void HandleDelegate1(string info, Label label);
        public void updateLabel(string info, Label label)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new HandleDelegate1(updateLabel), new Object[] { info, label });
            }
            else
            {
                label.Text = info;

            }
        }
        RobotTaskService rts;
        decimal yxyRobot, yxyCigSeq, cgyFb, yxyBsul;
        private void btnDw_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRobot.Text + txtFb.Text))
            {
                return;
            } 
            string info = "";
            if (!string.IsNullOrWhiteSpace(txtFb.Text))
            {
                info += "翻版从" + txtFb.Text + " 包号开始";
                  cgyFb = txtFb.Text.CastTo<decimal>();
            } 
            if (!string.IsNullOrWhiteSpace(txtBsul.Text))
            {
                info += "\r\n倍速链从" + txtBsul.Text + " 包号开始";
                yxyBsul = txtBsul.Text.CastTo<decimal>();
            }
            if (!string.IsNullOrWhiteSpace(txtRobot.Text))
            {
                info += "\r\n异型烟机器人从" + txtRobot.Text + " 包号,第 " + txtCigseq.Text + " 条烟开始";
                  yxyRobot = txtRobot.Text.CastTo<decimal>();
                  yxyCigSeq = txtCigseq.Text.CastTo<decimal>();
            }
            DialogResult MsgBoxResult2 = MessageBox.Show(info,
                                                             "确认定位",
                                                             MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult.OK == MsgBoxResult2)
            {

                //DialogResult MsgBoxResult = MessageBox.Show(
                //                                        "定位后电控任务将会清除，可能会导致任务丢失！", //对话框的显示内容 
                //                                        "确定要定位任务?",//对话框的标题 
                //                                        MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                //                                        MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                //                                        MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (true)
                {
                   // FmInfo.GetTaskInfo("校验输入的包号是否存在...");
                    updateLabel("校验输入的包号是否存在...", lblOper);
                    if (rts.CheckPackageTaskNum(yxyRobot, yxyCigSeq, cgyFb, yxyBsul, out string errinfo))
                    {
                        //FmInfo.GetTaskInfo("校验通过！准备清空电控任务！");
                        updateLabel("校验通过！准备清空电控任务...", lblOper);
                        try
                        {
                            G7.Write(1, 0);//清空指令 常规烟翻版
                            G7.Write(yxyBsul, 2);//任务号 异型烟倍速链
                            G7.Write(1, 3);//清空指令 异型烟倍速链
                            Thread.Sleep(2000);//停顿两秒
                            if(G7.ReadD(0).CastTo(-1) == 0 && G7.ReadD(3).CastTo(-1) == 0)
                            {
                                //FmInfo.GetTaskInfo("电控任务清除成功！");
                                updateLabel("电控任务清除成功！", lblOper);
                            }
                            else
                            {
                                FmInfo.GetTaskInfo("电控任务清除失败，定位失败！");
                                updateLabel("电控任务清除失败，定位失败！", lblOper);
                                return;
                            }
                        }
                        catch (Exception ex )
                        { 
                            FmInfo.GetTaskInfo("电控任务清除失败，定位失败！错误："+ex.Message);
                        }
                       // FmInfo.GetTaskInfo("准备数据库进行定位..."  );
                        updateLabel("准备数据库进行定位...", lblOper);
                        if (rts.TaskLocate(yxyRobot, yxyCigSeq, cgyFb, yxyBsul))
                        {
                            updateLabel("定位成功！", lblOper);
                            MessageBox.Show("定位成功！"); 
                        }
                        else
                        {
                            updateLabel("定位失败！", lblOper);
                            MessageBox.Show("定位失败！"); 
                        }
                    }
                    else
                    {
                        FmInfo.GetTaskInfo("任务包号校验未通过：" + errinfo);
                        updateLabel("任务包号校验未通过：" + errinfo, lblOper);
                        MessageBox.Show(errinfo);
                    }
                
                }
            }
            else
            {
                MessageBox.Show("取消成功！", "任务定位", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


        }
    }
}
