using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace CPTS453_Sketchpad
{
    public class Edge : IShape
    {
        public float xStart, yStart, xEnd, yEnd;
        public Edge(float xStart, float yStart, float xEnd, float yEnd)
        {
            FillColor = Color.Red;
            this.xStart = xStart;
            this.yStart = yStart;   
            this.xEnd = xEnd;
            this.yEnd = yEnd;
        }
        public Color FillColor { get; set; }
        public Point Center { get; set; }
        public int Radious { get; set; }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddLine(xStart, yStart, xEnd, yEnd);
            return path;
        }

        public bool HitTest(Point p)
        {
            var result = false;
            using (var path = GetPath())
                result = path.IsVisible(p);
            return result;
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 4);
            using (var path = GetPath())
                g.DrawPath(pen, path);
        }
        public void Move(float xStart, float yStart, float xEnd, float yEnd)
        {
            this.xStart = xStart;
            this.yStart = yStart; 
            this.xEnd = xEnd;
            this.yEnd = yEnd;
        }

        public void Move(Point p)
        {

        }

    }
}
