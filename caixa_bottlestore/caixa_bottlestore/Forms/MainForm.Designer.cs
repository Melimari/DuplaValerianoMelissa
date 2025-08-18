namespace caixa_bottlestore.Forms
{
    public partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnReports;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 23);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Bem-vindo ao Sistema Bottle Store";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.Location = new System.Drawing.Point(12, 50);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(150, 40);
            this.btnManageProducts.TabIndex = 1;
            this.btnManageProducts.Text = "Gerenciar Produtos";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            this.btnManageProducts.Click += new System.EventHandler(this.btnManageProducts_Click);
            // 
            // btnSales
            // 
            this.btnSales.Location = new System.Drawing.Point(180, 50);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(150, 40);
            this.btnSales.TabIndex = 2;
            this.btnSales.Text = "Vendas";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(350, 50);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(150, 40);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Relatórios";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(520, 160);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnManageProducts);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnReports);

            this.Name = "MainForm";
            this.Text = "Sistema Bottle Store";
            this.ResumeLayout(false);
        }
    }
}
