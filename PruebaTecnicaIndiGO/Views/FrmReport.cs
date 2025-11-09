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
    public partial class FrmReport : Form, ISaleReportView
    {
        private readonly SaleReportPresenter _presenter;
        private Label lblStatistics;

        public DateTime StartDate => dateTimePicker1.Value.Date;
        public DateTime EndDate => dateTimePicker2.Value.Date;

        public FrmReport()
        {
            InitializeComponent();
            _presenter = new SaleReportPresenter(this);
            InitializeForm();
        }

        private void InitializeForm()
        {
            ConfigureDataGrid();
            ConfigureControls();
        }

        private void ConfigureDataGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SaleId",
                HeaderText = "ID Venta",
                DataPropertyName = "SaleId",
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Fecha",
                DataPropertyName = "Date",
                Width = 120,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total Venta",
                DataPropertyName = "Total",
                Width = 100,
                DefaultCellStyle = { Format = "C2" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalQuantity",
                HeaderText = "Cantidad Total",
                DataPropertyName = "TotalQuantity",
                Width = 120
            });

            var detailsColumn = new DataGridViewButtonColumn
            {
                Name = "Details",
                HeaderText = "Detalles",
                Text = "Ver Detalles",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dataGridView1.Columns.Add(detailsColumn);

            // Evento para manejar clic en botón detalles
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void ConfigureControls()
        {
            button1.Click += Button1_Click;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            // Cambiar cursor para indicar procesamiento
            Cursor = Cursors.WaitCursor;
            button1.Enabled = false;

            try
            {
                await _presenter.GenerateReportAsync();
            }
            finally
            {
                Cursor = Cursors.Default;
                button1.Enabled = true;
            }
        }

        private async void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Details"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow.DataBoundItem is SaleReportDto saleReport)
                {
                    await _presenter.ShowSaleDetailsAsync(saleReport.SaleId);
                }
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LoadSalesReport(List<SaleReportDto> salesReport)
        {
            dataGridView1.DataSource = new BindingList<SaleReportDto>(salesReport);
        }

      

        public void ClearReport()
        {
            dataGridView1.DataSource = null;
     
        }
    }
}
