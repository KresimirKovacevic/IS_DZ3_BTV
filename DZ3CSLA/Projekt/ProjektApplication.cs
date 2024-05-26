using System.Windows.Forms;

namespace UpravljanjeProjektima
{
  public static class ProjektApplication
  {
    public static MainForm MainForm { get; private set; }

    public static void Run()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      MainForm = new MainForm();
      
      Application.Run(MainForm);
    }
  }
}
