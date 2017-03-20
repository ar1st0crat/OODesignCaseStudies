namespace AirportAppMVC.View
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
            this.buttonFlightsByDepartureCity = new System.Windows.Forms.Button();
            this.textBoxDepartureCity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlights)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridFlights
            // 
            this.dataGridFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFlights.Location = new System.Drawing.Point(13, 13);
            this.dataGridFlights.Name = "dataGridFlights";
            this.dataGridFlights.RowTemplate.Height = 24;
            this.dataGridFlights.Size = new System.Drawing.Size(582, 244);
            this.dataGridFlights.TabIndex = 0;
            // 
            // buttonLoadFlights
            // 
            this.buttonLoadFlights.Location = new System.Drawing.Point(13, 277);
            this.buttonLoadFlights.Name = "buttonLoadFlights";
            this.buttonLoadFlights.Size = new System.Drawing.Size(177, 60);
            this.buttonLoadFlights.TabIndex = 1;
            this.buttonLoadFlights.Text = "Load Flights!";
            this.buttonLoadFlights.UseVisualStyleBackColor = true;
            this.buttonLoadFlights.Click += new System.EventHandler(this.buttonLoadFlights_Click);
            // 
            // buttonFlightsByDepartureCity
            // 
            this.buttonFlightsByDepartureCity.Location = new System.Drawing.Point(205, 277);
            this.buttonFlightsByDepartureCity.Name = "buttonFlightsByDepartureCity";
            this.buttonFlightsByDepartureCity.Size = new System.Drawing.Size(177, 60);
            this.buttonFlightsByDepartureCity.TabIndex = 2;
            this.buttonFlightsByDepartureCity.Text = "Load Flights From:";
            this.buttonFlightsByDepartureCity.UseVisualStyleBackColor = true;
            this.buttonFlightsByDepartureCity.Click += new System.EventHandler(this.buttonFlightsByDepartureCity_Click);
            // 
            // textBoxDepartureCity
            // 
            this.textBoxDepartureCity.Location = new System.Drawing.Point(399, 302);
            this.textBoxDepartureCity.Name = "textBoxDepartureCity";
            this.textBoxDepartureCity.Size = new System.Drawing.Size(196, 22);
            this.textBoxDepartureCity.TabIndex = 3;
            // 
            // FlightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 357);
            this.Controls.Add(this.textBoxDepartureCity);
            this.Controls.Add(this.buttonFlightsByDepartureCity);
            this.Controls.Add(this.buttonLoadFlights);
            this.Controls.Add(this.dataGridFlights);
            this.Name = "FlightsForm";
            this.Text = "Flights";
            this.Load += new System.EventHandler(this.FlightsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFlights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFlights;
        private System.Windows.Forms.Button buttonLoadFlights;
        private System.Windows.Forms.Button buttonFlightsByDepartureCity;
        private System.Windows.Forms.TextBox textBoxDepartureCity;
    }
}

