﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    partial class UiCanvasWindow
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
        private void InitializeComponent() {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UiCanvasWindow));
            this.SuspendLayout();
            // 
            // UiCanvasWindow
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(915, 637);
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4);
            this.Name = "UiCanvasWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Canvas";
            this.FormClosing += this.OnClose;
            this.Load += this.OnLoad;
            this.KeyDown += this.OnKeyDown;
            this.MouseDown += this.OnMouseDown;
            this.MouseMove += this.OnMouseMove;
            this.MouseUp += this.OnMouseUp;
            this.Resize += this.OnResize;
            this.ResumeLayout(false);
        }

        #endregion
    }
}