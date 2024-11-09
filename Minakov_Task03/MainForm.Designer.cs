
namespace Minakov_Task03
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            renderControl = new RenderControl();
            radioButton_f1 = new System.Windows.Forms.RadioButton();
            radioButton_f2 = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            checkBox_autoY = new System.Windows.Forms.CheckBox();
            labelYmin = new System.Windows.Forms.Label();
            labelYmax = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            numericUpDown_Xmin = new System.Windows.Forms.NumericUpDown();
            numericUpDown_Xmax = new System.Windows.Forms.NumericUpDown();
            numericUpDown_Ymin = new System.Windows.Forms.NumericUpDown();
            numericUpDown_Ymax = new System.Windows.Forms.NumericUpDown();
            numericUpDown_Points = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Xmin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Xmax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ymin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ymax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Points).BeginInit();
            SuspendLayout();
            // 
            // renderControl
            // 
            renderControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renderControl.BackColor = System.Drawing.Color.White;
            renderControl.ForeColor = System.Drawing.Color.White;
            renderControl.Location = new System.Drawing.Point(12, 43);
            renderControl.Name = "renderControl";
            renderControl.Size = new System.Drawing.Size(547, 411);
            renderControl.TabIndex = 0;
            renderControl.TextCodePage = 1251;
            // 
            // radioButton_f1
            // 
            radioButton_f1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton_f1.AutoSize = true;
            radioButton_f1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButton_f1.Location = new System.Drawing.Point(12, 12);
            radioButton_f1.Name = "radioButton_f1";
            radioButton_f1.Size = new System.Drawing.Size(59, 25);
            radioButton_f1.TabIndex = 1;
            radioButton_f1.TabStop = true;
            radioButton_f1.Text = "f1(x)";
            radioButton_f1.UseVisualStyleBackColor = true;
            radioButton_f1.CheckedChanged += radioButton_f1_CheckedChanged;
            // 
            // radioButton_f2
            // 
            radioButton_f2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            radioButton_f2.AutoSize = true;
            radioButton_f2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButton_f2.Location = new System.Drawing.Point(77, 12);
            radioButton_f2.Name = "radioButton_f2";
            radioButton_f2.Size = new System.Drawing.Size(59, 25);
            radioButton_f2.TabIndex = 2;
            radioButton_f2.TabStop = true;
            radioButton_f2.Text = "f2(x)";
            radioButton_f2.UseVisualStyleBackColor = true;
            radioButton_f2.CheckedChanged += radioButton_f2_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(578, 108);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 21);
            label1.TabIndex = 3;
            label1.Text = "Xmin";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(578, 157);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 21);
            label2.TabIndex = 4;
            label2.Text = "Xmax";
            // 
            // checkBox_autoY
            // 
            checkBox_autoY.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox_autoY.AutoSize = true;
            checkBox_autoY.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox_autoY.Location = new System.Drawing.Point(578, 204);
            checkBox_autoY.Name = "checkBox_autoY";
            checkBox_autoY.Size = new System.Drawing.Size(151, 25);
            checkBox_autoY.TabIndex = 5;
            checkBox_autoY.Text = "auto calculation Y";
            checkBox_autoY.UseVisualStyleBackColor = true;
            checkBox_autoY.CheckedChanged += checkBox_autoY_CheckedChanged;
            // 
            // labelYmin
            // 
            labelYmin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelYmin.AutoSize = true;
            labelYmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelYmin.Location = new System.Drawing.Point(578, 246);
            labelYmin.Name = "labelYmin";
            labelYmin.Size = new System.Drawing.Size(45, 21);
            labelYmin.TabIndex = 6;
            labelYmin.Text = "Ymin";
            // 
            // labelYmax
            // 
            labelYmax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelYmax.AutoSize = true;
            labelYmax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelYmax.Location = new System.Drawing.Point(578, 297);
            labelYmax.Name = "labelYmax";
            labelYmax.Size = new System.Drawing.Size(47, 21);
            labelYmax.TabIndex = 7;
            labelYmax.Text = "Ymax";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(578, 351);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 21);
            label5.TabIndex = 8;
            label5.Text = "Points";
            // 
            // numericUpDown_Xmin
            // 
            numericUpDown_Xmin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown_Xmin.DecimalPlaces = 1;
            numericUpDown_Xmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown_Xmin.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown_Xmin.Location = new System.Drawing.Point(643, 106);
            numericUpDown_Xmin.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown_Xmin.Name = "numericUpDown_Xmin";
            numericUpDown_Xmin.Size = new System.Drawing.Size(86, 29);
            numericUpDown_Xmin.TabIndex = 9;
            numericUpDown_Xmin.ValueChanged += numericUpDown_Xmin_ValueChanged;
            // 
            // numericUpDown_Xmax
            // 
            numericUpDown_Xmax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown_Xmax.DecimalPlaces = 1;
            numericUpDown_Xmax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown_Xmax.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown_Xmax.Location = new System.Drawing.Point(643, 155);
            numericUpDown_Xmax.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown_Xmax.Name = "numericUpDown_Xmax";
            numericUpDown_Xmax.Size = new System.Drawing.Size(86, 29);
            numericUpDown_Xmax.TabIndex = 10;
            numericUpDown_Xmax.ValueChanged += numericUpDown_Xmax_ValueChanged;
            // 
            // numericUpDown_Ymin
            // 
            numericUpDown_Ymin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown_Ymin.DecimalPlaces = 1;
            numericUpDown_Ymin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown_Ymin.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown_Ymin.Location = new System.Drawing.Point(643, 244);
            numericUpDown_Ymin.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown_Ymin.Name = "numericUpDown_Ymin";
            numericUpDown_Ymin.Size = new System.Drawing.Size(86, 29);
            numericUpDown_Ymin.TabIndex = 11;
            numericUpDown_Ymin.ValueChanged += numericUpDown_Ymin_ValueChanged;
            // 
            // numericUpDown_Ymax
            // 
            numericUpDown_Ymax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown_Ymax.DecimalPlaces = 1;
            numericUpDown_Ymax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown_Ymax.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown_Ymax.Location = new System.Drawing.Point(643, 295);
            numericUpDown_Ymax.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown_Ymax.Name = "numericUpDown_Ymax";
            numericUpDown_Ymax.Size = new System.Drawing.Size(86, 29);
            numericUpDown_Ymax.TabIndex = 12;
            numericUpDown_Ymax.ValueChanged += numericUpDown_Ymax_ValueChanged;
            // 
            // numericUpDown_Points
            // 
            numericUpDown_Points.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown_Points.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown_Points.Location = new System.Drawing.Point(643, 349);
            numericUpDown_Points.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown_Points.Name = "numericUpDown_Points";
            numericUpDown_Points.Size = new System.Drawing.Size(86, 29);
            numericUpDown_Points.TabIndex = 13;
            numericUpDown_Points.ValueChanged += numericUpDown_Points_ValueChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            ClientSize = new System.Drawing.Size(753, 466);
            Controls.Add(numericUpDown_Points);
            Controls.Add(numericUpDown_Ymax);
            Controls.Add(numericUpDown_Ymin);
            Controls.Add(numericUpDown_Xmax);
            Controls.Add(numericUpDown_Xmin);
            Controls.Add(label5);
            Controls.Add(labelYmax);
            Controls.Add(labelYmin);
            Controls.Add(checkBox_autoY);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(radioButton_f2);
            Controls.Add(radioButton_f1);
            Controls.Add(renderControl);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Xmin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Xmax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ymin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Ymax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Points).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RenderControl renderControl;
        private System.Windows.Forms.RadioButton radioButton_f1;
        private System.Windows.Forms.RadioButton radioButton_f2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_autoY;
        private System.Windows.Forms.Label labelYmin;
        private System.Windows.Forms.Label labelYmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_Xmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Xmax;
        private System.Windows.Forms.NumericUpDown numericUpDown_Ymin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Ymax;
        private System.Windows.Forms.NumericUpDown numericUpDown_Points;
    }
}

