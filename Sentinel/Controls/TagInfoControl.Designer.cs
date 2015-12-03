namespace Sentinel.Controls
{
    partial class TagInfoControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tagIndexLabel = new System.Windows.Forms.Label();
            this.tagOffsetLabel = new System.Windows.Forms.Label();
            this.tagSizeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag Index:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tag Offset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tag Size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tagIndexLabel
            // 
            this.tagIndexLabel.AutoSize = true;
            this.tagIndexLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tagIndexLabel.Location = new System.Drawing.Point(88, 3);
            this.tagIndexLabel.Margin = new System.Windows.Forms.Padding(3);
            this.tagIndexLabel.Name = "tagIndexLabel";
            this.tagIndexLabel.Size = new System.Drawing.Size(0, 17);
            this.tagIndexLabel.TabIndex = 3;
            this.tagIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tagOffsetLabel
            // 
            this.tagOffsetLabel.AutoSize = true;
            this.tagOffsetLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tagOffsetLabel.Location = new System.Drawing.Point(88, 26);
            this.tagOffsetLabel.Margin = new System.Windows.Forms.Padding(3);
            this.tagOffsetLabel.Name = "tagOffsetLabel";
            this.tagOffsetLabel.Size = new System.Drawing.Size(0, 17);
            this.tagOffsetLabel.TabIndex = 4;
            this.tagOffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tagSizeLabel
            // 
            this.tagSizeLabel.AutoSize = true;
            this.tagSizeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tagSizeLabel.Location = new System.Drawing.Point(88, 49);
            this.tagSizeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.tagSizeLabel.Name = "tagSizeLabel";
            this.tagSizeLabel.Size = new System.Drawing.Size(0, 17);
            this.tagSizeLabel.TabIndex = 5;
            this.tagSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tagSizeLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tagOffsetLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tagIndexLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(91, 69);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // TagInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TagInfoControl";
            this.Size = new System.Drawing.Size(94, 72);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tagIndexLabel;
        private System.Windows.Forms.Label tagOffsetLabel;
        private System.Windows.Forms.Label tagSizeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
