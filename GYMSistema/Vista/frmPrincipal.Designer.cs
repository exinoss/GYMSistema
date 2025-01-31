namespace GYMSistema.Vista
{
    partial class frmPrincipal
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
            this.pnlCuenco = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPagos = new System.Windows.Forms.Button();
            this.btnClases = new System.Windows.Forms.Button();
            this.btnMembresia = new System.Windows.Forms.Button();
            this.btnSocios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCuenco.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCuenco
            // 
            this.pnlCuenco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlCuenco.Controls.Add(this.label1);
            this.pnlCuenco.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCuenco.Location = new System.Drawing.Point(149, 0);
            this.pnlCuenco.Name = "pnlCuenco";
            this.pnlCuenco.Size = new System.Drawing.Size(671, 501);
            this.pnlCuenco.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIENVENIDO AL SISTEMA";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPagos);
            this.panel1.Controls.Add(this.btnClases);
            this.panel1.Controls.Add(this.btnMembresia);
            this.panel1.Controls.Add(this.btnSocios);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 501);
            this.panel1.TabIndex = 2;
            // 
            // btnPagos
            // 
            this.btnPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPagos.Location = new System.Drawing.Point(0, 179);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(143, 44);
            this.btnPagos.TabIndex = 4;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.UseVisualStyleBackColor = true;
            // 
            // btnClases
            // 
            this.btnClases.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClases.Location = new System.Drawing.Point(0, 135);
            this.btnClases.Name = "btnClases";
            this.btnClases.Size = new System.Drawing.Size(143, 44);
            this.btnClases.TabIndex = 3;
            this.btnClases.Text = "Clases";
            this.btnClases.UseVisualStyleBackColor = true;
            // 
            // btnMembresia
            // 
            this.btnMembresia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMembresia.Location = new System.Drawing.Point(0, 91);
            this.btnMembresia.Name = "btnMembresia";
            this.btnMembresia.Size = new System.Drawing.Size(143, 44);
            this.btnMembresia.TabIndex = 2;
            this.btnMembresia.Text = "Membresia";
            this.btnMembresia.UseVisualStyleBackColor = true;
            // 
            // btnSocios
            // 
            this.btnSocios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSocios.Location = new System.Drawing.Point(0, 47);
            this.btnSocios.Name = "btnSocios";
            this.btnSocios.Size = new System.Drawing.Size(143, 44);
            this.btnSocios.TabIndex = 0;
            this.btnSocios.Text = "Socios";
            this.btnSocios.UseVisualStyleBackColor = true;
            this.btnSocios.Click += new System.EventHandler(this.btnSocios_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 47);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "OPCIONES";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 501);
            this.Controls.Add(this.pnlCuenco);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(836, 540);
            this.MinimumSize = new System.Drawing.Size(836, 540);
            this.Name = "frmPrincipal";
            this.Text = "Principal";
            this.pnlCuenco.ResumeLayout(false);
            this.pnlCuenco.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCuenco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPagos;
        private System.Windows.Forms.Button btnClases;
        private System.Windows.Forms.Button btnMembresia;
        private System.Windows.Forms.Button btnSocios;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
    }
}