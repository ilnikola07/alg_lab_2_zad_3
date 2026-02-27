using System;
using System.Drawing;
using System.Linq;
namespace MyLogicLibrary
{
    public class GraphicEngine
    {
        // Храним частоты здесь
        public int[] _frequencies = new int[10];

        // Метод для обработки строки (вся логика из GetDigitFrequencies)
        public void CalculateFrequencies(string input)
        {
            _frequencies = new int[10]; // сброс
            if (string.IsNullOrEmpty(input)) return;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    int digit = c - '0';
                    _frequencies[digit]++;
                }
            }
        }

        // Метод отрисовки (вся логика из BuildHistogramInPictureBox)
        public void DrawScene(Graphics g, int width, int height)
        {
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int margin = 40;
            int chartWidth = width - 2 * margin;
            int chartHeight = height - 2 * margin - 30;

            int maxFrequency = _frequencies.Max();
            if (maxFrequency == 0) maxFrequency = 1;

            int barWidth = chartWidth / 10 - 5;
            int spacing = 5;

            // Рисуем оси
            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                g.DrawLine(axisPen, margin, height - margin, width - margin, height - margin);
                g.DrawLine(axisPen, margin, margin, margin, height - margin);
            }

            for (int i = 0; i < 10; i++)
            {
                int barHeight = (int)((_frequencies[i] / (double)maxFrequency) * chartHeight);
                int x = margin + i * (barWidth + spacing);
                int y = height - margin - barHeight;

                // Рисуем столбец
                Color barColor = (i % 2 == 0) ? Color.FromArgb(50, 100, 200) : Color.FromArgb(100, 150, 250);
                using (SolidBrush brush = new SolidBrush(barColor))
                {
                    g.FillRectangle(brush, x, y, barWidth, barHeight);
                }
                g.DrawRectangle(Pens.DarkBlue, x, y, barWidth, barHeight);

                // Подписи
                using (Font font = new Font("Arial", 8))
                {
                    g.DrawString(i.ToString(), font, Brushes.Black, x + barWidth / 2 - 5, height - margin + 5);
                    if (_frequencies[i] > 0)
                        g.DrawString(_frequencies[i].ToString(), font, Brushes.DarkRed, x + barWidth / 2 - 5, y - 15);
                }
            }
        }
    }
}
