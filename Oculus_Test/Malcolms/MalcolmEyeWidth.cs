namespace Oculus_Test.Malcolms
{
  public class MalcolmEyeWidth : Malcolm
  {
    private readonly EyeHeight _eyeHeight;
    public MalcolmEyeHeight(string dllVersion, TextBlock field)
    {
      _eyeHeight = new EyeHeight(dllVersion);
    }

    public void Update()
    {
      TextBlock.Inlines.Add(new Run("\n       "));
      TextBlock.Inlines.Add(new Run(_eyeHeight.Show()));
    }
  }
}
