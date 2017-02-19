namespace AirportApp
{
    partial class FlightsForm
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
            this.dataGridFlights = new System.Windows.Forms.DataGridView();
            this.buttonLoadFlights = new System.Windows.Forms.Button();
            this.buttonDelegatesDemo = new System.Windows.Forms.Button();
            this.buttonLINQDemo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlights)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFlights
            // 
            this.dataGridFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlights.Location = new System.Drawing.Point(16, 15);
            this.dataGridFlights.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridFlights.Name = "dataGridFlights";
            this.dataGridFlights.Size = new System.Drawing.Size(664, 326);
            this.dataGridFlights.TabIndex = 0;
            // 
            // buttonLoadFlights
            // 
            this.buttonLoadFlights.Location = new System.Drawing.Point(16, 349);
            this.buttonLoadFlights.Name = "buttonLoadFlights";
            this.buttonLoadFlights.Size = new System.Drawing.Size(221, 51);
            this.buttonLoadFlights.TabIndex = 1;
            this.buttonLoadFlights.Text = "Load Flights";
            this.buttonLoadFlights.UseVisualStyleBackColor = true;
            this.buttonLoadFlights.Click += new System.EventHandler(this.buttonLoadFlights_Click);
            // 
            // buttonDelegatesDemo
            // 
            this.buttonDelegatesDemo.Location = new System.Drawing.Point(243, 349);
            this.buttonDelegatesDemo.Name = "buttonDelegatesDemo";
            this.buttonDelegatesDemo.Size = new System.Drawing.Size(214, 51);
            this.buttonDelegatesDemo.TabIndex = 2;
            this.buttonDelegatesDemo.Text = "Delegates Demo";
            this.buttonDelegatesDemo.UseVisualStyleBackColor = true;
            this.buttonDelegatesDemo.Click += new System.EventHandler(this.buttonDelegatesDemo_Click);
            // 
            // buttonLINQDemo
            // 
            this.buttonLINQDemo.Location = new System.Drawing.Point(463, 349);
            this.buttonLINQDemo.Name = "buttonLINQDemo";
            this.buttonLINQDemo.Size = new System.Drawing.Size(217, 51);
            this.buttonLINQDemo.TabIndex = 3;
            this.buttonLINQDemo.Text = "LINQ Demo";
            this.buttonLINQDemo.UseVisualStyleBackColor = true;
            this.buttonLINQDemo.Click += new System.EventHandler(this.buttonLINQDemo_Click);
            // 
            // FlightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 412);
            this.Controls.Add(this.buttonLINQDemo);
            this.Controls.Add(this.buttonDelegatesDemo);
            this.Controls.Add(this.buttonLoadFlights);
            this.Controls.Add(this.dataGridFlights);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightsForm";
            this.Text = "FlightsForm";
            this.Load += new System.EventHandler(this.FlightsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFlights;
        private System.Windows.Forms.Button buttonLoadFlights;
        private System.Windows.Forms.Button buttonDelegatesDemo;
        private System.Windows.Forms.Button buttonLINQDemo;
    }
}

