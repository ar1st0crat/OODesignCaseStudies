
namespace Webinar1App.Views
{
    partial class DriverForm
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
            this.firstnameText = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.okButton = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lastnameText = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.experienceText = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // firstnameText
            // 
            this.firstnameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstnameText.Depth = 0;
            this.firstnameText.Font = new System.Drawing.Font("Roboto", 12F);
            this.firstnameText.Location = new System.Drawing.Point(12, 125);
            this.firstnameText.MaxLength = 32767;
            this.firstnameText.MouseState = MaterialSkin.MouseState.OUT;
            this.firstnameText.Multiline = false;
            this.firstnameText.Name = "firstnameText";
            this.firstnameText.Size = new System.Drawing.Size(660, 50);
            this.firstnameText.TabIndex = 0;
            this.firstnameText.TabStop = false;
            this.firstnameText.Text = "";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 88);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(72, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Firstname";
            // 
            // okButton
            // 
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Depth = 0;
            this.okButton.DrawShadows = true;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(315, 441);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(41, 36);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 195);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(72, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Lastname";
            // 
            // lastnameText
            // 
            this.lastnameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastnameText.Depth = 0;
            this.lastnameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lastnameText.Location = new System.Drawing.Point(12, 232);
            this.lastnameText.MaxLength = 32767;
            this.lastnameText.MouseState = MaterialSkin.MouseState.OUT;
            this.lastnameText.Multiline = false;
            this.lastnameText.Name = "lastnameText";
            this.lastnameText.Size = new System.Drawing.Size(660, 50);
            this.lastnameText.TabIndex = 3;
            this.lastnameText.TabStop = false;
            this.lastnameText.Text = "";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(15, 305);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(77, 19);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Experience";
            // 
            // experienceText
            // 
            this.experienceText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.experienceText.Depth = 0;
            this.experienceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.experienceText.Location = new System.Drawing.Point(15, 342);
            this.experienceText.MaxLength = 32767;
            this.experienceText.MouseState = MaterialSkin.MouseState.OUT;
            this.experienceText.Multiline = false;
            this.experienceText.Name = "experienceText";
            this.experienceText.Size = new System.Drawing.Size(660, 50);
            this.experienceText.TabIndex = 5;
            this.experienceText.TabStop = false;
            this.experienceText.Text = "";
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 521);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.experienceText);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.lastnameText);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.firstnameText);
            this.Name = "DriverForm";
            this.Text = "DriverForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox firstnameText;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton okButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox lastnameText;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox experienceText;
    }
}