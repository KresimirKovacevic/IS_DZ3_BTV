using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UpravljanjeProjektima.Core;
using UpravljanjeProjektima.Properties;

namespace UpravljanjeProjektima
{
  public partial class MainForm : XtraForm
  {
    #region Constructors
    public MainForm()
    {
      InitializeComponent();
    }
    #endregion

    #region Run Control
    // popis aktivnih kontrola
    private Dictionary<Type, BaseFormControl> activeControls = new Dictionary<Type, BaseFormControl>();

    // aktiviraj praznu kontrolu 
    protected void RunForm<T>()
      where T : BaseFormControl
    {
      using (new StatusBusy())
      {
        if (activeControls.ContainsKey(typeof(T))) // ako je bila instancirana
        {
          activeControls[typeof(T)].BringToFront();
        }
        else // instanciraj
        {
          BaseFormControl c = (BaseFormControl)Activator.CreateInstance<T>();
          activeControls.Add(typeof(T), c);
          c.Dock = DockStyle.Fill;
          groupControl1.Controls.Add(c);
          c.BringToFront();
          c.DoClose += new EventHandler(c_DoClose);
        }

        groupControl1.Text = activeControls[typeof(T)].FormTitle;
        RefreshPanel();
      }
    }

    // otvara formu za Osobu/Projekt (ulanèavanje)
    // ako je forma traženog tipa veæ otvorena postavi ju u fokus
    protected void RunForm<T>(object businessObject)
      where T : BaseFormControl
    {
      using (new StatusBusy())
      {
        if (activeControls.ContainsKey(typeof(T)))
        {
          activeControls[typeof(T)].BringToFront();
        }
        else
        {
          BaseFormControl c = (BaseFormControl)Activator.CreateInstance(typeof(T), businessObject);
          activeControls.Add(typeof(T), c);
          c.Dock = DockStyle.Fill;
          groupControl1.Controls.Add(c);
          c.BringToFront();
          c.DoClose += new EventHandler(c_DoClose);
        }

        groupControl1.Text = activeControls[typeof(T)].FormTitle;
        RefreshPanel();
      }
    }

    private void c_DoClose(object sender, EventArgs e)
    {
      BaseFormControl c = (BaseFormControl)sender;
      activeControls.Remove(c.GetType());
      c.Dispose();
      groupControl1.Controls.Remove(c);
      RefreshPanel();
    }

    private void RefreshPanel()
    {
      groupControl1.Visible = activeControls.Count > 0;
    }
    #endregion

    #region NavBar Item Click
    private void navBarExit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      Application.Exit();
    }

    private void navBarUloge_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      RunForm<UlogeControl>();
    }

    private void navBarAddProjekt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      RunForm<ProjektControl>();
    }

    private void navBarEditProjekt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      using (ProjektSelectDialog dlg = new ProjektSelectDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          var projekt = Projekt.Get(dlg.SifProjekta);
          RunForm<ProjektControl>(projekt);
        }
      }
    }

    private void navBarDeleteProjekt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      using (ProjektSelectDialog dlg = new ProjektSelectDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          Projekt.Delete(dlg.SifProjekta);
          MessageBox.Show(Resources.ObrisanoInfo, Resources.InformationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    private void navBarDeleteOsoba_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      using (OsobaSelectDialog dlg = new OsobaSelectDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          Osoba.Delete(dlg.IdOsobe);
          MessageBox.Show(Resources.ObrisanoInfo, Resources.InformationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    private void navBarAddOsoba_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      RunForm<OsobaControl>();
    }

    private void navBarEditOsoba_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
    {
      using (OsobaSelectDialog dlg = new OsobaSelectDialog())
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          var osoba = Osoba.Get(dlg.IdOsobe);
          RunForm<OsobaControl>(osoba);
        }
      }
    }
    #endregion

    #region Show...
    // ulanèavanje
    public void ShowOsoba(int idOsobe)
    {
      var osoba = Osoba.Get(idOsobe);
      RunForm<OsobaControl>(osoba);
    }

    public void ShowProjekt(string sifProjekta)
    {
      var projekt = Projekt.Get(sifProjekta);
      RunForm<ProjektControl>(projekt);
    }
    #endregion
  }
}