namespace program2
{
    partial class OrderAddForm
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
             this.groupBox1 = new System.Windows.Forms.GroupBox(); 
              this.button1 = new System.Windows.Forms.Button(); 
              this.label3 = new System.Windows.Forms.Label(); 
            this.textBox1 = new System.Windows.Forms.TextBox(); 
            this.label2 = new System.Windows.Forms.Label(); 
             this.button2 = new System.Windows.Forms.Button(); 
              this.groupBox1.SuspendLayout(); 
             this.SuspendLayout(); 
            //  
             // label1 
            //  
            this.label1.AutoSize = true; 
             this.label1.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
             this.label1.Location = new System.Drawing.Point(144, 9); 
              this.label1.Name = "label1"; 
             this.label1.Size = new System.Drawing.Size(93, 19); 
              this.label1.TabIndex = 0; 
              this.label1.Text = "添加订单"; 
            //  
             // groupBox1 
           //  
            this.groupBox1.Controls.Add(this.button2); 
             this.groupBox1.Controls.Add(this.button1); 
              this.groupBox1.Controls.Add(this.label3); 
              this.groupBox1.Controls.Add(this.textBox1); 
             this.groupBox1.Controls.Add(this.label2); 
             this.groupBox1.Font = new System.Drawing.Font("隶书", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
            this.groupBox1.Location = new System.Drawing.Point(39, 31); 
              this.groupBox1.Name = "groupBox1"; 
              this.groupBox1.Size = new System.Drawing.Size(302, 173); 
              this.groupBox1.TabIndex = 1; 
             this.groupBox1.TabStop = false; 
             this.groupBox1.Text = "添加订单"; 
    
            this.button1.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
             this.button1.Location = new System.Drawing.Point(109, 121); 
             this.button1.Name = "button1"; 
              this.button1.Size = new System.Drawing.Size(73, 36); 
              this.button1.TabIndex = 5; 
             this.button1.Text = "添加"; 
              this.button1.UseVisualStyleBackColor = true; 
              this.button1.Click += new System.EventHandler(this.button1_Click); 
              //  
             // label3 
           //  
           this.label3.AutoSize = true; 
              this.label3.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
            this.label3.Location = new System.Drawing.Point(25, 82); 
            this.label3.Name = "label3"; 
             this.label3.Size = new System.Drawing.Size(261, 19); 
              this.label3.TabIndex = 4; 
              this.label3.Text = "订单号和日期会自动生成！"; 
             //  
              // textBox1 
              //  
             this.textBox1.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
              this.textBox1.Location = new System.Drawing.Point(126, 32); 
             this.textBox1.Name = "textBox1"; 
             this.textBox1.Size = new System.Drawing.Size(148, 23); 
             this.textBox1.TabIndex = 3; 
             //  
             // label2 
              //  
             this.label2.AutoSize = true; 
              this.label2.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
              this.label2.Location = new System.Drawing.Point(6, 36); 
              this.label2.Name = "label2"; 
             this.label2.Size = new System.Drawing.Size(114, 19); 
              this.label2.TabIndex = 2; 
             this.label2.Text = "客户名称："; 
              //  
             // button2 
             //  
            this.button2.Font = new System.Drawing.Font("隶书", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134))); 
              this.button2.Location = new System.Drawing.Point(213, 121); 
             this.button2.Name = "button2"; 
             this.button2.Size = new System.Drawing.Size(73, 36); 
             this.button2.TabIndex = 6; 
              this.button2.Text = "关闭"; 
              this.button2.UseVisualStyleBackColor = true; 
              this.button2.Click += new System.EventHandler(this.button2_Click); 
             //  
              // OrderAddForm 
              //  
              this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F); 
              this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; 
             this.ClientSize = new System.Drawing.Size(386, 216); 
             this.Controls.Add(this.groupBox1); 
              this.Controls.Add(this.label1); 
              this.Name = "OrderAddForm"; 
             this.Text = "OrderAdd"; 
             this.groupBox1.ResumeLayout(false); 
            this.groupBox1.PerformLayout(); 
            this.ResumeLayout(false); 
             this.PerformLayout(); 
 
 
         } 
 
 
          #endregion 
  
 
          private System.Windows.Forms.Label label1; 
          private System.Windows.Forms.GroupBox groupBox1; 
          private System.Windows.Forms.Label label2; 
          private System.Windows.Forms.Button button1; 
        private System.Windows.Forms.Label label3; 
        private System.Windows.Forms.TextBox textBox1; 
         private System.Windows.Forms.Button button2;

}
}