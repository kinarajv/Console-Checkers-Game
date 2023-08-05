using CheckersGameLib;

partial class Program
{
    static void DrawBoard(GameRunner gr)
    {
        Console.WriteLine("+----+----+----+----+----+----+----+----+");
        for (int i = 0; i < gr.GetBoardBoundary(); i++)
        {
            for (int j = 0; j < gr.GetBoardBoundary(); j++)
            {
                string aPiece;
                Rank basic = Rank.Basic;
                PieceColor black = PieceColor.Black;
                Piece piece = gr.CheckPiece(i, j);
                if (piece != null)
                {
                    Rank pieceRank = piece.GetRank();
                    PieceColor pieceColor = piece.GetPieceColor();
                    if (pieceRank.Equals(basic))
                    {
                        if (pieceColor.Equals(black))
                        {
                            aPiece = "BB";
                        }
                        else
                        {
                            aPiece = "RB";
                        }
                    }
                    else
                    {
                        if (pieceColor.Equals(black))
                        {
                            aPiece = "BK";
                        }
                        else
                        {
                            aPiece = "RK";
                        }
                    }
                    Console.Write($"| {aPiece} ");
                }
                else
                {
                    Console.Write("|    ");
                }
            }
            Console.WriteLine("|");
            Console.WriteLine("+----+----+----+----+----+----+----+----+");
        }
    }
}
