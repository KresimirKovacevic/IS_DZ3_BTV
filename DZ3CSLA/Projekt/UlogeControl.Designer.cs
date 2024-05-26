namespace UpravljanjeProjektima
{
  partial class UlogeControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.ulogaGridControl = new DevExpress.XtraGrid.GridControl();
      this.ulogaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.ulogaGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colIdUloge = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colNazUloge = new DevExpress.XtraGrid.Columns.GridColumn();
      this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
      this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonSaveClose = new DevExpress.XtraEditors.SimpleButton();
      this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
      this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
      this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
      this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
      ((System.ComponentModel.ISupportInitialize)(this.styleController)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulogaGridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulogaBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulogaGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
      this.layoutControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
      this.SuspendLayout();
      // 
      // styleController
      // 
      this.styleController.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.styleController.Appearance.Options.UseFont = true;
      this.styleController.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 9F);
      this.styleController.AppearanceDisabled.Options.UseFont = true;
      this.styleController.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9F);
      this.styleController.AppearanceDropDown.Options.UseFont = true;
      this.styleController.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 9F);
      this.styleController.AppearanceDropDownHeader.Options.UseFont = true;
      this.styleController.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F);
      this.styleController.AppearanceFocused.Options.UseFont = true;
      this.styleController.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 9F);
      this.styleController.AppearanceReadOnly.Options.UseFont = true;
      // 
      // toolTipController
      // 
      this.toolTipController.Appearance.Font = new System.Drawing.Font("Arial", 9F);
      this.toolTipController.Appearance.Options.UseFont = true;
      this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
      this.toolTipController.AppearanceTitle.Options.UseFont = true;
      // 
      // ulogaGridControl
      // 
      this.ulogaGridControl.DataSource = this.ulogaBindingSource;
      this.ulogaGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ulogaGridControl.Location = new System.Drawing.Point(0, 0);
      this.ulogaGridControl.MainView = this.ulogaGridView;
      this.ulogaGridControl.Name = "ulogaGridControl";
      this.ulogaGridControl.Size = new System.Drawing.Size(527, 508);
      this.ulogaGridControl.TabIndex = 0;
      this.ulogaGridControl.ToolTipController = this.toolTipController;
      this.ulogaGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ulogaGridView});
      // 
      // ulogaBindingSource
      // 
      this.ulogaBindingSource.DataSource = typeof(UpravljanjeProjektima.Admin.Uloga);
      // 
      // ulogaGridView
      // 
      this.ulogaGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ulogaGridView.Appearance.HeaderPanel.Options.UseFont = true;
      this.ulogaGridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.ulogaGridView.Appearance.Row.Options.UseFont = true;
      this.ulogaGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdUloge,
            this.colNazUloge});
      this.ulogaGridView.GridControl = this.ulogaGridControl;
      this.ulogaGridView.Name = "ulogaGridView";
      this.ulogaGridView.OptionsBehavior.FocusLeaveOnTab = true;
      this.ulogaGridView.OptionsCustomization.AllowFilter = false;
      this.ulogaGridView.OptionsCustomization.AllowGroup = false;
      this.ulogaGridView.OptionsDetail.AllowZoomDetail = false;
      this.ulogaGridView.OptionsDetail.EnableMasterViewMode = false;
      this.ulogaGridView.OptionsDetail.ShowDetailTabs = false;
      this.ulogaGridView.OptionsDetail.SmartDetailExpand = false;
      this.ulogaGridView.OptionsFilter.AllowColumnMRUFilterList = false;
      this.ulogaGridView.OptionsFilter.AllowFilterEditor = false;
      this.ulogaGridView.OptionsFilter.AllowMRUFilterList = false;
      this.ulogaGridView.OptionsMenu.EnableColumnMenu = false;
      this.ulogaGridView.OptionsMenu.EnableFooterMenu = false;
      this.ulogaGridView.OptionsMenu.EnableGroupPanelMenu = false;
      this.ulogaGridView.OptionsNavigation.EnterMoveNextColumn = true;
      this.ulogaGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
      this.ulogaGridView.OptionsView.ShowDetailButtons = false;
      this.ulogaGridView.OptionsView.ShowGroupPanel = false;
      this.ulogaGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colIdUloge, DevExpress.Data.ColumnSortOrder.Ascending)});
      this.ulogaGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ulogaGridView_KeyDown);
      // 
      // colIdUloge
      // 
      this.colIdUloge.Caption = "ID";
      this.colIdUloge.FieldName = "IdUloge";
      this.colIdUloge.Name = "colIdUloge";
      this.colIdUloge.OptionsColumn.AllowEdit = false;
      this.colIdUloge.OptionsColumn.AllowFocus = false;
      this.colIdUloge.OptionsColumn.FixedWidth = true;
      this.colIdUloge.OptionsColumn.ReadOnly = true;
      this.colIdUloge.Visible = true;
      this.colIdUloge.VisibleIndex = 0;
      this.colIdUloge.Width = 50;
      // 
      // colNazUloge
      // 
      this.colNazUloge.Caption = "Uloga";
      this.colNazUloge.FieldName = "NazUloge";
      this.colNazUloge.Name = "colNazUloge";
      this.colNazUloge.Visible = true;
      this.colNazUloge.VisibleIndex = 1;
      this.colNazUloge.Width = 456;
      // 
      // layoutControl1
      // 
      this.layoutControl1.AllowCustomizationMenu = false;
      this.layoutControl1.Appearance.Control.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.layoutControl1.Appearance.Control.Options.UseFont = true;
      this.layoutControl1.Controls.Add(this.simpleButtonClose);
      this.layoutControl1.Controls.Add(this.simpleButtonSaveClose);
      this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Right;
      this.layoutControl1.Location = new System.Drawing.Point(527, 0);
      this.layoutControl1.Name = "layoutControl1";
      this.layoutControl1.Root = this.layoutControlGroup1;
      this.layoutControl1.Size = new System.Drawing.Size(165, 508);
      this.layoutControl1.StyleController = this.styleController;
      this.layoutControl1.TabIndex = 1;
      this.layoutControl1.Text = "layoutControl1";
      this.layoutControl1.ToolTipController = this.toolTipController;
      // 
      // simpleButtonClose
      // 
      this.simpleButtonClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.simpleButtonClose.Appearance.Options.UseFont = true;
      this.simpleButtonClose.Location = new System.Drawing.Point(12, 47);
      this.simpleButtonClose.Name = "simpleButtonClose";
      this.simpleButtonClose.Size = new System.Drawing.Size(159, 31);
      this.simpleButtonClose.StyleController = this.layoutControl1;
      this.simpleButtonClose.TabIndex = 5;
      this.simpleButtonClose.Text = "Odustani";
      this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
      // 
      // simpleButtonSaveClose
      // 
      this.simpleButtonSaveClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.simpleButtonSaveClose.Appearance.Options.UseFont = true;
      this.simpleButtonSaveClose.Location = new System.Drawing.Point(12, 12);
      this.simpleButtonSaveClose.Name = "simpleButtonSaveClose";
      this.simpleButtonSaveClose.Size = new System.Drawing.Size(159, 31);
      this.simpleButtonSaveClose.StyleController = this.layoutControl1;
      this.simpleButtonSaveClose.TabIndex = 4;
      this.simpleButtonSaveClose.Text = "Spremi i zatvori";
      this.simpleButtonSaveClose.Click += new System.EventHandler(this.simpleButtonSaveClose_Click);
      // 
      // layoutControlGroup1
      // 
      this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
      this.layoutControlGroup1.CustomizationFormText = "Root";
      this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
      this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
      this.layoutControlGroup1.Name = "Root";
      this.layoutControlGroup1.Size = new System.Drawing.Size(183, 491);
      this.layoutControlGroup1.Text = "Root";
      this.layoutControlGroup1.TextVisible = false;
      // 
      // layoutControlItem1
      // 
      this.layoutControlItem1.Control = this.simpleButtonSaveClose;
      this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
      this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
      this.layoutControlItem1.MaxSize = new System.Drawing.Size(163, 35);
      this.layoutControlItem1.MinSize = new System.Drawing.Size(163, 35);
      this.layoutControlItem1.Name = "layoutControlItem1";
      this.layoutControlItem1.Size = new System.Drawing.Size(163, 35);
      this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
      this.layoutControlItem1.Text = "layoutControlItem1";
      this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
      this.layoutControlItem1.TextToControlDistance = 0;
      this.layoutControlItem1.TextVisible = false;
      // 
      // layoutControlItem2
      // 
      this.layoutControlItem2.Control = this.simpleButtonClose;
      this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
      this.layoutControlItem2.Location = new System.Drawing.Point(0, 35);
      this.layoutControlItem2.MaxSize = new System.Drawing.Size(163, 35);
      this.layoutControlItem2.MinSize = new System.Drawing.Size(163, 35);
      this.layoutControlItem2.Name = "layoutControlItem2";
      this.layoutControlItem2.Size = new System.Drawing.Size(163, 35);
      this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
      this.layoutControlItem2.Text = "layoutControlItem2";
      this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
      this.layoutControlItem2.TextToControlDistance = 0;
      this.layoutControlItem2.TextVisible = false;
      // 
      // emptySpaceItem1
      // 
      this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
      this.emptySpaceItem1.Location = new System.Drawing.Point(0, 70);
      this.emptySpaceItem1.Name = "emptySpaceItem1";
      this.emptySpaceItem1.Size = new System.Drawing.Size(163, 401);
      this.emptySpaceItem1.Text = "emptySpaceItem1";
      this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
      // 
      // UlogeControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ulogaGridControl);
      this.Controls.Add(this.layoutControl1);
      this.FormTitle = "Uloge";
      this.Name = "UlogeControl";
      this.Size = new System.Drawing.Size(692, 508);
      this.Load += new System.EventHandler(this.UlogeControl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.styleController)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulogaGridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulogaBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ulogaGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
      this.layoutControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl ulogaGridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView ulogaGridView;
    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
    private DevExpress.XtraEditors.SimpleButton simpleButtonSaveClose;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    private System.Windows.Forms.BindingSource ulogaBindingSource;
    private DevExpress.XtraGrid.Columns.GridColumn colIdUloge;
    private DevExpress.XtraGrid.Columns.GridColumn colNazUloge;


  }
}
