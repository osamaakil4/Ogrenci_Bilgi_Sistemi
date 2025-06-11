using System;
    using System.Windows.Forms;
namespace Ogrenci_Bilgi_Sistemi
{
    

    
        internal static class Program
        {
            /// <summary>
            /// Uygulamanın ana giriş noktası.
            /// </summary>
            [STAThread]
            static void Main()
            {
                // Windows Forms ayarları
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Ana formu başlat
                Application.Run(new MainForm());
            }
        }
    
}