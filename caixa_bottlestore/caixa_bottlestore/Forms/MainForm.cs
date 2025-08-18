using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caixa_bottlestore.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManageProducts_Click(object? sender, EventArgs e)
        {
            var productForm = new ProductManagementForm();
            productForm.ShowDialog();
        }

        private void btnSales_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Abrir vendas");
        }

        private void btnReports_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Abrir relatórios");
        }



        // Fallback caso o arquivo Designer não seja reconhecido no build
        private void InitializeComponent()
        {
            this.SuspendLayout();

            var lblWelcome = new Label
            {
                Location = new System.Drawing.Point(12, 9),
                Name = "lblWelcome",
                Size = new System.Drawing.Size(400, 23),
                TabIndex = 0,
                Text = "Bem-vindo, Usuário",
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            var btnManageProducts = new Button
            {
                Location = new System.Drawing.Point(12, 50),
                Name = "btnManageProducts",
                Size = new System.Drawing.Size(150, 40),
                TabIndex = 1,
                Text = "Gerenciar Produtos",
                UseVisualStyleBackColor = true
            };
            btnManageProducts.Click += new EventHandler(this.btnManageProducts_Click);

            var btnSales = new Button
            {
                Location = new System.Drawing.Point(180, 50),
                Name = "btnSales",
                Size = new System.Drawing.Size(150, 40),
                TabIndex = 2,
                Text = "Vendas",
                UseVisualStyleBackColor = true
            };
            btnSales.Click += new EventHandler(this.btnSales_Click);

            var btnReports = new Button
            {
                Location = new System.Drawing.Point(350, 50),
                Name = "btnReports",
                Size = new System.Drawing.Size(150, 40),
                TabIndex = 3,
                Text = "Relatórios",
                UseVisualStyleBackColor = true
            };
            btnReports.Click += new EventHandler(this.btnReports_Click);



            this.ClientSize = new System.Drawing.Size(520, 160);
            this.Name = "MainForm";
            this.Text = "Sistema Bottle Store";
            this.Controls.Add(lblWelcome);
            this.Controls.Add(btnManageProducts);
            this.Controls.Add(btnSales);
            this.Controls.Add(btnReports);

            this.ResumeLayout(false);
        }
    }
}
