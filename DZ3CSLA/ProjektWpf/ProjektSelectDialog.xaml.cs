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
  /// Interaction logic for ProjektSelectDialog.xaml
  /// </summary>
  public partial class ProjektSelectDialog : Window
  {
    public string SifProjekta
    {
      get { return ((ProjektInfo)listViewProjekti.SelectedItem).SifProjekta; }
    }

    public ProjektSelectDialog()
    {
      InitializeComponent();
    }

    private void Odaberi(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }
  }
}
