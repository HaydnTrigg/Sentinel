namespace Sentinel
{
    partial class MapControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.split = new System.Windows.Forms.SplitContainer();
            this.tagTreeView = new System.Windows.Forms.TreeView();
            this.tagToolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.engineVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.tagTreeView);
            this.split.Panel1.Controls.Add(this.tagToolStrip);
            this.split.Size = new System.Drawing.Size(667, 594);
            this.split.SplitterDistance = 308;
            this.split.TabIndex = 0;
            // 
            // tagTreeView
            // 
            this.tagTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagTreeView.Location = new System.Drawing.Point(0, 25);
            this.tagTreeView.Name = "tagTreeView";
            this.tagTreeView.Size = new System.Drawing.Size(308, 569);
            this.tagTreeView.TabIndex = 1;
            // 
            // tagToolStrip
            // 
            this.tagToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tagToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tagToolStrip.Name = "tagToolStrip";
            this.tagToolStrip.Size = new System.Drawing.Size(308, 25);
            this.tagToolStrip.TabIndex = 0;
            this.tagToolStrip.Text = "toolStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.engineVersionLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 594);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(667, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // engineVersionLabel
            // 
            this.engineVersionLabel.Name = "engineVersionLabel";
            this.engineVersionLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.split);
            this.Controls.Add(this.statusStrip);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(667, 616);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.TreeView tagTreeView;
        private System.Windows.Forms.ToolStrip tagToolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel engineVersionLabel;
    }
}
