﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Sequences
{
    public class ActivationBox : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        public int xTest;
        public int yTest;
        public int wTest;
        public int hTest;

        public ActivationBox()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public ActivationBox(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public ActivationBox(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void RenderOnPreview()
        {
            this.pen = new Pen(Color.Red);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
                drawLine();
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen = new Pen(Color.Blue);
            pen.Width = 1.5f;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
                drawLine();
            }
        }

        public override void RenderOnStaticView()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawRectangle(pen, X, Y, Width, Height);
                drawLine();
            }
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }

        public int x1;
        public int y1;
        public int x2;
        public int y2;

        public void drawLine()
        {
            x1 = (Width / 2) + X;
            y1 = Height + Y;
            y2 = Width * 2;

            Point sTest = new Point(x1, y1);
            Point eTest = new Point(x1, y2);
            this.Graphics.DrawLine(pen, sTest, eTest);
        }
    }
}
