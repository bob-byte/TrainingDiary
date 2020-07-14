namespace Painkiller
{
    partial class DialogSeekExercise
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
            this.CBGroup = new System.Windows.Forms.ComboBox();
            this.numExercise = new System.Windows.Forms.NumericUpDown();
            this.CBExercise = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numExercise)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(203, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Вправа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Група м\'язів";
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
            this.CBGroup.Location = new System.Drawing.Point(105, 30);
            this.CBGroup.Name = "CBGroup";
            this.CBGroup.Size = new System.Drawing.Size(251, 26);
            this.CBGroup.TabIndex = 14;
            this.CBGroup.SelectedIndexChanged += new System.EventHandler(this.CBGroup_SelectedIndexChanged);
            // 
            // numExercise
            // 
            this.numExercise.BackColor = System.Drawing.Color.Yellow;
            this.numExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numExercise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.numExercise.Location = new System.Drawing.Point(481, 61);
            this.numExercise.Name = "numExercise";
            this.numExercise.Size = new System.Drawing.Size(116, 27);
            this.numExercise.TabIndex = 18;
            this.numExercise.ValueChanged += new System.EventHandler(this.numExercise_ValueChanged);
            // 
            // CBExercise
            // 
            this.CBExercise.BackColor = System.Drawing.Color.Yellow;
            this.CBExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBExercise.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CBExercise.FormattingEnabled = true;
            this.CBExercise.Location = new System.Drawing.Point(3, 91);
            this.CBExercise.Name = "CBExercise";
            this.CBExercise.Size = new System.Drawing.Size(464, 26);
            this.CBExercise.TabIndex = 15;
            this.CBExercise.Click += new System.EventHandler(this.CBExercise_Click);
            // 
            // DialogSeekExercise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(618, 133);
            this.Controls.Add(this.numExercise);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBExercise);
            this.Controls.Add(this.CBGroup);
            this.Name = "DialogSeekExercise";
            this.Text = "Пошук вправи";
            ((System.ComponentModel.ISupportInitialize)(this.numExercise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBGroup;
        private System.Windows.Forms.NumericUpDown numExercise;
        private System.Windows.Forms.ComboBox CBExercise;
    }
}