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

        private SecondaryBuffer[] clank = new SecondaryBuffer[10];
        int clankToUse = 0;

        private SecondaryBuffer nah = null;
        private SecondaryBuffer gameover = null;

        public GameSounds(Form form)
        {
            SoundDevice = new Device();
            SoundDevice.SetCooperativeLevel(form, CooperativeLevel.Priority);

            Load(ref nah, "../../Nah1.wav");
            Load(ref gameover, "../../GameOver.wav");
            //Load(ref arms, "../../arms.wav");

            /*
            for (int i = 0; i < clank.Length; i++)
                Load(ref clank[i], "../../clank.wav");
            */
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

        public void Clank()
        {
            clankToUse = (clankToUse + 1) % clank.Length;

            if (clank[clankToUse] == null)
                return;

            if (!clank[clankToUse].Status.Playing)
                clank[clankToUse].Play(0, BufferPlayFlags.Default);
        }

        public void Nah()
        {
            if (nah == null)
                return;

            if (!nah.Status.Playing)
                nah.Play(0, BufferPlayFlags.Default);
        }

        public void NahEnd()
        {
            if (nah == null)
                return;

            if (nah.Status.Playing)
                nah.Stop();
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