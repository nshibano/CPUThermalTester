using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CPUThermalTester
{
    public struct PointD
    {
        public double X;
        public double Y;
        public PointD(double x, double y) { X = x; Y = y; }
    }

    public struct RangeD
    {
        public double Begin;
        public double End;
        public RangeD(double begin, double end) { Begin = begin; End = end; }
    }

    public static class PlotTool
    {
        public static int PlotLeftMargin = 40;
        public static int PlotBottomMargin = 20;
        public static int PlotRightMargin = 20;
        public static int PlotTopMargin = 10;
        public static int XLabelOffset = 3;
        public static int YLabelOffset = 4;
        public static int DotSize = 5;
        public static int MarkerSize = 9;

        public static Color[] ColorTable =
        {
           Color.FromArgb(255, 0xFF, 0xA5, 0), // orange
           Color.FromArgb(255, 255, 255, 0), // yellow
           Color.FromArgb(255, 0, 255, 0), // green
           Color.FromArgb(255, 0, 255, 255), // cyan
           Color.FromArgb(255, 255, 0, 255), // purple
           Color.FromArgb(255, 255, 185, 185), // pink
           Color.FromArgb(255, 185, 255, 185), // light green
           Color.FromArgb(255, 185, 185, 255), // light blue
           Color.FromArgb(255, 160, 0, 0), // dark red
           Color.FromArgb(255, 160, 160, 0), // olive
           Color.FromArgb(255, 0, 128, 0), // dark green
           Color.FromArgb(255, 0, 160, 160), // dark cyan
           Color.FromArgb(255, 160, 0, 160), // dark purple
           Color.FromArgb(255, 0, 0, 255), // blue
        };

        public static Color ChooseColor(int i)
        {
            return ColorTable[i % ColorTable.Length];
        }

        public static bool Point_IsValid(Point p)
        {
            return !(p.X == Int32.MinValue);
        }

        public class Translator
        {
            readonly Rectangle PlotRectangle;
            readonly RangeD XRange;
            readonly RangeD YRange;
            readonly double KX;
            readonly double KY;

            public Translator(Rectangle plotRectangle, RangeD xRange, RangeD yRange)
            {
                PlotRectangle = plotRectangle;
                XRange = xRange;
                YRange = yRange;
                KX = plotRectangle.Width / (xRange.End - xRange.Begin);
                KY = plotRectangle.Height / (yRange.End - yRange.Begin);
            }

            public Point Translate(PointD p)
            {
                var x = PlotRectangle.Left + KX * (p.X - XRange.Begin);
                var y = PlotRectangle.Bottom - KY * (p.Y - YRange.Begin);
                if (-1e-4 < x && x < 1e4 && -1e4 < y && y < 1e4)
                {
                    return new Point((int)Math.Round(x), (int)Math.Round(y));
                }
                else
                {
                    return new Point(Int32.MinValue, 0);
                }
            }
        }

        public static StringFormat StringFormatTop = new StringFormat(StringFormat.GenericTypographic) { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
        public static StringFormat StringFormatRight = new StringFormat(StringFormat.GenericTypographic) { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Far };

        public static void Plot(
            Graphics g,
            Rectangle plotRectangle,
            float fontSize,
            Color lineColor,
            Color textColor,
            RangeD xRange,
            RangeD yRange,
            Tuple<double, string>[] xTics,
            Tuple<double, string>[] yTics,
            bool enableDots,
            Tuple<Color, PointD[]>[] data,
            PointD? marker)
        {
            var font = new Font("Consolas", fontSize, GraphicsUnit.Pixel);
            var linePen = new Pen(lineColor);
            var lineBrush = new SolidBrush(lineColor);
            var textBrush = new SolidBrush(textColor);

            g.DrawRectangles(linePen, new[] { plotRectangle });

            var ticLength = 3;
            var t = new Translator(plotRectangle, xRange, yRange);

            foreach (var tic in xTics)
            {
                var x = t.Translate(new PointD(tic.Item1, 0.0)).X;
                g.DrawString(tic.Item2, font, textBrush, new PointF(x, plotRectangle.Bottom + XLabelOffset), StringFormatTop);
                g.DrawLine(linePen, x, plotRectangle.Top, x, plotRectangle.Top + ticLength);
                g.DrawLine(linePen, x, plotRectangle.Bottom - ticLength, x, plotRectangle.Bottom);
            }

            foreach (var tic in yTics)
            {
                var y = t.Translate(new PointD(0, tic.Item1)).Y;
                g.DrawString(tic.Item2, font, textBrush, new PointF(plotRectangle.Left - YLabelOffset, y), StringFormatRight);
                g.DrawLine(linePen, plotRectangle.Left, y, plotRectangle.Left + ticLength, y);
                g.DrawLine(linePen, plotRectangle.Right - ticLength, y, plotRectangle.Right, y);
            }

            for (int i = 0; i < data.Length; i++)
            {
                var curve = Array.ConvertAll(data[i].Item2, t.Translate);

                Color color = data[i].Item1;

                using (var pen = new Pen(color))
                using (var brush = new SolidBrush(color))
                {
                    for (int j = 0; j < curve.Length; j++)
                    {
                        if (j != 0 && Point_IsValid(curve[j - 1]) && Point_IsValid(curve[j]))
                        {
                            g.DrawLine(pen, curve[j - 1], curve[j]);
                        }

                        if (enableDots && Point_IsValid(curve[j]))
                        {
                            g.FillRectangle(brush, new Rectangle(curve[j].X - DotSize / 2, curve[j].Y - DotSize / 2, DotSize, DotSize));
                        }
                    }
                }
            }

            if (marker.HasValue)
            {
                var p = t.Translate(marker.Value);
                if (Point_IsValid(p))
                {
                    g.DrawRectangles(Pens.White, new[] { new RectangleF(p.X - MarkerSize / 2, p.Y - MarkerSize / 2, MarkerSize - 1, MarkerSize - 1) });
                }
            }

            font.Dispose();
            linePen.Dispose();
            lineBrush.Dispose();
            textBrush.Dispose();
        }
    }
}
