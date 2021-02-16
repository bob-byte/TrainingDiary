namespace Painkiller
{
    partial class ExerciseFiltr
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBExercise = new System.Windows.Forms.ComboBox();
            this.CBGroup = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(258, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Вправа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(242, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Група м\'язів";
            // 
            // CBExercise
            // 
            this.CBExercise.BackColor = System.Drawing.Color.Yellow;
            this.CBExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBExercise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CBExercise.FormattingEnabled = true;
            this.CBExercise.Location = new System.Drawing.Point(22, 94);
            this.CBExercise.Name = "CBExercise";
            this.CBExercise.Size = new System.Drawing.Size(519, 26);
            this.CBExercise.TabIndex = 19;
            this.CBExercise.Click += new System.EventHandler(this.CBExercise_Click);
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
            this.CBGroup.Location = new System.Drawing.Point(167, 34);
            this.CBGroup.Name = "CBGroup";
            this.CBGroup.Size = new System.Drawing.Size(251, 26);
            this.CBGroup.TabIndex = 18;
            this.CBGroup.SelectedIndexChanged += new System.EventHandler(this.CBGroup_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(193, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 76);
            this.button1.TabIndex = 22;
            this.button1.Text = "Додати вправу до списку фільтрації";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExerciseFiltr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(613, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBExercise);
            this.Controls.Add(this.CBGroup);
            this.Name = "ExerciseFiltr";
            this.Text = "ExerciseFiltr";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBExercise;
        private System.Windows.Forms.ComboBox CBGroup;
        private System.Windows.Forms.Button button1;
    }
}