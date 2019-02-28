using System;
using System.Drawing;
using System.Windows.Forms;

namespace PackageMachine.Code
{
	// Token: 0x02000036 RID: 54
	internal class ButtonCreator
	{
		// Token: 0x060002C5 RID: 709 RVA: 0x00021FE4 File Offset: 0x000201E4
		public static Button Create(Control parent, int index)
		{
			foreach (object obj in parent.Controls)
			{
				Control control = (Control)obj;
				if (control.Name == "btn_" + index.ToString())
				{
					return (Button)control;
				}
			}
			Button button = new Button();
			button.Location = new Point(200, 150);
			button.Name = "btn_" + index.ToString();
			button.Size = new Size(75, 23);
			button.Text = "button" + index;
			parent.Controls.Add(button);
			return button;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x000220EC File Offset: 0x000202EC
		public static int[][] GetSizeAndPosition(int width, int height, int marginLeft, int marginTop)
		{
			return ButtonCreator.GetSizeAndPosition(width, height, marginLeft, marginTop, 5, 5);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0002210C File Offset: 0x0002030C
		public static int[][] GetSizeAndPosition(int width, int height, int marginLeft, int marginTop, int lineCount, int coloumCount)
		{
			width -= 2 * marginLeft;
			height -= 2 * marginTop;
			int num = width / coloumCount;
			int num2 = height / lineCount;
			int num3 = lineCount * coloumCount;
			int[][] array = new int[num3][];
			int num4 = 0;
			for (int i = 0; i < lineCount; i++)
			{
				for (int j = 0; j < coloumCount; j++)
				{
					array[num4] = new int[]
					{
						num - 1,
						num2 - 5,
						marginLeft + j * num,
						marginTop + i * num2
					};
					num4++;
				}
			}
			return array;
		}
	}
}
