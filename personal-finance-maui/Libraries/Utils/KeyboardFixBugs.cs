using System;
using System.Collections.Generic;
using System.Text;

namespace personal_finance_maui.Libraries.Utils
{
    public class KeyboardFixBugs
    {
        public static void HideKeyboard()
        {
#if ANDROID
            if (Platform.CurrentActivity.CurrentFocus != null)
            {
                Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
            }
#endif
        }
    }
}
