using System.Windows.Controls;

namespace Oculus_Test.Malcolms
{
  public class MalcolmDllVersion : Malcolm
  {
    private readonly OculusAction _oculusAction;

    public MalcolmDllVersion(string dllVersion, TextBlock field)
    {
      _oculusAction = new OculusAction(DllVersion);
    }

    public new void Update()
    {
      if (_oculusAction.IsDllLoad())
      {
        Textblock.Text = DllVersion;
      }
    }
  }
}
