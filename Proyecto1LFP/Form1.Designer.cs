namespace Proyecto1LFP
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.abrirFicheroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresoRb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.analizarBt = new System.Windows.Forms.Button();
            this.tablaSimbolosBt = new System.Windows.Forms.Button();
            this.tablaErroresBt = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(653, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirFicheroToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "Archivo";
            // 
            // abrirFicheroToolStripMenuItem
            // 
            this.abrirFicheroToolStripMenuItem.Name = "abrirFicheroToolStripMenuItem";
            this.abrirFicheroToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.abrirFicheroToolStripMenuItem.Text = "Abrir Fichero";
            this.abrirFicheroToolStripMenuItem.Click += new System.EventHandler(this.abrirFicheroToolStripMenuItem_Click);
            // 
            // ingresoRb
            // 
            this.ingresoRb.Location = new System.Drawing.Point(12, 87);
            this.ingresoRb.Name = "ingresoRb";
            this.ingresoRb.Size = new System.Drawing.Size(569, 150);
            this.ingresoRb.TabIndex = 1;
            this.ingresoRb.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Texto Cargado a Analizar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(15, 299);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(569, 165);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resultado del Análisis";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // analizarBt
            // 
            this.analizarBt.Location = new System.Drawing.Point(18, 40);
            this.analizarBt.Name = "analizarBt";
            this.analizarBt.Size = new System.Drawing.Size(75, 23);
            this.analizarBt.TabIndex = 5;
            this.analizarBt.Text = "Analizar";
            this.analizarBt.UseVisualStyleBackColor = true;
            this.analizarBt.Click += new System.EventHandler(this.analizarBt_Click);
            // 
            // tablaSimbolosBt
            // 
            this.tablaSimbolosBt.Location = new System.Drawing.Point(99, 40);
            this.tablaSimbolosBt.Name = "tablaSimbolosBt";
            this.tablaSimbolosBt.Size = new System.Drawing.Size(164, 23);
            this.tablaSimbolosBt.TabIndex = 6;
            this.tablaSimbolosBt.Text = "Mostrar Tabla de Simbolos";
            this.tablaSimbolosBt.UseVisualStyleBackColor = true;
            this.tablaSimbolosBt.Click += new System.EventHandler(this.tablaSimbolosBt_Click);
            // 
            // tablaErroresBt
            // 
            this.tablaErroresBt.Location = new System.Drawing.Point(269, 40);
            this.tablaErroresBt.Name = "tablaErroresBt";
            this.tablaErroresBt.Size = new System.Drawing.Size(146, 23);
            this.tablaErroresBt.TabIndex = 7;
            this.tablaErroresBt.Text = "Mostar tabla de Errores";
            this.tablaErroresBt.UseVisualStyleBackColor = true;
            this.tablaErroresBt.Click += new System.EventHandler(this.tablaErroresBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 485);
            this.Controls.Add(this.tablaErroresBt);
            this.Controls.Add(this.tablaSimbolosBt);
            this.Controls.Add(this.analizarBt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingresoRb);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Proyecto 1 LFP";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem abrirFicheroToolStripMenuItem;
        private System.Windows.Forms.RichTextBox ingresoRb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button analizarBt;
        private System.Windows.Forms.Button tablaSimbolosBt;
        private System.Windows.Forms.Button tablaErroresBt;
    }
}

