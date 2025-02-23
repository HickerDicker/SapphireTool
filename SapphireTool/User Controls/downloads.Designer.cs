namespace SapphireTool.UserControls
{
    partial class Downloads
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.ProgressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblDownload = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.subLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.version,
            this.type,
            this.size});
            this.listView1.Font = new System.Drawing.Font("Inter Medium", 14.25F);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 54);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(908, 492);
            this.listView1.TabIndex = 125;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_BeforeLabelEdit);
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 347;
            // 
            // version
            // 
            this.version.Text = "Version";
            this.version.Width = 177;
            // 
            // type
            // 
            this.type.Text = "Type";
            this.type.Width = 155;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 148;
            // 
            // searchBox
            // 
            this.searchBox.Animated = true;
            this.searchBox.BackColor = System.Drawing.Color.Transparent;
            this.searchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBox.DefaultText = "";
            this.searchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.searchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.searchBox.FocusedState.BorderColor = System.Drawing.Color.BlueViolet;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchBox.ForeColor = System.Drawing.Color.White;
            this.searchBox.HoverState.BorderColor = System.Drawing.Color.BlueViolet;
            this.searchBox.Location = new System.Drawing.Point(742, 46);
            this.searchBox.Name = "searchBox";
            this.searchBox.PasswordChar = '\0';
            this.searchBox.PlaceholderText = "Search";
            this.searchBox.SelectedText = "";
            this.searchBox.Size = new System.Drawing.Size(155, 28);
            this.searchBox.TabIndex = 385;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.btnCancel.Font = new System.Drawing.Font("Inter Medium", 11.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(803, 554);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 30);
            this.btnCancel.TabIndex = 451;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(12, 558);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(662, 23);
            this.ProgressBar1.TabIndex = 455;
            this.ProgressBar1.Text = "guna2ProgressBar1";
            this.ProgressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.White;
            this.lblSpeed.Location = new System.Drawing.Point(376, 591);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(0, 21);
            this.lblSpeed.TabIndex = 454;
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownload.ForeColor = System.Drawing.Color.White;
            this.lblDownload.Location = new System.Drawing.Point(728, 593);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(0, 21);
            this.lblDownload.TabIndex = 453;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Inter Medium", 12F);
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Location = new System.Drawing.Point(8, 589);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(119, 19);
            this.status.TabIndex = 452;
            this.status.Text = "Status : Idle....";
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.AutoSize = true;
            this.guna2VScrollBar1.BindingContainer = this.listView1;
            this.guna2VScrollBar1.BorderRadius = 8;
            this.guna2VScrollBar1.FillColor = System.Drawing.Color.Transparent;
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 100;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(900, 54);
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 18;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 492);
            this.guna2VScrollBar1.TabIndex = 457;
            this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.Gray;
            this.guna2VScrollBar1.ThumbSize = 100F;
            this.guna2VScrollBar1.Value = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.BorderRadius = 5;
            this.btnDownload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(49)))), ((int)(((byte)(61)))));
            this.btnDownload.Font = new System.Drawing.Font("Inter Medium", 11.25F);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(681, 554);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(106, 30);
            this.btnDownload.TabIndex = 451;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // subLabel
            // 
            this.subLabel.AutoSize = true;
            this.subLabel.Font = new System.Drawing.Font("Inter Medium", 9F);
            this.subLabel.ForeColor = System.Drawing.Color.Silver;
            this.subLabel.Location = new System.Drawing.Point(3, 0);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(298, 15);
            this.subLabel.TabIndex = 459;
            this.subLabel.Text = "Download essential freewares or cracked software";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 41);
            this.label1.TabIndex = 458;
            this.label1.Text = "Downloads";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.subLabel);
            this.panel1.Location = new System.Drawing.Point(10, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 28);
            this.panel1.TabIndex = 460;
            // 
            // Downloads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.status);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listView1);
            this.Name = "Downloads";
            this.Size = new System.Drawing.Size(918, 619);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader version;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader size;
        private Guna.UI2.WinForms.Guna2TextBox searchBox;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2ProgressBar ProgressBar1;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label status;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private Guna.UI2.WinForms.Guna2Button btnDownload;
        private System.Windows.Forms.Label subLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}