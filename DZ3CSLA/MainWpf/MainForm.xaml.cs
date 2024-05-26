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

    private UserControl currControl;

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

    public static void ShowControl(UserControl control)
    {
      mainForm.ShowOwnControl(control);
    }

    private void ShowOwnControl(UserControl control)
    {
      UnhookTitleEvent(currControl);

      sadrzaj.Children.Clear();
      if (control != null)
        sadrzaj.Children.Add(control);
      currControl = control;

      HookTitleEvent(currControl);
    }

    private void UnhookTitleEvent(UserControl control)
    {
      EditForm form = control as EditForm;
      if (form != null)
        form.TitleChanged -= new EventHandler(SetTitle);
    }

    private void HookTitleEvent(UserControl control)
    {
      SetTitle(control, EventArgs.Empty);
      EditForm form = control as EditForm;
      if (form != null)
        form.TitleChanged += new EventHandler(SetTitle);
    }


    private void SetTitle(object sender, EventArgs e)
    {
      EditForm form = sender as EditForm;
      if (form != null && !string.IsNullOrEmpty(form.Title))
        mainForm.Title = string.Format("BTV App - {0}", ((EditForm)sender).Title);
      else
        mainForm.Title = string.Format("BTV App");
    }
    #endregion

    #region Menu items
/*
    private void AddWorker(object sender, EventArgs e)
    {
      WorkerEdit workerForm = new WorkerEdit(-1);
      ShowControl(WorkerForm);
    }

    private void EditWorker(object sender, EventArgs e)
    {
      PersonSelectDialog dialog = new PersonSelectDialog();
      dialog.ShowDialog();

      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        WorkerEdit frm = new WorkerEdit(dialog.personId);
        ShowControl(frm);
      }
    }

    private void DeleteWorker(object sender, EventArgs e)
    {
      PersonSelectDialog dialog = new PersonSelectDialog();
      dialog.ShowDialog();

      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        Person.Delete(dialog.personId);
        MessageBox.Show("Personell removed.", "Removing personnel", MessageBoxButton.OK, MessageBoxImage.Information);
      }
    }
*/
    private void EditDepartments(object sender, EventArgs e)
    {
      DepartmentsEdit depForm = new DepartmentsEdit();
      ShowControl(depForm);
    }

    private void Quit(object sender, EventArgs e)
    {
      this.Close();
    }


    #endregion

  }
}
