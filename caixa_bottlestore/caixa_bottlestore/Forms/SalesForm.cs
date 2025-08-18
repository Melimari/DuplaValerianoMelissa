using System;
using System.Collections.Generic;
using System.Windows.Forms;
using caixa_bottlestore.Models;
using caixa_bottlestore.Services;

namespace caixa_bottlestore.Forms
{
    public partial class SalesForm : Form
    {
        private readonly ProductService _productService;
        private readonly SaleService _saleService;
        private List<SaleItem> _saleItems;
        private decimal _totalAmount;

        public SalesForm()
        {
            InitializeComponent();
            _productService = new ProductService();
            _saleService = new SaleService();
            _saleItems = new List<SaleItem>();
            _totalAmount = 0;
            LoadProducts();
        }

        private void InitializeComponent()
        {
            this.Text = "Sistema de Vendas";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título
            var lblTitle = new Label
            {
                Text = "NOVA VENDA",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 30)
            };

            // Produto
            var lblProduct = new Label { Text = "Produto:", Location = new System.Drawing.Point(20, 70), Size = new System.Drawing.Size(80, 20) };
            var cmbProduct = new ComboBox { Name = "cmbProduct", Location = new System.Drawing.Point(110, 70), Size = new System.Drawing.Size(300, 20) };

            // Quantidade
            var lblQuantity = new Label { Text = "Quantidade:", Location = new System.Drawing.Point(20, 100), Size = new System.Drawing.Size(80, 20) };
            var numQuantity = new NumericUpDown { Name = "numQuantity", Location = new System.Drawing.Point(110, 100), Size = new System.Drawing.Size(100, 20), Minimum = 1, Maximum = 999, Value = 1 };

            // Preço
            var lblPrice = new Label { Text = "Preço:", Location = new System.Drawing.Point(20, 130), Size = new System.Drawing.Size(80, 20) };
            var txtPrice = new TextBox { Name = "txtPrice", Location = new System.Drawing.Point(110, 130), Size = new System.Drawing.Size(100, 20), ReadOnly = true };

            // Botão adicionar
            var btnAdd = new Button
            {
                Text = "Adicionar",
                Location = new System.Drawing.Point(430, 70),
                Size = new System.Drawing.Size(100, 60)
            };
            btnAdd.Click += BtnAdd_Click;

            // Lista de itens
            var dgvItems = new DataGridView
            {
                Name = "dgvItems",
                Location = new System.Drawing.Point(20, 200),
                Size = new System.Drawing.Size(550, 200),
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            // Configurar colunas
            dgvItems.Columns.Add("ProductId", "ID");
            dgvItems.Columns.Add("ProductName", "Produto");
            dgvItems.Columns.Add("Quantity", "Qtd");
            dgvItems.Columns.Add("Price", "Preço");
            dgvItems.Columns.Add("Total", "Total");

            // Total
            var lblTotal = new Label { Text = "TOTAL:", Location = new System.Drawing.Point(400, 420), Size = new System.Drawing.Size(100, 20), Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold) };
            var txtTotal = new TextBox { Name = "txtTotal", Location = new System.Drawing.Point(500, 420), Size = new System.Drawing.Size(100, 20), ReadOnly = true, Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold) };

            // Método de pagamento
            var lblPayment = new Label { Text = "Pagamento:", Location = new System.Drawing.Point(20, 420), Size = new System.Drawing.Size(100, 20) };
            var cmbPayment = new ComboBox { Name = "cmbPayment", Location = new System.Drawing.Point(120, 420), Size = new System.Drawing.Size(150, 20) };
            cmbPayment.Items.AddRange(new object[] { "Dinheiro", "Cartão", "PIX" });
            cmbPayment.SelectedIndex = 0;

            // Botões
            var btnFinish = new Button
            {
                Text = "Finalizar Venda",
                Location = new System.Drawing.Point(580, 460),
                Size = new System.Drawing.Size(120, 40),
                BackColor = System.Drawing.Color.Green,
                ForeColor = System.Drawing.Color.White
            };
            btnFinish.Click += BtnFinish_Click;

            var btnCancel = new Button
            {
                Text = "Cancelar",
                Location = new System.Drawing.Point(580, 510),
                Size = new System.Drawing.Size(120, 40)
            };
            btnCancel.Click += BtnCancel_Click;

            // Adicionar controles
            this.Controls.AddRange(new Control[]
            {
                lblTitle, lblProduct, cmbProduct, lblQuantity, numQuantity,
                lblPrice, txtPrice, btnAdd, dgvItems, lblTotal, txtTotal,
                lblPayment, cmbPayment, btnFinish, btnCancel
            });

            // Eventos
            cmbProduct.SelectedIndexChanged += CmbProduct_SelectedIndexChanged;
            numQuantity.ValueChanged += NumQuantity_ValueChanged;
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAll();
                cmbProduct.Items.Clear();
                foreach (var product in products)
                {
                    cmbProduct.Items.Add(product);
                }
                if (cmbProduct.Items.Count > 0)
                    cmbProduct.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
            }
        }

        private void CmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is Product product)
            {
                txtPrice.Text = product.Price.ToString("C");
                numQuantity.Maximum = product.StockQuantity;
            }
        }

        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            if (cmbProduct.SelectedItem is Product product)
            {
                var total = product.Price * numQuantity.Value;
                txtTotal.Text = total.ToString("C");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is Product product)
            {
                var quantity = (int)numQuantity.Value;
                var total = product.Price * quantity;

                var saleItem = new SaleItem
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    TotalPrice = total
                };

                _saleItems.Add(saleItem);
                RefreshItemsGrid();
                UpdateTotalAmount();
            }
        }

        private void RefreshItemsGrid()
        {
            dgvItems.Rows.Clear();
            foreach (var item in _saleItems)
            {
                var product = _productService.GetById(item.ProductId);
                var rowIndex = dgvItems.Rows.Add();
                dgvItems.Rows[rowIndex].Cells["ProductId"].Value = item.ProductId;
                dgvItems.Rows[rowIndex].Cells["ProductName"].Value = product?.Name ?? "N/A";
                dgvItems.Rows[rowIndex].Cells["Quantity"].Value = item.Quantity;
                dgvItems.Rows[rowIndex].Cells["Price"].Value = item.UnitPrice.ToString("C");
                dgvItems.Rows[rowIndex].Cells["Total"].Value = item.TotalPrice.ToString("C");
            }
        }

        private void UpdateTotalAmount()
        {
            _totalAmount = _saleItems.Sum(i => i.TotalPrice);
            txtTotal.Text = _totalAmount.ToString("C");
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (_saleItems.Count == 0)
            {
                MessageBox.Show("Adicione produtos à venda.");
                return;
            }

            try
            {
                var sale = new Sale
                {
                    SaleDate = DateTime.Now,
                    TotalAmount = _totalAmount,
                    PaymentMethod = cmbPayment.SelectedItem.ToString(),
                    Notes = ""
                };

                _saleService.AddSale(sale, _saleItems);
                MessageBox.Show($"Venda finalizada! Total: {_totalAmount:C}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
