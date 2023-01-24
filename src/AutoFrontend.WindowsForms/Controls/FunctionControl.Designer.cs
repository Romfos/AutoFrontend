namespace AutoFrontend.WindowsForms.Controls;

partial class FunctionControl
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
			this.resultPanel = new System.Windows.Forms.Panel();
			this.button = new System.Windows.Forms.Button();
			this.argumentPanel = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// resultPanel
			// 
			this.resultPanel.AutoSize = true;
			this.resultPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.resultPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.resultPanel.Location = new System.Drawing.Point(3, 44);
			this.resultPanel.Name = "resultPanel";
			this.resultPanel.Size = new System.Drawing.Size(1, 0);
			this.resultPanel.TabIndex = 0;
			// 
			// button
			// 
			this.button.Dock = System.Windows.Forms.DockStyle.Top;
			this.button.Location = new System.Drawing.Point(3, 9);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(1, 29);
			this.button.TabIndex = 0;
			this.button.Text = "function name";
			this.button.UseVisualStyleBackColor = true;
			// 
			// argumentPanel
			// 
			this.argumentPanel.AutoSize = true;
			this.argumentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.argumentPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.argumentPanel.Location = new System.Drawing.Point(3, 3);
			this.argumentPanel.Name = "argumentPanel";
			this.argumentPanel.Size = new System.Drawing.Size(1, 0);
			this.argumentPanel.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(6, 69);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.argumentPanel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.resultPanel, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 47);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// FunctionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.groupBox1);
			this.Name = "FunctionControl";
			this.Size = new System.Drawing.Size(9, 72);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel resultPanel;
    private System.Windows.Forms.Button button;
    private System.Windows.Forms.Panel argumentPanel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
}
