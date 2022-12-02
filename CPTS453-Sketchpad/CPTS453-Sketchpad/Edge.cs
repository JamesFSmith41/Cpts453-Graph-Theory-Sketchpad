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
        Point startPoint  ,endPoint, midPoint;
        public int number { get; set; }
        public Color tempColor { get; set; }
        public Point[] curvePoints;
        bool isLoop;
        public Edge(float xStart, float yStart, float xEnd, float yEnd, int num, bool loop, Color color)
        {
            FillColor = color;
            this.xStart = xStart;
            this.yStart = yStart;   
            this.xEnd = xEnd;
            this.yEnd = yEnd;
            this.number = num;
            this.tempColor = Color.Black;
            startPoint = new Point((int)xStart, (int)yStart);
            endPoint = new Point((int)xEnd, (int)yEnd);
            curvePoints = new Point[] { startPoint, endPoint };
            isLoop = loop;
        }

        public Edge (float xStart, float yStart, int num, bool loop, Color color)
        {
            FillColor = color;
            tempColor = color;
            this.xStart = xStart;
            this.yStart = yStart;
            number = num;
            isLoop = loop;
            startPoint = new Point((int)xStart, (int)yStart);

            curvePoints = new Point[60];
            curvePoints[0] = startPoint;
            curvePoints[59] = startPoint;

            int x = 0;
            int y = 0;
            bool xPlus = false;
            bool yPlus = false;

            for (int i = 1; i < 59; i++)
            {
                curvePoints[i] = new Point(((int)(xStart + x)), ((int)(yStart + y)));

                if (x == -15)
                {
                    xPlus = true;
                }
                else if (x == 15)
                {
                    xPlus = false;
                }
                
                if (xPlus)
                {
                    x--;
                }
                else
                {
                    x++;
                }

                if (y == -30)
                {
                    yPlus = true;
                }
                else
                {
                    yPlus = false;
                }

                if(yPlus)
                {
                    y--;
                }
                else
                {
                    y++;
                }
            } 
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
            
            Pen pen = new Pen(FillColor, 4);
             if (isLoop)
            {
                curvePoints = new Point[60];
                curvePoints[0] = startPoint;
                curvePoints[59] = startPoint;

                int x = 0;
                int y = 0;

                for (int i = 1; i < 59; i++)
                {
                    curvePoints[i] = new Point(((int)(xStart + x)), ((int)(yStart + y)));

                    if (x == -15)
                    {
                        x++;
                    }
                    else if (x == 15)
                    {
                        x--;
                    }
                    else
                    {
                        x++;
                    }

                    if (y == -30)
                    {
                        y++;
                    }
                    else
                    {
                        y--;
                    }
                }
            }
            else
            {
                float xDif = (int)(xEnd - xStart) / 2;
                float yDif = (int)(yEnd - yStart) / 2;
                float lineDir = -0.5F;
                if (yDif < 0)
                {
                    lineDir = 0.5F;
                    yDif = yDif * -1;
                }

                lineDir = lineDir * (yDif / 10);
                midPoint = new Point((int)(xStart + xDif), (int)(yStart + lineDir + yDif));
                curvePoints = new Point[] { startPoint, midPoint, endPoint };

            }

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
            startPoint = new Point((int)xStart, (int)yStart);
            endPoint = new Point((int)xEnd, (int)yEnd);
            curvePoints = new Point[] { startPoint, endPoint };
        }

    }
}
