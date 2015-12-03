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
            this.toolTabControl = new Sentinel.Controls.AdvancedTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
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
            this.split.Panel1MinSize = 300;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.toolTabControl);
            this.split.Size = new System.Drawing.Size(845, 594);
            this.split.SplitterDistance = 300;
            this.split.TabIndex = 0;
            // 
            // tagTreeView
            // 
            this.tagTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagTreeView.Location = new System.Drawing.Point(0, 25);
            this.tagTreeView.Name = "tagTreeView";
            this.tagTreeView.Size = new System.Drawing.Size(300, 569);
            this.tagTreeView.TabIndex = 1;
            this.tagTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tagTreeView_AfterSelect);
            this.tagTreeView.DoubleClick += new System.EventHandler(this.tagTreeView_DoubleClick);
            // 
            // tagToolStrip
            // 
            this.tagToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tagToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tagToolStrip.Name = "tagToolStrip";
            this.tagToolStrip.Size = new System.Drawing.Size(300, 25);
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
            this.statusStrip.Size = new System.Drawing.Size(845, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // engineVersionLabel
            // 
            this.engineVersionLabel.Name = "engineVersionLabel";
            this.engineVersionLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTabControl
            // 
            this.toolTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolTabControl.Location = new System.Drawing.Point(0, 0);
            this.toolTabControl.Name = "toolTabControl";
            this.toolTabControl.SelectedIndex = 0;
            this.toolTabControl.Size = new System.Drawing.Size(541, 594);
            this.toolTabControl.TabIndex = 0;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.split);
            this.Controls.Add(this.statusStrip);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(845, 616);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel1.PerformLayout();
            this.split.Panel2.ResumeLayout(false);
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
        private Sentinel.Controls.AdvancedTabControl toolTabControl;
    }
}
