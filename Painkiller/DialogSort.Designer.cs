namespace Painkiller
{
    partial class DialogSort
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
            this.RBGroup = new System.Windows.Forms.RadioButton();
            this.RBExercise = new System.Windows.Forms.RadioButton();
            this.RBTypeTraining = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBHorning = new System.Windows.Forms.RadioButton();
            this.RBGrowth = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SortFiltrSearch
            // 
            this.SortFiltrSearch.BackColor = System.Drawing.Color.Yellow;
            this.SortFiltrSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SortFiltrSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SortFiltrSearch.Location = new System.Drawing.Point(216, 150);
            this.SortFiltrSearch.Name = "SortFiltrSearch";
            this.SortFiltrSearch.Size = new System.Drawing.Size(148, 69);
            this.SortFiltrSearch.TabIndex = 6;
            this.SortFiltrSearch.Text = "Сортувати";
            this.SortFiltrSearch.UseVisualStyleBackColor = false;
            this.SortFiltrSearch.Click += new System.EventHandler(this.SortFiltrSearch_Click);
            // 
            // RBGroup
            // 
            this.RBGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBGroup.ForeColor = System.Drawing.Color.Yellow;
            this.RBGroup.Location = new System.Drawing.Point(249, 21);
            this.RBGroup.Name = "RBGroup";
            this.RBGroup.Size = new System.Drawing.Size(246, 24);
            this.RBGroup.TabIndex = 0;
            this.RBGroup.TabStop = true;
            this.RBGroup.Text = "По назвах груп м\'язів";
            this.RBGroup.UseVisualStyleBackColor = true;
            // 
            // RBExercise
            // 
            this.RBExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBExercise.ForeColor = System.Drawing.Color.Yellow;
            this.RBExercise.Location = new System.Drawing.Point(249, 92);
            this.RBExercise.Name = "RBExercise";
            this.RBExercise.Size = new System.Drawing.Size(229, 38);
            this.RBExercise.TabIndex = 0;
            this.RBExercise.TabStop = true;
            this.RBExercise.Text = "По назвах вправ";
            this.RBExercise.UseVisualStyleBackColor = true;
            // 
            // RBTypeTraining
            // 
            this.RBTypeTraining.AutoSize = true;
            this.RBTypeTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBTypeTraining.ForeColor = System.Drawing.Color.Yellow;
            this.RBTypeTraining.Location = new System.Drawing.Point(249, 62);
            this.RBTypeTraining.Name = "RBTypeTraining";
            this.RBTypeTraining.Size = new System.Drawing.Size(284, 24);
            this.RBTypeTraining.TabIndex = 7;
            this.RBTypeTraining.TabStop = true;
            this.RBTypeTraining.Text = "По назвах видів тренувань";
            this.RBTypeTraining.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.RBHorning);
            this.groupBox1.Controls.Add(this.RBGrowth);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 102);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сортувати за";
            // 
            // RBHorning
            // 
            this.RBHorning.AutoSize = true;
            this.RBHorning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBHorning.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RBHorning.Location = new System.Drawing.Point(6, 55);
            this.RBHorning.Name = "RBHorning";
            this.RBHorning.Size = new System.Drawing.Size(135, 24);
            this.RBHorning.TabIndex = 1;
            this.RBHorning.TabStop = true;
            this.RBHorning.Text = "Спаданням";
            this.RBHorning.UseVisualStyleBackColor = true;
            // 
            // RBGrowth
            // 
            this.RBGrowth.AutoSize = true;
            this.RBGrowth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBGrowth.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RBGrowth.Location = new System.Drawing.Point(6, 21);
            this.RBGrowth.Name = "RBGrowth";
            this.RBGrowth.Size = new System.Drawing.Size(143, 24);
            this.RBGrowth.TabIndex = 0;
            this.RBGrowth.TabStop = true;
            this.RBGrowth.Text = "Зростанням";
            this.RBGrowth.UseVisualStyleBackColor = true;
            // 
            // DialogSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(577, 243);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RBTypeTraining);
            this.Controls.Add(this.RBExercise);
            this.Controls.Add(this.RBGroup);
            this.Controls.Add(this.SortFiltrSearch);
            this.Name = "DialogSort";
            this.Text = "Виберіть, будь ласка, критерій сортування";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SortFiltrSearch;
        private System.Windows.Forms.RadioButton RBGroup;
        private System.Windows.Forms.RadioButton RBExercise;
        private System.Windows.Forms.RadioButton RBTypeTraining;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBHorning;
        private System.Windows.Forms.RadioButton RBGrowth;
    }
}