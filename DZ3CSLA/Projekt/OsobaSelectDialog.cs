using System;
using System.Windows.Forms;

namespace UpravljanjeProjektima
{
  public partial class OsobaSelectDialog : DevExpress.XtraEditors.XtraForm
  {
    public OsobaSelectDialog()
    {
      InitializeComponent();

      osobaBindingSource.DataSource = OsobaInfoList.Get();
    }

    public int IdOsobe
    {
      get { return (osobaBindingSource.Current as OsobaInfo).IdOsobe; }
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