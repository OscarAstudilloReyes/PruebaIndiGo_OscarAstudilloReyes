using PruebaTecnicaIndiGO.Model;
using PruebaTecnicaIndiGO.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTecnicaIndiGO.Views
{
    public partial class FrmSales : Form, ISaleView
    {
        private readonly SalePresenter _presenter;

        public int SelectedProductId => cbProduct.SelectedValue != null ? (int)cbProduct.SelectedValue : 0;
        public int Quantity => int.TryParse(txtQuantity.Text, out var val) ? val : 0;
        public decimal TotalValue => decimal.TryParse(txtTotalValue.Text, out var val) ? val : 0;
        public DateTime SaleDateTime => txtDateTime.Value;

        public FrmSales()
        {
            InitializeComponent();
            _presenter = new SalePresenter(this);
            InitializeForm();
        }

        private async void InitializeForm()
        {
            ConfigureDataGrid();
            ConfigureControls();
            await LoadInitialData();
        }

        private void ConfigureDataGrid()
        {
            dataGridSalesItem.AutoGenerateColumns = false;
            dataGridSalesItem.ReadOnly = true;
            dataGridSalesItem.Columns.Clear();

            dataGridSalesItem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Cantidad",
                DataPropertyName = "Quantity",
                Width = 80
            });

            dataGridSalesItem.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalValue",
                HeaderText = "Total",
                DataPropertyName = "TotalValue",
                Width = 100,
                DefaultCellStyle = { Format = "C2" }
            });


        }

        private void ConfigureControls()
        {
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;

            txtTotalValue.ReadOnly = true;

            
            txtDateTime.Format = DateTimePickerFormat.Custom;
            txtDateTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            txtDateTime.Value = DateTime.Now;

            button1.Click += Button1_Click; // Agregar item
            button2.Click += Button2_Click; // Guardar venta

            txtQuantity.TextChanged += TxtQuantity_TextChanged;
            cbProduct.SelectedIndexChanged += CbProduct_SelectedIndexChanged;
        }

        private async Task LoadInitialData()
        {
            await _presenter.LoadProductsAsync();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            _presenter.AddItemToGridAsync();
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await _presenter.SaveSaleAsync();
        }


        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateItemTotal();
        }

        private void CbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateItemTotal();
        }

        private void CalculateItemTotal()
        {
            try
            {
                if (cbProduct.SelectedItem is Product product && Quantity > 0)
                {
                    decimal itemTotal = Quantity * product.Cost;
                    txtTotalValue.Text = itemTotal.ToString("F2");
                }
                else
                {
                    txtTotalValue.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                txtTotalValue.Text = "0.00";
            }
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LoadProductsComboBox(List<Product> products)
        {
            cbProduct.DataSource = products;
        }

        public void LoadSaleItemsGrid(List<SaleItems> saleItems)
        {
            dataGridSalesItem.DataSource = new BindingList<SaleItems>(saleItems);
        }

        public void UpdateTotalValue(decimal total)
        {
            if (cbProduct.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                txtTotalValue.Text = total.ToString("F2");
            }
        }

        public void ClearItemFields()
        {
            cbProduct.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtTotalValue.Text = "0.00";
        }

        public void ClearAllFields()
        {
            ClearItemFields();
            txtTotalValue.Text = "0.00";
            txtDateTime.Value = DateTime.Now;
            dataGridSalesItem.DataSource = null;
        }
    }
}
