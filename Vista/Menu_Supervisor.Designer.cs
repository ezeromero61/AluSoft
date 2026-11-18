using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    public partial class Menu_Supervisor : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Name = "Menu_Supervisor";
            this.Text = "Menu_Supervisor";
            this.Load += new System.EventHandler(this.Menu_Supervisor_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}