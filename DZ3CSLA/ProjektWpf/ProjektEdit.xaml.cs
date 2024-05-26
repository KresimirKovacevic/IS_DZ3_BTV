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
  /// Interaction logic for ProjektEdit.xaml
  /// </summary>
  public partial class ProjektEdit : EditForm
  {

    private string idProjekta;
    private Csla.Wpf.CslaDataProvider dataProvider;

    public ProjektEdit()
    {
      InitializeComponent();
      this.Loaded += new RoutedEventHandler(ProjektEdit_Loaded);
      dataProvider = this.FindResource("Projekt") as Csla.Wpf.CslaDataProvider;
      dataProvider.DataChanged += new EventHandler(DataChanged);
    }

    public ProjektEdit(string id)
      : this()
    {
      idProjekta = id;
    }

    void ProjektEdit_Loaded(object sender, RoutedEventArgs e)
    {
      using (dataProvider.DeferRefresh())
      {
        dataProvider.FactoryParameters.Clear();
        if (idProjekta.Equals(string.Empty))
        {
          dataProvider.FactoryMethod = "New";
        }
        else
        {
          dataProvider.FactoryMethod = "Get";
          dataProvider.FactoryParameters.Add(idProjekta);
        }
      }
      if (dataProvider.Data != null)
        SetEditTitle((Projekt)dataProvider.Data);
      else
        MainForm.PrikaziKontrolu(null);
    }

    void SetEditTitle(Projekt projekt)
    {
      if (projekt.IsNew)
        this.Title = string.Format("Projekt: {0}", "<novi>");
      else
        this.Title = string.Format("Projekt: {0}", projekt.NazProjekta);
    }


    private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      if (e.Parameter != null)
      {
        OsobaEdit osobaEditForm = new OsobaEdit(Convert.ToInt32(e.Parameter));
        MainForm.PrikaziKontrolu(osobaEditForm);
      }
    }

    private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
    { e.CanExecute = true; }

    void Assign(object sender, EventArgs e)
    {
      OsobaSelectDialog dialog = new OsobaSelectDialog();
      if ((bool)dialog.ShowDialog())
      {
        int id = dialog.IdOsobe;
        Projekt projekt = (Projekt)dataProvider.Data;
        try
        {
          projekt.SudioniciProjekta.DodijeliOsobu(id);
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
  }
}
