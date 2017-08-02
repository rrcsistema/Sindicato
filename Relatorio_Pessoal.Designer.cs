namespace Sindicato
{
    partial class Relatorio_Pessoal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorio_Pessoal));
            this.crvRelatorio_Pessoal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRelatorio_Pessoal
            // 
            this.crvRelatorio_Pessoal.ActiveViewIndex = -1;
            this.crvRelatorio_Pessoal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crvRelatorio_Pessoal.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvRelatorio_Pessoal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRelatorio_Pessoal.EnableToolTips = false;
            this.crvRelatorio_Pessoal.Location = new System.Drawing.Point(0, 0);
            this.crvRelatorio_Pessoal.Name = "crvRelatorio_Pessoal";
            this.crvRelatorio_Pessoal.ReuseParameterValuesOnRefresh = true;
            this.crvRelatorio_Pessoal.ShowCloseButton = false;
            this.crvRelatorio_Pessoal.ShowCopyButton = false;
            this.crvRelatorio_Pessoal.ShowGroupTreeButton = false;
            this.crvRelatorio_Pessoal.ShowParameterPanelButton = false;
            this.crvRelatorio_Pessoal.ShowRefreshButton = false;
            this.crvRelatorio_Pessoal.ShowTextSearchButton = false;
            this.crvRelatorio_Pessoal.Size = new System.Drawing.Size(605, 413);
            this.crvRelatorio_Pessoal.TabIndex = 0;
            this.crvRelatorio_Pessoal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Relatorio_Pessoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 413);
            this.Controls.Add(this.crvRelatorio_Pessoal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Relatorio_Pessoal";
            this.Text = "Relatorio Pessoal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRelatorio_Pessoal;

    }
}