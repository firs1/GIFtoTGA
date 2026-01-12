namespace giftoTGA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectGif = new Button();
            btnConvertToTGA = new Button();
            pictureBox = new PictureBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            txtFrameWidth = new TextBox();
            txtFrameHeight = new TextBox();
            lblFrameWidth = new Label();
            lblFrameHeight = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // btnSelectGif
            // 
            btnSelectGif.Location = new Point(10, 10);
            btnSelectGif.Name = "btnSelectGif";
            btnSelectGif.Size = new Size(100, 30);
            btnSelectGif.TabIndex = 0;
            btnSelectGif.Text = "Выбрать GIF";
            btnSelectGif.UseVisualStyleBackColor = true;
            // 
            // btnConvertToTGA
            // 
            btnConvertToTGA.Enabled = false;
            btnConvertToTGA.Location = new Point(120, 10);
            btnConvertToTGA.Name = "btnConvertToTGA";
            btnConvertToTGA.Size = new Size(160, 30);
            btnConvertToTGA.TabIndex = 1;
            btnConvertToTGA.Text = "Конвертировать в TGA";
            btnConvertToTGA.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(10, 50);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(760, 350);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "GIF files (*.gif)|*.gif";
            openFileDialog.Title = "Выберите GIF файл";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "TGA files (*.tga)|*.tga";
            saveFileDialog.Title = "Сохранить TGA файл";
            // 
            // txtFrameWidth
            // 
            txtFrameWidth.Location = new Point(12, 414);
            txtFrameWidth.Name = "txtFrameWidth";
            txtFrameWidth.PlaceholderText = "Ширина фрейма";
            txtFrameWidth.Size = new Size(100, 23);
            txtFrameWidth.TabIndex = 3;
            txtFrameWidth.TextChanged += txtFrameWidth_TextChanged;
            // 
            // txtFrameHeight
            // 
            txtFrameHeight.Location = new Point(176, 414);
            txtFrameHeight.Name = "txtFrameHeight";
            txtFrameHeight.PlaceholderText = "Высота фрейма";
            txtFrameHeight.Size = new Size(100, 23);
            txtFrameHeight.TabIndex = 4;
            // 
            // lblFrameWidth
            // 
            lblFrameWidth.Location = new Point(10, 440);
            lblFrameWidth.Name = "lblFrameWidth";
            lblFrameWidth.Size = new Size(200, 30);
            lblFrameWidth.TabIndex = 5;
            lblFrameWidth.Text = "Ширина фрейма: ";
            // 
            // lblFrameHeight
            // 
            lblFrameHeight.Location = new Point(176, 440);
            lblFrameHeight.Name = "lblFrameHeight";
            lblFrameHeight.Size = new Size(200, 30);
            lblFrameHeight.TabIndex = 6;
            lblFrameHeight.Text = "Высота фрейма: ";
            // 
            // Form1
            // 
            ClientSize = new Size(800, 480);
            Controls.Add(lblFrameHeight);
            Controls.Add(lblFrameWidth);
            Controls.Add(txtFrameHeight);
            Controls.Add(txtFrameWidth);
            Controls.Add(pictureBox);
            Controls.Add(btnConvertToTGA);
            Controls.Add(btnSelectGif);
            Name = "Form1";
            Text = "GIF в TGA Конвертер";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSelectGif;
        private System.Windows.Forms.Button btnConvertToTGA;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox txtFrameWidth;
        private System.Windows.Forms.TextBox txtFrameHeight;
        private System.Windows.Forms.Label lblFrameWidth;
        private System.Windows.Forms.Label lblFrameHeight;
    }
}


