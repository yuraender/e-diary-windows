using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace E_Diary_for_Windows.Utils {
    public class Captcha {

        private string[] fontNames = new string[] {
            "Comic Sans MS",
            "Arial",
            "Times New Roman",
            "Georgia",
            "Verdana",
            "Geneva"
        };
        private FontStyle[] fontStyles = new FontStyle[] {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline
        };
        private HatchStyle[] hatchStyles = new HatchStyle[] {
            HatchStyle.BackwardDiagonal, HatchStyle.Cross,
            HatchStyle.DashedDownwardDiagonal, HatchStyle.DashedHorizontal,
            HatchStyle.DashedUpwardDiagonal, HatchStyle.DashedVertical,
            HatchStyle.DiagonalBrick, HatchStyle.DiagonalCross,
            HatchStyle.Divot, HatchStyle.DottedDiamond, HatchStyle.DottedGrid,
            HatchStyle.ForwardDiagonal, HatchStyle.Horizontal,
            HatchStyle.HorizontalBrick, HatchStyle.LargeCheckerBoard,
            HatchStyle.LargeConfetti, HatchStyle.LargeGrid,
            HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal,
            HatchStyle.LightUpwardDiagonal, HatchStyle.LightVertical,
            HatchStyle.Max, HatchStyle.Min, HatchStyle.NarrowHorizontal,
            HatchStyle.NarrowVertical, HatchStyle.OutlinedDiamond,
            HatchStyle.Plaid, HatchStyle.Shingle, HatchStyle.SmallCheckerBoard,
            HatchStyle.SmallConfetti, HatchStyle.SmallGrid,
            HatchStyle.SolidDiamond, HatchStyle.Sphere, HatchStyle.Trellis,
            HatchStyle.Vertical, HatchStyle.Wave, HatchStyle.Weave,
            HatchStyle.WideDownwardDiagonal, HatchStyle.WideUpwardDiagonal, HatchStyle.ZigZag
        };
        private int[] fontEmSizes = new int[] { 15, 20, 25, 30, 35 };
        private Random random = new Random();

        public string ProcessRequest(Control control) {
            int width = 190;
            int height = 80;

            string captcha = random.Next(100000, 999999).ToString();
            control.Paint += (sender, e) => {
                Graphics graphics = e.Graphics;
                graphics.DrawImage(new Bitmap(width, height, PixelFormat.Format24bppRgb),
                    new Rectangle(0, 0, width, height),
                    RectangleF.Empty, GraphicsUnit.Pixel);

                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                Brush brush = new HatchBrush(hatchStyles[random.Next(hatchStyles.Length - 1)],
                    Color.FromArgb(random.Next(100, 255), random.Next(100, 255), random.Next(100, 255)),
                    Color.White);
                graphics.FillRectangle(brush, new RectangleF(0, 0, width, height));

                Matrix matrix = new Matrix();
                for (int i = 0; i <= captcha.Length - 1; i++) {
                    int x = width / (captcha.Length + 1) * i;
                    int y = height / 2;

                    matrix.Reset();
                    matrix.RotateAt(random.Next(-40, 40), new PointF(x, y));
                    graphics.Transform = matrix;

                    graphics.DrawString(captcha.Substring(i, 1),
                        new Font(fontNames[random.Next(fontNames.Length - 1)],
                            fontEmSizes[random.Next(fontEmSizes.Length - 1)],
                            fontStyles[random.Next(fontStyles.Length - 1)]),
                        new SolidBrush(
                            Color.FromArgb(random.Next(0, 100), random.Next(0, 100), random.Next(0, 100))),
                            x, random.Next(10, 40));
                    graphics.ResetTransform();
                }
            };

            return captcha;
        }
    }
}
