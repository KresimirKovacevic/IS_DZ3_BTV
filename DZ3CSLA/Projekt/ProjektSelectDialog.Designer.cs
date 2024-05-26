namespace UpravljanjeProjektima
{
  partial class ProjektSelectDialog
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
      this.projektBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.projektGridControl = new DevExpress.XtraGrid.GridControl();
      this.projektGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colNazProjekta = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.projektBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.projektGridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.projektGridView)).BeginInit();
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
      // projektBindingSource
      // 
      this.projektBindingSource.DataSource = typeof(UpravljanjeProjektima.ProjektInfoList);
      // 
      // projektGridControl
      // 
      this.projektGridControl.DataSource = this.projektBindingSource;
      this.projektGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.projektGridControl.Location = new System.Drawing.Point(0, 0);
      this.projektGridControl.MainView = this.projektGridView;
      this.projektGridControl.Name = "projektGridControl";
      this.projektGridControl.Size = new System.Drawing.Size(392, 486);
      this.projektGridControl.TabIndex = 1;
      this.projektGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.projektGridView});
      // 
      // projektGridView
      // 
      this.projektGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.projektGridView.Appearance.HeaderPanel.Options.UseFont = true;
      this.projektGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.projektGridView.Appearance.Row.Options.UseFont = true;
      this.projektGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNazProjekta});
      this.projektGridView.GridControl = this.projektGridControl;
      this.projektGridView.Name = "projektGridView";
      this.projektGridView.OptionsBehavior.Editable = false;
      this.projektGridView.OptionsBehavior.FocusLeaveOnTab = true;
      this.projektGridView.OptionsDetail.AllowZoomDetail = false;
      this.projektGridView.OptionsDetail.EnableMasterViewMode = false;
      this.projektGridView.OptionsDetail.ShowDetailTabs = false;
      this.projektGridView.OptionsDetail.SmartDetailExpand = false;
      this.projektGridView.OptionsMenu.EnableColumnMenu = false;
      this.projektGridView.OptionsMenu.EnableFooterMenu = false;
      this.projektGridView.OptionsMenu.EnableGroupPanelMenu = false;
      this.projektGridView.OptionsNavigation.EnterMoveNextColumn = true;
      this.projektGridView.OptionsView.ShowAutoFilterRow = true;
      this.projektGridView.OptionsView.ShowGroupPanel = false;
      // 
      // colNazProjekta
      // 
      this.colNazProjekta.Caption = "Projekt";
      this.colNazProjekta.FieldName = "NazProjekta";
      this.colNazProjekta.Name = "colNazProjekta";
      this.colNazProjekta.OptionsColumn.ReadOnly = true;
      this.colNazProjekta.Visible = true;
      this.colNazProjekta.VisibleIndex = 0;
      // 
      // ProjektSelectDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(392, 554);
      this.ControlBox = false;
      this.Controls.Add(this.projektGridControl);
      this.Controls.Add(this.panelControl1);
      this.Name = "ProjektSelectDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Odaberi projekt";
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.projektBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.projektGridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.projektGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private System.Windows.Forms.BindingSource projektBindingSource;
    private DevExpress.XtraGrid.GridControl projektGridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView projektGridView;
    private DevExpress.XtraGrid.Columns.GridColumn colNazProjekta;
    private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
    private DevExpress.XtraEditors.SimpleButton simpleButtonSaveClose;
  }
}