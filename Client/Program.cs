using Client.GuiController;

namespace Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            LoginGuiController.Instance.ShowFrmLogin();
        }
    }
}
