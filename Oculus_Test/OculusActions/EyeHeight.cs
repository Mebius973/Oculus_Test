using System;
using System.Runtime.InteropServices;
using Oculus_Test.Utils;

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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int GetImageHeight();
        private void Ask()
        {
            var eyeHeight = Dll.GetProcAddress(HGetProcIddll, "getImageHeight");
            var getImageHeight = (GetImageHeight)Marshal.GetDelegateForFunctionPointer(eyeHeight, typeof(GetImageHeight));
            _height = getImageHeight();
        }
    }
}