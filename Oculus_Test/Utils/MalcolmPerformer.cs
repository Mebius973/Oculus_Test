using System;
using System.Dynamic;
using System.Reflection;
using System.Windows.Controls;
using Oculus_Test.Malcolms;

namespace Oculus_Test.Utils
{
  public static class MalcolmPerformer
  {
    public static void For(string action, string dllVersion, TextBlock field)
    {
      // Voir comment faire ça bien
      object[] args = {dllVersion, field};
      var malcolmFullName = "Oculus_Test.Malcolms.Malcolm" + action;
      var malcolmClassName = Type.GetType(malcolmFullName);
      if (malcolmClassName != null)
      {
        var malcolm = Activator.CreateInstance(malcolmClassName, args);
      }
      //var malcolm = malcolmClassName.InvokeMember("MalcolmEyeHeight", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, args);
      //malcolm.Update();
    }
  }
}
