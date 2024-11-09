using System;
using System.Windows.Forms;

namespace Minakov_Task03
{
    public partial class MainForm : Form
    {
        // Поточний об'єкт функції
        private FunctionBase currentFunction;

        // Попередні значення для Xmin, Xmax, Ymin, Ymax
        private decimal prevXmin;
        private decimal prevXmax;
        private decimal prevYmin;
        private decimal prevYmax;

        // Автоматичні Ymin та Ymax
        private double autoYmin;
        private double autoYmax;

        public MainForm()
        {
            InitializeComponent();

            // Встановлюємо функцію за замовчуванням та початкові значення
            currentFunction = new Function1();
            numericUpDown_Xmin.Value = -10;
            numericUpDown_Xmax.Value = 10;
            numericUpDown_Points.Value = 10000;
            checkBox_autoY.Checked = true;
            radioButton_f1.Checked = true;

            // Ініціалізуємо попередні значення
            prevXmin = numericUpDown_Xmin.Value;
            prevXmax = numericUpDown_Xmax.Value;
            prevYmin = numericUpDown_Ymin.Value;
            prevYmax = numericUpDown_Ymax.Value;

            // Встановлюємо допустимі мінімальні та максимальні значення для Y
            numericUpDown_Ymin.Minimum = decimal.MinValue;
            numericUpDown_Ymin.Maximum = decimal.MaxValue;
            numericUpDown_Ymax.Minimum = decimal.MinValue;
            numericUpDown_Ymax.Maximum = decimal.MaxValue;
        }

        // Обробник для вибору функції f1
        private void radioButton_f1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_f1.Checked)
            {
                currentFunction = new Function1();
                renderControl.Invalidate();
            }
        }

        // Обробник для вибору функції f2
        private void radioButton_f2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_f2.Checked)
            {
                currentFunction = new Function2();
                renderControl.Invalidate();
            }
        }

        // Перевірка та оновлення значення Xmin
        private void numericUpDown_Xmin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Xmin.Value >= numericUpDown_Xmax.Value)
            {
                MessageBox.Show("Xmin не може бути більшим або рівним Xmax.", "Неприпустиме значення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown_Xmin.Value = prevXmin;
            }
            else
            {
                prevXmin = numericUpDown_Xmin.Value;
                renderControl.Invalidate();
            }
        }

        // Перевірка та оновлення значення Xmax
        private void numericUpDown_Xmax_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Xmax.Value <= numericUpDown_Xmin.Value)
            {
                MessageBox.Show("Xmax не може бути меншим або рівним Xmin.", "Неприпустиме значення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown_Xmax.Value = prevXmax;
            }
            else
            {
                prevXmax = numericUpDown_Xmax.Value;
                renderControl.Invalidate();
            }
        }

        // Обробка автоматичного масштабування Y
        private void checkBox_autoY_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBox_autoY.Checked;
            numericUpDown_Ymin.Visible = !isChecked;
            numericUpDown_Ymax.Visible = !isChecked;
            labelYmin.Visible = !isChecked;
            labelYmax.Visible = !isChecked;

            if (!isChecked)
            {
                // При вимкненні авто Y встановлюємо значення з авто діапазону
                numericUpDown_Ymin.Value = (decimal)autoYmin;
                numericUpDown_Ymax.Value = (decimal)autoYmax;

                // Оновлюємо попередні значення
                prevYmin = numericUpDown_Ymin.Value;
                prevYmax = numericUpDown_Ymax.Value;
            }

            renderControl.Invalidate();
        }

        // Перевірка та оновлення значення Ymin
        private void numericUpDown_Ymin_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Ymin.Value >= numericUpDown_Ymax.Value)
            {
                MessageBox.Show("Ymin не може бути більшим або рівним Ymax.", "Неприпустиме значення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown_Ymin.Value = prevYmin;
            }
            else
            {
                prevYmin = numericUpDown_Ymin.Value;
                renderControl.Invalidate();
            }
        }

        // Перевірка та оновлення значення Ymax
        private void numericUpDown_Ymax_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Ymax.Value <= numericUpDown_Ymin.Value)
            {
                MessageBox.Show("Ymax не може бути меншим або рівним Ymin.", "Неприпустиме значення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown_Ymax.Value = prevYmax;
            }
            else
            {
                prevYmax = numericUpDown_Ymax.Value;
                renderControl.Invalidate();
            }
        }

        // Оновлення при зміні кількості точок
        private void numericUpDown_Points_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Invalidate();
        }

        // Метод для встановлення автоматичного діапазону Y
        public void SetAutoYRange(double minY, double maxY)
        {
            autoYmin = minY;
            autoYmax = maxY;
        }

        // Властивості для доступу до значень з RenderControl
        public double Xmin => (double)numericUpDown_Xmin.Value;
        public double Xmax => (double)numericUpDown_Xmax.Value;
        public double Ymin => (double)numericUpDown_Ymin.Value;
        public double Ymax => (double)numericUpDown_Ymax.Value;
        public int Points => (int)numericUpDown_Points.Value;
        public bool AutoY => checkBox_autoY.Checked;
        public FunctionBase CurrentFunction => currentFunction;
    }
}