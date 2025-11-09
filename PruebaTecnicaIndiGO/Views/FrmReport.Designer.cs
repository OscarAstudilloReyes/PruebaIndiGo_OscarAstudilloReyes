namespace PruebaTecnicaIndiGO.Views
{
    partial class FrmReport
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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            label = new Label();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(120, 30);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(450, 30);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(44, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(718, 159);
            dataGridView1.TabIndex = 2;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(159, 8);
            label.Name = "label";
            label.Size = new Size(36, 15);
            label.TabIndex = 3;
            label.Text = "Inicio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(531, 10);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 4;
            label2.Text = "Fin";
            // 
            // button1
            // 
            button1.Location = new Point(339, 61);
            button1.Name = "button1";
            button1.Size = new Size(86, 36);
            button1.TabIndex = 5;
            button1.Text = "Filtrar";
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 289);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Name = "FrmReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmReport";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridView dataGridView1;
        private Label label;
        private Label label2;
        private Button button1;
    }
}