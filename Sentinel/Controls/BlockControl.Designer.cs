namespace Sentinel.Controls
{
    partial class BlockControl
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
            this.headerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toggleButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.indexBox = new System.Windows.Forms.ComboBox();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerTableLayout.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerTableLayout
            // 
            this.headerTableLayout.AutoSize = true;
            this.headerTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerTableLayout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.headerTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.headerTableLayout.ColumnCount = 5;
            this.headerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.headerTableLayout.Controls.Add(this.toggleButton, 0, 0);
            this.headerTableLayout.Controls.Add(this.nameLabel, 1, 0);
            this.headerTableLayout.Controls.Add(this.removeButton, 4, 0);
            this.headerTableLayout.Controls.Add(this.addButton, 3, 0);
            this.headerTableLayout.Controls.Add(this.indexBox, 2, 0);
            this.headerTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTableLayout.Location = new System.Drawing.Point(3, 3);
            this.headerTableLayout.Name = "headerTableLayout";
            this.headerTableLayout.RowCount = 1;
            this.headerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerTableLayout.Size = new System.Drawing.Size(497, 35);
            this.headerTableLayout.TabIndex = 0;
            // 
            // toggleButton
            // 
            this.toggleButton.AutoSize = true;
            this.toggleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toggleButton.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleButton.Location = new System.Drawing.Point(4, 4);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(26, 27);
            this.toggleButton.TabIndex = 0;
            this.toggleButton.Text = "-";
            this.toggleButton.UseVisualStyleBackColor = true;
            this.toggleButton.Click += new System.EventHandler(this.toggleButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameLabel.Location = new System.Drawing.Point(37, 1);
            this.nameLabel.MinimumSize = new System.Drawing.Size(200, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(200, 33);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // removeButton
            // 
            this.removeButton.AutoSize = true;
            this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeButton.Location = new System.Drawing.Point(423, 4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(70, 27);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.Location = new System.Drawing.Point(373, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(43, 27);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // indexBox
            // 
            this.indexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.indexBox.FormattingEnabled = true;
            this.indexBox.Location = new System.Drawing.Point(245, 5);
            this.indexBox.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.indexBox.Name = "indexBox";
            this.indexBox.Size = new System.Drawing.Size(121, 24);
            this.indexBox.TabIndex = 4;
            // 
            // controlPanel
            // 
            this.controlPanel.AutoSize = true;
            this.controlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(3, 44);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(497, 1);
            this.controlPanel.TabIndex = 2;
            // 
            // headerPanel
            // 
            this.headerPanel.AutoSize = true;
            this.headerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerPanel.ColumnCount = 1;
            this.headerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerPanel.Controls.Add(this.headerTableLayout, 0, 0);
            this.headerPanel.Controls.Add(this.controlPanel, 0, 1);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.RowCount = 2;
            this.headerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.headerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headerPanel.Size = new System.Drawing.Size(503, 47);
            this.headerPanel.TabIndex = 1;
            // 
            // BlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.headerPanel);
            this.Name = "BlockControl";
            this.Size = new System.Drawing.Size(503, 47);
            this.headerTableLayout.ResumeLayout(false);
            this.headerTableLayout.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel headerTableLayout;
        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox indexBox;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.TableLayoutPanel headerPanel;
    }
}
