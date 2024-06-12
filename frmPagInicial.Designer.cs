namespace AutenticarV
{
    partial class frmPagInicial
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
            btnSair = new Button();
            lstCredenciais = new ListView();
            btnListar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(264, 42);
            label1.Name = "label1";
            label1.Size = new Size(273, 32);
            label1.TabIndex = 0;
            label1.Text = "Bem-vindo a aplicação";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(568, 371);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(87, 38);
            btnSair.TabIndex = 1;
            btnSair.Text = "Exit";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // lstCredenciais
            // 
            lstCredenciais.Location = new Point(159, 98);
            lstCredenciais.Name = "lstCredenciais";
            lstCredenciais.Size = new Size(496, 267);
            lstCredenciais.TabIndex = 2;
            lstCredenciais.UseCompatibleStateImageBehavior = false;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(475, 371);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(87, 38);
            btnListar.TabIndex = 3;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // frmPagInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnListar);
            Controls.Add(lstCredenciais);
            Controls.Add(btnSair);
            Controls.Add(label1);
            Name = "frmPagInicial";
            Text = "frmPagInicial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSair;
        private ListView lstCredenciais;
        private Button btnListar;
    }
}