namespace SharpGLWinformsApplication1
{
    partial class SharpGLForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpGLForm));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.lbYCoor = new System.Windows.Forms.Label();
            this.lbXCoor = new System.Windows.Forms.Label();
            this.lbZCoor = new System.Windows.Forms.Label();
            this.lbθ3Coor = new System.Windows.Forms.Label();
            this.lbθ2Coor = new System.Windows.Forms.Label();
            this.lbθ1Coor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbθ3Coor = new System.Windows.Forms.TextBox();
            this.tbθ2Coor = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.tbθ1Coor = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbWorkSpace = new System.Windows.Forms.GroupBox();
            this.tbYCoor = new System.Windows.Forms.TextBox();
            this.tbZCoor = new System.Windows.Forms.TextBox();
            this.tbXCoor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbWorkSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.AutoScroll = true;
            this.openGLControl.AutoSize = true;
            this.openGLControl.BackColor = System.Drawing.Color.White;
            this.openGLControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openGLControl.BitDepth = 24;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.FrameRate = 20;
            this.openGLControl.Location = new System.Drawing.Point(12, 0);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl.Size = new System.Drawing.Size(1270, 648);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyDown);
            this.openGLControl.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseWheel);
            // 
            // lbYCoor
            // 
            this.lbYCoor.AutoSize = true;
            this.lbYCoor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbYCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYCoor.ForeColor = System.Drawing.Color.Yellow;
            this.lbYCoor.Location = new System.Drawing.Point(25, 67);
            this.lbYCoor.Name = "lbYCoor";
            this.lbYCoor.Size = new System.Drawing.Size(29, 24);
            this.lbYCoor.TabIndex = 219;
            this.lbYCoor.Text = "Y:";
            // 
            // lbXCoor
            // 
            this.lbXCoor.AutoSize = true;
            this.lbXCoor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbXCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXCoor.ForeColor = System.Drawing.Color.Yellow;
            this.lbXCoor.Location = new System.Drawing.Point(25, 41);
            this.lbXCoor.Name = "lbXCoor";
            this.lbXCoor.Size = new System.Drawing.Size(31, 24);
            this.lbXCoor.TabIndex = 218;
            this.lbXCoor.Text = "X:";
            // 
            // lbZCoor
            // 
            this.lbZCoor.AutoSize = true;
            this.lbZCoor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbZCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZCoor.ForeColor = System.Drawing.Color.Yellow;
            this.lbZCoor.Location = new System.Drawing.Point(25, 94);
            this.lbZCoor.Name = "lbZCoor";
            this.lbZCoor.Size = new System.Drawing.Size(29, 24);
            this.lbZCoor.TabIndex = 220;
            this.lbZCoor.Text = "Z:";
            // 
            // lbθ3Coor
            // 
            this.lbθ3Coor.AutoSize = true;
            this.lbθ3Coor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbθ3Coor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbθ3Coor.ForeColor = System.Drawing.Color.Yellow;
            this.lbθ3Coor.Location = new System.Drawing.Point(25, 215);
            this.lbθ3Coor.Name = "lbθ3Coor";
            this.lbθ3Coor.Size = new System.Drawing.Size(38, 24);
            this.lbθ3Coor.TabIndex = 237;
            this.lbθ3Coor.Text = "θ3:";
            // 
            // lbθ2Coor
            // 
            this.lbθ2Coor.AutoSize = true;
            this.lbθ2Coor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbθ2Coor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbθ2Coor.ForeColor = System.Drawing.Color.Yellow;
            this.lbθ2Coor.Location = new System.Drawing.Point(25, 188);
            this.lbθ2Coor.Name = "lbθ2Coor";
            this.lbθ2Coor.Size = new System.Drawing.Size(38, 24);
            this.lbθ2Coor.TabIndex = 236;
            this.lbθ2Coor.Text = "θ2:";
            // 
            // lbθ1Coor
            // 
            this.lbθ1Coor.AutoSize = true;
            this.lbθ1Coor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbθ1Coor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbθ1Coor.ForeColor = System.Drawing.Color.Yellow;
            this.lbθ1Coor.Location = new System.Drawing.Point(25, 162);
            this.lbθ1Coor.Name = "lbθ1Coor";
            this.lbθ1Coor.Size = new System.Drawing.Size(38, 24);
            this.lbθ1Coor.TabIndex = 235;
            this.lbθ1Coor.Text = "θ1:";
            this.lbθ1Coor.Click += new System.EventHandler(this.lbθ1Coor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbθ3Coor);
            this.groupBox1.Controls.Add(this.tbθ2Coor);
            this.groupBox1.Controls.Add(this.button22);
            this.groupBox1.Controls.Add(this.tbθ1Coor);
            this.groupBox1.Controls.Add(this.button23);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 143);
            this.groupBox1.TabIndex = 238;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Join-space";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(63, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 24);
            this.label10.TabIndex = 180;
            this.label10.Text = "θ3:";
            // 
            // tbθ3Coor
            // 
            this.tbθ3Coor.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbθ3Coor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbθ3Coor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbθ3Coor.ForeColor = System.Drawing.Color.Yellow;
            this.tbθ3Coor.Location = new System.Drawing.Point(103, 85);
            this.tbθ3Coor.Name = "tbθ3Coor";
            this.tbθ3Coor.Size = new System.Drawing.Size(123, 20);
            this.tbθ3Coor.TabIndex = 169;
            this.tbθ3Coor.Text = "0.000";
            this.tbθ3Coor.TextChanged += new System.EventHandler(this.tbθ3Coor_TextChanged);
            // 
            // tbθ2Coor
            // 
            this.tbθ2Coor.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbθ2Coor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbθ2Coor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbθ2Coor.ForeColor = System.Drawing.Color.Yellow;
            this.tbθ2Coor.Location = new System.Drawing.Point(102, 59);
            this.tbθ2Coor.Name = "tbθ2Coor";
            this.tbθ2Coor.Size = new System.Drawing.Size(124, 20);
            this.tbθ2Coor.TabIndex = 167;
            this.tbθ2Coor.Text = "0.000";
            this.tbθ2Coor.TextChanged += new System.EventHandler(this.tbθ2Coor_TextChanged);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(293, 228);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(48, 23);
            this.button22.TabIndex = 179;
            this.button22.Text = "zero";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // tbθ1Coor
            // 
            this.tbθ1Coor.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbθ1Coor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbθ1Coor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbθ1Coor.ForeColor = System.Drawing.Color.Yellow;
            this.tbθ1Coor.Location = new System.Drawing.Point(104, 33);
            this.tbθ1Coor.Name = "tbθ1Coor";
            this.tbθ1Coor.Size = new System.Drawing.Size(122, 20);
            this.tbθ1Coor.TabIndex = 166;
            this.tbθ1Coor.Text = "0.000";
            this.tbθ1Coor.TextChanged += new System.EventHandler(this.tbθ1Coor_TextChanged);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(347, 228);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(48, 23);
            this.button23.TabIndex = 177;
            this.button23.Text = "set";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(222, 25);
            this.label7.TabIndex = 127;
            this.label7.Text = "                                   ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 25);
            this.label8.TabIndex = 168;
            this.label8.Text = "                                   ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 25);
            this.label9.TabIndex = 129;
            this.label9.Text = "                                   ";
            // 
            // gbWorkSpace
            // 
            this.gbWorkSpace.Controls.Add(this.tbYCoor);
            this.gbWorkSpace.Controls.Add(this.tbZCoor);
            this.gbWorkSpace.Controls.Add(this.tbXCoor);
            this.gbWorkSpace.Controls.Add(this.label1);
            this.gbWorkSpace.Controls.Add(this.label2);
            this.gbWorkSpace.Controls.Add(this.label3);
            this.gbWorkSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWorkSpace.ForeColor = System.Drawing.Color.Blue;
            this.gbWorkSpace.Location = new System.Drawing.Point(12, 13);
            this.gbWorkSpace.Name = "gbWorkSpace";
            this.gbWorkSpace.Size = new System.Drawing.Size(265, 121);
            this.gbWorkSpace.TabIndex = 221;
            this.gbWorkSpace.TabStop = false;
            this.gbWorkSpace.Text = "Work-space";
            this.gbWorkSpace.Enter += new System.EventHandler(this.gbWorkSpace_Enter);
            // 
            // tbYCoor
            // 
            this.tbYCoor.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbYCoor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbYCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbYCoor.ForeColor = System.Drawing.Color.Yellow;
            this.tbYCoor.Location = new System.Drawing.Point(104, 59);
            this.tbYCoor.Name = "tbYCoor";
            this.tbYCoor.Size = new System.Drawing.Size(144, 20);
            this.tbYCoor.TabIndex = 167;
            this.tbYCoor.Text = "0";
            this.tbYCoor.TextChanged += new System.EventHandler(this.tbYCoor_TextChanged);
            // 
            // tbZCoor
            // 
            this.tbZCoor.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbZCoor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbZCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZCoor.ForeColor = System.Drawing.Color.Yellow;
            this.tbZCoor.Location = new System.Drawing.Point(103, 85);
            this.tbZCoor.Name = "tbZCoor";
            this.tbZCoor.Size = new System.Drawing.Size(145, 20);
            this.tbZCoor.TabIndex = 169;
            this.tbZCoor.Text = "0";
            this.tbZCoor.TextChanged += new System.EventHandler(this.tbZCoor_TextChanged);
            // 
            // tbXCoor
            // 
            this.tbXCoor.BackColor = System.Drawing.SystemColors.MenuText;
            this.tbXCoor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbXCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbXCoor.ForeColor = System.Drawing.Color.Yellow;
            this.tbXCoor.Location = new System.Drawing.Point(104, 30);
            this.tbXCoor.Name = "tbXCoor";
            this.tbXCoor.Size = new System.Drawing.Size(145, 20);
            this.tbXCoor.TabIndex = 166;
            this.tbXCoor.Text = "0";
            this.tbXCoor.TextChanged += new System.EventHandler(this.tbXCoor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 127;
            this.label1.Text = "                                   ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 25);
            this.label2.TabIndex = 168;
            this.label2.Text = "                                   ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 25);
            this.label3.TabIndex = 129;
            this.label3.Text = "                                   ";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "windy.png");
            this.imageList1.Images.SetKeyName(1, "stop.png");
            this.imageList1.Images.SetKeyName(2, "bolt.png");
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 324);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(222, 20);
            this.textBox1.TabIndex = 239;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 28);
            this.button1.TabIndex = 240;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // timer3
            // 
            this.timer3.Interval = 50;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 28);
            this.button2.TabIndex = 241;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(65, 298);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 20);
            this.textBox2.TabIndex = 242;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(167, 298);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(94, 20);
            this.textBox3.TabIndex = 243;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(39, 494);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(222, 20);
            this.textBox4.TabIndex = 244;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(39, 536);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(222, 20);
            this.textBox5.TabIndex = 245;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(38, 575);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(222, 20);
            this.textBox6.TabIndex = 246;
            // 
            // SharpGLForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 660);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbYCoor);
            this.Controls.Add(this.lbXCoor);
            this.Controls.Add(this.lbZCoor);
            this.Controls.Add(this.lbθ3Coor);
            this.Controls.Add(this.lbθ2Coor);
            this.Controls.Add(this.lbθ1Coor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbWorkSpace);
            this.Controls.Add(this.openGLControl);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "SharpGLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SharpGL Form";
            this.Load += new System.EventHandler(this.SharpGLForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpGLForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbWorkSpace.ResumeLayout(false);
            this.gbWorkSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbYCoor;
        private System.Windows.Forms.Label lbXCoor;
        private System.Windows.Forms.Label lbZCoor;
        private System.Windows.Forms.Label lbθ3Coor;
        private System.Windows.Forms.Label lbθ2Coor;
        private System.Windows.Forms.Label lbθ1Coor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbWorkSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbθ3Coor;
        private System.Windows.Forms.TextBox tbθ2Coor;
        private System.Windows.Forms.TextBox tbθ1Coor;
        private System.Windows.Forms.TextBox tbZCoor;
        private System.Windows.Forms.TextBox tbYCoor;
        private System.Windows.Forms.TextBox tbXCoor;
        private System.Windows.Forms.Timer timer2;
        public SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button2;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
    }
}

