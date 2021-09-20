
namespace HeadphonesShop.PresentationWF.Forms.CommonUser
{
    partial class CommonCatalogForm
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
            this.SuspendLayout();
            // 
            // CommonCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "CommonCatalogForm";
            this.Text = "CommonCatalogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommonCatalogFormClosed);
            this.Load += new System.EventHandler(this.CommonCatalogFormLoad);
            this.ResumeLayout(false);

        }

        #endregion
    }
}