namespace FEM
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.glWindow = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.hsbAxisY = new System.Windows.Forms.HScrollBar();
            this.hsbAxisX = new System.Windows.Forms.HScrollBar();
            this.hsbAxisZ = new System.Windows.Forms.HScrollBar();
            this.nudParts = new System.Windows.Forms.NumericUpDown();
            this.btnDivide = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.cbxShowElements = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nudCubeIndex = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCubeIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new System.Drawing.Point(723, 96);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 20);
            label1.TabIndex = 3;
            label1.Text = "X axis";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(723, 66);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(132, 20);
            label2.TabIndex = 4;
            label2.Text = "Rotation around :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(723, 137);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 20);
            label3.TabIndex = 5;
            label3.Text = "Y axis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.Location = new System.Drawing.Point(723, 175);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(50, 20);
            label4.TabIndex = 6;
            label4.Text = "Z axis";
            // 
            // glWindow
            // 
            this.glWindow.AccumBits = ((byte)(0));
            this.glWindow.AutoCheckErrors = false;
            this.glWindow.AutoFinish = false;
            this.glWindow.AutoMakeCurrent = true;
            this.glWindow.AutoSwapBuffers = true;
            this.glWindow.BackColor = System.Drawing.Color.White;
            this.glWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glWindow.ColorBits = ((byte)(32));
            this.glWindow.DepthBits = ((byte)(16));
            this.glWindow.ForeColor = System.Drawing.Color.Black;
            this.glWindow.Location = new System.Drawing.Point(12, 12);
            this.glWindow.Name = "glWindow";
            this.glWindow.Size = new System.Drawing.Size(694, 636);
            this.glWindow.StencilBits = ((byte)(0));
            this.glWindow.TabIndex = 0;
            this.glWindow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Window_KeyUp);
            // 
            // hsbAxisY
            // 
            this.hsbAxisY.LargeChange = 1;
            this.hsbAxisY.Location = new System.Drawing.Point(840, 137);
            this.hsbAxisY.Maximum = 360;
            this.hsbAxisY.Name = "hsbAxisY";
            this.hsbAxisY.Size = new System.Drawing.Size(184, 24);
            this.hsbAxisY.TabIndex = 2;
            this.hsbAxisY.Tag = "Z rotation angle";
            this.hsbAxisY.Value = 330;
            this.hsbAxisY.ValueChanged += new System.EventHandler(this.ScrollBar_ValueChanged);
            // 
            // hsbAxisX
            // 
            this.hsbAxisX.LargeChange = 1;
            this.hsbAxisX.Location = new System.Drawing.Point(840, 96);
            this.hsbAxisX.Maximum = 360;
            this.hsbAxisX.Name = "hsbAxisX";
            this.hsbAxisX.Size = new System.Drawing.Size(184, 24);
            this.hsbAxisX.TabIndex = 7;
            this.hsbAxisX.Tag = "Z rotation angle";
            this.hsbAxisX.Value = 30;
            this.hsbAxisX.ValueChanged += new System.EventHandler(this.ScrollBar_ValueChanged);
            // 
            // hsbAxisZ
            // 
            this.hsbAxisZ.LargeChange = 1;
            this.hsbAxisZ.Location = new System.Drawing.Point(840, 175);
            this.hsbAxisZ.Maximum = 360;
            this.hsbAxisZ.Name = "hsbAxisZ";
            this.hsbAxisZ.Size = new System.Drawing.Size(184, 24);
            this.hsbAxisZ.TabIndex = 8;
            this.hsbAxisZ.Tag = "Z rotation angle";
            this.hsbAxisZ.ValueChanged += new System.EventHandler(this.ScrollBar_ValueChanged);
            // 
            // nudParts
            // 
            this.nudParts.Location = new System.Drawing.Point(789, 12);
            this.nudParts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudParts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudParts.Name = "nudParts";
            this.nudParts.Size = new System.Drawing.Size(42, 20);
            this.nudParts.TabIndex = 9;
            this.nudParts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(713, 12);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(75, 20);
            this.btnDivide.TabIndex = 10;
            this.btnDivide.Text = "Divide";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(712, 232);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(326, 366);
            this.rtb.TabIndex = 11;
            this.rtb.Text = "";
            // 
            // cbxShowElements
            // 
            this.cbxShowElements.AutoSize = true;
            this.cbxShowElements.Location = new System.Drawing.Point(713, 209);
            this.cbxShowElements.Name = "cbxShowElements";
            this.cbxShowElements.Size = new System.Drawing.Size(96, 17);
            this.cbxShowElements.TabIndex = 12;
            this.cbxShowElements.Text = "show elements";
            this.cbxShowElements.UseVisualStyleBackColor = true;
            this.cbxShowElements.CheckedChanged += new System.EventHandler(this.cbxShowElements_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // nudCubeIndex
            // 
            this.nudCubeIndex.Location = new System.Drawing.Point(840, 209);
            this.nudCubeIndex.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCubeIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCubeIndex.Name = "nudCubeIndex";
            this.nudCubeIndex.Size = new System.Drawing.Size(42, 20);
            this.nudCubeIndex.TabIndex = 14;
            this.nudCubeIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCubeIndex.ValueChanged += new System.EventHandler(this.nudCubeIndex_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1033, 660);
            this.Controls.Add(this.nudCubeIndex);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbxShowElements);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.nudParts);
            this.Controls.Add(this.hsbAxisZ);
            this.Controls.Add(this.hsbAxisX);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.hsbAxisY);
            this.Controls.Add(this.glWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.Text = "FEM";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Window_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.nudParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCubeIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl glWindow;
        private System.Windows.Forms.HScrollBar hsbAxisY;
        private System.Windows.Forms.HScrollBar hsbAxisX;
        private System.Windows.Forms.HScrollBar hsbAxisZ;
        private System.Windows.Forms.NumericUpDown nudParts;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.CheckBox cbxShowElements;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nudCubeIndex;
    }
}

