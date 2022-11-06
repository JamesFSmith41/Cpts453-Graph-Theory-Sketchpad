using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPTS453_Sketchpad
{
    public partial class Form1 : Form
    {
        int clickX;
        int clickY;
        bool addVertex, delete, addEdge;
        int counter;
        Timer timer;
        int verts;
        int edges;
        Dictionary<int, List<int>> vertEdgePairs;
        Color color;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer1_Tick);
            verts = 0;
            addVertex = false;
            delete = false;
            addEdge = false;
            vertEdgePairs = new Dictionary<int, List<int>>();
            color = Color.Black;
            /*dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Test";
            dataGridView1.Rows[1].Cells[1].Value = 12;*/
            //dataGridView1.Rows.Add(row);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentActionTxt.Text = "none";
            numOfVerts.Text = verts.ToString();
            drawingSurface1.vertEdgePairChanged += this.updateVertexEdgePair;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            drawingSurface1.Invalidate();
            counter = counter + 1;
            timerTxt.Text = "Total Frames: " + counter.ToString();
        }

        private void panel_click(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            clickX = p.X;
            clickY = p.Y;
            lastXPos.Text = clickX.ToString();
            lastYPos.Text = clickY.ToString();
            if (addVertex)
            {
               drawingAddVertex();
               verts++;
                numOfVerts.Text = verts.ToString();
            }
            panel1.Invalidate();
        }
        private void addVertex_Click(object sender, EventArgs e)
        {
            if (!addVertex)
            {
                buttonSwitch(0);
            }
            else
            {
                addVertex = false;
                currentActionTxt.Text = "None";
                addVertexBtn.BackColor = Color.Transparent;
            }
            
        }

        private void buttonSwitch(int button)
        {
            switch(button)
            {
                case 0:
                    addVertex = true;
                    currentActionTxt.Text = "Add Vertex";
                    addVertexBtn.BackColor = Color.Gray;
                    delete = false;
                    drawingSurface1.delete = false;
                    deleteBtn.BackColor = Color.Transparent;
                    addEdge = false;
                    drawingSurface1.createEdge = false;
                    addEdgeBtn.BackColor = Color.Transparent;
                    drawingSurface1.clearTempShapes();
                    break;
                case 1:
                    delete = true;
                    drawingSurface1.delete = true;
                    currentActionTxt.Text = "Delete";
                    deleteBtn.BackColor = Color.Gray;
                    addVertex = false;
                    addVertexBtn.BackColor = Color.Transparent;
                    addEdge = false;
                    drawingSurface1.createEdge = false;
                    addEdgeBtn.BackColor = Color.Transparent;
                    drawingSurface1.clearTempShapes();
                    break;
                case 2:
                    addEdge = true;
                    drawingSurface1.createEdge = true;
                    currentActionTxt.Text = "Add Edge";
                    addEdgeBtn.BackColor = Color.Gray;
                    addVertex = false;
                    addVertexBtn.BackColor = Color.Transparent;
                    delete = false;
                    drawingSurface1.delete = false;
                    deleteBtn.BackColor = Color.Transparent;
                    drawingSurface1.clearTempShapes();
                    break;
                case 3:
                    addEdge = false;
                    drawingSurface1.createEdge = false;
                    currentActionTxt.Text = "None";
                    addEdgeBtn.BackColor = Color.Transparent;
                    addVertex = false;
                    addVertexBtn.BackColor = Color.Transparent;
                    delete = false;
                    drawingSurface1.delete = false;
                    deleteBtn.BackColor = Color.Transparent;
                    drawingSurface1.clearTempShapes();
                    break;
                case 4:

                    addEdge = false;
                    drawingSurface1.createEdge = false;
                    currentActionTxt.Text = "Change Color";

                    addEdgeBtn.BackColor = Color.Transparent;
                    addVertex = false;
                    addVertexBtn.BackColor = Color.Transparent;

                    delete = false;
                    drawingSurface1.delete = false;
                    deleteBtn.BackColor = Color.Transparent;

                    colorBtn.BackColor = Color.Gray;

                    drawingSurface1.clearTempShapes();
                    break;



            }
        }
        private void drawingAddVertex()
        {
            drawingSurface1.AddShape(clickX, clickY, color);
        }

        private void clearDrawingBtn_Click(object sender, EventArgs e)
        {
            drawingSurface1.clearDrawing();
            verts = 0;
            addVertex = false;
            delete = false;
            addEdge = false;
            buttonSwitch(3);
        }


        private void deleteVertexBtn_Click(object sender, EventArgs e)
        {
            if (!delete)
            {
                buttonSwitch(1);

            }
            else
            {
                delete = false; 
                currentActionTxt.Text = "None";
                deleteBtn.BackColor = Color.Transparent;
                drawingSurface1.createEdge=false;
                drawingSurface1.delete = false;
            }

        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
                drawingSurface1.updateColor(color);
            }
           

        }

        private void addEdgeBtn_Click(object sender, EventArgs e)
        {
            if (!addEdge)
            {
                buttonSwitch(2);

            }
            else
            {
                addEdge = false;
                currentActionTxt.Text = "None";
                addEdgeBtn.BackColor = Color.Transparent;
                drawingSurface1.createEdge = false;
                drawingSurface1.clearTempShapes();
            }
        }

        private void updateVertexEdgePair(object sender, EventArgs e)
        {
            //vertEdgePairs = new Dictionary<int, List<int>>();
            vertEdgePairs = drawingSurface1.getVertEdgePairs();
            dataGridView1.Rows.Clear();

            foreach (int vertex in vertEdgePairs.Keys)
            {
                String edgeStr = "";
                foreach (int edge in vertEdgePairs[vertex])
                {
                    edgeStr += edge.ToString();
                    edgeStr += " ";
                }
                dataGridView1.Rows.Add(vertex, edgeStr);
            }
        }
    }
}
