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
        Point startPoint  ,endPoint;
        public int number { get; set; }
        public Color tempColor { get; set; }
        public Point[] curvePoints;
        public Edge(float xStart, float yStart, float xEnd, float yEnd, int num)
        {
            FillColor = Color.Black;
            this.xStart = xStart;
            this.yStart = yStart;   
            this.xEnd = xEnd;
            this.yEnd = yEnd;
            this.number = num;
            this.tempColor = Color.Black;
            Point startPoint = new Point((int)xStart, (int)yStart);
            Point endPoint = new Point((int)xEnd, (int)yEnd);
            curvePoints = new Point[] { startPoint, endPoint };
        }

        public Color FillColor { get; set; }
        public Point Center { get; set; }
        public int Radious { get; set; }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddCurve(curvePoints);
            return path;
        }

        public bool HitTest(Point p)
        {
            var result = false;
            Pen pen = new Pen(Color.Black, 4);
            using (var path = GetPath())
                result = path.IsOutlineVisible(p.X, p.Y, pen);
            return result;
        }
        public void Draw(Graphics g)
        {
            
            Pen pen = new Pen(Color.Black, 4);
         //   Point midPoint = new Point((int)(xEnd - xStart), (int)(yEnd - yStart) + 10);
            curvePoints = new Point[] { startPoint, midPoint, endPoint };

            using (var path = GetPath())

                g.DrawCurve(pen, curvePoints);
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
            int index = 0;
            foreach (Point point in curvePoints)
            {
                if (point.X != this.xStart && point.Y != this.yStart)
                {
                    if (Math.Abs(p.X - xStart) < Math.Abs(point.X - xStart) && Math.Abs(p.Y - yStart) < Math.Abs(point.Y - yStart))
                    {
                        break;
                    }
                }
                else if (point.X == this.xEnd && point.Y == this.yEnd)
                {
                    break;
                }
                index++;
            }
            Point[] tempPoints = new Point[curvePoints.Length + 1];
            Boolean insertedCenter = false;
            for (int i = 0; i < tempPoints.Length; i++)
            {
                if (i == index)
                {
                    tempPoints[i] = Center;
                    insertedCenter = true;
                }
                else
                {
                    if (insertedCenter)
                    {
                        tempPoints[i] = curvePoints[i - 1];
                    }
                    else
                    {
                        tempPoints[i] = curvePoints[i];
                    }
                }
            }
            curvePoints = tempPoints;
        }

        public void restPoints()
        {
            Point startPoint = new Point((int)xStart, (int)yStart);
            Point endPoint = new Point((int)xEnd, (int)yEnd);
            curvePoints = new Point[] { startPoint, endPoint };
        }

    }
}
