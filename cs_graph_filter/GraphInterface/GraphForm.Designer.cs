namespace GraphForm
{
	public partial class GraphingForm
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.gPanel = new GraphingPanel();
			this.GrpGraph = new System.Windows.Forms.GroupBox();
			this.GrpParameters = new System.Windows.Forms.GroupBox();
			this.GrpGraph.SuspendLayout();
			this.GrpParameters.SuspendLayout();
            this.SuspendLayout();


			this.gPanel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.gPanel.AutoScroll = true;
			this.gPanel.Location = new System.Drawing.Point(7, 17);
			this.gPanel.Name = "GraphicsPanel";
			this.gPanel.Size = new System.Drawing.Size(446, 446);
			this.gPanel.TabIndex = 0;
			this.gPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_Paint);


			this.GrpGraph.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.GrpGraph.Controls.Add(this.gPanel);
			this.GrpGraph.Location = new System.Drawing.Point(5, 5);
			this.GrpGraph.Name = "GrpGraph";
			this.GrpGraph.Size = new System.Drawing.Size(460, 470);
			this.GrpGraph.TabIndex = 1;
			this.GrpGraph.TabStop = false;
			this.GrpGraph.Text = "Graph";


			this.GrpParameters.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.GrpParameters.Location = new System.Drawing.Point(480, 5);
			this.GrpParameters.Name = "GrpGraph";
			this.GrpParameters.Size = new System.Drawing.Size(310, 470);
			this.GrpParameters.TabIndex = 2;
			this.GrpParameters.TabStop = false;
			this.GrpParameters.Text = "Parameters";


            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.MinimumSize = new System.Drawing.Size(320, 200);
//            this.Controls.Add(this.gPanel);
            this.Controls.Add(this.GrpGraph);
            this.Controls.Add(this.GrpParameters);
            this.KeyPreview = true;
            this.MaximizeBox = true;
            this.Name = "GraphForm";
            this.Text = "Graph";
			this.GrpGraph.ResumeLayout(false);
			this.GrpParameters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}




		private System.Windows.Forms.GroupBox GrpGraph;
		private System.Windows.Forms.GroupBox GrpParameters;
		private GraphingPanel gPanel;
    }
}



