using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpravljanjeProjektima.Dal
{
  // po uzoru na CSLA.ContextManger - komentirano na kraju datoteke
  public class ContextManager<C> : IDisposable where C : System.Data.Entity.DbContext
  {
    private C dalContext;
    private string connectionString;
    private static ContextManager<C> dalContextManager;

    private ContextManager(string ConnectionString) // stvara se u GetManager 
    {
      connectionString = ConnectionString;
    }

    public C DataContext 
    {
      get
      {
        if (dalContext == null)
        {
          dalContext = (C)Activator.CreateInstance(typeof(C), connectionString);
          //dalContext = (C)Activator.CreateInstance(typeof(C));
        }
        return dalContext;
      }
    }

    // stvara ContextManager koji će stvoriti kontekst na temelju connStringa
    public static ContextManager<C> GetManager(string ConnectionString)
    {
      if (dalContextManager == null)
      {
        dalContextManager = new ContextManager<C>(ConnectionString);
      }
      return dalContextManager;
    }

    #region IDisposable Members

    public void Dispose()
    {
      if (dalContext != null)
      {
        dalContext.Dispose();
        dalContext = null;
      }
  
    }
    #endregion
  }
}

//namespace Csla.Data
//{
//  // Summary:
//  //     Provides an automated way to reuse LINQ data context objects within the context
//  //     of a single data portal operation.
//  //
//  // Type parameters:
//  //   C:
//  //     Type of database LINQ data context objects object to use.
//  //
//  // Remarks:
//  //     This type stores the LINQ data context object in Csla.ApplicationContext.LocalContext
//  //     and uses reference counting through System.IDisposable to keep the data context
//  //     object open for reuse by child objects, and to automatically dispose the
//  //     object when the last consumer has called Dispose."
//  public class ContextManager<C> : IDisposable where C : global::System.Data.Linq.DataContext
//  {
//    // Summary:
//    //     Gets the LINQ data context object.
//    public C DataContext { get; }

//    // Summary:
//    //     Dispose object, dereferencing or disposing the context it is managing.
//    public void Dispose();
//    //
//    // Summary:
//    //     Gets the ContextManager object for the specified database.
//    //
//    // Parameters:
//    //   database:
//    //     Database name as shown in the config file.
//    public static ContextManager<C> GetManager(string database);
//    //
//    // Summary:
//    //     Gets the ContextManager object for the specified database.
//    //
//    // Parameters:
//    //   database:
//    //     The database name or connection string.
//    //
//    //   isDatabaseName:
//    //     True to indicate that the connection string should be retrieved from the
//    //     config file. If False, the database parameter is directly used as a connection
//    //     string.
//    //
//    // Returns:
//    //     ContextManager object for the name.
//    public static ContextManager<C> GetManager(string database, bool isDatabaseName);
//  }
//}