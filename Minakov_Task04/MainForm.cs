using System.Windows.Forms;
using System;

namespace Minakov_Task04
{
    public partial class MainForm : Form
    {
        // Флаг для визначення, чи оновлюються точки відрізка
        private bool isUpdatingSegmentPoints = false;

        public MainForm()
        {
            InitializeComponent();

            // Встановлюємо початкові значення елементів інтерфейсу
            radioButtonEllipse.Checked = true;

            numericUpDownHalfA.Value = 100;
            numericUpDownHalfB.Value = 50;

            numericUpDownA.Value = 1;
            numericUpDownB.Value = 0;
            numericUpDownC.Value = 0;
            numericUpDownTmin.Value = -10;
            numericUpDownTmax.Value = 10;

            numericUpDownA_X.Value = -50;
            numericUpDownA_Y.Value = -50;
            numericUpDownB_X.Value = 50;
            numericUpDownB_Y.Value = 50;

            // Встановлюємо значення в RenderControl
            renderControl.IsEllipseSelected = radioButtonEllipse.Checked;

            renderControl.Ellipse.CenterX = 0;
            renderControl.Ellipse.CenterY = 0;

            renderControl.Ellipse.SemiMajorAxis = (double)numericUpDownHalfA.Value;
            renderControl.Ellipse.SemiMinorAxis = (double)numericUpDownHalfB.Value;

            renderControl.Parabola.A = (double)numericUpDownA.Value;
            renderControl.Parabola.B = (double)numericUpDownB.Value;
            renderControl.Parabola.C = (double)numericUpDownC.Value;
            renderControl.Parabola.TMin = (double)numericUpDownTmin.Value;
            renderControl.Parabola.TMax = (double)numericUpDownTmax.Value;

            renderControl.Segment.AX = (double)numericUpDownA_X.Value;
            renderControl.Segment.AY = (double)numericUpDownA_Y.Value;
            renderControl.Segment.BX = (double)numericUpDownB_X.Value;
            renderControl.Segment.BY = (double)numericUpDownB_Y.Value;

            renderControl.Epsilon = 1e-6;

            // Підписуємося на подію зміни точок відрізка
            renderControl.SegmentPointsChanged += RenderControl_SegmentPointsChanged;
        }

        // Обробник події зміни точок відрізка
        private void RenderControl_SegmentPointsChanged(object sender, EventArgs e)
        {
            isUpdatingSegmentPoints = true;

            numericUpDownA_X.Value = (decimal)renderControl.Segment.AX;
            numericUpDownA_Y.Value = (decimal)renderControl.Segment.AY;
            numericUpDownB_X.Value = (decimal)renderControl.Segment.BX;
            numericUpDownB_Y.Value = (decimal)renderControl.Segment.BY;

            isUpdatingSegmentPoints = false;
        }

        // Обробник зміни стану радіокнопки еліпса
        private void radioButtonEllipse_CheckedChanged(object sender, EventArgs e)
        {
            renderControl.IsEllipseSelected = radioButtonEllipse.Checked;
            renderControl.Invalidate();
        }

        // Обробник зміни стану радіокнопки параболи
        private void radioButtonParabola_CheckedChanged(object sender, EventArgs e)
        {
            renderControl.IsEllipseSelected = !radioButtonParabola.Checked;
            renderControl.Invalidate();
        }

        // Обробник зміни значення піввісі A еліпса
        private void numericUpDownHalfA_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Ellipse.SemiMajorAxis = (double)numericUpDownHalfA.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни значення піввісі B еліпса
        private void numericUpDownHalfB_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Ellipse.SemiMinorAxis = (double)numericUpDownHalfB.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни коефіцієнта A параболи
        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Parabola.A = (double)numericUpDownA.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни коефіцієнта B параболи
        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Parabola.B = (double)numericUpDownB.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни коефіцієнта C параболи
        private void numericUpDownC_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Parabola.C = (double)numericUpDownC.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни мінімального параметра t параболи
        private void numericUpDownTmin_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Parabola.TMin = (double)numericUpDownTmin.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни максимального параметра t параболи
        private void numericUpDownTmax_ValueChanged(object sender, EventArgs e)
        {
            renderControl.Parabola.TMax = (double)numericUpDownTmax.Value;
            renderControl.Invalidate();
        }

        // Обробник зміни координати X точки A відрізка
        private void numericUpDownA_X_ValueChanged(object sender, EventArgs e)
        {
            if (!isUpdatingSegmentPoints)
            {
                renderControl.Segment.AX = (double)numericUpDownA_X.Value;
                renderControl.Invalidate();
            }
        }

        // Обробник зміни координати Y точки A відрізка
        private void numericUpDownA_Y_ValueChanged(object sender, EventArgs e)
        {
            if (!isUpdatingSegmentPoints)
            {
                renderControl.Segment.AY = (double)numericUpDownA_Y.Value;
                renderControl.Invalidate();
            }
        }

        // Обробник зміни координати X точки B відрізка
        private void numericUpDownB_X_ValueChanged(object sender, EventArgs e)
        {
            if (!isUpdatingSegmentPoints)
            {
                renderControl.Segment.BX = (double)numericUpDownB_X.Value;
                renderControl.Invalidate();
            }
        }

        // Обробник зміни координати Y точки B відрізка
        private void numericUpDownB_Y_ValueChanged(object sender, EventArgs e)
        {
            if (!isUpdatingSegmentPoints)
            {
                renderControl.Segment.BY = (double)numericUpDownB_Y.Value;
                renderControl.Invalidate();
            }
        }
    }
}