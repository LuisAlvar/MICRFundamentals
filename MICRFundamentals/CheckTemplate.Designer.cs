
using CoreLogic.Structures;

namespace MICRFundamentals
{
    partial class CheckTemplate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
      
        /// <summary>
        /// 
        /// </summary>
        private CoreLogic.Layout.BorderLayout blayout = null;

        private double pVirtualWidth;
        private double pVirtualHeight;

        /// <summary>
        ///  Clean up any resources being used.
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

        private System.Windows.Forms.Label LeftMargin = null;
        private System.Windows.Forms.Label RightMargin = null;
        private System.Windows.Forms.Label BottomMargin = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            int resolWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            int resolHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            double screenDiag = 14.2;


            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            string fmtWidth = System.Configuration.ConfigurationManager.AppSettings["CheckWidth"];
            string fmtHeight = System.Configuration.ConfigurationManager.AppSettings["CheckHeight"];

            blayout = new CoreLogic.Layout.BorderLayout(resolWidth, resolHeight, screenDiag, double.Parse(fmtWidth), double.Parse(fmtHeight));
            pVirtualWidth = blayout.CalcualtePPM() * double.Parse(fmtWidth);
            pVirtualHeight = blayout.CalcualtePPM() * double.Parse(fmtHeight);

            this.ClientSize = new System.Drawing.Size((int)pVirtualWidth, (int)pVirtualHeight); 
            
            this.Text = "CheckTemplate";

            SetContextPlane();
        }

        public void SetContextPlane()
        {
            CoreLogic.Structures.Point LeftTop = new CoreLogic.Structures.Point(blayout.CalculateLeftMargin(), 0);
            this.LeftMargin = new System.Windows.Forms.Label();
            this.LeftMargin.Text = "";
            this.LeftMargin.Location = new System.Drawing.Point((int)LeftTop.X, (int)LeftTop.Y);
            this.LeftMargin.BackColor = System.Drawing.Color.Black;
            this.LeftMargin.BorderStyle = BorderStyle.Fixed3D;
            this.LeftMargin.Size = new System.Drawing.Size(1, (int)pVirtualHeight);

            CoreLogic.Structures.Point RightTop = new CoreLogic.Structures.Point(blayout.CalcualteRightMargin(), 0);
            this.RightMargin = new System.Windows.Forms.Label();
            this.RightMargin.Text = "";
            this.RightMargin.Location = new System.Drawing.Point((int)RightTop.X, (int)RightTop.Y);
            this.RightMargin.BackColor = System.Drawing.Color.Black;
            this.RightMargin.BorderStyle = BorderStyle.Fixed3D;
            this.RightMargin.Size = new System.Drawing.Size(1, (int)pVirtualHeight);

            CoreLogic.Structures.Point LeftBot = new CoreLogic.Structures.Point(blayout.CalculateLeftMargin(), blayout.CalculateClearAreaMargin());
            CoreLogic.Structures.Point RightBot = new CoreLogic.Structures.Point(blayout.CalcualteRightMargin(), blayout.CalculateClearAreaMargin());

            this.BottomMargin = new System.Windows.Forms.Label();
            this.BottomMargin.Text = "";
            this.BottomMargin.Location = new System.Drawing.Point((int)LeftBot.X, (int)LeftBot.Y);
            this.BottomMargin.BackColor = System.Drawing.Color.Black;
            this.BottomMargin.BorderStyle = BorderStyle.Fixed3D;
            this.BottomMargin.Size = new System.Drawing.Size((int)RightBot.X - (int)LeftBot.X, 1);

            this.Controls.Add(LeftMargin);
            this.Controls.Add(RightMargin);
            this.Controls.Add(BottomMargin);  
        }

        #endregion
    }
}