namespace UpravljanjeProjektima
{
  partial class OsobaSelectDialog
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
      this.components = new System.ComponentModel.Container();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonSaveClose = new DevExpress.XtraEditors.SimpleButton();
      this.osobaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.osobaGridControl = new DevExpress.XtraGrid.GridControl();
      this.osobaGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colNazOsobe = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.osobaBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.osobaGridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.osobaGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.simpleButtonCancel);
      this.panelControl1.Controls.Add(this.simpleButtonSaveClose);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl1.Location = new System.Drawing.Point(0, 486);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(392, 68);
      this.panelControl1.TabIndex = 0;
      // 
      // simpleButtonCancel
      // 
      this.simpleButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.simpleButtonCancel.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.simpleButtonCancel.Appearance.Options.UseFont = true;
      this.simpleButtonCancel.Location = new System.Drawing.Point(205, 23);
      this.simpleButtonCancel.Name = "simpleButtonCancel";
      this.simpleButtonCancel.Size = new System.Drawing.Size(125, 23);
      this.simpleButtonCancel.TabIndex = 1;
      this.simpleButtonCancel.Text = "Odustani";
      this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
      // 
      // simpleButtonSaveClose
      // 
      this.simpleButtonSaveClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.simpleButtonSaveClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.simpleButtonSaveClose.Appearance.Options.UseFont = true;
      this.simpleButtonSaveClose.Location = new System.Drawing.Point(63, 23);
      this.simpleButtonSaveClose.Name = "simpleButtonSaveClose";
      this.simpleButtonSaveClose.Size = new System.Drawing.Size(125, 23);
      this.simpleButtonSaveClose.TabIndex = 0;
      this.simpleButtonSaveClose.Text = "Odaberi";
      this.simpleButtonSaveClose.Click += new System.EventHandler(this.simpleButtonSaveClose_Click);
      // 
      // osobaBindingSource
      // 
      this.osobaBindingSource.DataSource = typeof(UpravljanjeProjektima.OsobaInfoList);
      // 
      // osobaGridControl
      // 
      this.osobaGridControl.DataSource = this.osobaBindingSource;
      this.osobaGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.osobaGridControl.Location = new System.Drawing.Point(0, 0);
      this.osobaGridControl.MainView = this.osobaGridView;
      this.osobaGridControl.Name = "osobaGridControl";
      this.osobaGridControl.Size = new System.Drawing.Size(392, 486);
      this.osobaGridControl.TabIndex = 1;
      this.osobaGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.osobaGridView});
      // 
      // osobaGridView
      // 
      this.osobaGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.osobaGridView.Appearance.HeaderPanel.Options.UseFont = true;
      this.osobaGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.osobaGridView.Appearance.Row.Options.UseFont = true;
      this.osobaGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNazOsobe});
      this.osobaGridView.GridControl = this.osobaGridControl;
      this.osobaGridView.Name = "osobaGridView";
      this.osobaGridView.OptionsBehavior.Editable = false;
      this.osobaGridView.OptionsBehavior.FocusLeaveOnTab = true;
      this.osobaGridView.OptionsDetail.AllowZoomDetail = false;
      this.osobaGridView.OptionsDetail.EnableMasterViewMode = false;
      this.osobaGridView.OptionsDetail.ShowDetailTabs = false;
      this.osobaGridView.OptionsDetail.SmartDetailExpand = false;
      this.osobaGridView.OptionsMenu.EnableColumnMenu = false;
      this.osobaGridView.OptionsMenu.EnableFooterMenu = false;
      this.osobaGridView.OptionsMenu.EnableGroupPanelMenu = false;
      this.osobaGridView.OptionsNavigation.EnterMoveNextColumn = true;
      this.osobaGridView.OptionsView.ShowAutoFilterRow = true;
      this.osobaGridView.OptionsView.ShowGroupPanel = false;
      // 
      // colNazOsobe
      // 
      this.colNazOsobe.Caption = "Osoba";
      this.colNazOsobe.FieldName = "NazOsobe";
      this.colNazOsobe.Name = "colNazOsobe";
      this.colNazOsobe.OptionsColumn.ReadOnly = true;
      this.colNazOsobe.Visible = true;
      this.colNazOsobe.VisibleIndex = 0;
      // 
      // OsobaSelectDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(392, 554);
      this.ControlBox = false;
      this.Controls.Add(this.osobaGridControl);
      this.Controls.Add(this.panelControl1);
      this.Name = "OsobaSelectDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Odaberi osobu";
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.osobaBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.osobaGridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.osobaGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private System.Windows.Forms.BindingSource osobaBindingSource;
    private DevExpress.XtraGrid.GridControl osobaGridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView osobaGridView;
    private DevExpress.XtraGrid.Columns.GridColumn colNazOsobe;
    private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
    private DevExpress.XtraEditors.SimpleButton simpleButtonSaveClose;
  }
}