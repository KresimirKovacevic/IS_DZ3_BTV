namespace UpravljanjeProjektima.Core
{
  partial class BaseFormControl
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
      this.styleController = new DevExpress.XtraEditors.StyleController(this.components);
      this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.styleController)).BeginInit();
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
      // BaseControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "BaseControl";
      this.Size = new System.Drawing.Size(364, 549);
      this.toolTipController.SetSuperTip(this, null);
      ((System.ComponentModel.ISupportInitialize)(this.styleController)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    protected DevExpress.XtraEditors.StyleController styleController;
    protected DevExpress.Utils.ToolTipController toolTipController;
  }
}
