﻿namespace Painkiller
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
            this.CBSelectTypeFilter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SortFiltrSearch
            // 
            this.SortFiltrSearch.BackColor = System.Drawing.Color.Yellow;
            this.SortFiltrSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SortFiltrSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SortFiltrSearch.Location = new System.Drawing.Point(176, 67);
            this.SortFiltrSearch.Name = "SortFiltrSearch";
            this.SortFiltrSearch.Size = new System.Drawing.Size(148, 69);
            this.SortFiltrSearch.TabIndex = 2;
            this.SortFiltrSearch.Text = "Фільтрувати";
            this.SortFiltrSearch.UseVisualStyleBackColor = false;
            this.SortFiltrSearch.Click += new System.EventHandler(this.SortFiltr_Click);
            // 
            // CBSelectTypeFilter
            // 
            this.CBSelectTypeFilter.BackColor = System.Drawing.Color.Yellow;
            this.CBSelectTypeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBSelectTypeFilter.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.CBSelectTypeFilter.FormattingEnabled = true;
            this.CBSelectTypeFilter.Items.AddRange(new object[] {
            "За групою м\'язів",
            "За max вагою/к-стю повторень/к-стю підходів"});
            this.CBSelectTypeFilter.Location = new System.Drawing.Point(12, 12);
            this.CBSelectTypeFilter.Name = "CBSelectTypeFilter";
            this.CBSelectTypeFilter.Size = new System.Drawing.Size(497, 28);
            this.CBSelectTypeFilter.TabIndex = 7;
            this.CBSelectTypeFilter.SelectedIndexChanged += new System.EventHandler(this.CBSelectTypeFilter_SelectedIndexChanged);
            // 
            // DialogFiltr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(522, 147);
            this.Controls.Add(this.CBSelectTypeFilter);
            this.Controls.Add(this.SortFiltrSearch);
            this.Name = "DialogFiltr";
            this.Text = "Виберіть критерій фільтрування";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SortFiltrSearch;
        private System.Windows.Forms.ComboBox CBSelectTypeFilter;
    }
}