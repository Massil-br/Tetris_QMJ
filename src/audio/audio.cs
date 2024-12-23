using Raylib_cs;

namespace Tetris_QMJ.src.Audio
{
    public class AudioGame
    {
        public static Music musicBackgroundMainMenu1;
        public static Music musicBackgroundMainMenu2;
        public static Music musicStartButton;
        public static Sound soundPieceRotate;
        public static Sound soundPieceMove;
        public static Sound soundButtonMenu;
        public static Sound soundClearLineGrid;
        public static Music musicBackgroundInGame;

        public static void InitAudioGame()
        {
            musicBackgroundMainMenu1 = Raylib.LoadMusicStream("assets/Audio/musicBackgroundMainMenu1.mp3");
            musicBackgroundMainMenu2 = Raylib.LoadMusicStream("assets/Audio/musicBackgroundMainMenu2.mp3");
            musicStartButton = Raylib.LoadMusicStream("assets/Audio/startButton.mp3");
            soundPieceRotate = Raylib.LoadSound("assets/Audio/pieceRotate.wav");
            soundPieceMove = Raylib.LoadSound("assets/Audio/pieceMove.wav");
            soundButtonMenu = Raylib.LoadSound("assets/Audio/buttonMenu.wav");
            soundClearLineGrid = Raylib.LoadSound("assets/Audio/clearLineGrid.wav"); 
        }

        private static bool isMusicPlaying = false;

        public static void PlayMusic(Music music)
        {
            if (!isMusicPlaying)
            {
                Raylib.PlayMusicStream(music);
                Raylib.SetMusicVolume(music, 1.0f);
                isMusicPlaying = true;
            }
            Raylib.UpdateMusicStream(music);
        }

        public static void PlayMusicOnButton(Music music)
        {
            // Arrête la musique actuelle, si nécessaire
            if (Raylib.IsMusicStreamPlaying(music))
            {
                Raylib.StopMusicStream(music);
            }

            // Joue la musique
            Raylib.PlayMusicStream(music);
            Raylib.SetMusicVolume(music, 1.0f);

            // Met à jour le flux audio pour s'assurer qu'il est bien joué
            while (Raylib.IsMusicStreamPlaying(music))
            {
                Raylib.UpdateMusicStream(music);
            }
        }

        public static void SwitchMusic(Music newMusic)
        {
            Raylib.StopMusicStream(musicBackgroundMainMenu1); // Arrête la musique actuelle
            isMusicPlaying = false;
            PlayMusic(newMusic); // Joue la nouvelle musique
        }

        public static void UnloadAudioResources()
        {
            Raylib.UnloadMusicStream(musicBackgroundMainMenu1);
            Raylib.UnloadMusicStream(musicBackgroundMainMenu2);
            Raylib.UnloadMusicStream(musicStartButton);
            Raylib.UnloadSound(soundPieceRotate);
            Raylib.UnloadSound(soundPieceMove);
            Raylib.UnloadSound(soundButtonMenu);
            Raylib.UnloadSound(soundClearLineGrid);
            Raylib.UnloadMusicStream(musicBackgroundInGame);
        }
    }
}