namespace program2

{

    partial class ChangeOrderDetailForm

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

            this.groupBox1 = new System.Windows.Forms.GroupBox();

            this.label4 = new System.Windows.Forms.Label();

            this.label5 = new System.Windows.Forms.Label();

            this.button2 = new System.Windows.Forms.Button();

            this.button1 = new System.Windows.Forms.Button();

            this.label3 = new System.Windows.Forms.Label();

            this.label1 = new System.Windows.Forms.Label();

            this.dataGridView2 = new System.Windows.Forms.DataGridView();

            this.groupBox1.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();

            this.SuspendLayout();

            // 

            // groupBox1

            // 

            this.groupBox1.Controls.Add(this.label4);

            this.groupBox1.Controls.Add(this.label5);

            this.groupBox1.Controls.Add(this.button2);

            this.groupBox1.Controls.Add(this.button1);

            this.groupBox1.Controls.Add(this.label3);

            this.groupBox1.Font = new System.Drawing.Font("隶书", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.groupBox1.Location = new System.Drawing.Point(12, 160);

            this.groupBox1.Name = "groupBox1";

            this.groupBox1.Size = new System.Drawing.Size(323, 224);

            this.groupBox1.TabIndex = 5;

            this.groupBox1.TabStop = false;

            this.groupBox1.Text = "修改商品条目";

            // 

            // label4

            // 

            this.label4.AutoSize = true;

            this.label4.Location = new System.Drawing.Point(21, 55);

            this.label4.Name = "label4";

            this.label4.Size = new System.Drawing.Size(127, 14);

            this.label4.TabIndex = 8;

            this.label4.Text = "此条目属于订单：";

            // 

            // label5

            // 

            this.label5.AutoSize = true;

            this.label5.Location = new System.Drawing.Point(154, 55);

            this.label5.Name = "label5";

            this.label5.Size = new System.Drawing.Size(0, 14);

            this.label5.TabIndex = 7;

            // 

            // button2

            // 

            this.button2.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.button2.Location = new System.Drawing.Point(213, 163);

            this.button2.Name = "button2";

            this.button2.Size = new System.Drawing.Size(73, 36);

            this.button2.TabIndex = 6;

            this.button2.Text = "关闭";

            this.button2.UseVisualStyleBackColor = true;

            this.button2.Click += new System.EventHandler(this.button2_Click);

            // 

            // button1

            // 

            this.button1.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.button1.Location = new System.Drawing.Point(109, 163);

            this.button1.Name = "button1";

            this.button1.Size = new System.Drawing.Size(73, 36);

            this.button1.TabIndex = 5;

            this.button1.Text = "修改";

            this.button1.UseVisualStyleBackColor = true;

            this.button1.Click += new System.EventHandler(this.button1_Click);

            // 

            // label3

            // 

            this.label3.AutoSize = true;

            this.label3.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.label3.Location = new System.Drawing.Point(56, 93);

            this.label3.Name = "label3";

            this.label3.Size = new System.Drawing.Size(198, 19);

            this.label3.TabIndex = 4;

            this.label3.Text = "双击单元格直接修改";

            // 

            // label1

            // 

            this.label1.AutoSize = true;

            this.label1.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            this.label1.Location = new System.Drawing.Point(106, 18);

            this.label1.Name = "label1";

            this.label1.Size = new System.Drawing.Size(135, 19);

            this.label1.TabIndex = 4;

            this.label1.Text = "修改商品条目";

            // 

            // dataGridView2

            // 

            this.dataGridView2.AllowUserToAddRows = false;

            this.dataGridView2.AllowUserToDeleteRows = false;

            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView2.Location = new System.Drawing.Point(2, 40);

            this.dataGridView2.Name = "dataGridView2";

            this.dataGridView2.RowTemplate.Height = 23;

            this.dataGridView2.Size = new System.Drawing.Size(343, 114);

            this.dataGridView2.TabIndex = 9;

            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);

            this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView2_DataError);

            // 

            // ChangeOrderDetailForm

            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(347, 394);

            this.Controls.Add(this.dataGridView2);

            this.Controls.Add(this.groupBox1);

            this.Controls.Add(this.label1);

            this.Name = "ChangeOrderDetailForm";

            this.Text = "ChangeOrderDetailForm";

            this.groupBox1.ResumeLayout(false);

            this.groupBox1.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();



        }



        #endregion



        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DataGridView dataGridView2;

    }

}