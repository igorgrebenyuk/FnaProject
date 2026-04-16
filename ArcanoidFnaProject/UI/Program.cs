using FnaProject.UI;

namespace FnaProject
{
    /// <summary>
    /// Точка входа в приложение.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главный метод, запускающий игровой цикл скринсейвера.
        /// </summary>
        static void Main(string[] args)
        {
            using (var game = new SnowFallGame())
            {
                game.Run();
            }
        }
    }
}