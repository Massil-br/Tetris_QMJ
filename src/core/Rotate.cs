using System;
using Raylib_cs;
using Tetris_QMJ.src.Audio;

namespace Tetris_QMJ.src.Core {
    public class Rotation {
        private Grid grid;
        private Entities.Piece piece;

        public Rotation(Grid grid)
        {
            this.grid = grid;
        }

        public Rotation (Grid grid, Rotation rotation){
            this.grid = grid;
            
        }

        public void HandleInput() {
            // Vérifie si la barre d'espace est pressée
            if (Raylib.IsKeyPressed(KeyboardKey.Space)) 
            {
                AudioGame.PlaySound(AudioGame.soundPieceRotate);
                RotatePiece();
            }
        }

        public void RotatePiece() {
            piece = grid.GetPiece();

            if (piece != null && piece.IsActive) { 
                grid.RemovePiece(piece); 
                piece.Rotation90();

                if (!grid.AddPiece(piece)) {
                    // Annule la rotation en cas de collision ou de dépassement
                    piece.Rotation90();
                    piece.Rotation90();
                    piece.Rotation90();
                    grid.AddPiece(piece);
                }
            }
        }
    }
}
