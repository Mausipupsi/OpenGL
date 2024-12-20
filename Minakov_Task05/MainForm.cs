using System;
using System.Drawing;
using System.Windows.Forms;
using static Minakov_Task05.OpenGL;

namespace Minakov_Task05
{
    public partial class MainForm : Form
    {
        // Зберігає останню позицію миші для обробки руху
        private Point lastMousePos;
        // Кути обертання по осях X та Y
        private float angleX = 0;
        private float angleY = 0;

        public MainForm()
        {
            InitializeComponent();

            // Додаємо обробники подій для управління обертанням сцени мишею
            renderControl1.MouseDown += RenderControl1_MouseDown;
            renderControl1.MouseMove += RenderControl1_MouseMove;

            // Додаємо обробники подій для радіокнопок режиму рендерингу
            radioButtonFill.CheckedChanged += RadioButtonFill_CheckedChanged;
            radioButtonLine.CheckedChanged += RadioButtonLine_CheckedChanged;
            radioButtonPerspective.CheckedChanged += radioButtonPerspective_CheckedChanged;
            radioButtonOrtho.CheckedChanged += radioButtonOrtho_CheckedChanged;

            // Встановлюємо початковий режим рендерингу на каркасний
            radioButtonLine.Checked = true;

            // Встановлюємо початкову проекцію на ортографічну
            radioButtonOrtho.Checked = true;

            // Ініціалізація стану управління плоскостями відсічення
            checkBox_Clip.Checked = false;
            numericUpDownA.Visible = false;
            numericUpDownB.Visible = false;
            numericUpDownC.Visible = false;
            numericUpDownD.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            // Встановлення значень за замовчуванням для коефіцієнтів плоскості відсічення
            numericUpDownA.Value = 1;
            numericUpDownB.Value = 0;
            numericUpDownC.Value = 0;
            numericUpDownD.Value = 0;

            // Встановлення плоскості відсічення за замовчуванням
            double[] defaultPlane = { (double)numericUpDownA.Value, (double)numericUpDownB.Value, (double)numericUpDownC.Value, (double)numericUpDownD.Value };
            renderControl1.SetClippingPlane(false, defaultPlane);

            // Додаємо обробник події для чекбоксу плоскості відсічення
            checkBox_Clip.CheckedChanged += checkBox_Clip_CheckedChanged;

            // Додаємо обробники подій для зміни значень коефіцієнтів плоскості відсічення
            numericUpDownA.ValueChanged += numericUpDownA_ValueChanged;
            numericUpDownB.ValueChanged += numericUpDownB_ValueChanged;
            numericUpDownC.ValueChanged += numericUpDownC_ValueChanged;
            numericUpDownD.ValueChanged += numericUpDownD_ValueChanged;
        }

        // Обробник події натискання кнопки миші
        private void RenderControl1_MouseDown(object sender, MouseEventArgs e)
        {
            lastMousePos = e.Location;
        }

        // Обробник події переміщення миші
        private void RenderControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Зміна кутів обертання на основі переміщення миші
                angleX += (e.Y - lastMousePos.Y);
                angleY += (e.X - lastMousePos.X);
                lastMousePos = e.Location;

                // Передача нових кутів в RenderControl і перерисовка
                renderControl1.SetRotation(angleX, angleY);
                renderControl1.Invalidate();
            }
        }

        // Обробник зміни стану радіокнопки "Заливка"
        private void RadioButtonFill_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFill.Checked)
            {
                renderControl1.SetRenderingMode(true); // Встановлення режиму заливки
            }
        }

        // Обробник зміни стану радіокнопки "Каркас"
        private void RadioButtonLine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLine.Checked)
            {
                renderControl1.SetRenderingMode(false); // Встановлення каркасного режиму
            }
        }

        // Обробник зміни стану чекбоксу плоскості відсічення
        private void checkBox_Clip_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBox_Clip.Checked;
            // Показуємо або ховаємо елементи керування плоскостями відсічення
            numericUpDownA.Visible = isChecked;
            numericUpDownB.Visible = isChecked;
            numericUpDownC.Visible = isChecked;
            numericUpDownD.Visible = isChecked;
            label1.Visible = isChecked;
            label2.Visible = isChecked;
            label3.Visible = isChecked;
            label4.Visible = isChecked;

            if (isChecked)
            {
                UpdateClippingPlane(); // Оновлюємо плоскості відсічення
            }
            else
            {
                renderControl1.SetClippingPlane(false, null); // Вимикаємо плоскості відсічення
            }
        }

        // Метод для оновлення плоскості відсічення на основі введених значень
        private void UpdateClippingPlane()
        {
            double A = (double)numericUpDownA.Value;
            double B = (double)numericUpDownB.Value;
            double C = (double)numericUpDownC.Value;
            double D = (double)numericUpDownD.Value;

            double[] planeEquation = { A, B, C, D };
            renderControl1.SetClippingPlane(true, planeEquation);
        }

        // Обробники змін значень числових полів для плоскості відсічення
        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Clip.Checked)
            {
                UpdateClippingPlane();
            }
        }

        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Clip.Checked)
            {
                UpdateClippingPlane();
            }
        }

        private void numericUpDownC_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Clip.Checked)
            {
                UpdateClippingPlane();
            }
        }

        private void numericUpDownD_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Clip.Checked)
            {
                UpdateClippingPlane();
            }
        }

        // Обробник зміни стану радіокнопки "Перспективна проекція"
        private void radioButtonPerspective_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPerspective.Checked)
            {
                renderControl1.SetProjectionMode(false); // Встановлення перспективної проекції
            }
        }

        // Обробник зміни стану радіокнопки "Ортографічна проекція"
        private void radioButtonOrtho_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOrtho.Checked)
            {
                renderControl1.SetProjectionMode(true); // Встановлення ортографічної проекції
            }
        }
    }
}