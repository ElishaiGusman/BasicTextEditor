using System;
using System.Windows.Forms;
using BasicTextEditor.BL;

namespace BasicTextEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MessageService service = new MessageService();
            FileManager manager = new FileManager();

            MainPresenter presenter = new MainPresenter(form, service, manager);

            Application.Run(form);
        }
    }
}
