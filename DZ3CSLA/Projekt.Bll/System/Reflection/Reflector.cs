using System.Linq.Expressions;

namespace System.Reflection
{
  public static class Reflector
  {
    public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
    {
      return GetProperty<T>(expression).Name;
    }

    public static MethodInfo GetStaticMethod(Expression<Action> expression)
    {
      var methodCall = expression.Body as MethodCallExpression;
      if (methodCall == null)
      {
        throw new ArgumentException(UpravljanjeProjektima.Properties.Resources.MethodCallExpected);
      }
      return methodCall.Method;
    }

    public static MethodInfo GetMethod<T>(Expression<Action<T>> expression)
    {
      var methodCall = expression.Body as MethodCallExpression;
      if (methodCall == null)
      {
        throw new ArgumentException(UpravljanjeProjektima.Properties.Resources.MethodCallExpected);
      }
      return methodCall.Method;
    }

    public static PropertyInfo GetProperty<T>(Expression<Func<T, object>> expression)
    {
      MemberExpression memberExpression;

      var unary = expression.Body as UnaryExpression;
      if (unary != null)
      {
        memberExpression = unary.Operand as MemberExpression;
      }
      else
      {
        memberExpression = expression.Body as MemberExpression;
      }

      if (memberExpression == null || !(memberExpression.Member is PropertyInfo))
      {
        throw new ArgumentException(UpravljanjeProjektima.Properties.Resources.PropertyExpected);
      }
      return (PropertyInfo)memberExpression.Member;
    }
  }
}
