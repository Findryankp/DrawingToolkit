﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class RectangleState : StateDrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        public RectangleState()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public RectangleState(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public RectangleState(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
            }
        }

        public override void RenderOnPreview()
        {
            RenderOnStaticView();
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
            }
        }
    }
}