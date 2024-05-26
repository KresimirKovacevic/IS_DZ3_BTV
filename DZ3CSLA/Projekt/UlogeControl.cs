using System;
using System.Windows.Forms;
using Csla;
using UpravljanjeProjektima.Admin;
using UpravljanjeProjektima.Core;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  public partial class UlogeControl : BaseFormControl
  {
    #region Constructors
    public UlogeControl()
    {
      InitializeComponent();
    }
    #endregion

    #region Fields
    private Uloge uloge;
    #endregion

    #region Form Load
    private void UlogeControl_Load(object sender, EventArgs e)
    {
      try
      {
        uloge = Uloge.Get();
      }
      catch (DataPortalException ex)
      {
        MessageBox.Show(ex.BusinessException.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      if (uloge != null)
      {
        this.ulogaBindingSource.DataSource = uloge;
      }
    }
    #endregion

    #region Save / Cancel
    private void simpleButtonSaveClose_Click(object sender, EventArgs e)
    {
      this.ulogaBindingSource.RaiseListChangedEvents = false;

      UnbindBindingSource(this.ulogaBindingSource, true, true);

      try
      {
        uloge = uloge.Save();
        Close();
      }
      catch (DataPortalException ex)
      {
        MessageBox.Show(ex.BusinessException.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        this.ulogaBindingSource.DataSource = uloge;
        this.ulogaBindingSource.RaiseListChangedEvents = true;
        this.ulogaBindingSource.ResetBindings(false);
      }
    }

    private void simpleButtonClose_Click(object sender, EventArgs e)
    {
      Close();
    }
    #endregion

    #region Brisanje
    private void ulogaGridView_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        ulogaGridView.DeleteSelectedRows();
      }
    }
    #endregion
  }
}
