namespace CakeStoreMng
{
    partial class Admin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbbSurvice = new System.Windows.Forms.ComboBox();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.lbSurvice = new System.Windows.Forms.Label();
            this.ptbColor1 = new System.Windows.Forms.PictureBox();
            this.lbInfor1 = new System.Windows.Forms.Label();
            this.txtInfor1 = new System.Windows.Forms.TextBox();
            this.txtInfor2 = new System.Windows.Forms.TextBox();
            this.lbInfor2 = new System.Windows.Forms.Label();
            this.txtInfor3 = new System.Windows.Forms.TextBox();
            this.lbInfor3 = new System.Windows.Forms.Label();
            this.txtInfor6 = new System.Windows.Forms.TextBox();
            this.lbInfor6 = new System.Windows.Forms.Label();
            this.txtInfor5 = new System.Windows.Forms.TextBox();
            this.lbInfor5 = new System.Windows.Forms.Label();
            this.txtInfor4 = new System.Windows.Forms.TextBox();
            this.lbInfor4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbbInfor4 = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CakeStoreMng.Properties.Resources.Free_vector_000290_mo_hinh_san_pham_banh_bang_tay;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -422);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(891, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cbbSurvice
            // 
            this.cbbSurvice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSurvice.FormattingEnabled = true;
            this.cbbSurvice.Items.AddRange(new object[] {
            "Category",
            "Cake",
            "Employee",
            "Customer",
            "Orders",
            "OrderDetail",
            "Import",
            "ImportDetail"});
            this.cbbSurvice.Location = new System.Drawing.Point(610, 23);
            this.cbbSurvice.Name = "cbbSurvice";
            this.cbbSurvice.Size = new System.Drawing.Size(135, 37);
            this.cbbSurvice.TabIndex = 2;
            this.cbbSurvice.TextChanged += new System.EventHandler(this.cbbSurvice_TextChanged);
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(44)))), ((int)(((byte)(42)))));
            this.lbWelcome.Location = new System.Drawing.Point(55, 23);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(115, 29);
            this.lbWelcome.TabIndex = 3;
            this.lbWelcome.Text = "Welcome";
            this.lbWelcome.Click += new System.EventHandler(this.lbUser_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(319, 100);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.Size = new System.Drawing.Size(556, 395);
            this.dgvTable.TabIndex = 4;
            this.dgvTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTable_CellClick);
            // 
            // lbSurvice
            // 
            this.lbSurvice.AutoSize = true;
            this.lbSurvice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.lbSurvice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSurvice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(44)))), ((int)(((byte)(42)))));
            this.lbSurvice.Location = new System.Drawing.Point(500, 26);
            this.lbSurvice.Name = "lbSurvice";
            this.lbSurvice.Size = new System.Drawing.Size(101, 29);
            this.lbSurvice.TabIndex = 5;
            this.lbSurvice.Text = "survice: ";
            // 
            // ptbColor1
            // 
            this.ptbColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ptbColor1.Location = new System.Drawing.Point(12, 100);
            this.ptbColor1.Name = "ptbColor1";
            this.ptbColor1.Size = new System.Drawing.Size(278, 395);
            this.ptbColor1.TabIndex = 6;
            this.ptbColor1.TabStop = false;
            // 
            // lbInfor1
            // 
            this.lbInfor1.AutoSize = true;
            this.lbInfor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor1.Location = new System.Drawing.Point(30, 111);
            this.lbInfor1.Name = "lbInfor1";
            this.lbInfor1.Size = new System.Drawing.Size(56, 18);
            this.lbInfor1.TabIndex = 7;
            this.lbInfor1.Text = "lbInfor1";
            this.lbInfor1.Visible = false;
            // 
            // txtInfor1
            // 
            this.txtInfor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfor1.Location = new System.Drawing.Point(36, 132);
            this.txtInfor1.Name = "txtInfor1";
            this.txtInfor1.Size = new System.Drawing.Size(218, 24);
            this.txtInfor1.TabIndex = 8;
            this.txtInfor1.Visible = false;
            // 
            // txtInfor2
            // 
            this.txtInfor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfor2.Location = new System.Drawing.Point(33, 186);
            this.txtInfor2.Name = "txtInfor2";
            this.txtInfor2.Size = new System.Drawing.Size(218, 24);
            this.txtInfor2.TabIndex = 10;
            this.txtInfor2.Visible = false;
            // 
            // lbInfor2
            // 
            this.lbInfor2.AutoSize = true;
            this.lbInfor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor2.Location = new System.Drawing.Point(28, 165);
            this.lbInfor2.Name = "lbInfor2";
            this.lbInfor2.Size = new System.Drawing.Size(56, 18);
            this.lbInfor2.TabIndex = 9;
            this.lbInfor2.Text = "lbInfor2";
            this.lbInfor2.Visible = false;
            // 
            // txtInfor3
            // 
            this.txtInfor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfor3.Location = new System.Drawing.Point(33, 240);
            this.txtInfor3.Name = "txtInfor3";
            this.txtInfor3.Size = new System.Drawing.Size(218, 24);
            this.txtInfor3.TabIndex = 12;
            this.txtInfor3.Visible = false;
            // 
            // lbInfor3
            // 
            this.lbInfor3.AutoSize = true;
            this.lbInfor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor3.Location = new System.Drawing.Point(29, 219);
            this.lbInfor3.Name = "lbInfor3";
            this.lbInfor3.Size = new System.Drawing.Size(56, 18);
            this.lbInfor3.TabIndex = 11;
            this.lbInfor3.Text = "lbInfor3";
            this.lbInfor3.Visible = false;
            // 
            // txtInfor6
            // 
            this.txtInfor6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfor6.Location = new System.Drawing.Point(33, 400);
            this.txtInfor6.Name = "txtInfor6";
            this.txtInfor6.Size = new System.Drawing.Size(218, 24);
            this.txtInfor6.TabIndex = 18;
            this.txtInfor6.Visible = false;
            // 
            // lbInfor6
            // 
            this.lbInfor6.AutoSize = true;
            this.lbInfor6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor6.Location = new System.Drawing.Point(29, 379);
            this.lbInfor6.Name = "lbInfor6";
            this.lbInfor6.Size = new System.Drawing.Size(56, 18);
            this.lbInfor6.TabIndex = 17;
            this.lbInfor6.Text = "lbInfor6";
            this.lbInfor6.Visible = false;
            // 
            // txtInfor5
            // 
            this.txtInfor5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfor5.Location = new System.Drawing.Point(33, 346);
            this.txtInfor5.Name = "txtInfor5";
            this.txtInfor5.Size = new System.Drawing.Size(218, 24);
            this.txtInfor5.TabIndex = 16;
            this.txtInfor5.Visible = false;
            // 
            // lbInfor5
            // 
            this.lbInfor5.AutoSize = true;
            this.lbInfor5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor5.Location = new System.Drawing.Point(28, 325);
            this.lbInfor5.Name = "lbInfor5";
            this.lbInfor5.Size = new System.Drawing.Size(56, 18);
            this.lbInfor5.TabIndex = 15;
            this.lbInfor5.Text = "lbInfor5";
            this.lbInfor5.Visible = false;
            // 
            // txtInfor4
            // 
            this.txtInfor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfor4.Location = new System.Drawing.Point(36, 292);
            this.txtInfor4.Name = "txtInfor4";
            this.txtInfor4.Size = new System.Drawing.Size(218, 24);
            this.txtInfor4.TabIndex = 14;
            this.txtInfor4.Visible = false;
            // 
            // lbInfor4
            // 
            this.lbInfor4.AutoSize = true;
            this.lbInfor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor4.Location = new System.Drawing.Point(30, 271);
            this.lbInfor4.Name = "lbInfor4";
            this.lbInfor4.Size = new System.Drawing.Size(56, 18);
            this.lbInfor4.TabIndex = 13;
            this.lbInfor4.Text = "lbInfor4";
            this.lbInfor4.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAdd.Location = new System.Drawing.Point(33, 440);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 46);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnUpdate.Location = new System.Drawing.Point(115, 440);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 46);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(197, 440);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 46);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbbInfor4
            // 
            this.cbbInfor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbInfor4.FormattingEnabled = true;
            this.cbbInfor4.Items.AddRange(new object[] {
            "Sale",
            "Warehouse",
            "Admin"});
            this.cbbInfor4.Location = new System.Drawing.Point(31, 290);
            this.cbbInfor4.Name = "cbbInfor4";
            this.cbbInfor4.Size = new System.Drawing.Size(223, 26);
            this.cbbInfor4.TabIndex = 23;
            this.cbbInfor4.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLogout.Location = new System.Drawing.Point(778, 24);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(97, 36);
            this.btnLogout.TabIndex = 24;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(887, 507);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.cbbInfor4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtInfor6);
            this.Controls.Add(this.lbInfor6);
            this.Controls.Add(this.txtInfor5);
            this.Controls.Add(this.lbInfor5);
            this.Controls.Add(this.txtInfor4);
            this.Controls.Add(this.lbInfor4);
            this.Controls.Add(this.txtInfor3);
            this.Controls.Add(this.lbInfor3);
            this.Controls.Add(this.txtInfor2);
            this.Controls.Add(this.lbInfor2);
            this.Controls.Add(this.txtInfor1);
            this.Controls.Add(this.lbInfor1);
            this.Controls.Add(this.ptbColor1);
            this.Controls.Add(this.lbSurvice);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.cbbSurvice);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbColor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbbSurvice;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Label lbSurvice;
        private System.Windows.Forms.PictureBox ptbColor1;
        private System.Windows.Forms.Label lbInfor1;
        private System.Windows.Forms.TextBox txtInfor1;
        private System.Windows.Forms.TextBox txtInfor2;
        private System.Windows.Forms.Label lbInfor2;
        private System.Windows.Forms.TextBox txtInfor3;
        private System.Windows.Forms.Label lbInfor3;
        private System.Windows.Forms.TextBox txtInfor6;
        private System.Windows.Forms.Label lbInfor6;
        private System.Windows.Forms.TextBox txtInfor5;
        private System.Windows.Forms.Label lbInfor5;
        private System.Windows.Forms.TextBox txtInfor4;
        private System.Windows.Forms.Label lbInfor4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbbInfor4;
        private System.Windows.Forms.Button btnLogout;
    }
}