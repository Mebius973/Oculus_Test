using System.Windows.Controls;

namespace Oculus_Test.Malcolms
{
  public class MalcolmDllVersion : Malcolm
  {
    private readonly OculusAction _oculusAction;

    public MalcolmDllVersion(string dllVersion, string imageMode, TextBlock field)
      : base(dllVersion, imageMode, field)
    {
      _oculusAction = new OculusAction(DllVersion);
    }

    public new void Update()
    {
      if (OculusAction.IsDllLoad())
      {
        Textblock.Text = DllVersion;
      }
    }
  }
}
