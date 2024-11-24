namespace canchacubo
{
    partial class empleado
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.dgv_empleado = new System.Windows.Forms.DataGridView();
            this.cbxopciones = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empleado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(315, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleado";
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(615, 327);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(105, 39);
            this.btn_volver.TabIndex = 1;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // dgv_empleado
            // 
            this.dgv_empleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_empleado.Location = new System.Drawing.Point(57, 148);
            this.dgv_empleado.Name = "dgv_empleado";
            this.dgv_empleado.Size = new System.Drawing.Size(542, 190);
            this.dgv_empleado.TabIndex = 2;
            // 
            // cbxopciones
            // 
            this.cbxopciones.FormattingEnabled = true;
            this.cbxopciones.Items.AddRange(new object[] {
            "0",
            "50000",
            "75000"});
            this.cbxopciones.Location = new System.Drawing.Point(478, 108);
            this.cbxopciones.Name = "cbxopciones";
            this.cbxopciones.Size = new System.Drawing.Size(121, 21);
            this.cbxopciones.TabIndex = 3;
            this.cbxopciones.SelectedIndexChanged += new System.EventHandler(this.cbxopciones_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(305, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "salario anual superiror a:";
            // 
            // empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::canchacubo.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxopciones);
            this.Controls.Add(this.dgv_empleado);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.label1);
            this.Name = "empleado";
            this.Text = "empleado";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.DataGridView dgv_empleado;
        private System.Windows.Forms.ComboBox cbxopciones;
        private System.Windows.Forms.Label label2;
    }
}