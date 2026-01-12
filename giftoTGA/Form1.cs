using ImageMagick;
using System;
using System.Windows.Forms;

namespace giftoTGA
{
    public partial class Form1 : Form
    {
        private string selectedGifPath = string.Empty;
        private int defaultFrameWidth = 128;
        private int defaultFrameHeight = 128;

        public Form1()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            btnSelectGif.Click += BtnSelectGif_Click;
            btnConvertToTGA.Click += BtnConvertToTGA_Click;
        }

        private void BtnSelectGif_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedGifPath = openFileDialog.FileName;

                // Загружаем и отображаем GIF
                pictureBox.Image = System.Drawing.Image.FromFile(selectedGifPath);

                // Получаем размеры первого кадра GIF
                using (var images = new MagickImageCollection(selectedGifPath))
                {
                    defaultFrameWidth = (int)images[0].Width;
                    defaultFrameHeight = (int)images[0].Height;
                }

                // Обновляем метки с размерами фрейма
                lblFrameWidth.Text = $"Ширина фрейма: {defaultFrameWidth}";
                lblFrameHeight.Text = $"Высота фрейма: {defaultFrameHeight}";

                // Разрешаем конвертацию
                btnConvertToTGA.Enabled = true;
            }
        }

        private void BtnConvertToTGA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedGifPath))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string tgaFilePath = saveFileDialog.FileName;
                        int frameWidth = int.TryParse(txtFrameWidth.Text, out int width) ? width : defaultFrameWidth;
                        int frameHeight = int.TryParse(txtFrameHeight.Text, out int height) ? height : defaultFrameHeight;

                        using (var images = new MagickImageCollection())
                        {
                            images.Read(selectedGifPath);
                            images.Coalesce(); // Важно: преобразует дельта-кадры в полные кадры

                            int framesCount = images.Count;

                            uint finalWidth = (uint)(frameWidth * framesCount);
                            uint finalHeight = (uint)frameHeight;

                            finalWidth = GetNearestPowerOfTwo(finalWidth); // Округление до ближайшей степени двойки
                            finalHeight = GetNearestPowerOfTwo(finalHeight);

                            using (var resultImage = new MagickImage(MagickColors.Transparent, finalWidth, finalHeight))
                            {
                                resultImage.Format = MagickFormat.Tga;

                                int x = 0;
                                int processedFrames = 0;

                                for (int i = 0; i < framesCount; i++)
                                {
                                    // Перемещаем фреймы по одному
                                    using (var frame = images[i].Clone())
                                    {
                                        // Ресайзим кадры, если нужно
                                        if (frame.Width != frameWidth || frame.Height != frameHeight)
                                        {
                                            frame.Resize((uint)frameWidth, (uint)frameHeight);
                                        }

                                        resultImage.Composite(frame, x, 0, CompositeOperator.Copy);
                                        processedFrames++;
                                    }

                                    x += frameWidth;
                                }

                                resultImage.Write(tgaFilePath);

                                // Обновляем сообщение с подробной информацией
                                string message = $"Файл успешно сохранен!\n\n" +
                                                 $"Путь: {tgaFilePath}\n" +
                                                 $"Размер изображения: {finalWidth} x {finalHeight}\n" +
                                                 $"Размер фрейма: {frameWidth} x {frameHeight}\n" +
                                                 $"Количество фреймов: {processedFrames} из {framesCount}\n" +
                                                 $"Файл формата: TGA";

                                MessageBox.Show(message, "Конвертация завершена",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }

        private uint GetNearestPowerOfTwo(uint value)
        {
            uint powerOfTwo = 1;
            while (powerOfTwo < value)
            {
                powerOfTwo <<= 1; // Удваиваем степень двойки
            }
            return powerOfTwo;
        }

        private void txtFrameWidth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}