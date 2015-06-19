namespace Oculus_Test.Malcolms
{
  public class MalcolmRelease : Malcolm
  {
    private readonly Release _release;
    public MalcolmRelease(string dllVersion, TextBlock field)
    {
      _release = new Release(dllVersion);
    }

    public void Update()
    {
      // This technique of display will be a problem when we ask the size several time in a row
      TextBlock.Inlines.Add(new Run("\n       "));
      TextBlock.Inlines.Add(new Run(_release.Show()));
    }
  }
}
