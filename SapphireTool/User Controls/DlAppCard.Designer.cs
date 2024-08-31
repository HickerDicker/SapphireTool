using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2;
using Guna.UI2.WinForms;

namespace SapphireTool.User_Controls
{
    partial class DlAppCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
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
            this.appTitle = new Guna.UI2.WinForms.Guna2CheckBox();
            this.version = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appTitle
            // 
            this.appTitle.Animated = true;
            this.appTitle.AutoSize = true;
            this.appTitle.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.appTitle.CheckedState.BorderRadius = 0;
            this.appTitle.CheckedState.BorderThickness = 0;
            this.appTitle.CheckedState.FillColor = System.Drawing.Color.BlueViolet;
            this.appTitle.ForeColor = System.Drawing.Color.White;
            this.appTitle.Location = new System.Drawing.Point(10, 8);
            this.appTitle.Name = "appTitle";
            this.appTitle.Size = new System.Drawing.Size(68, 17);
            this.appTitle.TabIndex = 1;
            this.appTitle.Text = "App Title";
            this.appTitle.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.appTitle.UncheckedState.BorderRadius = 0;
            this.appTitle.UncheckedState.BorderThickness = 0;
            this.appTitle.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Inter Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.Color.White;
            this.version.Location = new System.Drawing.Point(250, 7);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(0, 23);
            this.version.TabIndex = 4;
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Font = new System.Drawing.Font("Inter Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.type.ForeColor = System.Drawing.Color.White;
            this.type.Location = new System.Drawing.Point(545, 4);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(0, 23);
            this.type.TabIndex = 5;
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Inter Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size.ForeColor = System.Drawing.Color.White;
            this.size.Location = new System.Drawing.Point(708, 7);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(0, 23);
            this.size.TabIndex = 6;
            // 
            // DlAppCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.appTitle);
            this.Controls.Add(this.version);
            this.Controls.Add(this.type);
            this.Controls.Add(this.size);
            this.Name = "DlAppCard";
            this.Size = new System.Drawing.Size(931, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private IContainer components = null;
        public Guna2CheckBox appTitle;
        public Label version;
        public Label type;
        public Label size;
    }

        #endregion
    }

