using System;
using Oculus_Test.Properties;
using Oculus_Test.Utils;

namespace Oculus_Test
{
    public class OculusAction
    {
        public IntPtr HGetProcIddll;

        public OculusAction()
        {
            HGetProcIddll = Dll.LoadLibrary("Oculus (DX11).dll");
            if (HGetProcIddll == null)
            {
                Console.WriteLine(Resources.OculusAction_OculusAction_Error_could_not_load_the_dynamic_library);
            }
        }

        public string Show()
        {
            throw new NotImplementedException();
        }
    }
}