namespace program2

{

    partial class Form1

    {

        /// <summary>

        /// 必需的设计器变量。

        /// </summary>

        private System.ComponentModel.IContainer components = null;



        /// <summary>

        /// 清理所有正在使用的资源。

        /// </summary>

        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>

        protected override void Dispose(bool disposing)

        {

            if (disposing && (components != null))

            {

                components.Dispose();

            }

            base.Dispose(disposing);

        }



        #region Windows 窗体设计器生成的代码



        /// <summary>

        /// 设计器支持所需的方法 - 不要修改

        /// 使用代码编辑器修改此方法的内容。

        /// </summary>

        private void InitializeComponent()

        {

            this.components = new System.ComponentModel.Container();

            this.button1 = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.label1 = new System.Windows.Forms.Label();

            this.label2 = new System.Windows.Forms.Label();

            this.button2 = new System.Windows.Forms.Button();

            this.textBox1 = new System.Windows.Forms.TextBox();

            this.groupBox1 = new System.Windows.Forms.GroupBox();

            this.radioButton4 = new System.Windows.Forms.RadioButton();

            this.radioButton3 = new System.Windows.Forms.RadioButton();

            this.radioButton2 = new System.Windows.Forms.RadioButton();

            this.radioButton1 = new System.Windows.Forms.RadioButton();

            this.dataGridView2 = new System.Windows.Forms.DataGridView();

            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();

            this.button3 = new System.Windows.Forms.Button();

            this.button4 = new System.Windows.Forms.Button();

            this.button5 = new System.Windows.Forms.Button();

            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();

            this.button6 = new System.Windows.Forms.Button();

            this.button7 = new System.Windows.Forms.Button();

            this.button8 = new System.Windows.Forms.Button();

            this.radioButton5 = new System.Windows.Forms.RadioButton();

            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);

            this.orderNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.clientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.clinetPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.allPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.myOrderDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.button9 = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();

            this.groupBox1.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();

            this.flowLayoutPanel1.SuspendLayout();

            this.flowLayoutPanel2.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();

            this.SuspendLayout();

            // 

            // button1

            // 

            this.button1.Location = new System.Drawing.Point(72, 282);

            this.button1.Name = "button1";

            this.button1.Size = new System.Drawing.Size(90, 33);

            this.button1.TabIndex = 0;

            this.button1.Text = "显示全部订单";

            this.button1.UseVisualStyleBackColor = true;

            this.button1.Click += new System.EventHandler(this.button1_Click);

            // 

            // dataGridView1

            // 

            this.dataGridView1.AllowUserToAddRows = false;

            this.dataGridView1.AllowUserToDeleteRows = false;

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {

            this.orderNumDataGridViewTextBoxColumn,

            this.clientNameDataGridViewTextBoxColumn,

            this.clinetPhoneNumberDataGridViewTextBoxColumn,

            this.allPriceDataGridViewTextBoxColumn,

            this.myOrderDateTimeDataGridViewTextBoxColumn});

            this.dataGridView1.DataSource = this.orderBindingSource;

            this.dataGridView1.Location = new System.Drawing.Point(236, 28);

            this.dataGridView1.Name = "dataGridView1";

            this.dataGridView1.ReadOnly = true;

            this.dataGridView1.RowTemplate.Height = 23;

            this.dataGridView1.Size = new System.Drawing.Size(546, 135);

            this.dataGridView1.TabIndex = 1;

            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // 

            // label1

            // 

