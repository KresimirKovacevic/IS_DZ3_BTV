using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UpravljanjeProjektima
{
  /// <summary>
  /// Interaction logic for OsobaSelectDialog.xaml
  /// </summary>
  public partial class OsobaSelectDialog : Window
  {

    public int IdOsobe
    {
      get { return ((OsobaInfo)listViewOsobe.SelectedItem).IdOsobe; }
    }

    public OsobaSelectDialog()
    {
      InitializeComponent();
    }

    private void Odaberi(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }



  }
}
