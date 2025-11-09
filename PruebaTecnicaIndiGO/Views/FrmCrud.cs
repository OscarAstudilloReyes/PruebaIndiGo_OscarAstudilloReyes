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
    public partial class FrmCrud : Form, IProductView
    {
        private readonly ProductPresenter _presenter;

        public string ProductCode => txtCode.Text;
        public string ProductName => txtName.Text;
        public decimal ProductCost => decimal.TryParse(txtCost.Text, out var val) ? val : 0;
        public int ProductStock => int.TryParse(txtStock.Text, out var val) ? val : 0;
        public string ProductPicture => "";

        public FrmCrud()
        {
            InitializeComponent();
            _presenter = new ProductPresenter(this);
            ConfigureDataGrid();
            LoadProducts(); 
        }

         /// <summary>
         /// Evento para guardar producto
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.SaveProductAsync();
            LoadProducts();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await _presenter.SearchProductByCodeAsync(txtCode.Text);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void LoadProduct(Product product)
        {
            txtCode.Text = product.Code;
            txtName.Text = product.Name;
            txtCost.Text = product.Cost.ToString();
            txtStock.Text = product.Stock.ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Dese  eliminar el producto con código '{txtCode.Text}'?",
                "Confirmar elimincaion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _presenter.DeleteProductAsync(txtCode.Text);
                ClearFields();
                LoadProducts();
            }
        }

        private void ClearFields()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtCost.Text = "";
            txtStock.Text = "";
        }

        private void ConfigureDataGrid()
        {
            if (Controls.ContainsKey("dataGridProducts"))
            {
                var dataGrid = Controls["dataGridProducts"] as DataGridView;
                if (dataGrid != null)
                {
                    dataGrid.AutoGenerateColumns = false;
                    dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGrid.MultiSelect = false;
                    dataGrid.ReadOnly = true;
                    dataGrid.Columns.Clear();

                    dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Code",
                        HeaderText = "Código",
                        DataPropertyName = "Code",
                        Width = 100
                    });

                    dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Name",
                        HeaderText = "Nombre",
                        DataPropertyName = "Name",
                        Width = 200
                    });

                    dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Cost",
                        HeaderText = "Precio",
                        DataPropertyName = "Cost",
                        Width = 100,
                        DefaultCellStyle = { Format = "C2" }
                    });

                    dataGrid.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Stock",
                        HeaderText = "Stock",
                        DataPropertyName = "Stock",
                        Width = 80
                    });
                    dataGrid.SelectionChanged += DataGrid_SelectionChanged;
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, EventArgs e)
        {
            var dataGrid = sender as DataGridView;
            if (dataGrid != null && dataGrid.SelectedRows.Count > 0)
            {
                var selectedRow = dataGrid.SelectedRows[0];
                if (selectedRow.DataBoundItem is Product product)
                {
                    LoadProduct(product);
                }
            }
        }

        public async void LoadProducts()
        {
            await _presenter.LoadAllProductsAsync();
        }

        public void LoadProductsGrid(List<Product> products)
        {
            if (Controls.ContainsKey("dataGridProducts"))
            {
                var dataGrid = Controls["dataGridProducts"] as DataGridView;
                if (dataGrid != null)
                {
                    dataGrid.DataSource = products;
                }
            }
            else
            {
                CreateDataGrid(products);
            }
        }

        private void CreateDataGrid(List<Product> products)
        {
            var dataGrid = new DataGridView
            {
                Name = "dataGridProducts",
                Location = new Point(20, 150),
                Size = new Size(600, 200),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };

            dataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Code",
                HeaderText = "Código",
                DataPropertyName = "Code",
                Width = 100
            });

            dataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Width = 200
            });

            dataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cost",
                HeaderText = "Precio",
                DataPropertyName = "Cost",
                Width = 100,
                DefaultCellStyle = { Format = "C2" }
            });

            dataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                DataPropertyName = "Stock",
                Width = 80
            });

            dataGrid.SelectionChanged += DataGrid_SelectionChanged;
            Controls.Add(dataGrid);
            dataGrid.DataSource = products;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSales fs = new FrmSales();
            fs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmReport fs = new FrmReport();
            fs.Show();
        }

       
    }
}
