
namespace Minakov_Lab2
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
            label1 = new System.Windows.Forms.Label();
            renderControl = new RenderControl();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            numericUpDownHorizontal = new System.Windows.Forms.NumericUpDown();
            numericUpDownVertical = new System.Windows.Forms.NumericUpDown();
            radioButtonFill = new System.Windows.Forms.RadioButton();
            radioButtonLine = new System.Windows.Forms.RadioButton();
            radioButtonPoint = new System.Windows.Forms.RadioButton();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHorizontal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVertical).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(643, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 21);
            label1.TabIndex = 0;
            label1.Text = "Tile count:";
            // 
            // renderControl
            // 
            renderControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renderControl.BackColor = System.Drawing.Color.Silver;
            renderControl.ForeColor = System.Drawing.Color.White;
            renderControl.Location = new System.Drawing.Point(12, 12);
            renderControl.Name = "renderControl";
            renderControl.Size = new System.Drawing.Size(579, 449);
            renderControl.TabIndex = 1;
            renderControl.TextCodePage = 1251;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(608, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(80, 21);
            label2.TabIndex = 2;
            label2.Text = "horizontal";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(608, 88);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 21);
            label3.TabIndex = 3;
            label3.Text = "vertical";
            // 
            // numericUpDownHorizontal
            // 
            numericUpDownHorizontal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownHorizontal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownHorizontal.Location = new System.Drawing.Point(703, 47);
            numericUpDownHorizontal.Name = "numericUpDownHorizontal";
            numericUpDownHorizontal.Size = new System.Drawing.Size(48, 29);
            numericUpDownHorizontal.TabIndex = 4;
            numericUpDownHorizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            numericUpDownHorizontal.ValueChanged += NumericUpDownHorizontal_ValueChanged;
            // 
            // numericUpDownVertical
            // 
            numericUpDownVertical.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownVertical.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownVertical.Location = new System.Drawing.Point(703, 86);
            numericUpDownVertical.Name = "numericUpDownVertical";
            numericUpDownVertical.Size = new System.Drawing.Size(48, 29);
            numericUpDownVertical.TabIndex = 5;
            numericUpDownVertical.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            numericUpDownVertical.ValueChanged += NumericUpDownVertical_ValueChanged;
            // 
            // radioButtonFill
            // 
            radioButtonFill.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonFill.AutoSize = true;
            radioButtonFill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonFill.ForeColor = System.Drawing.Color.Red;
            radioButtonFill.Location = new System.Drawing.Point(631, 216);
            radioButtonFill.Name = "radioButtonFill";
            radioButtonFill.Size = new System.Drawing.Size(92, 25);
            radioButtonFill.TabIndex = 6;
            radioButtonFill.TabStop = true;
            radioButtonFill.Text = "Fill mode";
            radioButtonFill.UseVisualStyleBackColor = true;
            radioButtonFill.CheckedChanged += RadioButtonFill_CheckedChanged;
            // 
            // radioButtonLine
            // 
            radioButtonLine.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonLine.AutoSize = true;
            radioButtonLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonLine.ForeColor = System.Drawing.Color.Green;
            radioButtonLine.Location = new System.Drawing.Point(631, 247);
            radioButtonLine.Name = "radioButtonLine";
            radioButtonLine.Size = new System.Drawing.Size(101, 25);
            radioButtonLine.TabIndex = 7;
            radioButtonLine.TabStop = true;
            radioButtonLine.Text = "Line mode";
            radioButtonLine.UseVisualStyleBackColor = true;
            radioButtonLine.CheckedChanged += RadioButtonLine_CheckedChanged;
            // 
            // radioButtonPoint
            // 
            radioButtonPoint.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonPoint.AutoSize = true;
            radioButtonPoint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonPoint.ForeColor = System.Drawing.Color.Blue;
            radioButtonPoint.Location = new System.Drawing.Point(631, 278);
            radioButtonPoint.Name = "radioButtonPoint";
            radioButtonPoint.Size = new System.Drawing.Size(107, 25);
            radioButtonPoint.TabIndex = 8;
            radioButtonPoint.TabStop = true;
            radioButtonPoint.Text = "Point mode";
            radioButtonPoint.UseVisualStyleBackColor = true;
            radioButtonPoint.CheckedChanged += RadioButtonPoint_CheckedChanged;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(608, 181);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(108, 21);
            label4.TabIndex = 9;
            label4.Text = "Display mode:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(766, 473);
            Controls.Add(label4);
            Controls.Add(radioButtonPoint);
            Controls.Add(radioButtonLine);
            Controls.Add(radioButtonFill);
            Controls.Add(numericUpDownVertical);
            Controls.Add(numericUpDownHorizontal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(renderControl);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "OpenGL Application";
            ((System.ComponentModel.ISupportInitialize)numericUpDownHorizontal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVertical).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RenderControl renderControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownHorizontal;
        private System.Windows.Forms.NumericUpDown numericUpDownVertical;
        private System.Windows.Forms.RadioButton radioButtonFill;
        private System.Windows.Forms.RadioButton radioButtonLine;
        private System.Windows.Forms.RadioButton radioButtonPoint;
        private System.Windows.Forms.Label label4;
    }
}

