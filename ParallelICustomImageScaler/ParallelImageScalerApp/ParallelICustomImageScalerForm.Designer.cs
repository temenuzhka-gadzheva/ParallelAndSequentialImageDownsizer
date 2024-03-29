﻿namespace ParallelImageScalerApp
{
    partial class ParallelICustomImageScalerForm
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

        /// <summary>
        /// Windowns Form Designer variables generated
        /// </summary>

        private System.Windows.Forms.Button ChooseImageButton;
        private System.Windows.Forms.NumericUpDown ScaleFactorNumeric;
        private System.Windows.Forms.Button ResizeSequentialButton;
        private System.Windows.Forms.Button ResizeParallelButton;
        private System.Windows.Forms.PictureBox resizedPictureBox;
        private System.Windows.Forms.Label originalImageLabel;
        private System.Windows.Forms.Label resizedImageLabel;
        private System.Windows.Forms.Label scaleFactorNumericLabel;
        private System.Windows.Forms.Label resizingTypeLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.Button DownloadResizedImage;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChooseImageButton = new System.Windows.Forms.Button();
            this.ScaleFactorNumeric = new System.Windows.Forms.NumericUpDown();
            this.ResizeSequentialButton = new System.Windows.Forms.Button();
            this.ResizeParallelButton = new System.Windows.Forms.Button();
            this.resizedPictureBox = new System.Windows.Forms.PictureBox();
            this.originalImageLabel = new System.Windows.Forms.Label();
            this.resizedImageLabel = new System.Windows.Forms.Label();
            this.scaleFactorNumericLabel = new System.Windows.Forms.Label();
            this.resizingTypeLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.DownloadResizedImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleFactorNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChooseImageButton
            // 
            this.ChooseImageButton.BackColor = System.Drawing.Color.White;
            this.ChooseImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseImageButton.Location = new System.Drawing.Point(20, 58);
            this.ChooseImageButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChooseImageButton.Name = "ChooseImageButton";
            this.ChooseImageButton.Size = new System.Drawing.Size(266, 89);
            this.ChooseImageButton.TabIndex = 0;
            this.ChooseImageButton.Text = "Upload image";
            this.ChooseImageButton.UseVisualStyleBackColor = false;
            this.ChooseImageButton.Click += new System.EventHandler(this.ChooseImageButton_Click);
            // 
            // ScaleFactorNumeric
            // 
            this.ScaleFactorNumeric.BackColor = System.Drawing.Color.White;
            this.ScaleFactorNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScaleFactorNumeric.Location = new System.Drawing.Point(1012, 104);
            this.ScaleFactorNumeric.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ScaleFactorNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleFactorNumeric.Name = "ScaleFactorNumeric";
            this.ScaleFactorNumeric.Size = new System.Drawing.Size(215, 39);
            this.ScaleFactorNumeric.TabIndex = 1;
            this.ScaleFactorNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ResizeSequentialButton
            // 
            this.ResizeSequentialButton.BackColor = System.Drawing.Color.White;
            this.ResizeSequentialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResizeSequentialButton.Location = new System.Drawing.Point(605, 76);
            this.ResizeSequentialButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResizeSequentialButton.Name = "ResizeSequentialButton";
            this.ResizeSequentialButton.Size = new System.Drawing.Size(218, 71);
            this.ResizeSequentialButton.TabIndex = 2;
            this.ResizeSequentialButton.Text = "Sequential";
            this.ResizeSequentialButton.UseVisualStyleBackColor = false;
            this.ResizeSequentialButton.Click += new System.EventHandler(this.ResizeSequentialButton_Click);
            // 
            // ResizeParallelButton
            // 
            this.ResizeParallelButton.BackColor = System.Drawing.Color.White;
            this.ResizeParallelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResizeParallelButton.Location = new System.Drawing.Point(351, 76);
            this.ResizeParallelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResizeParallelButton.Name = "ResizeParallelButton";
            this.ResizeParallelButton.Size = new System.Drawing.Size(215, 71);
            this.ResizeParallelButton.TabIndex = 3;
            this.ResizeParallelButton.Text = "Parallel";
            this.ResizeParallelButton.UseVisualStyleBackColor = false;
            this.ResizeParallelButton.Click += new System.EventHandler(this.ResizeParallelButton_Click);
            // 
            // resizedPictureBox
            // 
            this.resizedPictureBox.Location = new System.Drawing.Point(849, 239);
            this.resizedPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resizedPictureBox.Name = "resizedPictureBox";
            this.resizedPictureBox.Size = new System.Drawing.Size(457, 331);
            this.resizedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resizedPictureBox.TabIndex = 5;
            this.resizedPictureBox.TabStop = false;
            // 
            // originalImageLabel
            // 
            this.originalImageLabel.AutoSize = true;
            this.originalImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.originalImageLabel.Location = new System.Drawing.Point(15, 187);
            this.originalImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.originalImageLabel.Name = "originalImageLabel";
            this.originalImageLabel.Size = new System.Drawing.Size(222, 32);
            this.originalImageLabel.TabIndex = 6;
            this.originalImageLabel.Text = "Uploaded image";
            // 
            // resizedImageLabel
            // 
            this.resizedImageLabel.AutoSize = true;
            this.resizedImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resizedImageLabel.Location = new System.Drawing.Point(843, 187);
            this.resizedImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resizedImageLabel.Name = "resizedImageLabel";
            this.resizedImageLabel.Size = new System.Drawing.Size(238, 32);
            this.resizedImageLabel.TabIndex = 7;
            this.resizedImageLabel.Text = "Downsized image";
            // 
            // scaleFactorNumericLabel
            // 
            this.scaleFactorNumericLabel.AutoSize = true;
            this.scaleFactorNumericLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scaleFactorNumericLabel.Location = new System.Drawing.Point(1006, 34);
            this.scaleFactorNumericLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scaleFactorNumericLabel.Name = "scaleFactorNumericLabel";
            this.scaleFactorNumericLabel.Size = new System.Drawing.Size(222, 29);
            this.scaleFactorNumericLabel.TabIndex = 8;
            this.scaleFactorNumericLabel.Text = "Downscaling factor ";
            // 
            // resizingTypeLabel
            // 
            this.resizingTypeLabel.AutoSize = true;
            this.resizingTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resizingTypeLabel.Location = new System.Drawing.Point(431, 34);
            this.resizingTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resizingTypeLabel.Name = "resizingTypeLabel";
            this.resizingTypeLabel.Size = new System.Drawing.Size(299, 32);
            this.resizingTypeLabel.TabIndex = 9;
            this.resizingTypeLabel.Text = "Choose downsize type";
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.White;
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(1346, 40);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(295, 139);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Clear image";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.originalPictureBox.Location = new System.Drawing.Point(15, 239);
            this.originalPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(474, 331);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPictureBox.TabIndex = 12;
            this.originalPictureBox.TabStop = false;
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.BackColor = System.Drawing.Color.White;
            this.percentageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.percentageLabel.Location = new System.Drawing.Point(1111, 107);
            this.percentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(39, 32);
            this.percentageLabel.TabIndex = 13;
            this.percentageLabel.Text = "%";
            // 
            // DownloadResizedImage
            // 
            this.DownloadResizedImage.BackColor = System.Drawing.Color.White;
            this.DownloadResizedImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadResizedImage.Location = new System.Drawing.Point(1346, 202);
            this.DownloadResizedImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DownloadResizedImage.Name = "DownloadResizedImage";
            this.DownloadResizedImage.Size = new System.Drawing.Size(295, 96);
            this.DownloadResizedImage.TabIndex = 14;
            this.DownloadResizedImage.Text = "Download";
            this.DownloadResizedImage.UseVisualStyleBackColor = false;
            this.DownloadResizedImage.Click += new System.EventHandler(this.DownloadResizedImage_Click);
            // 
            // ParallelICustomImageScalerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1663, 598);
            this.Controls.Add(this.DownloadResizedImage);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.originalPictureBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.resizingTypeLabel);
            this.Controls.Add(this.scaleFactorNumericLabel);
            this.Controls.Add(this.resizedImageLabel);
            this.Controls.Add(this.originalImageLabel);
            this.Controls.Add(this.resizedPictureBox);
            this.Controls.Add(this.ResizeParallelButton);
            this.Controls.Add(this.ResizeSequentialButton);
            this.Controls.Add(this.ScaleFactorNumeric);
            this.Controls.Add(this.ChooseImageButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ParallelICustomImageScalerForm";
            this.Text = "Custom Image Scaler";
            ((System.ComponentModel.ISupportInitialize)(this.ScaleFactorNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}