            this.label1.AutoSize = true;

            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "OrderNum", true));

            this.label1.Location = new System.Drawing.Point(346, 9);

            this.label1.Name = "label1";

            this.label1.Size = new System.Drawing.Size(17, 12);

            this.label1.TabIndex = 2;

            this.label1.Text = "。";

            // 

            // label2

            // 

            this.label2.AutoSize = true;

            this.label2.Location = new System.Drawing.Point(260, 9);

            this.label2.Name = "label2";

            this.label2.Size = new System.Drawing.Size(65, 12);

            this.label2.TabIndex = 3;

            this.label2.Text = "选中订单：";

            // 

            // button2

            // 

            this.button2.Location = new System.Drawing.Point(171, 190);

            this.button2.Name = "button2";

            this.button2.Size = new System.Drawing.Size(47, 33);

            this.button2.TabIndex = 4;

            this.button2.Text = "查询订单";

            this.button2.UseVisualStyleBackColor = true;

            this.button2.Click += new System.EventHandler(this.button2_Click);

            // 

            // textBox1

            // 

            this.textBox1.Location = new System.Drawing.Point(0, 197);

            this.textBox1.Name = "textBox1";

            this.textBox1.Size = new System.Drawing.Size(150, 21);

            this.textBox1.TabIndex = 5;

            // 

            // groupBox1

            // 

            this.groupBox1.Controls.Add(this.radioButton5);

            this.groupBox1.Controls.Add(this.radioButton4);

            this.groupBox1.Controls.Add(this.radioButton3);

            this.groupBox1.Controls.Add(this.radioButton2);

            this.groupBox1.Controls.Add(this.radioButton1);

            this.groupBox1.Controls.Add(this.textBox1);

            this.groupBox1.Controls.Add(this.button2);

            this.groupBox1.Location = new System.Drawing.Point(6, 28);

            this.groupBox1.Name = "groupBox1";

            this.groupBox1.Size = new System.Drawing.Size(224, 248);

            this.groupBox1.TabIndex = 7;

            this.groupBox1.TabStop = false;

            this.groupBox1.Text = "查询订单";

            // 

            // radioButton4

            // 

            this.radioButton4.AutoSize = true;

            this.radioButton4.Location = new System.Drawing.Point(6, 119);

            this.radioButton4.Name = "radioButton4";

            this.radioButton4.Size = new System.Drawing.Size(155, 16);

            this.radioButton4.TabIndex = 9;

            this.radioButton4.TabStop = true;

            this.radioButton4.Text = "根据顶点包含有某种商品";

            this.radioButton4.UseVisualStyleBackColor = true;

            // 

            // radioButton3

            // 

            this.radioButton3.AutoSize = true;

            this.radioButton3.Location = new System.Drawing.Point(6, 85);

            this.radioButton3.Name = "radioButton3";

            this.radioButton3.Size = new System.Drawing.Size(119, 16);

            this.radioButton3.TabIndex = 8;

            this.radioButton3.TabStop = true;

            this.radioButton3.Text = "根据订单客户名称";

            this.radioButton3.UseVisualStyleBackColor = true;

            // 

            // radioButton2

            // 

            this.radioButton2.AutoSize = true;

            this.radioButton2.Location = new System.Drawing.Point(6, 53);

            this.radioButton2.Name = "radioButton2";

            this.radioButton2.Size = new System.Drawing.Size(191, 16);

            this.radioButton2.TabIndex = 7;

            this.radioButton2.TabStop = true;

            this.radioButton2.Text = "根据订单日期（格式20181010）";

            this.radioButton2.UseVisualStyleBackColor = true;

            // 

            // radioButton1

            // 

            this.radioButton1.AutoSize = true;

            this.radioButton1.Location = new System.Drawing.Point(6, 20);

            this.radioButton1.Name = "radioButton1";

            this.radioButton1.Size = new System.Drawing.Size(203, 16);

            this.radioButton1.TabIndex = 6;

            this.radioButton1.TabStop = true;

            this.radioButton1.Text = "根据订单号（格式2018-10-10-1）";

            this.radioButton1.UseVisualStyleBackColor = true;

            // 

            // dataGridView2

            // 

            this.dataGridView2.AllowUserToAddRows = false;

            this.dataGridView2.AllowUserToDeleteRows = false;

            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView2.Location = new System.Drawing.Point(348, 210);

            this.dataGridView2.Name = "dataGridView2";

            this.dataGridView2.ReadOnly = true;

            this.dataGridView2.RowTemplate.Height = 23;

            this.dataGridView2.Size = new System.Drawing.Size(343, 114);

            this.dataGridView2.TabIndex = 8;

            // 

            // flowLayoutPanel1

            // 

            this.flowLayoutPanel1.Controls.Add(this.button3);

            this.flowLayoutPanel1.Controls.Add(this.button4);

            this.flowLayoutPanel1.Controls.Add(this.button5);

            this.flowLayoutPanel1.Location = new System.Drawing.Point(389, 169);

            this.flowLayoutPanel1.Name = "flowLayoutPanel1";

            this.flowLayoutPanel1.Size = new System.Drawing.Size(254, 32);

            this.flowLayoutPanel1.TabIndex = 9;

            // 

            // button3

            // 

            this.button3.Location = new System.Drawing.Point(3, 3);

            this.button3.Name = "button3";

            this.button3.Size = new System.Drawing.Size(75, 23);

            this.button3.TabIndex = 0;

            this.button3.Text = "添加";

            this.button3.UseVisualStyleBackColor = true;

            this.button3.Click += new System.EventHandler(this.button3_Click);

            // 

            // button4

            // 

            this.button4.Location = new System.Drawing.Point(84, 3);

            this.button4.Name = "button4";

            this.button4.Size = new System.Drawing.Size(75, 23);

            this.button4.TabIndex = 1;

            this.button4.Text = "修改";

            this.button4.UseVisualStyleBackColor = true;

            this.button4.Click += new System.EventHandler(this.button4_Click);

            // 

            // button5

            // 

            this.button5.Location = new System.Drawing.Point(165, 3);

            this.button5.Name = "button5";

            this.button5.Size = new System.Drawing.Size(75, 23);

            this.button5.TabIndex = 2;

            this.button5.Text = "删除";

            this.button5.UseVisualStyleBackColor = true;

            this.button5.Click += new System.EventHandler(this.button5_Click);

            // 

            // flowLayoutPanel2

            // 

            this.flowLayoutPanel2.Controls.Add(this.button6);

            this.flowLayoutPanel2.Controls.Add(this.button7);

            this.flowLayoutPanel2.Controls.Add(this.button8);

            this.flowLayoutPanel2.Location = new System.Drawing.Point(389, 330);

            this.flowLayoutPanel2.Name = "flowLayoutPanel2";

            this.flowLayoutPanel2.Size = new System.Drawing.Size(254, 32);

            this.flowLayoutPanel2.TabIndex = 10;

            // 

            // button6

            // 

            this.button6.Location = new System.Drawing.Point(3, 3);

            this.button6.Name = "button6";

            this.button6.Size = new System.Drawing.Size(75, 23);

            this.button6.TabIndex = 0;

            this.button6.Text = "添加";

            this.button6.UseVisualStyleBackColor = true;

            this.button6.Click += new System.EventHandler(this.button6_Click);

            // 

            // button7

            // 

            this.button7.Location = new System.Drawing.Point(84, 3);

            this.button7.Name = "button7";

            this.button7.Size = new System.Drawing.Size(75, 23);

            this.button7.TabIndex = 1;

            this.button7.Text = "修改";

            this.button7.UseVisualStyleBackColor = true;

            this.button7.Click += new System.EventHandler(this.button7_Click);

            // 

            // button8

            // 

            this.button8.Location = new System.Drawing.Point(165, 3);

            this.button8.Name = "button8";

            this.button8.Size = new System.Drawing.Size(75, 23);

            this.button8.TabIndex = 2;

            this.button8.Text = "删除";

            this.button8.UseVisualStyleBackColor = true;

            this.button8.Click += new System.EventHandler(this.button8_Click);

            // 

            // radioButton5

            // 

            this.radioButton5.AutoSize = true;

            this.radioButton5.Location = new System.Drawing.Point(6, 151);

            this.radioButton5.Name = "radioButton5";

            this.radioButton5.Size = new System.Drawing.Size(119, 16);

            this.radioButton5.TabIndex = 10;

            this.radioButton5.TabStop = true;

            this.radioButton5.Text = "根据订单客户电话";

            this.radioButton5.UseVisualStyleBackColor = true;

            // 

            // orderBindingSource

            // 

            this.orderBindingSource.DataSource = typeof(program1.Order);

            // 

            // orderNumDataGridViewTextBoxColumn

            // 

            this.orderNumDataGridViewTextBoxColumn.DataPropertyName = "OrderNum";

            this.orderNumDataGridViewTextBoxColumn.HeaderText = "订单号";

            this.orderNumDataGridViewTextBoxColumn.Name = "orderNumDataGridViewTextBoxColumn";

            this.orderNumDataGridViewTextBoxColumn.ReadOnly = true;

            // 

            // clientNameDataGridViewTextBoxColumn

            // 

            this.clientNameDataGridViewTextBoxColumn.DataPropertyName = "ClientName";

            this.clientNameDataGridViewTextBoxColumn.HeaderText = "客户名称";

            this.clientNameDataGridViewTextBoxColumn.Name = "clientNameDataGridViewTextBoxColumn";

            this.clientNameDataGridViewTextBoxColumn.ReadOnly = true;

            // 

            // clinetPhoneNumberDataGridViewTextBoxColumn

            // 

            this.clinetPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "ClinetPhoneNumber";

            this.clinetPhoneNumberDataGridViewTextBoxColumn.HeaderText = "客户电话";

            this.clinetPhoneNumberDataGridViewTextBoxColumn.Name = "clinetPhoneNumberDataGridViewTextBoxColumn";

            this.clinetPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;

            // 

            // allPriceDataGridViewTextBoxColumn

            // 

            this.allPriceDataGridViewTextBoxColumn.DataPropertyName = "AllPrice";

            this.allPriceDataGridViewTextBoxColumn.HeaderText = "订单总价";

            this.allPriceDataGridViewTextBoxColumn.Name = "allPriceDataGridViewTextBoxColumn";

            this.allPriceDataGridViewTextBoxColumn.ReadOnly = true;

            // 

            // myOrderDateTimeDataGridViewTextBoxColumn

            // 

            this.myOrderDateTimeDataGridViewTextBoxColumn.DataPropertyName = "MyOrderDateTime";

            this.myOrderDateTimeDataGridViewTextBoxColumn.HeaderText = "下单时间";

            this.myOrderDateTimeDataGridViewTextBoxColumn.Name = "myOrderDateTimeDataGridViewTextBoxColumn";

            this.myOrderDateTimeDataGridViewTextBoxColumn.ReadOnly = true;

            // 

            // button9

            // 

            this.button9.Location = new System.Drawing.Point(72, 377);

            this.button9.Name = "button9";

            this.button9.Size = new System.Drawing.Size(166, 65);

            this.button9.TabIndex = 11;

            this.button9.Text = "导出为HTML文件";

            this.button9.UseVisualStyleBackColor = true;

            this.button9.Click += new System.EventHandler(this.button9_Click);

            // 

            // Form1

            // 

            this.AllowDrop = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(811, 467);

            this.Controls.Add(this.button9);

            this.Controls.Add(this.flowLayoutPanel1);

            this.Controls.Add(this.dataGridView2);

            this.Controls.Add(this.groupBox1);

            this.Controls.Add(this.flowLayoutPanel2);

            this.Controls.Add(this.label2);

            this.Controls.Add(this.label1);

            this.Controls.Add(this.dataGridView1);

            this.Controls.Add(this.button1);

            this.Name = "Form1";

            this.Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();

            this.groupBox1.ResumeLayout(false);

            this.groupBox1.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();

            this.flowLayoutPanel1.ResumeLayout(false);

            this.flowLayoutPanel2.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();



        }



        #endregion



        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.RadioButton radioButton3;

        private System.Windows.Forms.RadioButton radioButton2;

        private System.Windows.Forms.RadioButton radioButton1;

        private System.Windows.Forms.RadioButton radioButton4;

        private System.Windows.Forms.DataGridView dataGridView2;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.Button button5;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

        private System.Windows.Forms.Button button6;

        private System.Windows.Forms.Button button7;

        private System.Windows.Forms.Button button8;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumDataGridViewTextBoxColumn;

        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;

        private System.Windows.Forms.DataGridViewTextBoxColumn clinetPhoneNumberDataGridViewTextBoxColumn;

        private System.Windows.Forms.DataGridViewTextBoxColumn allPriceDataGridViewTextBoxColumn;

        private System.Windows.Forms.DataGridViewTextBoxColumn myOrderDateTimeDataGridViewTextBoxColumn;

        private System.Windows.Forms.BindingSource orderBindingSource;

        private System.Windows.Forms.RadioButton radioButton5;

        private System.Windows.Forms.Button button9;

    }

}

