namespace Oculus_Test.Malcolms
{
  public class MalcolmInit : Malcolm
  {
    private readonly Init _init;

    public MalcolmInit(string dllVersion, TextBlock field)
    {
      _init = new Init(dllVersion);
    }

    public void Update()
    {
      TextBlock.Inlines.Add(new Run("\n       "));
      TextBlock.Inlines.Add(new Run(_init.Show()));
    }
  }
}
