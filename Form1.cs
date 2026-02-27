using MyLogicLibrary;
using System;
using System.Drawing;
using System.Linq;

namespace WinFormsApp_alg_lab_2_zad_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private GraphicEngine _engine = new GraphicEngine();

        //public MainForm()
        //{
        //    InitializeComponent();
        //}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Вызываем логику из библиотеки, передавая Graphics из события Paint
            _engine.DrawScene(e.Graphics, pictureBox1.Width, pictureBox1.Height);
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    // Если данные изменились, просто просим PictureBox перерисоваться
        //    pictureBox1.Invalidate();
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // Принудительно вызывает событие Paint у PictureBox
        //    pictureBox1.Invalidate();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Проверяем длину (валидация на стороне формы — это нормально)
            if (textBox1.Text.Length > 20)
            {
                MessageBox.Show("Строка слишком длинная!");
                return;
            }

            // 2. Передаем текст в библиотеку для расчетов
            _engine.CalculateFrequencies(textBox1.Text);

            // 3. Обновляем PictureBox (это вызовет Paint и метод DrawScene)
            pictureBox1.Invalidate();


            //try
            //{
            //    // Получаем частоты цифр
            //    int[] digitFrequencies = GetDigitFrequenciesFromTextBox(textBox1);

            //    // Строим гистограмму
            //    BuildHistogramInPictureBox(digitFrequencies, pictureBox1);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //private int[] GetDigitFrequenciesFromTextBox(TextBox textBox)
        //{
        //    int maxlength = 20;
        //    string input = textBox.Text.Trim();
        //    if (input.Length > maxlength)
        //    {
        //        throw new ArgumentException($"Строка слишком длинная. Максимальная длина: {maxlength} символов.");
        //    }

        //    if (string.IsNullOrEmpty(input))
        //    {
        //        MessageBox.Show("Введите число в поле ввода", "Предупреждение",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return new int[10]; // Возвращаем массив нулей
        //    }

        //    int[] frequency = new int[10];
        //    bool hasDigits = false; // Флаг: нашли ли хотя бы одну цифру

        //    foreach (char c in input)
        //    {
        //        if (char.IsDigit(c))
        //        {
        //            int digit = c - '0';
        //            frequency[digit]++;
        //            hasDigits = true; // Отметили, что цифра есть
        //        }
        //    }

        //    // Если ни одной цифры не найдено — сообщаем пользователю
        //    if (!hasDigits)
        //    {
        //        MessageBox.Show("Введённая строка не содержит ни одной цифры. Пожалуйста, введите цифры.",
        //            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return new int[10]; // Возвращаем массив нулей
        //    }

        //    return frequency;

        //}
        //private void BuildHistogramInPictureBox(int[] frequencies, PictureBox pictureBox)
        //{
        //    // Проверяем, есть ли данные
        //    if (frequencies == null || frequencies.Length != 10)
        //        return;

        //    // Создаём Bitmap для рисования
        //    int width = pictureBox.Width;
        //    int height = pictureBox.Height;
        //    Bitmap bitmap = new Bitmap(width, height);
        //    using (Graphics g = Graphics.FromImage(bitmap))
        //    {
        //        // Очищаем фон
        //        g.Clear(Color.White);

        //        // Настраиваем сглаживание для более гладких линий
        //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        //        // Определяем параметры для столбцов
        //        int margin = 40; // Отступы от краёв
        //        int chartWidth = width - 2 * margin;
        //        int chartHeight = height - 2 * margin - 30; // -30 для подписей оси X

        //        // Находим максимальное значение для масштабирования
        //        int maxFrequency = frequencies.Max();
        //        if (maxFrequency == 0) maxFrequency = 1; // Чтобы избежать деления на ноль

        //        // Ширина одного столбца
        //        int barWidth = chartWidth / 10 - 5; // 10 столбцов, отступ между ними
        //        int spacing = 5;

        //        // Рисуем оси
        //        Pen axisPen = new Pen(Color.Black, 2);
        //        g.DrawLine(axisPen, margin, height - margin, width - margin, height - margin); // Ось X
        //        g.DrawLine(axisPen, margin, margin, margin, height - margin); // Ось Y

        //        // Подписи осей
        //        using (Font font = new Font("Arial", 8))
        //        {
        //            g.DrawString("Цифры", font, Brushes.Black, width / 2 - 20, height - 14);
        //            g.DrawString("Частота", font, Brushes.Black, 10, height / 14);
        //        }

        //        // Рисуем столбцы и подписи
        //        for (int i = 0; i < 10; i++)
        //        {
        //            // Рассчитываем высоту столбца (пропорционально частоте)
        //            int barHeight = (int)((frequencies[i] / (double)maxFrequency) * chartHeight);

        //            // Позиция столбца
        //            int x = margin + i * (barWidth + spacing);
        //            int y = height - margin - barHeight;

        //            // Цвет столбца (можно сделать градиент или разные цвета)
        //            Color barColor = Color.FromArgb(50, 100, 200);
        //            if (i % 2 == 0)
        //                barColor = Color.FromArgb(100, 150, 250);

        //            // Рисуем столбец
        //            using (SolidBrush brush = new SolidBrush(barColor))
        //            {
        //                g.FillRectangle(brush, x, y, barWidth, barHeight);
        //            }

        //            // Обводим контур
        //            g.DrawRectangle(Pens.DarkBlue, x, y, barWidth, barHeight);

        //            // Подпись под столбцом (цифра)
        //            string digitLabel = i.ToString();
        //            g.DrawString(digitLabel, new Font("Arial", 8), Brushes.Black, x + barWidth / 2 - 5, height - margin + 5);

        //            // Подпись над столбцом (частота)
        //            if (frequencies[i] > 0)
        //            {
        //                string freqLabel = frequencies[i].ToString();
        //                g.DrawString(freqLabel, new Font("Arial", 7), Brushes.DarkRed, x + barWidth / 2 - 5, y - 15);
        //            }
        //        }
        //    }

        //    // Назначаем готовый Bitmap в PictureBox
        //    pictureBox.Image = bitmap;
        //}
    }
}
