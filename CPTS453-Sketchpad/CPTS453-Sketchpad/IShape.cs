using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace CPTS453_Sketchpad
{
    public interface IShape
    {
 
        GraphicsPath GetPath();
        bool HitTest(Point p);
        void Draw(Graphics g);
        void Move(Point d);
        void Move(float xStart, float yStart, float xEnd, float yEnd);
    }
}
