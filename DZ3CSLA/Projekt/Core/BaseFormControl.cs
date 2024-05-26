using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UpravljanjeProjektima.Core
{
  [ToolboxItem(false)]
  public partial class BaseFormControl : XtraUserControl
  {
    #region Constructors
    protected BaseFormControl()
    {
      InitializeComponent();
    }
    #endregion

    #region Helper Methods

    // dovršetak ureðivanja EndEdit / CancelEdit
    // isRoot=true : master, inaèe detail
    protected void UnbindBindingSource(BindingSource source, bool apply, bool isRoot)
    {
      IEditableObject current = source.Current as IEditableObject;
      if (isRoot)
      {
        source.DataSource = null;
      }
      if (current != null)
      {
        if (apply)
        {
          current.EndEdit();
        }
        else
        {
          current.CancelEdit();
        }
      }
    }
    #endregion

    #region Close
    private EventHandler doClose;
    public event EventHandler DoClose
    {
      add { doClose += value; }
      remove { doClose -= value; }
    }

    public void Close()
    {
      if (doClose != null)
        doClose.Invoke(this, new EventArgs());
    }
    #endregion

    #region FormTitle
    private string formTitle = string.Empty;
    [Category("Appearance"), Browsable(true), DefaultValue("")]
    public string FormTitle
    {
      get { return formTitle; }
      set { formTitle = value; }
    }
    #endregion
  }
}
