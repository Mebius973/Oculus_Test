namespace Oculus_Test.Malcolms
{
  public class MalcolmDllVersion : Malcolm
  {
    private readonly OculusAction _oculusAction;
    public MalcolmDllVersion(string dllVersion, TextBlock field)
    {
      _oculusAction = new OculusAction(_dllVersion);
    }

    public void Update()
    {
      if (_oculusAction.IsDllLoad())
      {
        TextBlock.Text = _dllVersion;
      }
    }
  }
}
