﻿using DrawingToolkit.Tools;
using System.Windows.Forms;
using DrawingToolkit.Interfaces;
using DrawingToolkit.Tools;

namespace DrawingToolkit
{
    public partial class DrawingForm : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;

        public DrawingForm()
        {
            InitializeComponent();
           
            #region Canvas

            this.canvas = new Canvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);

            #endregion

            #region Toolbox

            this.toolbox = new Toolboxes();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);

            #endregion

            #region Tools
            this.toolbox.AddTool(new LineTool());
            //this.toolbox.AddTool(new SelectTool());
            //this.toolbox.AddTool(new RectangleTool());
            //this.toolbox.AddTool(new CircleTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
