namespace ForumView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.докладчикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыФорумовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.докладыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форумыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регистрацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.докладчикиToolStripMenuItem,
            this.типыФорумовToolStripMenuItem,
            this.докладыToolStripMenuItem,
            this.форумыToolStripMenuItem,
            this.входToolStripMenuItem,
            this.регистрацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // докладчикиToolStripMenuItem
            // 
            this.докладчикиToolStripMenuItem.Name = "докладчикиToolStripMenuItem";
            this.докладчикиToolStripMenuItem.Size = new System.Drawing.Size(106, 26);
            this.докладчикиToolStripMenuItem.Text = "Докладчики";
            this.докладчикиToolStripMenuItem.Click += new System.EventHandler(this.докладчикиToolStripMenuItem_Click);
            // 
            // типыФорумовToolStripMenuItem
            // 
            this.типыФорумовToolStripMenuItem.Name = "типыФорумовToolStripMenuItem";
            this.типыФорумовToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.типыФорумовToolStripMenuItem.Text = "Типы форумов";
            this.типыФорумовToolStripMenuItem.Click += new System.EventHandler(this.типыФорумовToolStripMenuItem_Click);
            // 
            // докладыToolStripMenuItem
            // 
            this.докладыToolStripMenuItem.Name = "докладыToolStripMenuItem";
            this.докладыToolStripMenuItem.Size = new System.Drawing.Size(84, 26);
            this.докладыToolStripMenuItem.Text = "Доклады";
            this.докладыToolStripMenuItem.Click += new System.EventHandler(this.докладыToolStripMenuItem_Click);
            // 
            // форумыToolStripMenuItem
            // 
            this.форумыToolStripMenuItem.Name = "форумыToolStripMenuItem";
            this.форумыToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.форумыToolStripMenuItem.Text = "Форумы";
            this.форумыToolStripMenuItem.Click += new System.EventHandler(this.форумыToolStripMenuItem_Click);
            // 
            // входToolStripMenuItem
            // 
            this.входToolStripMenuItem.Name = "входToolStripMenuItem";
            this.входToolStripMenuItem.Size = new System.Drawing.Size(56, 26);
            this.входToolStripMenuItem.Text = "Вход";
            this.входToolStripMenuItem.Click += new System.EventHandler(this.входToolStripMenuItem_Click);
            // 
            // регистрацияToolStripMenuItem
            // 
            this.регистрацияToolStripMenuItem.Name = "регистрацияToolStripMenuItem";
            this.регистрацияToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.регистрацияToolStripMenuItem.Text = "Регистрация";
            this.регистрацияToolStripMenuItem.Click += new System.EventHandler(this.регистрацияToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 134);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(990, 416);
            this.dataGridView.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(320, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 76);
            this.label1.TabIndex = 14;
            this.label1.Text = "Форумы.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(852, 85);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(122, 36);
            this.buttonRef.TabIndex = 15;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 563);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.FormOrders_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem докладчикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыФорумовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem докладыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форумыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem входToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem регистрацияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRef;
    }
}