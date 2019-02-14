using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PackageMachine.Code
{
	// Token: 0x0200004F RID: 79
	public class ImageHelper
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x00030448 File Offset: 0x0002E648
		public static Image GetBackImage(string ImageName)
		{
			Image result;
			try
			{
				string path = Application.StartupPath + "\\Data\\TobaccoImage\\";
				string[] files = Directory.GetFiles(path);
				foreach (string text in files)
				{
					if (text.Contains(ImageName))
					{
						return Image.FromFile(text);
					}
				}
				result = null;
			}
			catch (Exception ex)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000304D0 File Offset: 0x0002E6D0
		public static Image MakeThumbnail(Image originalImage, int width, int height, ThumbnailMode mode)
		{
			int num = width;
			int num2 = height;
			int x = 0;
			int y = 0;
			int num3 = originalImage.Width;
			int num4 = originalImage.Height;
			switch (mode)
			{
			case ThumbnailMode.UsrHeightWidthBound:
				if (originalImage.Width <= width && originalImage.Height <= height)
				{
					return originalImage;
				}
				if (originalImage.Width < width)
				{
					num = originalImage.Width;
				}
				if (originalImage.Height < height)
				{
					num2 = originalImage.Height;
				}
				break;
			case ThumbnailMode.UsrWidth:
				num2 = originalImage.Height * width / originalImage.Width;
				break;
			case ThumbnailMode.UsrWidthBound:
				if (originalImage.Width <= width)
				{
					return originalImage;
				}
				num2 = originalImage.Height * width / originalImage.Width;
				break;
			case ThumbnailMode.UsrHeight:
				num = originalImage.Width * height / originalImage.Height;
				break;
			case ThumbnailMode.UsrHeightBound:
				if (originalImage.Height <= height)
				{
					return originalImage;
				}
				num = originalImage.Width * height / originalImage.Height;
				break;
			case ThumbnailMode.Cut:
				if ((double)originalImage.Width / (double)originalImage.Height > (double)num / (double)num2)
				{
					num4 = originalImage.Height;
					num3 = originalImage.Height * num / num2;
					y = 0;
					x = (originalImage.Width - num3) / 2;
				}
				else
				{
					num3 = originalImage.Width;
					num4 = originalImage.Width * height / num;
					x = 0;
					y = (originalImage.Height - num4) / 2;
				}
				break;
			}
			Image image = new Bitmap(num, num2);
			Graphics graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.DrawImage(originalImage, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
			graphics.Dispose();
			return image;
		}
        public enum ThumbnailMode
        {
            // Token: 0x040002AE RID: 686
            UsrHeightWidth,
            // Token: 0x040002AF RID: 687
            UsrHeightWidthBound,
            // Token: 0x040002B0 RID: 688
            UsrWidth,
            // Token: 0x040002B1 RID: 689
            UsrWidthBound,
            // Token: 0x040002B2 RID: 690
            UsrHeight,
            // Token: 0x040002B3 RID: 691
            UsrHeightBound,
            // Token: 0x040002B4 RID: 692
            Cut,
            // Token: 0x040002B5 RID: 693
            NONE
        }
    }
}
