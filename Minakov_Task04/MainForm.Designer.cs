
namespace Minakov_Task04
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
            Ellipse ellipse1 = new Ellipse();
            Parabola parabola1 = new Parabola();
            Segment segment1 = new Segment();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            renderControl = new RenderControl();
            radioButtonEllipse = new System.Windows.Forms.RadioButton();
            radioButtonParabola = new System.Windows.Forms.RadioButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            numericUpDownHalfB = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            numericUpDownHalfA = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            numericUpDownTmax = new System.Windows.Forms.NumericUpDown();
            label20 = new System.Windows.Forms.Label();
            numericUpDownTmin = new System.Windows.Forms.NumericUpDown();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            numericUpDownC = new System.Windows.Forms.NumericUpDown();
            numericUpDownB = new System.Windows.Forms.NumericUpDown();
            numericUpDownA = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label19 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            numericUpDownB_Y = new System.Windows.Forms.NumericUpDown();
            numericUpDownB_X = new System.Windows.Forms.NumericUpDown();
            label17 = new System.Windows.Forms.Label();
            numericUpDownA_Y = new System.Windows.Forms.NumericUpDown();
            label16 = new System.Windows.Forms.Label();
            numericUpDownA_X = new System.Windows.Forms.NumericUpDown();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHalfB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHalfA).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTmax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTmin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB_Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB_X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA_Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA_X).BeginInit();
            SuspendLayout();
            // 
            // renderControl
            // 
            renderControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renderControl.BackColor = System.Drawing.Color.White;
            ellipse1.CenterX = 0D;
            ellipse1.CenterY = 0D;
            ellipse1.SemiMajorAxis = 100D;
            ellipse1.SemiMinorAxis = 50D;
            renderControl.Ellipse = ellipse1;
            renderControl.Epsilon = 1E-06D;
            renderControl.ForeColor = System.Drawing.Color.White;
            renderControl.IsEllipseSelected = true;
            renderControl.Location = new System.Drawing.Point(12, 14);
            renderControl.Name = "renderControl";
            parabola1.A = 1D;
            parabola1.B = 0D;
            parabola1.C = 0D;
            parabola1.TMax = 10D;
            parabola1.TMin = -10D;
            renderControl.Parabola = parabola1;
            segment1.AX = -50D;
            segment1.AY = -50D;
            segment1.BX = 50D;
            segment1.BY = 50D;
            renderControl.Segment = segment1;
            renderControl.Size = new System.Drawing.Size(606, 508);
            renderControl.TabIndex = 0;
            renderControl.TextCodePage = 1251;
            // 
            // radioButtonEllipse
            // 
            radioButtonEllipse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonEllipse.AutoSize = true;
            radioButtonEllipse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonEllipse.Location = new System.Drawing.Point(664, 14);
            radioButtonEllipse.Name = "radioButtonEllipse";
            radioButtonEllipse.Size = new System.Drawing.Size(64, 25);
            radioButtonEllipse.TabIndex = 1;
            radioButtonEllipse.TabStop = true;
            radioButtonEllipse.Text = "Еліпс";
            radioButtonEllipse.UseVisualStyleBackColor = true;
            radioButtonEllipse.CheckedChanged += radioButtonEllipse_CheckedChanged;
            // 
            // radioButtonParabola
            // 
            radioButtonParabola.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            radioButtonParabola.AutoSize = true;
            radioButtonParabola.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            radioButtonParabola.Location = new System.Drawing.Point(763, 14);
            radioButtonParabola.Name = "radioButtonParabola";
            radioButtonParabola.Size = new System.Drawing.Size(98, 25);
            radioButtonParabola.TabIndex = 2;
            radioButtonParabola.TabStop = true;
            radioButtonParabola.Text = "Парабола";
            radioButtonParabola.UseVisualStyleBackColor = true;
            radioButtonParabola.CheckedChanged += radioButtonParabola_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(numericUpDownHalfB);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numericUpDownHalfA);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(632, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(273, 121);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Парамери Еліпса";
            // 
            // numericUpDownHalfB
            // 
            numericUpDownHalfB.DecimalPlaces = 1;
            numericUpDownHalfB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownHalfB.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownHalfB.Location = new System.Drawing.Point(156, 85);
            numericUpDownHalfB.Name = "numericUpDownHalfB";
            numericUpDownHalfB.Size = new System.Drawing.Size(72, 27);
            numericUpDownHalfB.TabIndex = 9;
            numericUpDownHalfB.ValueChanged += numericUpDownHalfB_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(26, 87);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(112, 20);
            label6.TabIndex = 8;
            label6.Text = "Мала піввісь =";
            // 
            // numericUpDownHalfA
            // 
            numericUpDownHalfA.DecimalPlaces = 1;
            numericUpDownHalfA.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownHalfA.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownHalfA.Location = new System.Drawing.Point(156, 52);
            numericUpDownHalfA.Name = "numericUpDownHalfA";
            numericUpDownHalfA.Size = new System.Drawing.Size(72, 27);
            numericUpDownHalfA.TabIndex = 7;
            numericUpDownHalfA.ValueChanged += numericUpDownHalfA_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(26, 54);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(124, 20);
            label5.TabIndex = 6;
            label5.Text = "Велика піввісь =";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(8, 25);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 20);
            label4.TabIndex = 5;
            label4.Text = "Півосі:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(numericUpDownTmax);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(numericUpDownTmin);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(numericUpDownC);
            groupBox2.Controls.Add(numericUpDownB);
            groupBox2.Controls.Add(numericUpDownA);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox2.Location = new System.Drawing.Point(632, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(273, 228);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметри Параболи";
            // 
            // numericUpDownTmax
            // 
            numericUpDownTmax.DecimalPlaces = 2;
            numericUpDownTmax.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownTmax.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownTmax.Location = new System.Drawing.Point(195, 188);
            numericUpDownTmax.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownTmax.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numericUpDownTmax.Name = "numericUpDownTmax";
            numericUpDownTmax.Size = new System.Drawing.Size(72, 27);
            numericUpDownTmax.TabIndex = 11;
            numericUpDownTmax.ValueChanged += numericUpDownTmax_ValueChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label20.Location = new System.Drawing.Point(137, 192);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(56, 20);
            label20.TabIndex = 10;
            label20.Text = "tmax =";
            // 
            // numericUpDownTmin
            // 
            numericUpDownTmin.DecimalPlaces = 2;
            numericUpDownTmin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownTmin.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownTmin.Location = new System.Drawing.Point(62, 190);
            numericUpDownTmin.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownTmin.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numericUpDownTmin.Name = "numericUpDownTmin";
            numericUpDownTmin.Size = new System.Drawing.Size(72, 27);
            numericUpDownTmin.TabIndex = 9;
            numericUpDownTmin.ValueChanged += numericUpDownTmin_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label12.Location = new System.Drawing.Point(6, 192);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(53, 20);
            label12.TabIndex = 8;
            label12.Text = "tmin =";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(8, 156);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(91, 20);
            label11.TabIndex = 7;
            label11.Text = "Параметр t:";
            // 
            // numericUpDownC
            // 
            numericUpDownC.DecimalPlaces = 2;
            numericUpDownC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownC.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownC.Location = new System.Drawing.Point(120, 117);
            numericUpDownC.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownC.Name = "numericUpDownC";
            numericUpDownC.Size = new System.Drawing.Size(73, 27);
            numericUpDownC.TabIndex = 6;
            numericUpDownC.ValueChanged += numericUpDownC_ValueChanged;
            // 
            // numericUpDownB
            // 
            numericUpDownB.DecimalPlaces = 2;
            numericUpDownB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownB.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownB.Location = new System.Drawing.Point(120, 84);
            numericUpDownB.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownB.Name = "numericUpDownB";
            numericUpDownB.Size = new System.Drawing.Size(73, 27);
            numericUpDownB.TabIndex = 5;
            numericUpDownB.ValueChanged += numericUpDownB_ValueChanged;
            // 
            // numericUpDownA
            // 
            numericUpDownA.DecimalPlaces = 2;
            numericUpDownA.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownA.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownA.Location = new System.Drawing.Point(121, 51);
            numericUpDownA.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownA.Name = "numericUpDownA";
            numericUpDownA.Size = new System.Drawing.Size(72, 27);
            numericUpDownA.TabIndex = 4;
            numericUpDownA.ValueChanged += numericUpDownA_ValueChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(73, 118);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(32, 21);
            label10.TabIndex = 3;
            label10.Text = "c =";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(73, 86);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(32, 20);
            label9.TabIndex = 2;
            label9.Text = "b =";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.Location = new System.Drawing.Point(73, 53);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(31, 20);
            label8.TabIndex = 1;
            label8.Text = "a =";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(8, 25);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(96, 20);
            label7.TabIndex = 0;
            label7.Text = "Коефіцієнти:";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(numericUpDownB_Y);
            groupBox3.Controls.Add(numericUpDownB_X);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(numericUpDownA_Y);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(numericUpDownA_X);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox3.Location = new System.Drawing.Point(632, 406);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(273, 116);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Відрізок";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label19.ForeColor = System.Drawing.Color.DodgerBlue;
            label19.Location = new System.Drawing.Point(156, 83);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(30, 20);
            label19.TabIndex = 10;
            label19.Text = "y =";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label18.ForeColor = System.Drawing.Color.DodgerBlue;
            label18.Location = new System.Drawing.Point(41, 82);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(30, 20);
            label18.TabIndex = 9;
            label18.Text = "x =";
            // 
            // numericUpDownB_Y
            // 
            numericUpDownB_Y.DecimalPlaces = 1;
            numericUpDownB_Y.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownB_Y.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownB_Y.Location = new System.Drawing.Point(190, 80);
            numericUpDownB_Y.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownB_Y.Name = "numericUpDownB_Y";
            numericUpDownB_Y.Size = new System.Drawing.Size(75, 27);
            numericUpDownB_Y.TabIndex = 8;
            numericUpDownB_Y.ValueChanged += numericUpDownB_Y_ValueChanged;
            // 
            // numericUpDownB_X
            // 
            numericUpDownB_X.DecimalPlaces = 1;
            numericUpDownB_X.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownB_X.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownB_X.Location = new System.Drawing.Point(77, 80);
            numericUpDownB_X.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownB_X.Name = "numericUpDownB_X";
            numericUpDownB_X.Size = new System.Drawing.Size(73, 27);
            numericUpDownB_X.TabIndex = 7;
            numericUpDownB_X.ValueChanged += numericUpDownB_X_ValueChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label17.ForeColor = System.Drawing.Color.DodgerBlue;
            label17.Location = new System.Drawing.Point(15, 83);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(21, 20);
            label17.TabIndex = 6;
            label17.Text = "b:";
            // 
            // numericUpDownA_Y
            // 
            numericUpDownA_Y.DecimalPlaces = 1;
            numericUpDownA_Y.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownA_Y.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownA_Y.Location = new System.Drawing.Point(192, 41);
            numericUpDownA_Y.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownA_Y.Name = "numericUpDownA_Y";
            numericUpDownA_Y.Size = new System.Drawing.Size(73, 27);
            numericUpDownA_Y.TabIndex = 5;
            numericUpDownA_Y.ValueChanged += numericUpDownA_Y_ValueChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label16.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label16.Location = new System.Drawing.Point(156, 44);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(30, 20);
            label16.TabIndex = 4;
            label16.Text = "y =";
            // 
            // numericUpDownA_X
            // 
            numericUpDownA_X.DecimalPlaces = 1;
            numericUpDownA_X.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDownA_X.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownA_X.Location = new System.Drawing.Point(77, 42);
            numericUpDownA_X.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDownA_X.Name = "numericUpDownA_X";
            numericUpDownA_X.Size = new System.Drawing.Size(73, 27);
            numericUpDownA_X.TabIndex = 3;
            numericUpDownA_X.ValueChanged += numericUpDownA_X_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label15.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label15.Location = new System.Drawing.Point(41, 45);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(30, 20);
            label15.TabIndex = 2;
            label15.Text = "x =";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label14.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
            label14.Location = new System.Drawing.Point(15, 45);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(20, 20);
            label14.TabIndex = 1;
            label14.Text = "a:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label13.Location = new System.Drawing.Point(8, 25);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(53, 20);
            label13.TabIndex = 0;
            label13.Text = "Точки:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(917, 534);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(radioButtonParabola);
            Controls.Add(radioButtonEllipse);
            Controls.Add(renderControl);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Main Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHalfB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHalfA).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTmax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTmin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownC).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB_Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB_X).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA_Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownA_X).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RenderControl renderControl;
        private System.Windows.Forms.RadioButton radioButtonEllipse;
        private System.Windows.Forms.RadioButton radioButtonParabola;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownHalfB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownHalfA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownTmin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownC;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownA_X;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownB_Y;
        private System.Windows.Forms.NumericUpDown numericUpDownB_X;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownA_Y;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownTmax;
        private System.Windows.Forms.Label label20;
    }
}

