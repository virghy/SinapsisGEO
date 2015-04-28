namespace Tracker
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lbRTShow = new System.Windows.Forms.ListBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(49, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(95, 20);
            this.txtIP.TabIndex = 15;
            this.txtIP.Text = "192.168.1.225";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Puerto";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(298, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(231, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(53, 20);
            this.txtPort.TabIndex = 16;
            this.txtPort.Text = "4370";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "IP";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Crimson;
            this.lblState.Location = new System.Drawing.Point(415, 17);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(146, 13);
            this.lblState.TabIndex = 13;
            this.lblState.Text = "Estado Actual:Desconectado";
            // 
            // lbRTShow
            // 
            this.lbRTShow.FormattingEnabled = true;
            this.lbRTShow.Location = new System.Drawing.Point(10, 15);
            this.lbRTShow.Name = "lbRTShow";
            this.lbRTShow.Size = new System.Drawing.Size(445, 251);
            this.lbRTShow.TabIndex = 4;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lbRTShow);
            this.GroupBox1.Location = new System.Drawing.Point(21, 59);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(468, 279);
            this.GroupBox1.TabIndex = 19;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Eventos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 350);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.GroupBox1);
            this.Name = "Form1";
            this.Text = "Tracker";
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ListBox lbRTShow;
        private System.Windows.Forms.GroupBox GroupBox1;
    }
}

