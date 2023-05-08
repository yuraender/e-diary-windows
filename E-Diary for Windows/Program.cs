using E_Diary_for_Windows.Forms;
using E_Diary_for_Windows.Forms.Authorization;
using E_Diary_for_Windows.Properties;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace E_Diary_for_Windows {
    public static class Program {

        [STAThread]
        public static void Main() {
            using (Mutex mutex = new Mutex(false, "Global\\" + Assembly
                .GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value)) {
                if (!mutex.WaitOne(0, false)) {
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                string token = (string) Settings.Default["Token"];
                EDiaryAPI api = new EDiaryAPI(token);
                if (api.Authenticator != null) {
                    Application.Run(new MainForm(true));
                } else {
                    Application.Run(new LoginForm());
                }
            }
        }
    }
}
