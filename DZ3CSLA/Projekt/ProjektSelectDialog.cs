using System;
using System.Windows.Forms;

namespace UpravljanjeProjektima
{
  public partial class ProjektSelectDialog : DevExpress.XtraEditors.XtraForm
  {
    public ProjektSelectDialog()
    {
      InitializeComponent();
      
      projektBindingSource.DataSource = ProjektInfoList.Get();
    }

    public string SifProjekta
    {
      get { return (projektBindingSource.Current as ProjektInfo).SifProjekta; }
    }

    private void simpleButtonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void simpleButtonSaveClose_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}