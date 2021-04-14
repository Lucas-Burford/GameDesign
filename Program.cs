using System;

namespace UpdatedEngine2
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Kernel())
                game.Run();
        }
    }
}
