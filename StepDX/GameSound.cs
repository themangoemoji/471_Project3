using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;


namespace StepDX
{
    class GameSounds
    {
        private Device SoundDevice = null;

        private SecondaryBuffer collision = null;
        private SecondaryBuffer gameover = null;
        private SecondaryBuffer bgm = null;

        public GameSounds(Form form)
        {
            SoundDevice = new Device();
            SoundDevice.SetCooperativeLevel(form, CooperativeLevel.Priority);

            Load(ref collision, "../../Collision.wav");
            Load(ref gameover, "../../GameOver.wav");
            Load(ref bgm, "../../BGM.wav");
        }

        private void Load(ref SecondaryBuffer buffer, string filename)
        {
            try
            {
                buffer = new SecondaryBuffer(filename, SoundDevice);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load " + filename,
                                "Danger, Will Robinson", MessageBoxButtons.OK);
                buffer = null;
            }
        }

        public void BGM()
        {
            if (bgm == null)
                return;
            if (!bgm.Status.Playing)
                bgm.Play(0, BufferPlayFlags.Looping);
        }

        public void BGMEnd()
        {
            if (bgm == null)
                return;
            if (bgm.Status.Playing)
                bgm.Stop();
        }



        public void Collision()
        {
            if (collision == null)
                return;

            if (!collision.Status.Playing)
            {
                collision.SetCurrentPosition(0);
                collision.Play(0, BufferPlayFlags.Default);
            }
        }

        public void CollisionEnd()
        {
            if (collision == null)
                return;

            if (collision.Status.Playing)
                collision.Stop();
        }


        public void GameOver()
        {
            if (gameover == null)
                return;

            if (!gameover.Status.Playing)
            {
                gameover.SetCurrentPosition(0);
                gameover.Play(0, BufferPlayFlags.Default);
            }
        }

        
        public void GameOverEnd()
        {
            if (gameover == null)
                return;

            if (gameover.Status.Playing)
                gameover.Stop();
        }
        

    }
}