namespace CPTS453_Sketchpad
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addVertexBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.addEdgeBtn = new System.Windows.Forms.ToolStripButton();
            this.lastX = new System.Windows.Forms.RichTextBox();
            this.lastXPos = new System.Windows.Forms.RichTextBox();
            this.lastY = new System.Windows.Forms.RichTextBox();
            this.lastYPos = new System.Windows.Forms.RichTextBox();
            this.currentActionTxt = new System.Windows.Forms.RichTextBox();
            this.actionTxt = new System.Windows.Forms.RichTextBox();
            this.timerTxt = new System.Windows.Forms.RichTextBox();
            this.numOfFrames = new System.Windows.Forms.RichTextBox();
            this.numVerts = new System.Windows.Forms.RichTextBox();
            this.numOfVerts = new System.Windows.Forms.RichTextBox();
            this.drawingSurface1 = new CPTS453_Sketchpad.DrawingSurface();
            this.clearDrawingBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 360);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1458, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(168, 361);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(627, 19);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(627, 44);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVertexBtn,
            this.deleteBtn,
            this.addEdgeBtn,
            this.clearDrawingBtn});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(290, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addVertexBtn
            // 
            this.addVertexBtn.BackColor = System.Drawing.Color.Transparent;
            this.addVertexBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addVertexBtn.Image = ((System.Drawing.Image)(resources.GetObject("addVertexBtn.Image")));
            this.addVertexBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addVertexBtn.Name = "addVertexBtn";
            this.addVertexBtn.Size = new System.Drawing.Size(68, 22);
            this.addVertexBtn.Text = "Add Vertex";
            this.addVertexBtn.Click += new System.EventHandler(this.addVertex_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(44, 22);
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteVertexBtn_Click);
            // 
            // addEdgeBtn
            // 
            this.addEdgeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addEdgeBtn.Image = ((System.Drawing.Image)(resources.GetObject("addEdgeBtn.Image")));
            this.addEdgeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addEdgeBtn.Name = "addEdgeBtn";
            this.addEdgeBtn.Size = new System.Drawing.Size(62, 22);
            this.addEdgeBtn.Text = "Add Edge";
            this.addEdgeBtn.Click += new System.EventHandler(this.addEdgeBtn_Click);
            // 
            // lastX
            // 
            this.lastX.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastX.Location = new System.Drawing.Point(0, 633);
            this.lastX.Name = "lastX";
            this.lastX.ReadOnly = true;
            this.lastX.Size = new System.Drawing.Size(58, 31);
            this.lastX.TabIndex = 3;
            this.lastX.Text = "Last X ";
            // 
            // lastXPos
            // 
            this.lastXPos.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastXPos.Location = new System.Drawing.Point(64, 633);
            this.lastXPos.Name = "lastXPos";
            this.lastXPos.ReadOnly = true;
            this.lastXPos.Size = new System.Drawing.Size(126, 31);
            this.lastXPos.TabIndex = 4;
            this.lastXPos.Text = "";
            // 
            // lastY
            // 
            this.lastY.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastY.Location = new System.Drawing.Point(196, 633);
            this.lastY.Name = "lastY";
            this.lastY.ReadOnly = true;
            this.lastY.Size = new System.Drawing.Size(58, 31);
            this.lastY.TabIndex = 5;
            this.lastY.Text = "Last Y";
            // 
            // lastYPos
            // 
            this.lastYPos.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastYPos.Location = new System.Drawing.Point(260, 633);
            this.lastYPos.Name = "lastYPos";
            this.lastYPos.ReadOnly = true;
            this.lastYPos.Size = new System.Drawing.Size(126, 31);
            this.lastYPos.TabIndex = 6;
            this.lastYPos.Text = "";
            // 
            // currentActionTxt
            // 
            this.currentActionTxt.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentActionTxt.Location = new System.Drawing.Point(535, 633);
            this.currentActionTxt.Name = "currentActionTxt";
            this.currentActionTxt.ReadOnly = true;
            this.currentActionTxt.Size = new System.Drawing.Size(163, 31);
            this.currentActionTxt.TabIndex = 8;
            this.currentActionTxt.Text = "";
            // 
            // actionTxt
            // 
            this.actionTxt.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionTxt.Location = new System.Drawing.Point(403, 633);
            this.actionTxt.Name = "actionTxt";
            this.actionTxt.ReadOnly = true;
            this.actionTxt.Size = new System.Drawing.Size(126, 31);
            this.actionTxt.TabIndex = 9;
            this.actionTxt.Text = "Current Action";
            // 
            // timerTxt
            // 
            this.timerTxt.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerTxt.Location = new System.Drawing.Point(1428, 633);
            this.timerTxt.Name = "timerTxt";
            this.timerTxt.ReadOnly = true;
            this.timerTxt.Size = new System.Drawing.Size(198, 31);
            this.timerTxt.TabIndex = 10;
            this.timerTxt.Text = "";
            // 
            // numOfFrames
            // 
            this.numOfFrames.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfFrames.Location = new System.Drawing.Point(1260, 633);
            this.numOfFrames.Name = "numOfFrames";
            this.numOfFrames.ReadOnly = true;
            this.numOfFrames.Size = new System.Drawing.Size(162, 31);
            this.numOfFrames.TabIndex = 11;
            this.numOfFrames.Text = "Total Frames";
            // 
            // numVerts
            // 
            this.numVerts.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVerts.Location = new System.Drawing.Point(715, 633);
            this.numVerts.Name = "numVerts";
            this.numVerts.ReadOnly = true;
            this.numVerts.Size = new System.Drawing.Size(159, 31);
            this.numVerts.TabIndex = 12;
            this.numVerts.Text = "Number of Vertices";
            // 
            // numOfVerts
            // 
            this.numOfVerts.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfVerts.Location = new System.Drawing.Point(880, 633);
            this.numOfVerts.Name = "numOfVerts";
            this.numOfVerts.ReadOnly = true;
            this.numOfVerts.Size = new System.Drawing.Size(126, 31);
            this.numOfVerts.TabIndex = 13;
            this.numOfVerts.Text = "";
            // 
            // drawingSurface1
            // 
            this.drawingSurface1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.drawingSurface1.Location = new System.Drawing.Point(0, 28);
            this.drawingSurface1.Name = "drawingSurface1";
            this.drawingSurface1.Size = new System.Drawing.Size(1452, 599);
            this.drawingSurface1.TabIndex = 7;
            this.drawingSurface1.Text = "drawingSurface1";
            this.drawingSurface1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_click);
            // 
            // clearDrawingBtn
            // 
            this.clearDrawingBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearDrawingBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearDrawingBtn.Image")));
            this.clearDrawingBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearDrawingBtn.Name = "clearDrawingBtn";
            this.clearDrawingBtn.Size = new System.Drawing.Size(73, 22);
            this.clearDrawingBtn.Text = "Clear Graph";
            this.clearDrawingBtn.Click += new System.EventHandler(this.clearDrawingBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1638, 676);
            this.Controls.Add(this.numOfVerts);
            this.Controls.Add(this.numVerts);
            this.Controls.Add(this.numOfFrames);
            this.Controls.Add(this.timerTxt);
            this.Controls.Add(this.actionTxt);
            this.Controls.Add(this.currentActionTxt);
            this.Controls.Add(this.drawingSurface1);
            this.Controls.Add(this.lastYPos);
            this.Controls.Add(this.lastY);
            this.Controls.Add(this.lastXPos);
            this.Controls.Add(this.lastX);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addVertexBtn;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.RichTextBox lastX;
        private System.Windows.Forms.RichTextBox lastXPos;
        private System.Windows.Forms.RichTextBox lastY;
        private System.Windows.Forms.RichTextBox lastYPos;
        private DrawingSurface drawingSurface1;
        private System.Windows.Forms.RichTextBox currentActionTxt;
        private System.Windows.Forms.RichTextBox actionTxt;
        private System.Windows.Forms.RichTextBox timerTxt;
        private System.Windows.Forms.RichTextBox numOfFrames;
        private System.Windows.Forms.RichTextBox numVerts;
        private System.Windows.Forms.RichTextBox numOfVerts;
        private System.Windows.Forms.ToolStripButton addEdgeBtn;
        private System.Windows.Forms.ToolStripButton clearDrawingBtn;
    }
}

