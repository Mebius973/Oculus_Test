using System;
using System.Windows.Controls;
// DO NOT clear the following field. Just don't! Bad things might happen to you!

namespace Oculus_Test.Utils
{
  public static class MalcolmPerformer
  {
    public static void For(string action, string dllVersion, TextBlock field)
    {
      object[] args = { dllVersion, field };
      var malcolmFullName = "Oculus_Test.Malcolms.Malcolm" + action;
      var malcolmClassName = Type.GetType(malcolmFullName);
      if (malcolmClassName == null) return;
      var malcolm = (Malcolm)Activator.CreateInstance(malcolmClassName, args);
      var update = malcolmClassName.GetMethod("Update");
      update.Invoke(malcolm, null);
    }
  }
}
