namespace PruebaTecnicaIndiGO.Views
{
    partial class FrmCrud
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
            dataGridProducts = new DataGridView();
            txtCost = new TextBox();
            pictureBox1 = new PictureBox();
            txtStock = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            txtName = new TextBox();
            button4 = new Button();
            label5 = new Label();
            txtCode = new TextBox();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridProducts
            // 
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(41, 119);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.Size = new Size(612, 199);
            dataGridProducts.TabIndex = 0;
            // 
            // txtCost
            // 
            txtCost.Location = new Point(236, 45);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(87, 23);
            txtCost.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(435, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 46);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(329, 45);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 27);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 5;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 27);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 6;
            label2.Text = "Precio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(329, 27);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Stock";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(435, 14);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 8;
            label4.Text = "Imagen";
            // 
            // button1
            // 
            button1.Location = new Point(41, 90);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(136, 90);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(236, 90);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Buscar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(155, 45);
            txtName.Name = "txtName";
            txtName.Size = new Size(75, 23);
            txtName.TabIndex = 12;
            // 
            // button4
            // 
            button4.Location = new Point(329, 90);
            button4.Name = "button4";
            button4.Size = new Size(104, 23);
            button4.TabIndex = 13;
            button4.Text = "Registrar venta";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 27);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 14;
            label5.Text = "Codigo";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(49, 45);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(100, 23);
            txtCode.TabIndex = 15;
            // 
            // button5
            // 
            button5.Location = new Point(450, 90);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 16;
            button5.Text = "Ver reporte";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // FrmCrud
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 345);
            Controls.Add(button5);
            Controls.Add(txtCode);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(txtName);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStock);
            Controls.Add(pictureBox1);
            Controls.Add(txtCost);
            Controls.Add(dataGridProducts);
            Name = "FrmCrud";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCrud";
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridProducts;
        private TextBox txtCost;
        private PictureBox pictureBox1;
        private TextBox txtStock;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox txtName;
        private Button button4;
        private Label label5;
        private TextBox txtCode;
        private Button button5;
    }
}