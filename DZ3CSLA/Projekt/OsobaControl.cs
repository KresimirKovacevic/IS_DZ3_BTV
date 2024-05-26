using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using UpravljanjeProjektima.Core;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  public partial class OsobaControl : BaseFormControl
  {
    #region Constructors
    public OsobaControl()
    {
      InitializeComponent();
      repositoryItemHyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(repositoryItemHyperLinkEdit1_OpenLink);
      this.osoba = Osoba.New();
    }

    public OsobaControl(Osoba osoba)
    {
      InitializeComponent();
      repositoryItemHyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(repositoryItemHyperLinkEdit1_OpenLink);
      this.osoba = osoba;
    }
    #endregion

    #region Projekt
    private Osoba osoba;
    [Browsable(false)]
    public Osoba Osoba
    {
      get { return osoba; }
    }
    #endregion

    #region Form Load
    private void ProjektControl_Load(object sender, EventArgs e)
    {
      ulogaBindingSource.DataSource = UlogaList.Get();
      BindUI();
    }
    #endregion

    #region Button Clicks
    private void simpleButtonSaveClose_Click(object sender, EventArgs e)
    {
      using (new StatusBusy())
      {
        RebindUI(true, false);
      }
      Close();
    }

    private void simpleButtonSave_Click(object sender, EventArgs e)
    {
      using (new StatusBusy())
      {
        RebindUI(true, true);
      }
    }

    private void simpleButtonCancel_Click(object sender, EventArgs e)
    {
      RebindUI(false, true);
    }

    private void simpleButtonClose_Click(object sender, EventArgs e)
    {
      RebindUI(false, true);
      Close();
    }
    #endregion

    #region Binding
    private void BindUI()
    {
      osoba.BeginEdit();
      osobaBindingSource.DataSource = osoba;
    }

    private void RebindUI(bool saveObject, bool rebind)
    {
      this.osobaBindingSource.RaiseListChangedEvents = false;
      this.projektiOsobeBindingSource.RaiseListChangedEvents = false;
      try
      {
        UnbindBindingSource(this.projektiOsobeBindingSource, saveObject, false);
        UnbindBindingSource(this.osobaBindingSource, saveObject, true);
        this.projektiOsobeBindingSource.DataSource = this.osobaBindingSource;

        if (saveObject)
        {
          osoba.ApplyEdit();
          try
          {
            osoba = osoba.Save();
          }
          catch (Csla.DataPortalException ex)
          {
            MessageBox.Show(ex.BusinessException.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          osoba.CancelEdit();
        }
      }
      finally
      {
        if (rebind)
        {
          BindUI();
        }

        this.osobaBindingSource.RaiseListChangedEvents = true;
        this.projektiOsobeBindingSource.RaiseListChangedEvents = true;

        if (rebind)
        {
          this.osobaBindingSource.ResetBindings(false);
          this.projektiOsobeBindingSource.ResetBindings(false);
        }
      }
    }
    #endregion

    #region Zoom
    private void repositoryItemHyperLinkEdit1_OpenLink(object sender, OpenLinkEventArgs e)
    {
      ProjektApplication.MainForm.ShowProjekt((projektiOsobeBindingSource.Current as ProjektOsobe).SifProjekta);
      Close();
    }
    #endregion

    #region Upravljanje osobama
    private void simpleButtonAddProjekt_Click(object sender, EventArgs e)
    {
      ProjektSelectDialog dlg = new ProjektSelectDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        try
        {
          osoba.ProjektiOsobe.DodijeliProjekt(dlg.SifProjekta);
        }
        catch (InvalidOperationException ex)
        {
          MessageBox.Show(ex.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString(), Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void simpleButtonRemoveProjekt_Click(object sender, EventArgs e)
    {
      object toRemove = projektGridView.GetFocusedRow();
      if (toRemove != null)
      {
        osoba.ProjektiOsobe.Remove((ProjektOsobe)toRemove);
      }
    }
    #endregion
  }
}
