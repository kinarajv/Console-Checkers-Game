namespace CheckersGameLib;

public partial class GameRunner
{
    // Make Move    
    public bool MakeMove(Position origin, Position destination)
    {
        int oriRow = origin.GetRow();
        int oriCol = origin.GetColumn();
        int desRow = destination.GetRow();
        int desCol = destination.GetColumn();
        Piece oriPiece = CheckPiece(oriRow, oriCol);
        PieceColor currColor = _isPlayerTurn ? PieceColor.Black : PieceColor.Red;

        List<Position> possibleMove = GetPossibleMove(oriPiece);

        foreach (Position position in possibleMove)
        {
            int row = position.GetRow();
            int col = position.GetColumn();
            if (desRow == row && desCol == col)
            {
                if (oriPiece.GetPieceColor().Equals(currColor))
                {
                    Piece pieceP1P1 = CheckPiece(oriRow + 1, oriCol + 1);
                    Piece pieceP3P3 = CheckPiece(oriRow + 3, oriCol + 3);
                    Piece pieceP3P1 = CheckPiece(oriRow + 3, oriCol + 1);
                    Piece pieceP1P3 = CheckPiece(oriRow + 1, oriCol + 3);

                    Piece pieceP1M1 = CheckPiece(oriRow + 1, oriCol - 1);
                    Piece pieceP3M3 = CheckPiece(oriRow + 3, oriCol - 3);
                    Piece pieceP3M1 = CheckPiece(oriRow + 3, oriCol - 1);
                    Piece pieceP1M3 = CheckPiece(oriRow + 1, oriCol - 3);

                    Piece pieceM1P1 = CheckPiece(oriRow - 1, oriCol + 1);
                    Piece pieceM3P3 = CheckPiece(oriRow - 3, oriCol + 3);
                    Piece pieceM3P1 = CheckPiece(oriRow - 3, oriCol + 1);
                    Piece pieceM1P3 = CheckPiece(oriRow - 1, oriCol + 3);

                    Piece pieceM1M1 = CheckPiece(oriRow - 1, oriCol - 1);
                    Piece pieceM3M3 = CheckPiece(oriRow - 3, oriCol - 3);
                    Piece pieceM3M1 = CheckPiece(oriRow - 3, oriCol - 1);
                    Piece pieceM1M3 = CheckPiece(oriRow - 1, oriCol - 3);

                    // 3,2 => (4,1) => 5,0 => (6,1) => 7,2

                    if (pieceP3P3 != null && desRow - oriRow == 4 && desCol - oriCol == 4)
                    {
                        if (pieceP1P1 != null)
                        {
                            pieceP1P1.SetIsEaten(true);
                            pieceP3P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceP3P1 != null && desRow - oriRow == 4 && desCol - oriCol == 0)
                    {
                        if (pieceP1P1 != null)
                        {
                            pieceP1P1.SetIsEaten(true);
                            pieceP3P1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceP1P3 != null && desRow - oriRow == 0 && desCol - oriCol == 4)
                    {
                        if (pieceP1P1 != null)
                        {
                            pieceP1P1.SetIsEaten(true);
                            pieceP1P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }

                    if (pieceP3M3 != null && desRow - oriRow == 4 && desCol - oriCol == -4)
                    {
                        if (pieceP1M1 != null)
                        {
                            pieceP1M1.SetIsEaten(true);
                            pieceP3M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceP3M1 != null && desRow - oriRow == 4 && desCol - oriCol == 0)
                    {
                        if (pieceP1M1 != null)
                        {
                            pieceP1M1.SetIsEaten(true);
                            pieceP3M1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceP1M3 != null && desRow - oriRow == 0 && desCol - oriCol == -4)
                    {
                        if (pieceP1M1 != null)
                        {
                            pieceP1M1.SetIsEaten(true);
                            pieceP1M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }

                    if (pieceM3P3 != null && desRow - oriRow == -4 && desCol - oriCol == 4)
                    {
                        if (pieceM1P1 != null)
                        {
                            pieceM1P1.SetIsEaten(true);
                            pieceM3P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceM3P1 != null && desRow - oriRow == -4 && desCol - oriCol == 0)
                    {
                        if (pieceM1P1 != null)
                        {
                            pieceM1P1.SetIsEaten(true);
                            pieceM3P1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceM1P3 != null && desRow - oriRow == 0 && desCol - oriCol == 4)
                    {
                        if (pieceM1P1 != null)
                        {
                            pieceM1P1.SetIsEaten(true);
                            pieceM1P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }

                    if (pieceM3M3 != null && desRow - oriRow == -4 && desCol - oriCol == -4)
                    {
                        if (pieceM1M1 != null)
                        {
                            pieceM1M1.SetIsEaten(true);
                            pieceM3M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceM3M1 != null && desRow - oriRow == -4 && desCol - oriCol == 0)
                    {
                        if (pieceM1M1 != null)
                        {
                            pieceM1M1.SetIsEaten(true);
                            pieceM3M1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }
                    if (pieceM1M3 != null && desRow - oriRow == 0 && desCol - oriCol == -4)
                    {
                        if (pieceM1M1 != null)
                        {
                            pieceM1M1.SetIsEaten(true);
                            pieceM1M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            PiecePromotion(oriPiece);
                            return true;
                        }
                    }

                    if (pieceP1P1 != null && desRow - oriRow == 2 && desCol - oriCol == 2)
                    {
                        pieceP1P1.SetIsEaten(true);
                        oriPiece.SetPosition(destination);
                        PiecePromotion(oriPiece);
                        return true;
                    }
                    if (pieceP1M1 != null && desRow - oriRow == 2 && desCol - oriCol == -2)
                    {
                        pieceP1M1.SetIsEaten(true);
                        oriPiece.SetPosition(destination);
                        PiecePromotion(oriPiece);
                        return true;
                    }
                    if (pieceM1P1 != null && desRow - oriRow == -2 && desCol - oriCol == 2)
                    {
                        pieceM1P1.SetIsEaten(true);
                        oriPiece.SetPosition(destination);
                        PiecePromotion(oriPiece);
                        return true;
                    }
                    if (pieceM1M1 != null && desRow - oriRow == -2 && desCol - oriCol == -2)
                    {
                        pieceM1M1.SetIsEaten(true);
                        oriPiece.SetPosition(destination);
                        PiecePromotion(oriPiece);
                        return true;
                    }

                    oriPiece.SetPosition(destination);
                    PiecePromotion(oriPiece);
                    return true;
                }
            }
        }
        return false;
    }
}