
namespace Webinar1App.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.removeDriverButton = new MaterialSkin.Controls.MaterialButton();
            this.addDriverButton = new MaterialSkin.Controls.MaterialButton();
            this.driversListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 119);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(905, 557);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.removeDriverButton);
            this.tabPage1.Controls.Add(this.addDriverButton);
            this.tabPage1.Controls.Add(this.driversListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(897, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Drivers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // removeDriverButton
            // 
            this.removeDriverButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeDriverButton.Depth = 0;
            this.removeDriverButton.DrawShadows = true;
            this.removeDriverButton.HighEmphasis = true;
            this.removeDriverButton.Icon = ((System.Drawing.Image)(resources.GetObject("removeDriverButton.Icon")));
            this.removeDriverButton.Location = new System.Drawing.Point(728, 483);
            this.removeDriverButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.removeDriverButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.removeDriverButton.Name = "removeDriverButton";
            this.removeDriverButton.Size = new System.Drawing.Size(162, 36);
            this.removeDriverButton.TabIndex = 6;
            this.removeDriverButton.Text = "Remove driver";
            this.removeDriverButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.removeDriverButton.UseAccentColor = false;
            this.removeDriverButton.UseVisualStyleBackColor = true;
            this.removeDriverButton.Click += new System.EventHandler(this.removeDriverButton_Click);
            // 
            // addDriverButton
            // 
            this.addDriverButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addDriverButton.Depth = 0;
            this.addDriverButton.DrawShadows = true;
            this.addDriverButton.HighEmphasis = true;
            this.addDriverButton.Icon = ((System.Drawing.Image)(resources.GetObject("addDriverButton.Icon")));
            this.addDriverButton.Location = new System.Drawing.Point(571, 483);
            this.addDriverButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addDriverButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addDriverButton.Name = "addDriverButton";
            this.addDriverButton.Size = new System.Drawing.Size(132, 36);
            this.addDriverButton.TabIndex = 5;
            this.addDriverButton.Text = "Add driver";
            this.addDriverButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.addDriverButton.UseAccentColor = false;
            this.addDriverButton.UseVisualStyleBackColor = true;
            this.addDriverButton.Click += new System.EventHandler(this.addDriverButton_Click);
            // 
            // driversListView
            // 
            this.driversListView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.driversListView.AutoSizeTable = false;
            this.driversListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.driversListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.driversListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.driversListView.Depth = 0;
            this.driversListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.driversListView.FullRowSelect = true;
            this.driversListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.driversListView.HideSelection = false;
            this.driversListView.LabelEdit = true;
            this.driversListView.Location = new System.Drawing.Point(22, 60);
            this.driversListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.driversListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.driversListView.MouseState = MaterialSkin.MouseState.OUT;
            this.driversListView.Name = "driversListView";
            this.driversListView.OwnerDraw = true;
            this.driversListView.Size = new System.Drawing.Size(852, 399);
            this.driversListView.TabIndex = 4;
            this.driversListView.UseCompatibleStateImageBehavior = false;
            this.driversListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Driver";
            this.columnHeader1.Width = 270;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Car";
            this.columnHeader2.Width = 270;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "No";
            this.columnHeader3.Width = 270;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(897, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(930, 74);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(929, 680);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Name = "MainForm";
            this.Text = "Taxi Service";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialButton addDriverButton;
        private MaterialSkin.Controls.MaterialListView driversListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialButton removeDriverButton;
    }
}

