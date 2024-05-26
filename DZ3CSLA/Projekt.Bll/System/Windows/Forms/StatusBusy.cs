namespace System.Windows.Forms
{
  public class StatusBusy : IDisposable
  {
    #region Fields
    private Cursor oldCursor;
    #endregion

    #region Constructors
    public StatusBusy()
      : this(Cursors.WaitCursor)
    {
    }

    public StatusBusy(Cursor cursor)
    {
      oldCursor = Cursor.Current;
      Cursor.Current = cursor;
    }
    #endregion

    #region IDisposable Members
    public void Dispose()
    {
      Cursor.Current = oldCursor;
    }
    #endregion
  }
}
