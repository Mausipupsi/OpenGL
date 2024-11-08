using System;
using System.Windows.Forms;
using static Minakov_Lab2.OpenGL;

namespace Minakov_Lab2
{
    public partial class MainForm : Form
    {
        // Конструктор головної форми
        public MainForm()
        {
            InitializeComponent();
            // Встановлення початкових значень для числових контролів
            numericUpDownHorizontal.Value = 1;
            numericUpDownVertical.Value = 1;
            // Встановлення радіокнопки "Fill" за замовчуванням
            radioButtonFill.Checked = true;
            // Підписка на подію зміни режиму рендерингу
            renderControl.RenderModeChanged += RenderControl_RenderModeChanged;
        }

        // Обробник зміни значення горизонтальної кількості плиток
        private void NumericUpDownHorizontal_ValueChanged(object sender, EventArgs e)
        {
            UpdateTileCount();
        }

        // Обробник зміни значення вертикальної кількості плиток
        private void NumericUpDownVertical_ValueChanged(object sender, EventArgs e)
        {
            UpdateTileCount();
        }

        // Метод оновлення кількості плиток на основі введених значень
        private void UpdateTileCount()
        {
            int horizontal = (int)numericUpDownHorizontal.Value;
            int vertical = (int)numericUpDownVertical.Value;
            renderControl.UpdateTileCount(horizontal, vertical);
        }

        // Обробник зміни стану радіокнопки "Fill"
        private void RadioButtonFill_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFill.Checked)
            {
                renderControl.SetRenderMode(RenderControl.RenderMode.Fill);
            }
        }

        // Обробник зміни стану радіокнопки "Line"
        private void RadioButtonLine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLine.Checked)
            {
                renderControl.SetRenderMode(RenderControl.RenderMode.Line);
            }
        }

        // Обробник зміни стану радіокнопки "Point"
        private void RadioButtonPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPoint.Checked)
            {
                renderControl.SetRenderMode(RenderControl.RenderMode.Point);
            }
        }

        // Обробник події зміни режиму рендерингу в контролі рендерингу
        private void RenderControl_RenderModeChanged(object sender, RenderControl.RenderModeChangedEventArgs e)
        {
            switch (e.NewRenderMode)
            {
                case RenderControl.RenderMode.Fill:
                    radioButtonFill.Checked = true;
                    break;
                case RenderControl.RenderMode.Line:
                    radioButtonLine.Checked = true;
                    break;
                case RenderControl.RenderMode.Point:
                    radioButtonPoint.Checked = true;
                    break;
            }
        }
    }
}