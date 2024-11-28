
namespace Minakov_Task05
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
            renderControl1 = new RenderControl();
            radioButtonFill = new System.Windows.Forms.RadioButton();
            radioButtonLine = new System.Windows.Forms.RadioButton();
            checkBox_Clip = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            numericUpDownA = new System.Windows.Forms.NumericUpDown();
            numericUpDownB = new System.Windows.Forms.NumericUpDown();
            numericUpDownC = new System.Windows.Forms.NumericUpDown();
            numericUpDownD = new System.Windows.Forms.NumericUpDown();
            radioButtonOrtho = new System.Windows.Forms.RadioButton();
            radioButtonPerspective = new System.Windows.Forms.RadioButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownD).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // renderControl1
            // 
            renderControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renderControl1.BackColor = System.Drawing.Color.White;
            renderControl1.ForeColor = System.Drawing.Color.White;
            renderControl1.Location = new System.Drawing.Point(12, 37);
            renderControl1.Name = "renderControl1";
            renderControl1.Size = new System.Drawing.Size(581, 349);
            renderControl1.TabIndex = 0;
            renderControl1.TextCodePage = 1251;
            // 
            // radioButtonFill
            // 
            radioButtonFill.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonFill.AutoSize = true;
            radioButtonFill.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonFill.Location = new System.Drawing.Point(6, 13);
            radioButtonFill.Name = "radioButtonFill";
            radioButtonFill.Size = new System.Drawing.Size(92, 25);
            radioButtonFill.TabIndex = 1;
            radioButtonFill.TabStop = true;
            radioButtonFill.Text = "Fill mode";
            radioButtonFill.UseVisualStyleBackColor = true;
            // 
            // radioButtonLine
            // 
            radioButtonLine.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonLine.AutoSize = true;
            radioButtonLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonLine.Location = new System.Drawing.Point(6, 53);
            radioButtonLine.Name = "radioButtonLine";
            radioButtonLine.Size = new System.Drawing.Size(101, 25);
            radioButtonLine.TabIndex = 2;
            radioButtonLine.TabStop = true;
            radioButtonLine.Text = "Line mode";
            radioButtonLine.UseVisualStyleBackColor = true;
            // 
            // checkBox_Clip
            // 
            checkBox_Clip.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox_Clip.AutoSize = true;
            checkBox_Clip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox_Clip.Location = new System.Drawing.Point(620, 12);
            checkBox_Clip.Name = "checkBox_Clip";
            checkBox_Clip.Size = new System.Drawing.Size(98, 25);
            checkBox_Clip.TabIndex = 3;
            checkBox_Clip.Text = "Clip plane";
            checkBox_Clip.UseVisualStyleBackColor = true;
            checkBox_Clip.CheckedChanged += checkBox_Clip_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(605, 53);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 21);
            label1.TabIndex = 4;
            label1.Text = "A =";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(605, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 21);
            label2.TabIndex = 5;
            label2.Text = "B =";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(605, 121);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(35, 21);
            label3.TabIndex = 6;
            label3.Text = "C =";
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(605, 155);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(36, 21);
            label4.TabIndex = 7;
            label4.Text = "D =";
            // 
            // numericUpDownA
            // 
            numericUpDownA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownA.Location = new System.Drawing.Point(645, 51);
            numericUpDownA.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownA.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numericUpDownA.Name = "numericUpDownA";
            numericUpDownA.Size = new System.Drawing.Size(61, 29);
            numericUpDownA.TabIndex = 8;
            // 
            // numericUpDownB
            // 
            numericUpDownB.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownB.Location = new System.Drawing.Point(645, 84);
            numericUpDownB.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownB.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numericUpDownB.Name = "numericUpDownB";
            numericUpDownB.Size = new System.Drawing.Size(61, 29);
            numericUpDownB.TabIndex = 9;
            // 
            // numericUpDownC
            // 
            numericUpDownC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownC.Location = new System.Drawing.Point(645, 119);
            numericUpDownC.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownC.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numericUpDownC.Name = "numericUpDownC";
            numericUpDownC.Size = new System.Drawing.Size(61, 29);
            numericUpDownC.TabIndex = 10;
            // 
            // numericUpDownD
            // 
            numericUpDownD.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDownD.DecimalPlaces = 1;
            numericUpDownD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownD.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericUpDownD.Location = new System.Drawing.Point(645, 153);
            numericUpDownD.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownD.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numericUpDownD.Name = "numericUpDownD";
            numericUpDownD.Size = new System.Drawing.Size(61, 29);
            numericUpDownD.TabIndex = 11;
            // 
            // radioButtonOrtho
            // 
            radioButtonOrtho.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonOrtho.AutoSize = true;
            radioButtonOrtho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonOrtho.Location = new System.Drawing.Point(6, 51);
            radioButtonOrtho.Name = "radioButtonOrtho";
            radioButtonOrtho.Size = new System.Drawing.Size(69, 25);
            radioButtonOrtho.TabIndex = 12;
            radioButtonOrtho.TabStop = true;
            radioButtonOrtho.Text = "Ortho";
            radioButtonOrtho.UseVisualStyleBackColor = true;
            radioButtonOrtho.CheckedChanged += radioButtonOrtho_CheckedChanged;
            // 
            // radioButtonPerspective
            // 
            radioButtonPerspective.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonPerspective.AutoSize = true;
            radioButtonPerspective.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonPerspective.Location = new System.Drawing.Point(6, 13);
            radioButtonPerspective.Name = "radioButtonPerspective";
            radioButtonPerspective.Size = new System.Drawing.Size(106, 25);
            radioButtonPerspective.TabIndex = 13;
            radioButtonPerspective.TabStop = true;
            radioButtonPerspective.Text = "Perspective";
            radioButtonPerspective.UseVisualStyleBackColor = true;
            radioButtonPerspective.CheckedChanged += radioButtonPerspective_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(radioButtonPerspective);
            groupBox1.Controls.Add(radioButtonOrtho);
            groupBox1.Location = new System.Drawing.Point(599, 188);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(122, 82);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(radioButtonFill);
            groupBox2.Controls.Add(radioButtonLine);
            groupBox2.Location = new System.Drawing.Point(599, 276);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(122, 86);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.Red;
            label5.Location = new System.Drawing.Point(24, 8);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(125, 21);
            label5.TabIndex = 16;
            label5.Text = "Вісь X - червона";
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
            label6.Location = new System.Drawing.Point(242, 8);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(113, 21);
            label6.TabIndex = 17;
            label6.Text = "Вісь Y - зелена";
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.Blue;
            label7.Location = new System.Drawing.Point(463, 8);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(98, 21);
            label7.TabIndex = 18;
            label7.Text = "Вісь Z - синя";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(733, 399);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(numericUpDownD);
            Controls.Add(numericUpDownC);
            Controls.Add(numericUpDownB);
            Controls.Add(numericUpDownA);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkBox_Clip);
            Controls.Add(renderControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)numericUpDownA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownC).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownD).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RenderControl renderControl1;
        private System.Windows.Forms.RadioButton radioButtonFill;
        private System.Windows.Forms.RadioButton radioButtonLine;
        private System.Windows.Forms.CheckBox checkBox_Clip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownC;
        private System.Windows.Forms.NumericUpDown numericUpDownD;
        private System.Windows.Forms.RadioButton radioButtonOrtho;
        private System.Windows.Forms.RadioButton radioButtonPerspective;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

