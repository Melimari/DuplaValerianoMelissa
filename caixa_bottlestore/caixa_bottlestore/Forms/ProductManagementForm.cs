using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using caixa_bottlestore.Services;
using caixa_bottlestore.Models;

namespace caixa_bottlestore.Forms
{
    public partial class ProductManagementForm : Form
    {
        private readonly ProductService _productService = new ProductService();
        private Product? _selectedProduct;

        public ProductManagementForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void InitializeComponent()
        {
            this.dgvProducts = new DataGridView();
            this.gbProduct = new GroupBox();
            this.lblCode = new Label();
            this.txtCode = new TextBox();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblCategory = new Label();
            this.txtCategory = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblStock = new Label();
            this.txtStock = new TextBox();
            this.lblLowStockThreshold = new Label();
            this.txtLowStockThreshold = new TextBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            this.btnRefresh = new Button();
            this.SuspendLayout();

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 12);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(600, 300);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.SelectionChanged += new EventHandler(this.dgvProducts_SelectionChanged);

            // gbProduct
            this.gbProduct.Controls.Add(this.btnClear);
            this.gbProduct.Controls.Add(this.btnDelete);
            this.gbProduct.Controls.Add(this.btnUpdate);
            this.gbProduct.Controls.Add(this.btnAdd);
            this.gbProduct.Controls.Add(this.txtLowStockThreshold);
            this.gbProduct.Controls.Add(this.lblLowStockThreshold);
            this.gbProduct.Controls.Add(this.txtStock);
            this.gbProduct.Controls.Add(this.lblStock);
            this.gbProduct.Controls.Add(this.txtPrice);
            this.gbProduct.Controls.Add(this.lblPrice);
            this.gbProduct.Controls.Add(this.txtCategory);
            this.gbProduct.Controls.Add(this.lblCategory);
            this.gbProduct.Controls.Add(this.txtName);
            this.gbProduct.Controls.Add(this.lblName);
            this.gbProduct.Controls.Add(this.txtCode);
            this.gbProduct.Controls.Add(this.lblCode);
            this.gbProduct.Location = new System.Drawing.Point(12, 320);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(600, 200);
            this.gbProduct.TabIndex = 1;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Produto";

            // lblCode
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(10, 25);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(46, 15);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Código:";

            // txtCode
            this.txtCode.Location = new System.Drawing.Point(80, 22);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 23);
            this.txtCode.TabIndex = 1;

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(200, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nome:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(270, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 3;

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(490, 25);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 15);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Categoria:";

            // txtCategory
            this.txtCategory.Location = new System.Drawing.Point(560, 22);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 23);
            this.txtCategory.TabIndex = 5;

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(10, 60);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(46, 15);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Preço:";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(80, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 7;

            // lblStock
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(200, 60);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(46, 15);
            this.lblStock.TabIndex = 8;
            this.lblStock.Text = "Estoque:";

            // txtStock
            this.txtStock.Location = new System.Drawing.Point(270, 57);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 23);
            this.txtStock.TabIndex = 9;

            // lblLowStockThreshold
            this.lblLowStockThreshold.AutoSize = true;
            this.lblLowStockThreshold.Location = new System.Drawing.Point(390, 60);
            this.lblLowStockThreshold.Name = "lblLowStockThreshold";
            this.lblLowStockThreshold.Size = new System.Drawing.Size(120, 15);
            this.lblLowStockThreshold.TabIndex = 10;
            this.lblLowStockThreshold.Text = "Estoque Mínimo:";

            // txtLowStockThreshold
            this.txtLowStockThreshold.Location = new System.Drawing.Point(520, 57);
            this.txtLowStockThreshold.Name = "txtLowStockThreshold";
            this.txtLowStockThreshold.Size = new System.Drawing.Size(100, 23);
            this.txtLowStockThreshold.TabIndex = 11;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(10, 100);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location = new System.Drawing.Point(100, 100);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(190, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Excluir";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(280, 100);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(520, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Atualizar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // ProductManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 532);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gbProduct);
            this.Controls.Add(this.dgvProducts);
            this.Name = "ProductManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestão de Produtos";
            this.ResumeLayout(false);
        }

        private void LoadProducts()
        {
            try
            {
                var products = _productService.GetAll().ToList();
                dgvProducts.DataSource = products;
                dgvProducts.Columns["Id"].Visible = false;
                dgvProducts.Columns["Active"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                _selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem as Product;
                if (_selectedProduct != null)
                {
                    txtCode.Text = _selectedProduct.Code ?? "";
                    txtName.Text = _selectedProduct.Name ?? "";
                    txtCategory.Text = _selectedProduct.Category ?? "";
                    txtPrice.Text = _selectedProduct.Price.ToString("F2");
                    txtStock.Text = _selectedProduct.Stock.ToString();
                    txtLowStockThreshold.Text = _selectedProduct.LowStockThreshold.ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var product = new Product
                {
                    Code = txtCode.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Category = txtCategory.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    Stock = int.Parse(txtStock.Text),
                    LowStockThreshold = int.Parse(txtLowStockThreshold.Text),
                    Active = true
                };

                _productService.Add(product);
                MessageBox.Show("Produto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Selecione um produto para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                _selectedProduct.Code = txtCode.Text.Trim();
                _selectedProduct.Name = txtName.Text.Trim();
                _selectedProduct.Category = txtCategory.Text.Trim();
                _selectedProduct.Price = decimal.Parse(txtPrice.Text);
                _selectedProduct.Stock = int.Parse(txtStock.Text);
                _selectedProduct.LowStockThreshold = int.Parse(txtLowStockThreshold.Text);

                _productService.Update(_selectedProduct);
                MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Selecione um produto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja excluir este produto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _productService.Delete(_selectedProduct.Id);
                    MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void ClearForm()
        {
            _selectedProduct = null;
            txtCode.Text = "";
            txtName.Text = "";
            txtCategory.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";
            txtLowStockThreshold.Text = "";
            dgvProducts.ClearSelection();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Preço deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Estoque deve ser um número inteiro válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtLowStockThreshold.Text, out _))
            {
                MessageBox.Show("Estoque mínimo deve ser um número inteiro válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}



