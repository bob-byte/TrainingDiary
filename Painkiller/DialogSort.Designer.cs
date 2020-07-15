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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBHorning = new System.Windows.Forms.RadioButton();
            this.RBGrowth = new System.Windows.Forms.RadioButton();
            this.CBTypeSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SortFiltrSearch
            // 
            this.SortFiltrSearch.BackColor = System.Drawing.Color.Yellow;
            this.SortFiltrSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SortFiltrSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SortFiltrSearch.Location = new System.Drawing.Point(43, 129);
            this.SortFiltrSearch.Name = "SortFiltrSearch";
            this.SortFiltrSearch.Size = new System.Drawing.Size(148, 69);
            this.SortFiltrSearch.TabIndex = 6;
            this.SortFiltrSearch.Text = "Сортувати";
            this.SortFiltrSearch.UseVisualStyleBackColor = false;
            this.SortFiltrSearch.Click += new System.EventHandler(this.SortFiltrSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.RBHorning);
            this.groupBox1.Controls.Add(this.RBGrowth);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 102);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сортувати за";
            // 
            // RBHorning
            // 
            this.RBHorning.AutoSize = true;
            this.RBHorning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.RBGrowth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBGrowth.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RBGrowth.Location = new System.Drawing.Point(6, 21);
            this.RBGrowth.Name = "RBGrowth";
            this.RBGrowth.Size = new System.Drawing.Size(143, 24);
            this.RBGrowth.TabIndex = 0;
            this.RBGrowth.TabStop = true;
            this.RBGrowth.Text = "Зростанням";
            this.RBGrowth.UseVisualStyleBackColor = true;
            // 
            // CBTypeSort
            // 
            this.CBTypeSort.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CBTypeSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBTypeSort.ForeColor = System.Drawing.Color.Yellow;
            this.CBTypeSort.FormattingEnabled = true;
            this.CBTypeSort.Items.AddRange(new object[] {
            "По групах м\'язів",
            "По видах тренувань",
            "По вправах",
            "По обтяженнях",
            "По положеннях тіла",
            "По max вазі",
            "По кількості повторень з max вагою",
            "По кількості загальних підходів"});
            this.CBTypeSort.Location = new System.Drawing.Point(235, 45);
            this.CBTypeSort.Name = "CBTypeSort";
            this.CBTypeSort.Size = new System.Drawing.Size(289, 28);
            this.CBTypeSort.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(231, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Виберіть критерій сортування";
            // 
            // DialogSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(558, 239);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBTypeSort);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBHorning;
        private System.Windows.Forms.RadioButton RBGrowth;
        private System.Windows.Forms.ComboBox CBTypeSort;
        private System.Windows.Forms.Label label1;
    }
}