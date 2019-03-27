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
    public partial class FmTaskLocate : Form
    {
        public FmTaskLocate()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void btnDw_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYxy.Text + txtFb.Text))
            {
                return;
            } 
            string info = "";
            if (!string.IsNullOrWhiteSpace(txtFb.Text))
            {
                info += "翻版从" + txtFb.Text + " 包号开始";
            }
            if (!string.IsNullOrWhiteSpace(txtYxy.Text))
            {
                info += "\r\n异型烟机器人从" + txtYxy.Text + "任务开始";
            }
            DialogResult MsgBoxResult2 = MessageBox.Show(info,
                                                             "确认定位",
                                                             MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult.OK == MsgBoxResult2)
            {

                DialogResult MsgBoxResult = MessageBox.Show(
                                                        "定位后电控任务将会清除，可能会导致任务丢失！", //对话框的显示内容 
                                                        "确定要定位任务?",//对话框的标题 
                                                        MessageBoxButtons.YesNo,//定义对话框的按钮，这里定义了YSE和NO两个按钮 
                                                        MessageBoxIcon.Question,//定义对话框内的图表式样，这里是一个黄色三角型内加一个感叹号 
                                                        MessageBoxDefaultButton.Button2);//定义对话框的按钮式样
                if (DialogResult.Yes == MsgBoxResult)
                {

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
