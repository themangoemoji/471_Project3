using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StepDX
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
            Game game = new Game();
            GameSounds gamesounds = new GameSounds(game);
            game.Show();
            gamesounds.BGM();
            do
            {
                game.Advance();
                game.Render();
                //When player is heading on the polygon
                //Play sound effect
                if (game.PlaySound() == "Polygon")
                {
                    gamesounds.CollisionEnd();
                    gamesounds.Collision();
                }
                //GameOver sound
                else if (game.PlaySound() == "GameOver")
                {
                    gamesounds.BGMEnd();
                    gamesounds.GameOver();
                }
                game.SoundStop();
                Application.DoEvents();
            } while (game.Created);
        }
    }
}
