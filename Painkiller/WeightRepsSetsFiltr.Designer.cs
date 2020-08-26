namespace Painkiller
{
    partial class WeightRepsSetsFiltr
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
            this.NUDCountWeigthRepsSets = new System.Windows.Forms.NumericUpDown();
            this.DUDMoreOrLess = new System.Windows.Forms.DomainUpDown();
            this.checkBoxes = new System.Windows.Forms.GroupBox();
            this.CBSets = new System.Windows.Forms.CheckBox();
            this.CBWeight = new System.Windows.Forms.CheckBox();
            this.CBReps = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCountWeigthRepsSets)).BeginInit();
            this.checkBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // NUDCountWeigthRepsSets
            // 
            this.NUDCountWeigthRepsSets.BackColor = System.Drawing.Color.Orange;
            this.NUDCountWeigthRepsSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NUDCountWeigthRepsSets.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NUDCountWeigthRepsSets.Location = new System.Drawing.Point(432, 64);
            this.NUDCountWeigthRepsSets.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.NUDCountWeigthRepsSets.Name = "NUDCountWeigthRepsSets";
            this.NUDCountWeigthRepsSets.Size = new System.Drawing.Size(103, 27);
            this.NUDCountWeigthRepsSets.TabIndex = 7;
            this.NUDCountWeigthRepsSets.ValueChanged += new System.EventHandler(this.NUDCountWeigthRepsSets_ValueChanged);
            // 
            // DUDMoreOrLess
            // 
            this.DUDMoreOrLess.BackColor = System.Drawing.Color.Orange;
            this.DUDMoreOrLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DUDMoreOrLess.Items.Add(">");
            this.DUDMoreOrLess.Items.Add("<");
            this.DUDMoreOrLess.Location = new System.Drawing.Point(363, 64);
            this.DUDMoreOrLess.Name = "DUDMoreOrLess";
            this.DUDMoreOrLess.ReadOnly = true;
            this.DUDMoreOrLess.Size = new System.Drawing.Size(63, 27);
            this.DUDMoreOrLess.TabIndex = 14;
            this.DUDMoreOrLess.Text = ">";
            this.DUDMoreOrLess.Wrap = true;
            this.DUDMoreOrLess.SelectedItemChanged += new System.EventHandler(this.DUDMoreOrLess_SelectedItemChanged);
            // 
            // checkBoxes
            // 
            this.checkBoxes.Controls.Add(this.CBSets);
            this.checkBoxes.Controls.Add(this.CBWeight);
            this.checkBoxes.Controls.Add(this.CBReps);
            this.checkBoxes.Location = new System.Drawing.Point(12, 12);
            this.checkBoxes.Name = "checkBoxes";
            this.checkBoxes.Size = new System.Drawing.Size(341, 123);
            this.checkBoxes.TabIndex = 15;
            this.checkBoxes.TabStop = false;
            // 
            // CBSets
            // 
            this.CBSets.AutoSize = true;
            this.CBSets.BackColor = System.Drawing.Color.Orange;
            this.CBSets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBSets.Location = new System.Drawing.Point(6, 83);
            this.CBSets.Name = "CBSets";
            this.CBSets.Size = new System.Drawing.Size(319, 24);
            this.CBSets.TabIndex = 16;
            this.CBSets.Text = "Фільтрувати за к-стю підходів";
            this.CBSets.UseVisualStyleBackColor = false;
            // 
            // CBWeight
            // 
            this.CBWeight.AutoSize = true;
            this.CBWeight.BackColor = System.Drawing.Color.Orange;
            this.CBWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBWeight.Location = new System.Drawing.Point(6, 21);
            this.CBWeight.Name = "CBWeight";
            this.CBWeight.Size = new System.Drawing.Size(279, 24);
            this.CBWeight.TabIndex = 15;
            this.CBWeight.Text = "Фільтрувати за max вагою";
            this.CBWeight.UseVisualStyleBackColor = false;
            // 
            // CBReps
            // 
            this.CBReps.AutoSize = true;
            this.CBReps.BackColor = System.Drawing.Color.Orange;
            this.CBReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBReps.Location = new System.Drawing.Point(6, 53);
            this.CBReps.Name = "CBReps";
            this.CBReps.Size = new System.Drawing.Size(323, 24);
            this.CBReps.TabIndex = 14;
            this.CBReps.Text = "Фільтрувати за к-стю повторів";
            this.CBReps.UseVisualStyleBackColor = false;
            // 
            // WeightRepsSetsFiltr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(693, 162);
            this.Controls.Add(this.checkBoxes);
            this.Controls.Add(this.DUDMoreOrLess);
            this.Controls.Add(this.NUDCountWeigthRepsSets);
            this.Name = "WeightRepsSetsFiltr";
            this.Text = "Фільтрувати за max вагою/к-стю повторень/к-стю підходів";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WeightRepsSetsFiltr_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NUDCountWeigthRepsSets)).EndInit();
            this.checkBoxes.ResumeLayout(false);
            this.checkBoxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown NUDCountWeigthRepsSets;
        private System.Windows.Forms.DomainUpDown DUDMoreOrLess;
        private System.Windows.Forms.GroupBox checkBoxes;
        private System.Windows.Forms.CheckBox CBSets;
        private System.Windows.Forms.CheckBox CBWeight;
        private System.Windows.Forms.CheckBox CBReps;
    }
}