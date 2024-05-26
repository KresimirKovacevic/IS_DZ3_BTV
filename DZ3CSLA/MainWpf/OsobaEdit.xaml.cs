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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UpravljanjeProjektima
{
  /// <summary>
  /// Interaction logic for OsobaEdit.xaml
  /// </summary>
  public partial class OsobaEdit : EditForm
  {
    private int idOsobe;
    private Csla.Wpf.CslaDataProvider dataProvider;

    public OsobaEdit()
    {
      InitializeComponent();
      this.Loaded += new RoutedEventHandler(ResourceEdit_Loaded);
      dataProvider = this.FindResource("Osoba") as Csla.Wpf.CslaDataProvider;
    }

    public OsobaEdit(int id)
      : this()
    {
      idOsobe = id;
    }

    void ResourceEdit_Loaded(object sender, RoutedEventArgs e)
    {
      using (dataProvider.DeferRefresh())
      {
        dataProvider.FactoryParameters.Clear();
        if (idOsobe == 0)
        {
          dataProvider.FactoryMethod = "New";
        }
        else
        {
          dataProvider.FactoryMethod = "Get";
          dataProvider.FactoryParameters.Add(idOsobe);
        }
      }
      if (dataProvider.Data != null)
        SetEditTitle((Osoba)dataProvider.Data);
      else
        MainForm.ShowControl(null);
    }

    void SetEditTitle(Osoba osoba)
    {
      if (osoba.IsNew)
        this.Title = string.Format("Osoba: {0}", "<novi>");
      else
        this.Title = string.Format("Osoba: {0}", osoba.PunoImeOsobe);
    }

    private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      if (e.Parameter != null)
      {
        ProjektEdit projektEditForm = new ProjektEdit(e.Parameter.ToString());
        MainForm.ShowControl(projektEditForm);
      }
    }

    private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
    { e.CanExecute = true; }


    void Pridruzi(object sender, EventArgs e)
    {
      ProjektSelectDialog dlg = new ProjektSelectDialog();
      if ((bool)dlg.ShowDialog())
      {
        string id = dlg.SifProjekta;
        Osoba resource = (Osoba)dataProvider.Data;
        try
        {
          resource.ProjektiOsobe.DodijeliProjekt(id);
        }
        catch (Exception ex)
        {
          MessageBox.Show(
            ex.Message,
            "Pogreška kod pridruživanja",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
        }
      }
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
