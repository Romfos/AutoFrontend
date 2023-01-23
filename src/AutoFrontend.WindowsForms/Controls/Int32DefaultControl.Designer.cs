namespace AutoFrontend.WindowsForms.Controls;

partial class Int32DefaultControl
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.numericUpDown);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(250, 50);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "field name";
			// 
			// numericUpDown
			// 
			this.numericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.numericUpDown.Location = new System.Drawing.Point(3, 19);
			this.numericUpDown.MinimumSize = new System.Drawing.Size(244, 0);
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(244, 23);
			this.numericUpDown.TabIndex = 0;
			// 
			// Int32DefaultControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox);
			this.MinimumSize = new System.Drawing.Size(250, 50);
			this.Name = "Int32DefaultControl";
			this.Size = new System.Drawing.Size(250, 50);
			this.groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.NumericUpDown numericUpDown;
}
