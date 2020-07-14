namespace Painkiller
{
    partial class DialogFiltr
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
            this.SortFiltrSearch = new System.Windows.Forms.Button();
            this.amountWeigthReps = new System.Windows.Forms.NumericUpDown();
            this.RBWeight = new System.Windows.Forms.RadioButton();
            this.RBReps = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.amountWeigthReps)).BeginInit();
            this.SuspendLayout();
            // 
            // SortFiltrSearch
            // 
            this.SortFiltrSearch.BackColor = System.Drawing.Color.Yellow;
            this.SortFiltrSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SortFiltrSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SortFiltrSearch.Location = new System.Drawing.Point(335, 64);
            this.SortFiltrSearch.Name = "SortFiltrSearch";
            this.SortFiltrSearch.Size = new System.Drawing.Size(148, 69);
            this.SortFiltrSearch.TabIndex = 2;
            this.SortFiltrSearch.Text = "Фільтрувати";
            this.SortFiltrSearch.UseVisualStyleBackColor = false;
            this.SortFiltrSearch.Click += new System.EventHandler(this.SortFiltr_Click);
            // 
            // amountWeigthReps
            // 
            this.amountWeigthReps.BackColor = System.Drawing.Color.Yellow;
            this.amountWeigthReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amountWeigthReps.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.amountWeigthReps.Location = new System.Drawing.Point(358, 26);
            this.amountWeigthReps.Name = "amountWeigthReps";
            this.amountWeigthReps.Size = new System.Drawing.Size(103, 27);
            this.amountWeigthReps.TabIndex = 4;
            this.amountWeigthReps.ValueChanged += new System.EventHandler(this.amountWeigthReps_ValueChanged);
            // 
            // RBWeight
            // 
            this.RBWeight.AutoSize = true;
            this.RBWeight.BackColor = System.Drawing.Color.Yellow;
            this.RBWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBWeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RBWeight.Location = new System.Drawing.Point(490, 26);
            this.RBWeight.Name = "RBWeight";
            this.RBWeight.Size = new System.Drawing.Size(278, 24);
            this.RBWeight.TabIndex = 5;
            this.RBWeight.TabStop = true;
            this.RBWeight.Text = "Фільтрувати за max вагою";
            this.RBWeight.UseVisualStyleBackColor = false;
            // 
            // RBReps
            // 
            this.RBReps.AutoSize = true;
            this.RBReps.BackColor = System.Drawing.Color.Yellow;
            this.RBReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBReps.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RBReps.Location = new System.Drawing.Point(12, 26);
            this.RBReps.Name = "RBReps";
            this.RBReps.Size = new System.Drawing.Size(322, 24);
            this.RBReps.TabIndex = 6;
            this.RBReps.TabStop = true;
            this.RBReps.Text = "Фільтрувати за к-стю повторів";
            this.RBReps.UseVisualStyleBackColor = false;
            // 
            // DialogFiltr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(792, 145);
            this.Controls.Add(this.RBReps);
            this.Controls.Add(this.RBWeight);
            this.Controls.Add(this.amountWeigthReps);
            this.Controls.Add(this.SortFiltrSearch);
            this.Name = "DialogFiltr";
            this.Text = "Виберіть критерій фільтрування";
            this.Load += new System.EventHandler(this.DialogFiltr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amountWeigthReps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SortFiltrSearch;
        private System.Windows.Forms.NumericUpDown amountWeigthReps;
        private System.Windows.Forms.RadioButton RBWeight;
        private System.Windows.Forms.RadioButton RBReps;
    }
}