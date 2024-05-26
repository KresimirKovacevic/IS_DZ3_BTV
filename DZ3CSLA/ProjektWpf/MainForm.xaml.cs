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
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class MainForm : Window
  {


    #region Izbornik i prikaz kontrola

    private static MainForm mainForm;

    private UserControl trenutnaKontrola;

    public MainForm()
    {

      InitializeComponent();
      mainForm = this;
      this.Loaded += new RoutedEventHandler(MainForm_Loaded);
    }

    private void MainForm_Loaded(object sender, RoutedEventArgs e)
    {
      this.Title = "Upravljanje projektima";
    }

    public static void PrikaziKontrolu(UserControl kontrola)
    {
      mainForm.PrikaziVlastituKontrolu(kontrola);
    }

    private void PrikaziVlastituKontrolu(UserControl kontrola)
    {
      UnhookTitleEvent(trenutnaKontrola);

      sadrzaj.Children.Clear();
      if (kontrola != null)
        sadrzaj.Children.Add(kontrola);
      trenutnaKontrola = kontrola;

      HookTitleEvent(trenutnaKontrola);
    }

    private void UnhookTitleEvent(UserControl kontrola)
    {
      EditForm form = kontrola as EditForm;
      if (form != null)
        form.TitleChanged -= new EventHandler(SetTitle);
    }

    private void HookTitleEvent(UserControl kontrola)
    {
      SetTitle(kontrola, EventArgs.Empty);
      EditForm form = kontrola as EditForm;
      if (form != null)
        form.TitleChanged += new EventHandler(SetTitle);
    }


    // forma se pretplati na "doradu" naslova, koja nadoda "Upravljanje projektima"
    private void SetTitle(object sender, EventArgs e)
    {
      EditForm form = sender as EditForm;
      if (form != null && !string.IsNullOrEmpty(form.Title))
        mainForm.Title = string.Format("Upravljanje projektima - {0}", ((EditForm)sender).Title);
      else
        mainForm.Title = string.Format("Upravljanje projektima");
    }

    #endregion

    #region Menu items

    private void DodajProjekt(object sender, EventArgs e)
    {
      ProjektEdit projektForm = new ProjektEdit(string.Empty);
      PrikaziKontrolu(projektForm);
    }

    private void AzurirajProjekt(object sender, EventArgs e)
    {
      ProjektSelectDialog dialog = new ProjektSelectDialog();
      dialog.ShowDialog();

      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        ProjektEdit frm = new ProjektEdit(dialog.SifProjekta);
        PrikaziKontrolu(frm);
      }
    }

    private void ObrisiProjekt(object sender, EventArgs e)
    {
      ProjektSelectDialog dialog = new ProjektSelectDialog();
      dialog.ShowDialog();

      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        Projekt.Delete(dialog.SifProjekta);
        MessageBox.Show("Projekt obrisan.", "Brisanje projekta", MessageBoxButton.OK, MessageBoxImage.Information);
      }
    }

    private void DodajOsobu(object sender, EventArgs e)
    {
      OsobaEdit frm = new OsobaEdit(0);
      PrikaziKontrolu(frm);
    }

    private void AzurirajOsobu(object sender, EventArgs e)
    {
      OsobaSelectDialog dialog = new OsobaSelectDialog();
      dialog.ShowDialog();

      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        OsobaEdit frm = new OsobaEdit(dialog.IdOsobe);
        PrikaziKontrolu(frm);
      }

    }

    private void ObrisiOsobu(object sender, EventArgs e)
    {
      OsobaSelectDialog dialog = new OsobaSelectDialog();
      dialog.ShowDialog();

      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        Osoba.Delete(dialog.IdOsobe);
        MessageBox.Show("Osoba obrisana.", "Brisanje osobe", MessageBoxButton.OK, MessageBoxImage.Information);
      }
    }

    private void UrediUloge(object sender, EventArgs e)
    {
      UlogeEdit projektForm = new UlogeEdit();
      PrikaziKontrolu(projektForm);
    }

    private void Izlaz(object sender, EventArgs e)
    {
      this.Close();
    }


    #endregion

  }
}
