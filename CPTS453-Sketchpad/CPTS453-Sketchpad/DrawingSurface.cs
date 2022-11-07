using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CPTS453_Sketchpad
{
    public class DrawingSurface : Control
    {
        //public List<Vertex> vertexMap { get; private set; }

        public int vertexsCount, edgeCount;
        Vertex selectedShape;
        Edge selectedEdge;
        Vertex shape1, shape2;
        public bool moving, createEdge, delete;
        bool createShape;
        Dictionary<Vertex, List<Edge>> vertexMap = new Dictionary<Vertex, List<Edge>>();
        Dictionary<Edge, Vertex[]> edgeMap = new Dictionary<Edge, Vertex[]>();
        Dictionary<int, List<int>> vertEdgePairs;
        private EventHandler onValueChanged;
        EventArgs t;
        Point previousPoint = Point.Empty;
        Color color;

        public DrawingSurface() 
        { 
            DoubleBuffered = true;
            vertexMap = new Dictionary<Vertex, List<Edge>>();
            createEdge = false;
            createShape = false;
            shape1 = null;
            shape2 = null;
            vertEdgePairs = new Dictionary<int, List<int>>();
            vertexsCount = 0;
            edgeCount = 0;
            color = Color.Black;
        }

        public void AddShape(int x, int y, Color color)
        {
            createShape = true;
            vertexMap.Add(new Vertex(x,y, color, vertexsCount), new List<Edge>());
            vertexsCount++;
            OnValueChanged(t);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (createEdge)
            {
                foreach (Vertex v in vertexMap.Keys)
                {
                    if (v.HitTest(e.Location))
                    {
                        selectedShape = v;
                        try
                        {
                            if (shape1 == null)
                            {
                                shape1 = selectedShape;
                                shape1.FillColor = Color.Yellow;
                            }
                            else
                            {
                                try
                                {
                                    shape2 = selectedShape;
                                    shape2.FillColor = Color.Yellow;
                                    Edge edge = new Edge(shape1.curX + 25, shape1.curY + 25, shape2.curX + 25, shape2.curY + 25, edgeCount);
                                    shape1.hasEdges = true;
                                    shape2.hasEdges = true;
                                    Vertex[] vertices = new Vertex[2];
                                    vertices[0] = shape1;
                                    vertices[1] = shape2;
                                    edgeMap.Add(edge, vertices);
                                    vertexMap[shape1].Add(edge);
                                    vertexMap[shape2].Add(edge);
                                    clearTempShapes();
                                    edgeCount++;
                                    OnValueChanged(t);
                                }
                                catch (Exception ex)
                                {

                                }

                            }
                        }
                        catch (NullReferenceException ex)
                        {

                        }
                        break;

                    }
                }
            }
            else if (delete)
            {

                foreach (Vertex v in vertexMap.Keys)
                {
                    if (v.HitTest(e.Location))
                    {
                        selectedShape = v;
                        break;
                    }
                }
                
                if (selectedShape == null)
                {
                    try
                    {
                        foreach (Edge edge in edgeMap.Keys)
                        {
                            if (edge.HitTest(e.Location))
                            {
                                selectedEdge = edge;
                                shape1 = edgeMap[selectedEdge][0];
                                shape2 = edgeMap[selectedEdge][1];
                                vertexMap[shape1].Remove(selectedEdge);
                                vertexMap[shape2].Remove(selectedEdge);
                                edgeMap.Remove(selectedEdge);
                                edgeCount--;
                                OnValueChanged(t);
                                break;
                            }
                        }
                    } catch (NullReferenceException ex)
                    {

                    }
                    
                }
                else
                {
                    try
                    {
                        if (selectedShape.hasEdges)
                        {
                            List<Edge> edges = vertexMap[selectedShape];
                            edgeCount = edgeCount - edges.Count;
                            for (int i = 0; i <= edges.Count - 1; i++)
                            {
                                edgeMap.Remove(edges[i]);
                            } 
                        }
                        if (vertexMap.ContainsKey(selectedShape))
                        {
                            vertexMap.Remove(selectedShape);
                            vertexsCount--;
                        }
                        OnValueChanged(t);
                    } catch(Exception ex)
                    {

                    }
                    
                }
                clearTempShapes();
            }
            else
            {
                clearTempShapes();

                foreach (Vertex v in vertexMap.Keys)
                {
                    if (v.HitTest(e.Location))
                    {
                        selectedShape = v;
                        break;
                    }
                }
                try
                {
                    if (selectedShape != null)
                    {
                        moving = true;
                        previousPoint = e.Location;
                        selectedShape.FillColor = Color.Yellow;
                        if (selectedShape.hasEdges)
                        {
                            List<Edge> tempEdge = vertexMap[selectedShape];
                            foreach (Edge edge in tempEdge)
                            {
                                edge.restPoints();
                                if (edgeMap[edge][0] == selectedShape)
                                {
                                    edge.xStart = e.Location.X;
                                    edge.yStart = e.Location.Y;
                                }
                                else
                                {
                                    edge.xEnd = e.Location.X;
                                    edge.yEnd = e.Location.Y;
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (Edge edge in edgeMap.Keys)
                        {
                            if (edge.HitTest(e.Location))
                            {
                                selectedEdge = edge;
                                break;
                            }
                        }

                        if (selectedEdge != null)
                        {
                            moving = true;
                            previousPoint = e.Location;
                            selectedEdge.FillColor = Color.Yellow;

                        }
                    }

                }
                catch (Exception ex)
                {

                }
                
                base.OnMouseDown(e);
            }
            
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (moving)
            {
                try
                {
                    if (selectedShape != null)
                    {
                        var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                        selectedShape.Move(d);
                        previousPoint = e.Location;
                        if (selectedShape.hasEdges)
                        {
                            List<Edge> tempEdge = vertexMap[selectedShape];
                            foreach (Edge edge in tempEdge)
                            {
                                if (edgeMap[edge][0] == selectedShape)
                                {
                                    edge.xStart = e.Location.X;
                                    edge.yStart = e.Location.Y;
                                }
                                else
                                {
                                    edge.xEnd = e.Location.X;
                                    edge.yEnd = e.Location.Y;
                                }
                                edge.restPoints();
                            }
                        }
                    }
                    else if (selectedEdge != null)
                    {
                        Point d = new Point(e.X, e.Y);
                        selectedEdge.Move(d);
                        previousPoint = e.Location;
                    }
                    
                }
                catch (Exception ex)
                {

                }
                
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!createShape)
            {
                if (moving)
                {
                    try
                    {
                        if (selectedShape != null)
                        {
                            if (selectedShape.hasEdges)
                            {
                                List<Edge> tempEdge = vertexMap[selectedShape];
                                foreach (Edge edge in tempEdge)
                                {
                                    if (edgeMap[edge][0] == selectedShape)
                                    {
                                        edge.xStart = e.Location.X;
                                        edge.yStart = e.Location.Y;
                                    }
                                    else
                                    {
                                        edge.xEnd = e.Location.X;
                                        edge.yEnd = e.Location.Y;
                                    }
                                }
                            }
                            selectedShape.tempColor = color;
                            selectedShape.FillColor = color;
                            selectedShape = null;
                            moving = false;
                        }
                        else if (selectedEdge != null)
                        {
                            selectedEdge.tempColor = color;
                            selectedEdge.FillColor = color;
                            selectedEdge = null;
                            moving = false;
                        }
                        
                    } catch (Exception ex)
                    {

                    }
                    
                }
            }
            base.OnMouseUp(e);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (createShape == true)
            {
                createShape = false;
            }
            foreach (Vertex shape in vertexMap.Keys)
            {
                shape.Draw(e.Graphics);
            }

            foreach (Edge edge in edgeMap.Keys)
            {
                edge.Draw(e.Graphics);
            }
            
        }

        public void clearTempShapes()
        {
            if (shape1 != null)
            {
                shape1.FillColor = shape1.tempColor;
            }
            if (shape2 != null)
            {
                shape2.FillColor = shape2.tempColor;
            }
            shape1 = null;
            shape2 = null;
            selectedShape = null;
            selectedEdge = null;
        }

        public void clearDrawing()
        {
            DoubleBuffered = true;
            vertexMap = new Dictionary<Vertex, List<Edge>>();
            edgeMap = new Dictionary<Edge, Vertex[]>();
            createEdge = false;
            createShape = false;
            shape1 = null;
            shape2 = null;
            this.Invalidate();
        }

        private void getPairs()
        {
            vertEdgePairs = new Dictionary<int, List<int>>();
            foreach (Vertex v in vertexMap.Keys)
            {
                List<int> pairs = new List<int>();

                foreach (Edge e in vertexMap[v])
                {
                    pairs.Add(e.number);
                }
                vertEdgePairs.Add(v.number, pairs);
            }
        }
            
        public Dictionary<int, List<int>> getVertEdgePairs()
        {
            getPairs();
            return vertEdgePairs;
        }

        public event EventHandler vertEdgePairChanged;

        protected virtual void OnValueChanged(EventArgs e)
        {
            vertEdgePairChanged?.Invoke(this, e);
        }

        public void updateColor(Color color)
        {
            this.color = color;
            if (shape1 != null)
            {
                shape1.FillColor = color;
            }
        }

    }
}
