namespace removipe
{
    partial class SettingForm
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
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_save_log_date = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chk_simul_mode = new System.Windows.Forms.CheckBox();
            this.chk_save_log = new System.Windows.Forms.CheckBox();
            this.chk_press_open = new System.Windows.Forms.CheckBox();
            this.chk_time_open = new System.Windows.Forms.CheckBox();
            this.txt_press_open_value = new System.Windows.Forms.TextBox();
            this.lbl_press_value = new System.Windows.Forms.Label();
            this.txt_time_open_value = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_press_count = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_valve_interval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_time_interval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_time_repeat_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_press_interval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_press_repeat_value = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_apply
            // 
            this.btn_apply.BackColor = System.Drawing.Color.White;
            this.btn_apply.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_apply.FlatAppearance.BorderSize = 2;
            this.btn_apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_apply.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_apply.Location = new System.Drawing.Point(473, 602);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(200, 180);
            this.btn_apply.TabIndex = 0;
            this.btn_apply.Text = "Apply";
            this.btn_apply.UseVisualStyleBackColor = false;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_close.FlatAppearance.BorderSize = 2;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(702, 602);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(200, 180);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_save_log_date
            // 
            this.lbl_save_log_date.AutoSize = true;
            this.lbl_save_log_date.Location = new System.Drawing.Point(31, 71);
            this.lbl_save_log_date.Name = "lbl_save_log_date";
            this.lbl_save_log_date.Size = new System.Drawing.Size(152, 23);
            this.lbl_save_log_date.TabIndex = 15;
            this.lbl_save_log_date.Text = "로그 최대 저장일(d)";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(190, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(55, 42);
            this.textBox3.TabIndex = 14;
            // 
            // chk_simul_mode
            // 
            this.chk_simul_mode.AutoSize = true;
            this.chk_simul_mode.Location = new System.Drawing.Point(13, 118);
            this.chk_simul_mode.Name = "chk_simul_mode";
            this.chk_simul_mode.Size = new System.Drawing.Size(137, 27);
            this.chk_simul_mode.TabIndex = 6;
            this.chk_simul_mode.Text = "시뮬레이터모드";
            this.chk_simul_mode.UseVisualStyleBackColor = true;
            // 
            // chk_save_log
            // 
            this.chk_save_log.AutoSize = true;
            this.chk_save_log.Location = new System.Drawing.Point(13, 27);
            this.chk_save_log.Name = "chk_save_log";
            this.chk_save_log.Size = new System.Drawing.Size(97, 27);
            this.chk_save_log.TabIndex = 3;
            this.chk_save_log.Text = "로그 저장";
            this.chk_save_log.UseVisualStyleBackColor = true;
            // 
            // chk_press_open
            // 
            this.chk_press_open.AutoSize = true;
            this.chk_press_open.Location = new System.Drawing.Point(19, 27);
            this.chk_press_open.Name = "chk_press_open";
            this.chk_press_open.Size = new System.Drawing.Size(152, 27);
            this.chk_press_open.TabIndex = 3;
            this.chk_press_open.Text = "압력 차 벨브 개폐";
            this.chk_press_open.UseVisualStyleBackColor = true;
            this.chk_press_open.CheckedChanged += new System.EventHandler(this.chk_press_open_CheckedChanged);
            // 
            // chk_time_open
            // 
            this.chk_time_open.AutoSize = true;
            this.chk_time_open.Location = new System.Drawing.Point(19, 301);
            this.chk_time_open.Name = "chk_time_open";
            this.chk_time_open.Size = new System.Drawing.Size(152, 27);
            this.chk_time_open.TabIndex = 4;
            this.chk_time_open.Text = "시간 차 벨브 개폐";
            this.chk_time_open.UseVisualStyleBackColor = true;
            this.chk_time_open.CheckedChanged += new System.EventHandler(this.chk_time_open_CheckedChanged);
            // 
            // txt_press_open_value
            // 
            this.txt_press_open_value.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_press_open_value.Location = new System.Drawing.Point(151, 60);
            this.txt_press_open_value.Name = "txt_press_open_value";
            this.txt_press_open_value.Size = new System.Drawing.Size(116, 42);
            this.txt_press_open_value.TabIndex = 10;
            this.txt_press_open_value.Click += new System.EventHandler(this.txt_press_open_value_TextChanged);
            // 
            // lbl_press_value
            // 
            this.lbl_press_value.AutoSize = true;
            this.lbl_press_value.Location = new System.Drawing.Point(47, 63);
            this.lbl_press_value.Name = "lbl_press_value";
            this.lbl_press_value.Size = new System.Drawing.Size(95, 23);
            this.lbl_press_value.TabIndex = 11;
            this.lbl_press_value.Text = "배수 압력 차";
            // 
            // txt_time_open_value
            // 
            this.txt_time_open_value.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_time_open_value.Location = new System.Drawing.Point(175, 340);
            this.txt_time_open_value.Name = "txt_time_open_value";
            this.txt_time_open_value.Size = new System.Drawing.Size(106, 42);
            this.txt_time_open_value.TabIndex = 12;
            this.txt_time_open_value.Click += new System.EventHandler(this.txt_time_open_value_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lbl_save_log_date);
            this.groupBox2.Controls.Add(this.chk_save_log);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.chk_simul_mode);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(473, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 582);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Setting";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_press_count);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_valve_interval);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_time_interval);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_time_repeat_value);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_press_interval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_press_repeat_value);
            this.groupBox1.Controls.Add(this.chk_time_open);
            this.groupBox1.Controls.Add(this.txt_time_open_value);
            this.groupBox1.Controls.Add(this.chk_press_open);
            this.groupBox1.Controls.Add(this.lbl_press_value);
            this.groupBox1.Controls.Add(this.txt_press_open_value);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 582);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Setting";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 23);
            this.label14.TabIndex = 33;
            this.label14.Text = "압력차 누적 회수";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 23);
            this.label13.TabIndex = 31;
            // 
            // txt_press_count
            // 
            this.txt_press_count.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_press_count.Location = new System.Drawing.Point(189, 236);
            this.txt_press_count.Name = "txt_press_count";
            this.txt_press_count.Size = new System.Drawing.Size(78, 42);
            this.txt_press_count.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(291, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 23);
            this.label11.TabIndex = 29;
            this.label11.Text = "(min)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 23);
            this.label10.TabIndex = 28;
            this.label10.Text = "벨브 작동 간격";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 519);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 23);
            this.label9.TabIndex = 27;
            this.label9.Text = "배수 명령 Interval";
            // 
            // txt_valve_interval
            // 
            this.txt_valve_interval.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_valve_interval.Location = new System.Drawing.Point(175, 510);
            this.txt_valve_interval.Name = "txt_valve_interval";
            this.txt_valve_interval.Size = new System.Drawing.Size(101, 42);
            this.txt_valve_interval.TabIndex = 26;
            this.txt_valve_interval.Click += new System.EventHandler(this.txt_valve_interval_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "(ms)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 465);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "(ms)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(282, 519);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "(ms)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "(Inlet - Outlet)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 462);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "배수 작동 Interval";
            // 
            // txt_time_interval
            // 
            this.txt_time_interval.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_time_interval.Location = new System.Drawing.Point(207, 456);
            this.txt_time_interval.Name = "txt_time_interval";
            this.txt_time_interval.Size = new System.Drawing.Size(74, 42);
            this.txt_time_interval.TabIndex = 20;
            this.txt_time_interval.Click += new System.EventHandler(this.txt_time_interval_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "벨브 작동 반복 회수";
            // 
            // txt_time_repeat_value
            // 
            this.txt_time_repeat_value.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_time_repeat_value.Location = new System.Drawing.Point(207, 397);
            this.txt_time_repeat_value.Name = "txt_time_repeat_value";
            this.txt_time_repeat_value.Size = new System.Drawing.Size(74, 42);
            this.txt_time_repeat_value.TabIndex = 18;
            this.txt_time_repeat_value.Click += new System.EventHandler(this.txt_time_repeat_value_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "배수 작동 Interval";
            // 
            // txt_press_interval
            // 
            this.txt_press_interval.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_press_interval.Location = new System.Drawing.Point(212, 173);
            this.txt_press_interval.Name = "txt_press_interval";
            this.txt_press_interval.Size = new System.Drawing.Size(78, 42);
            this.txt_press_interval.TabIndex = 16;
            this.txt_press_interval.Click += new System.EventHandler(this.txt_press_interval_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "벨브 작동 반복 회수";
            // 
            // txt_press_repeat_value
            // 
            this.txt_press_repeat_value.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_press_repeat_value.Location = new System.Drawing.Point(202, 118);
            this.txt_press_repeat_value.Name = "txt_press_repeat_value";
            this.txt_press_repeat_value.Size = new System.Drawing.Size(79, 42);
            this.txt_press_repeat_value.TabIndex = 14;
            this.txt_press_repeat_value.Click += new System.EventHandler(this.txt_press_repeat_value_TextChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 799);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_apply);
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.CheckBox chk_save_log;
        private System.Windows.Forms.CheckBox chk_simul_mode;
        private System.Windows.Forms.Label lbl_save_log_date;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox chk_press_open;
        private System.Windows.Forms.CheckBox chk_time_open;
        private System.Windows.Forms.TextBox txt_press_open_value;
        private System.Windows.Forms.Label lbl_press_value;
        private System.Windows.Forms.TextBox txt_time_open_value;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_press_interval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_press_repeat_value;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_time_interval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_time_repeat_value;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_valve_interval;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_press_count;
    }
}