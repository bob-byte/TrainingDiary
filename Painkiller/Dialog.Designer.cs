namespace Painkiller
{
    partial class Dialog
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
            this.ChBGroupWeight = new System.Windows.Forms.CheckBox();
            this.ChBExercise = new System.Windows.Forms.CheckBox();
            this.SortFiltrSearch = new System.Windows.Forms.Button();
            this.ChBTypeTrainingReps = new System.Windows.Forms.CheckBox();
            this.amountWeigthReps = new System.Windows.Forms.NumericUpDown();
            this.CBGroup = new System.Windows.Forms.ComboBox();
            this.CBExercise = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.amountWeigthReps)).BeginInit();
            this.SuspendLayout();
            // 
            // ChBGroupWeight
            // 
            this.ChBGroupWeight.AutoSize = true;
            this.ChBGroupWeight.BackColor = System.Drawing.Color.Yellow;
            this.ChBGroupWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChBGroupWeight.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChBGroupWeight.Location = new System.Drawing.Point(54, 25);
            this.ChBGroupWeight.Name = "ChBGroupWeight";
            this.ChBGroupWeight.Size = new System.Drawing.Size(232, 24);
            this.ChBGroupWeight.TabIndex = 0;
            this.ChBGroupWeight.Text = "По назвах груп м\'язів";
            this.ChBGroupWeight.UseVisualStyleBackColor = false;
            this.ChBGroupWeight.CheckedChanged += new System.EventHandler(this.ChBGroup_CheckedChanged);
            // 
            // ChBExercise
            // 
            this.ChBExercise.AutoSize = true;
            this.ChBExercise.BackColor = System.Drawing.Color.Yellow;
            this.ChBExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChBExercise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChBExercise.Location = new System.Drawing.Point(330, 26);
            this.ChBExercise.Name = "ChBExercise";
            this.ChBExercise.Size = new System.Drawing.Size(186, 24);
            this.ChBExercise.TabIndex = 1;
            this.ChBExercise.Text = "По назвах вправ";
            this.ChBExercise.UseVisualStyleBackColor = false;
            this.ChBExercise.CheckedChanged += new System.EventHandler(this.ChBExercise_CheckedChanged);
            // 
            // SortFiltrSearch
            // 
            this.SortFiltrSearch.BackColor = System.Drawing.Color.Yellow;
            this.SortFiltrSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SortFiltrSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SortFiltrSearch.Location = new System.Drawing.Point(345, 64);
            this.SortFiltrSearch.Name = "SortFiltrSearch";
            this.SortFiltrSearch.Size = new System.Drawing.Size(148, 69);
            this.SortFiltrSearch.TabIndex = 2;
            this.SortFiltrSearch.Text = "Сортувати";
            this.SortFiltrSearch.UseVisualStyleBackColor = false;
            this.SortFiltrSearch.Click += new System.EventHandler(this.SortFiltr_Click);
            // 
            // ChBTypeTrainingReps
            // 
            this.ChBTypeTrainingReps.AutoSize = true;
            this.ChBTypeTrainingReps.BackColor = System.Drawing.Color.Yellow;
            this.ChBTypeTrainingReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChBTypeTrainingReps.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ChBTypeTrainingReps.Location = new System.Drawing.Point(560, 26);
            this.ChBTypeTrainingReps.Name = "ChBTypeTrainingReps";
            this.ChBTypeTrainingReps.Size = new System.Drawing.Size(220, 24);
            this.ChBTypeTrainingReps.TabIndex = 3;
            this.ChBTypeTrainingReps.Text = "По виду тренування";
            this.ChBTypeTrainingReps.UseVisualStyleBackColor = false;
            this.ChBTypeTrainingReps.CheckedChanged += new System.EventHandler(this.ChBTypeTraining_CheckedChanged);
            // 
            // amountWeigthReps
            // 
            this.amountWeigthReps.BackColor = System.Drawing.Color.Yellow;
            this.amountWeigthReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amountWeigthReps.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.amountWeigthReps.Location = new System.Drawing.Point(330, 25);
            this.amountWeigthReps.Name = "amountWeigthReps";
            this.amountWeigthReps.Size = new System.Drawing.Size(186, 27);
            this.amountWeigthReps.TabIndex = 4;
            this.amountWeigthReps.ValueChanged += new System.EventHandler(this.amountWeigthReps_ValueChanged);
            // 
            // CBGroup
            // 
            this.CBGroup.BackColor = System.Drawing.Color.Yellow;
            this.CBGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBGroup.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CBGroup.FormattingEnabled = true;
            this.CBGroup.Items.AddRange(new object[] {
            "Ноги",
            "Спина",
            "Груди",
            "Руки",
            "Плечі"});
            this.CBGroup.Location = new System.Drawing.Point(54, 24);
            this.CBGroup.Name = "CBGroup";
            this.CBGroup.Size = new System.Drawing.Size(251, 26);
            this.CBGroup.TabIndex = 5;
            // 
            // CBExercise
            // 
            this.CBExercise.BackColor = System.Drawing.Color.Yellow;
            this.CBExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBExercise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CBExercise.FormattingEnabled = true;
            this.CBExercise.Location = new System.Drawing.Point(522, 25);
            this.CBExercise.Name = "CBExercise";
            this.CBExercise.Size = new System.Drawing.Size(329, 26);
            this.CBExercise.TabIndex = 6;
            this.CBExercise.Click += new System.EventHandler(this.CBExercise_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(145, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Група м\'язів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(653, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Вправа";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(900, 145);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBExercise);
            this.Controls.Add(this.CBGroup);
            this.Controls.Add(this.amountWeigthReps);
            this.Controls.Add(this.ChBTypeTrainingReps);
            this.Controls.Add(this.SortFiltrSearch);
            this.Controls.Add(this.ChBExercise);
            this.Controls.Add(this.ChBGroupWeight);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.Load += new System.EventHandler(this.Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amountWeigthReps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChBGroupWeight;
        private System.Windows.Forms.CheckBox ChBExercise;
        private System.Windows.Forms.Button SortFiltrSearch;
        private System.Windows.Forms.CheckBox ChBTypeTrainingReps;
        private System.Windows.Forms.NumericUpDown amountWeigthReps;
        private System.Windows.Forms.ComboBox CBGroup;
        private System.Windows.Forms.ComboBox CBExercise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}