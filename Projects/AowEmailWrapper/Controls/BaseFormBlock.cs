﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AowEmailWrapper.Controls
{
    public class BaseFormBlock : UserControl
    {
        protected Control TheEditControl;
        protected Label TheLabel;
        protected bool resizing = false;

        protected override void OnResize(EventArgs e)
        {
            if (!resizing && TheEditControl != null && TheLabel != null)
            {
                try
                {
                    resizing = true;
                    this.SuspendLayout();

                    double dThirdUnit = this.Width / 3;
                    int iThirdUnit = (int)Math.Ceiling(dThirdUnit);
                    TheEditControl.Width = (int)(iThirdUnit * 2);

                    Size sz = new Size(iThirdUnit, int.MaxValue);
                    sz = TextRenderer.MeasureText(TheLabel.Text, TheLabel.Font, sz, TextFormatFlags.WordBreak);
                    this.Height = sz.Height;

                    base.OnResize(e);
                    this.ResumeLayout();
                }
                catch
                { }
                finally
                {
                    resizing = false;
                }
            }
        }

        protected void SetControls(Label theLabel, Control theEditControl)
        {
            TheLabel = theLabel;
            TheEditControl = theEditControl;

            this.MinimumSize = new Size(int.MinValue, 24);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseFormBlock
            // 
            this.Name = "BaseFormBlock";
            this.Size = new System.Drawing.Size(383, 46);
            this.ResumeLayout(false);

        }
    }
}
