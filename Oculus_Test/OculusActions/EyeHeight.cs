namespace Oculus_Test.OculusActions
{
    public class EyeHeight : OculusAction
    {
        private int _height;

        public EyeHeight()
        {
            Ask();
        }

        public new string Show()
        {
            return _height.ToString();
        }

        private void Ask()
        {
            _height = 42;
        }
    }
}