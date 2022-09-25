namespace removipe
{
    partial class RemoPipe
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoPipe));
            this.btn_valve_close = new System.Windows.Forms.Button();
            this.btn_valve_open = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_monitoring = new System.Windows.Forms.Button();
            this.pnl_monitoring = new System.Windows.Forms.Panel();
            this.pro_outlet = new System.Windows.Forms.ProgressBar();
            this.pro_inlet = new System.Windows.Forms.ProgressBar();
            this.panel_close = new System.Windows.Forms.Panel();
            this.lbl_open = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_Outlet_Flow_Value = new System.Windows.Forms.Label();
            this.lbl_Inlet_Flow_Value = new System.Windows.Forms.Label();
            this.lbl_Valve = new System.Windows.Forms.Label();
            this.lbl_Outlet_Flow = new System.Windows.Forms.Label();
            this.lbl_Inlet_Flow = new System.Windows.Forms.Label();
            this.listview_log = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Repetitions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Interval = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_log = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.pnl_monitoring.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_valve_close
            // 
            this.btn_valve_close.BackColor = System.Drawing.Color.White;
            this.btn_valve_close.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_valve_close.FlatAppearance.BorderSize = 2;
            this.btn_valve_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_valve_close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_valve_close.Location = new System.Drawing.Point(559, 121);
            this.btn_valve_close.Name = "btn_valve_close";
            this.btn_valve_close.Size = new System.Drawing.Size(173, 70);
            this.btn_valve_close.TabIndex = 4;
            this.btn_valve_close.Text = "Valve Manual Close";
            this.btn_valve_close.UseVisualStyleBackColor = false;
            this.btn_valve_close.Click += new System.EventHandler(this.btn_valve_close_Click);
            // 
            // btn_valve_open
            // 
            this.btn_valve_open.BackColor = System.Drawing.Color.White;
            this.btn_valve_open.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_valve_open.FlatAppearance.BorderSize = 2;
            this.btn_valve_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_valve_open.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_valve_open.Location = new System.Drawing.Point(558, 30);
            this.btn_valve_open.Name = "btn_valve_open";
            this.btn_valve_open.Size = new System.Drawing.Size(173, 70);
            this.btn_valve_open.TabIndex = 5;
            this.btn_valve_open.Text = "Valve Manual Open";
            this.btn_valve_open.UseVisualStyleBackColor = false;
            this.btn_valve_open.Click += new System.EventHandler(this.btn_valve_open_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_exit.FlatAppearance.BorderSize = 2;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(745, 121);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(160, 70);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(768, 103);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(143, 15);
            this.lbl_version.TabIndex = 8;
            this.lbl_version.Text = "RemoPipe ver. 0.9.0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::removipe.Properties.Resources.logo_200px;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(33, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 114);
            this.panel1.TabIndex = 10;
            // 
            // btn_monitoring
            // 
            this.btn_monitoring.BackColor = System.Drawing.Color.White;
            this.btn_monitoring.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_monitoring.BackgroundImage")));
            this.btn_monitoring.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_monitoring.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_monitoring.FlatAppearance.BorderSize = 2;
            this.btn_monitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_monitoring.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monitoring.Location = new System.Drawing.Point(197, 21);
            this.btn_monitoring.Name = "btn_monitoring";
            this.btn_monitoring.Size = new System.Drawing.Size(170, 170);
            this.btn_monitoring.TabIndex = 9;
            this.btn_monitoring.Text = "Monitoring";
            this.btn_monitoring.UseVisualStyleBackColor = false;
            this.btn_monitoring.Click += new System.EventHandler(this.btn_monitoring_Click);
            // 
            // pnl_monitoring
            // 
            this.pnl_monitoring.BackColor = System.Drawing.Color.White;
            this.pnl_monitoring.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_monitoring.BackgroundImage")));
            this.pnl_monitoring.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_monitoring.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_monitoring.Controls.Add(this.pro_outlet);
            this.pnl_monitoring.Controls.Add(this.pro_inlet);
            this.pnl_monitoring.Controls.Add(this.panel_close);
            this.pnl_monitoring.Controls.Add(this.lbl_open);
            this.pnl_monitoring.Controls.Add(this.lbl_close);
            this.pnl_monitoring.Controls.Add(this.lbl_Outlet_Flow_Value);
            this.pnl_monitoring.Controls.Add(this.lbl_Inlet_Flow_Value);
            this.pnl_monitoring.Controls.Add(this.lbl_Valve);
            this.pnl_monitoring.Controls.Add(this.lbl_Outlet_Flow);
            this.pnl_monitoring.Controls.Add(this.lbl_Inlet_Flow);
            this.pnl_monitoring.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_monitoring.ForeColor = System.Drawing.Color.Black;
            this.pnl_monitoring.Location = new System.Drawing.Point(12, 206);
            this.pnl_monitoring.Name = "pnl_monitoring";
            this.pnl_monitoring.Size = new System.Drawing.Size(893, 587);
            this.pnl_monitoring.TabIndex = 7;
            // 
            // pro_outlet
            // 
            this.pro_outlet.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.pro_outlet.Location = new System.Drawing.Point(707, 246);
            this.pro_outlet.Name = "pro_outlet";
            this.pro_outlet.Size = new System.Drawing.Size(144, 33);
            this.pro_outlet.TabIndex = 11;
            // 
            // pro_inlet
            // 
            this.pro_inlet.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.pro_inlet.Location = new System.Drawing.Point(40, 246);
            this.pro_inlet.Name = "pro_inlet";
            this.pro_inlet.Size = new System.Drawing.Size(144, 33);
            this.pro_inlet.TabIndex = 10;
            // 
            // panel_close
            // 
            this.panel_close.BackColor = System.Drawing.Color.Red;
            this.panel_close.Location = new System.Drawing.Point(410, 438);
            this.panel_close.Name = "panel_close";
            this.panel_close.Size = new System.Drawing.Size(71, 130);
            this.panel_close.TabIndex = 9;
            // 
            // lbl_open
            // 
            this.lbl_open.AutoSize = true;
            this.lbl_open.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_open.Location = new System.Drawing.Point(545, 478);
            this.lbl_open.Name = "lbl_open";
            this.lbl_open.Size = new System.Drawing.Size(88, 32);
            this.lbl_open.TabIndex = 7;
            this.lbl_open.Text = "Open";
            // 
            // lbl_close
            // 
            this.lbl_close.AutoSize = true;
            this.lbl_close.BackColor = System.Drawing.Color.White;
            this.lbl_close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_close.ForeColor = System.Drawing.Color.Red;
            this.lbl_close.Location = new System.Drawing.Point(541, 478);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(92, 32);
            this.lbl_close.TabIndex = 6;
            this.lbl_close.Text = "Close";
            // 
            // lbl_Outlet_Flow_Value
            // 
            this.lbl_Outlet_Flow_Value.AutoSize = true;
            this.lbl_Outlet_Flow_Value.BackColor = System.Drawing.Color.White;
            this.lbl_Outlet_Flow_Value.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Outlet_Flow_Value.Location = new System.Drawing.Point(717, 210);
            this.lbl_Outlet_Flow_Value.Name = "lbl_Outlet_Flow_Value";
            this.lbl_Outlet_Flow_Value.Size = new System.Drawing.Size(22, 23);
            this.lbl_Outlet_Flow_Value.TabIndex = 5;
            this.lbl_Outlet_Flow_Value.Text = "0";
            // 
            // lbl_Inlet_Flow_Value
            // 
            this.lbl_Inlet_Flow_Value.AutoSize = true;
            this.lbl_Inlet_Flow_Value.BackColor = System.Drawing.Color.White;
            this.lbl_Inlet_Flow_Value.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Inlet_Flow_Value.Location = new System.Drawing.Point(56, 210);
            this.lbl_Inlet_Flow_Value.Name = "lbl_Inlet_Flow_Value";
            this.lbl_Inlet_Flow_Value.Size = new System.Drawing.Size(22, 23);
            this.lbl_Inlet_Flow_Value.TabIndex = 4;
            this.lbl_Inlet_Flow_Value.Text = "0";
            // 
            // lbl_Valve
            // 
            this.lbl_Valve.AutoSize = true;
            this.lbl_Valve.BackColor = System.Drawing.Color.White;
            this.lbl_Valve.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Valve.Location = new System.Drawing.Point(501, 439);
            this.lbl_Valve.Name = "lbl_Valve";
            this.lbl_Valve.Size = new System.Drawing.Size(185, 32);
            this.lbl_Valve.TabIndex = 3;
            this.lbl_Valve.Text = "Valve Status";
            // 
            // lbl_Outlet_Flow
            // 
            this.lbl_Outlet_Flow.AutoSize = true;
            this.lbl_Outlet_Flow.BackColor = System.Drawing.Color.White;
            this.lbl_Outlet_Flow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Outlet_Flow.Location = new System.Drawing.Point(688, 177);
            this.lbl_Outlet_Flow.Name = "lbl_Outlet_Flow";
            this.lbl_Outlet_Flow.Size = new System.Drawing.Size(163, 23);
            this.lbl_Outlet_Flow.TabIndex = 2;
            this.lbl_Outlet_Flow.Text = "Outlet Pressure";
            // 
            // lbl_Inlet_Flow
            // 
            this.lbl_Inlet_Flow.AutoSize = true;
            this.lbl_Inlet_Flow.BackColor = System.Drawing.Color.White;
            this.lbl_Inlet_Flow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Inlet_Flow.Location = new System.Drawing.Point(38, 177);
            this.lbl_Inlet_Flow.Name = "lbl_Inlet_Flow";
            this.lbl_Inlet_Flow.Size = new System.Drawing.Size(146, 23);
            this.lbl_Inlet_Flow.TabIndex = 1;
            this.lbl_Inlet_Flow.Text = "Inlet Pressure";
            // 
            // listview_log
            // 
            this.listview_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Type,
            this.Repetitions,
            this.Interval});
            this.listview_log.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_log.GridLines = true;
            this.listview_log.HideSelection = false;
            this.listview_log.Location = new System.Drawing.Point(20, 30);
            this.listview_log.Name = "listview_log";
            this.listview_log.Size = new System.Drawing.Size(885, 259);
            this.listview_log.TabIndex = 0;
            this.listview_log.UseCompatibleStateImageBehavior = false;
            this.listview_log.View = System.Windows.Forms.View.Details;
            this.listview_log.Visible = false;
            // 
            // Time
            // 
            this.Time.DisplayIndex = 1;
            this.Time.Text = "Process Time";
            this.Time.Width = 199;
            // 
            // Type
            // 
            this.Type.DisplayIndex = 0;
            this.Type.Text = "Type";
            this.Type.Width = 134;
            // 
            // Repetitions
            // 
            this.Repetitions.Text = "Repetitions";
            this.Repetitions.Width = 290;
            // 
            // Interval
            // 
            this.Interval.Text = "Interval";
            this.Interval.Width = 255;
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.Color.White;
            this.btn_log.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_log.BackgroundImage")));
            this.btn_log.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_log.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_log.FlatAppearance.BorderSize = 2;
            this.btn_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_log.Location = new System.Drawing.Point(373, 21);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(170, 170);
            this.btn_log.TabIndex = 2;
            this.btn_log.Text = "Log";
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // btn_setting
            // 
            this.btn_setting.BackColor = System.Drawing.Color.White;
            this.btn_setting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_setting.BackgroundImage")));
            this.btn_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_setting.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btn_setting.FlatAppearance.BorderSize = 2;
            this.btn_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setting.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_setting.Location = new System.Drawing.Point(745, 30);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(160, 70);
            this.btn_setting.TabIndex = 1;
            this.btn_setting.Text = "Setting";
            this.btn_setting.UseVisualStyleBackColor = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(17, 149);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(157, 38);
            this.lbl_time.TabIndex = 11;
            this.lbl_time.Text = "00:00:00";
            // 
            // RemoPipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 799);
            this.Controls.Add(this.pnl_monitoring);
            this.Controls.Add(this.listview_log);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_monitoring);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_valve_open);
            this.Controls.Add(this.btn_valve_close);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.btn_setting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RemoPipe";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.RemoPipe_Load);
            this.pnl_monitoring.ResumeLayout(false);
            this.pnl_monitoring.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.Button btn_valve_close;
        private System.Windows.Forms.Button btn_valve_open;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel pnl_monitoring;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Repetitions;
        private System.Windows.Forms.ColumnHeader Interval;
        private System.Windows.Forms.Label lbl_Valve;
        private System.Windows.Forms.Label lbl_Outlet_Flow;
        private System.Windows.Forms.Label lbl_Inlet_Flow;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_Outlet_Flow_Value;
        private System.Windows.Forms.Label lbl_Inlet_Flow_Value;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_monitoring;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView listview_log;
        private System.Windows.Forms.Label lbl_open;
        private System.Windows.Forms.Panel panel_close;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.ProgressBar pro_outlet;
        private System.Windows.Forms.ProgressBar pro_inlet;
    }
}

