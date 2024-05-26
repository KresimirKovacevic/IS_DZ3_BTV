using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using UpravljanjeProjektima.Core;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  public partial class ProjektControl : BaseFormControl
  {
    #region Constructors

    // zapoèni unos
    public ProjektControl()
    {
      InitializeComponent();
      repositoryItemHyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(repositoryItemHyperLinkEdit1_OpenLink);
      this.projekt = Projekt.New();
    }

    // zapoèni edit
    public ProjektControl(Projekt projekt)
    {
      InitializeComponent();
      repositoryItemHyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(repositoryItemHyperLinkEdit1_OpenLink);
      this.projekt = projekt;
    }
    #endregion

    #region Projekt
    private Projekt projekt;
    [Browsable(false)]
    public Projekt Projekt
    {
      get { return projekt; }
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
    // kombinacije spremi zatvori odustani
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
    // u Load te nakon spremanja
    private void BindUI()
    {
      projekt.BeginEdit();
      projektBindingSource.DataSource = projekt;
      SifProjektaTextEdit.Enabled = projekt.IsNew;
    }

    // saveObject : true-save, false-close
    // rebind : true - ostaje vidljiv, nakon save ili cancel
    private void RebindUI(bool saveObject, bool rebind)
    {
      this.projektBindingSource.RaiseListChangedEvents = false;
      this.sudioniciProjektaBindingSource.RaiseListChangedEvents = false;
      try
      {
        // dovrši ili opozovi edit
        UnbindBindingSource(this.sudioniciProjektaBindingSource, saveObject, false);
        UnbindBindingSource(this.projektBindingSource, saveObject, true);
        this.sudioniciProjektaBindingSource.DataSource = this.projektBindingSource;

        if (saveObject)
        {
          projekt.ApplyEdit(); // commit edit
          try
          {
            projekt = projekt.Save(); // save to database
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
          projekt.CancelEdit(); // restore object
        }
      }
      finally
      {
        if (rebind)
        {
          BindUI();
        }

        this.projektBindingSource.RaiseListChangedEvents = true;
        this.sudioniciProjektaBindingSource.RaiseListChangedEvents = true;

        if (rebind)
        {
          this.projektBindingSource.ResetBindings(false);
          this.sudioniciProjektaBindingSource.ResetBindings(false);
        }

        if (projekt != null)
        {
          SifProjektaTextEdit.Enabled = projekt.IsNew;
        }
      }
    }
    #endregion

    #region Zoom
    // ulanèavanje
    private void repositoryItemHyperLinkEdit1_OpenLink(object sender, OpenLinkEventArgs e)
    {
      ProjektApplication.MainForm.ShowOsoba((sudioniciProjektaBindingSource.Current as SudionikProjekta).IdOsobe);
      this.Close();
    }
    #endregion

    #region Upravljanje osobama
    private void simpleButtonAddOsoba_Click(object sender, EventArgs e)
    {
      OsobaSelectDialog dlg = new OsobaSelectDialog();
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        try
        {
          projekt.SudioniciProjekta.DodijeliOsobu(dlg.IdOsobe);
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

    private void simpleButtonRemoveOsoba_Click(object sender, EventArgs e)
    {
      object toRemove = osobeGridView.GetFocusedRow();
      if (toRemove != null)
      {
        projekt.SudioniciProjekta.Remove((SudionikProjekta)toRemove);
      }
    }
    #endregion
  }
}
