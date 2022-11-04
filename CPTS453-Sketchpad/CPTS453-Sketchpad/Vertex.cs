using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace CPTS453_Sketchpad
{
    public class Vertex : IShape
    {
        List<Edge> edges { get; set; }
        public bool hasEdges { get; set; }
        public int curX { get; set; }
        public int curY { get; set; }

        public Vertex(int x, int y, Color color) { 
            FillColor = color;
            Radious = 25;
            Center = new Point(x, y);
            edges = new List<Edge>();
            hasEdges = false;
            curX = x;
            curY = y;
        }
        public Color FillColor { get; set; }
        public Point Center { get; set; }
        public int Radious { get; set; }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            var p = Center;
            p.Offset(-Radious, -Radious);
            path.AddEllipse(p.X, p.Y, 2 * Radious, 2 * Radious);
            curX = p.X;
            curY = p.Y;
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
            using (var path = GetPath())
            using (var brush = new SolidBrush(FillColor))
                g.FillPath(brush, path);
        }
        public void addEdge(Edge edge)
        {
            edges.Add(edge);
            hasEdges = true;
        }

        public void Move(Point d)
        {
            Center = new Point(Center.X + d.X, Center.Y + d.Y);
        }

        public void Move(float xStart, float yStart, float xEnd, float yEnd)
        {

        }
    }
}
