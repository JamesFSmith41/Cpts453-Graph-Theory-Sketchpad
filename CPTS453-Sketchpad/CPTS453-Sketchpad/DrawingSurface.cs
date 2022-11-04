using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CPTS453_Sketchpad
{
    public class DrawingSurface : Control
    {
        //public List<Vertex> vertexMap { get; private set; }

        Vertex selectedShape;
        Edge selectedEdge;
        Vertex shape1, shape2;
        public bool moving, createEdge, delete;
        bool createShape;
        Dictionary<Vertex, List<Edge>> vertexMap = new Dictionary<Vertex, List<Edge>>();
        Dictionary<Edge, Vertex[]> edgeMap = new Dictionary<Edge, Vertex[]>();

        Point previousPoint = Point.Empty;

        public DrawingSurface() 
        { 
            DoubleBuffered = true;
            vertexMap = new Dictionary<Vertex, List<Edge>>();
            createEdge = false;
            createShape = false;
            shape1 = null;
            shape2 = null;
        }

        public void AddShape(int x, int y)
        {
            createShape = true;
            vertexMap.Add(new Vertex(x,y, Color.Red), new List<Edge>());
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
                        break;
                    }
                }
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
                            Edge edge = new Edge(shape1.curX + 25, shape1.curY + 25, shape2.curX + 25, shape2.curY + 25);
                            shape1.hasEdges = true;
                            shape2.hasEdges = true;
                            Vertex[] vertices = new Vertex[2];
                            vertices[0] = shape1;
                            vertices[1] = shape2;
                            edgeMap.Add(edge, vertices);
                            vertexMap[shape1].Add(edge);
                            vertexMap[shape2].Add(edge);
                            clearTempShapes();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                        
                    }
                }
                catch (NullReferenceException ex)
                {

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
                                break;
                            }
                        }
                        shape1 = edgeMap[selectedEdge][0];
                        shape2 = edgeMap[selectedEdge][1];
                        vertexMap[shape1].Remove(selectedEdge);
                        vertexMap[shape2].Remove(selectedEdge);
                        edgeMap.Remove(selectedEdge);
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
                            foreach (Edge edge in edges)
                            {
                                shape1 = edgeMap[edge][0];
                                shape2 = edgeMap[edge][1];
                                if (vertexMap.ContainsKey(shape1))
                                {
                                    vertexMap[shape1].Remove(edge);
                                }
                                if (vertexMap.ContainsKey(shape2))
                                {
                                    vertexMap[shape2].Remove(edge);
                                }
                            }
                            for (int i = 0; i < edges.Count; i++)
                            {
                                edgeMap.Remove(edges[i]);
                            }
                        }
                        if (vertexMap.ContainsKey(selectedShape))
                        {
                            vertexMap.Remove(selectedShape);
                        }
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
                    }
                } catch (Exception ex)
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
                        }
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
                    } catch (Exception ex)
                    {

                    }
                    
                    selectedShape = null;
                    moving = false;
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
                shape1.FillColor = Color.Red;
            }
            if (shape2 != null)
            {
                shape2.FillColor = Color.Red;
            }
            shape1 = null;
            shape2 = null;
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
   
    }
}
