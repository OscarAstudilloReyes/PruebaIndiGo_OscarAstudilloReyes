namespace PruebaTecnicaIndiGO.Views
{
    partial class FrmSales
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbProduct = new ComboBox();
            txtQuantity = new TextBox();
            txtTotalValue = new TextBox();
            button1 = new Button();
            dataGridSalesItem = new DataGridView();
            button2 = new Button();
            label4 = new Label();
            txtDateTime = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridSalesItem).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 42);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(156, 41);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "Cantidad";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(270, 40);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio";
            // 
            // cbProduct
            // 
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(27, 64);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(114, 23);
            cbProduct.TabIndex = 3;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(156, 67);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 4;
            // 
            // txtTotalValue
            // 
            txtTotalValue.Location = new Point(270, 64);
            txtTotalValue.Name = "txtTotalValue";
            txtTotalValue.Size = new Size(100, 23);
            txtTotalValue.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(31, 106);
            button1.Name = "button1";
            button1.Size = new Size(94, 32);
            button1.TabIndex = 6;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridSalesItem
            // 
            dataGridSalesItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSalesItem.Location = new Point(27, 144);
            dataGridSalesItem.Name = "dataGridSalesItem";
            dataGridSalesItem.Size = new Size(507, 219);
            dataGridSalesItem.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(222, 379);
            button2.Name = "button2";
            button2.Size = new Size(88, 44);
            button2.TabIndex = 8;
            button2.Text = "Guardar venta";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(376, 42);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 9;
            label4.Text = "Fecha";
            // 
            // txtDateTime
            // 
            txtDateTime.Location = new Point(376, 64);
            txtDateTime.Name = "txtDateTime";
            txtDateTime.Size = new Size(141, 23);
            txtDateTime.TabIndex = 10;
            // 
            // FrmSales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 450);
            Controls.Add(txtDateTime);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(dataGridSalesItem);
            Controls.Add(button1);
            Controls.Add(txtTotalValue);
            Controls.Add(txtQuantity);
            Controls.Add(cbProduct);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmSales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSales";
            ((System.ComponentModel.ISupportInitialize)dataGridSalesItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbProduct;
        private TextBox txtQuantity;
        private TextBox txtTotalValue;
        private Button button1;
        private DataGridView dataGridSalesItem;
        private Button button2;
        private Label label4;
        private DateTimePicker txtDateTime;
    }
}