
namespace System
{
    partial class Dashboard
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
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem,
            this.manageStudentToolStripMenuItem,
            this.marksToolStripMenuItem,
            this.feesToolStripMenuItem,
            this.showAllTransactionToolStripMenuItem,
            this.userToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(112, 36);
            this.studentToolStripMenuItem.Text = "Student";
            this.studentToolStripMenuItem.Click += new System.EventHandler(this.studentToolStripMenuItem_Click);
            // 
            // manageStudentToolStripMenuItem
            // 
            this.manageStudentToolStripMenuItem.Name = "manageStudentToolStripMenuItem";
            this.manageStudentToolStripMenuItem.Size = new System.Drawing.Size(206, 36);
            this.manageStudentToolStripMenuItem.Text = "Manage Student";
            this.manageStudentToolStripMenuItem.Click += new System.EventHandler(this.manageStudentToolStripMenuItem_Click_1);
            // 
            // marksToolStripMenuItem
            // 
            this.marksToolStripMenuItem.Name = "marksToolStripMenuItem";
            this.marksToolStripMenuItem.Size = new System.Drawing.Size(93, 36);
            this.marksToolStripMenuItem.Text = "Marks";
            this.marksToolStripMenuItem.Click += new System.EventHandler(this.marksToolStripMenuItem_Click_1);
            // 
            // feesToolStripMenuItem
            // 
            this.feesToolStripMenuItem.Name = "feesToolStripMenuItem";
            this.feesToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.feesToolStripMenuItem.Text = "Fees";
            this.feesToolStripMenuItem.Click += new System.EventHandler(this.feesToolStripMenuItem_Click_1);
            // 
            // showAllTransactionToolStripMenuItem
            // 
            this.showAllTransactionToolStripMenuItem.Name = "showAllTransactionToolStripMenuItem";
            this.showAllTransactionToolStripMenuItem.Size = new System.Drawing.Size(248, 36);
            this.showAllTransactionToolStripMenuItem.Text = "Show All Transaction";
            this.showAllTransactionToolStripMenuItem.Click += new System.EventHandler(this.showAllTransactionToolStripMenuItem_Click_1);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click_1);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(104, 36);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click_1);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(982, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.MenuStrip menuStrip1;
        private Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem manageStudentToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem marksToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem feesToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem showAllTransactionToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}