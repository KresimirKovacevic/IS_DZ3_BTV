using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace UpravljanjeProjektima
{
  /// <summary>
  /// Base class for edit forms that integrate
  /// with the MainForm navigation code.
  /// </summary>
  public class EditForm : UserControl, IRefresh
  {
    /// <summary>
    /// Creates an instance of the object.
    /// </summary>
    public EditForm()
    {

    }

    void IRefresh.Refresh()
    {

    }

    protected virtual void DataChanged(object sender, EventArgs e)
    {
      var dp = sender as System.Windows.Data.DataSourceProvider;
      if (dp.Error != null)
        MessageBox.Show(dp.Error.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
    }

    public event EventHandler TitleChanged;

    // Using a DependencyProperty as the backing store for _title.  
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(EditForm), null);

    public string Title
    {
      get { return (string)GetValue(TitleProperty); }
      set
      {
        SetValue(TitleProperty, value);  // System.Windows.DependencyObject.SetValue
        if (TitleChanged != null)
          TitleChanged(this, EventArgs.Empty);
      }
    }
  }
}

