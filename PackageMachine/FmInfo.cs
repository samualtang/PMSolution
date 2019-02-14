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
    public partial class FmInfo : Form
    {
        public FmInfo()
        {
            InitializeComponent();
            GetTobaccoCache();
        }

        void GetTobaccoCache()
        {

            for (int i = 0; i < 3; i++)
            {
                PictureBox img = new PictureBox();
                //Random rd = new Random();
                img.Name = "ImgName" + Guid.NewGuid().ToString();
                img.Size = new System.Drawing.Size(60*i, 80*i);
                img.BorderStyle = BorderStyle.FixedSingle;
                img.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("开始任务");
                img.SizeMode = PictureBoxSizeMode.Zoom;
                img.BorderStyle = BorderStyle.FixedSingle;
                img.Location = new Point((PanelCache.Width-img.Width) -  i * img.Width, PanelCache.Height- img.Height);
                 
                PanelCache.Controls.Add(img);

            }

        }
    }
}
