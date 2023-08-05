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
                    Piece pieceP3P3 = CheckPiece(oriRow + 3, oriCol + 1);
                    Piece pieceP3P1 = CheckPiece(oriRow + 3, oriCol + 1);
                    Piece pieceP1P3 = CheckPiece(oriRow + 1, oriCol + 3);

                    Piece pieceP1M1 = CheckPiece(oriRow + 1, oriCol - 1);
                    Piece pieceP3M3 = CheckPiece(oriRow + 3, oriCol - 1);
                    Piece pieceP3M1 = CheckPiece(oriRow + 3, oriCol - 1);
                    Piece pieceP1M3 = CheckPiece(oriRow + 1, oriCol - 3);

                    Piece pieceM1P1 = CheckPiece(oriRow - 1, oriCol + 1);
                    Piece pieceM3P3 = CheckPiece(oriRow - 3, oriCol + 1);
                    Piece pieceM3P1 = CheckPiece(oriRow - 3, oriCol + 1);
                    Piece pieceM1P3 = CheckPiece(oriRow - 1, oriCol + 3);

                    Piece pieceM1M1 = CheckPiece(oriRow - 1, oriCol - 1);
                    Piece pieceM3M3 = CheckPiece(oriRow - 3, oriCol - 1);
                    Piece pieceM3M1 = CheckPiece(oriRow - 3, oriCol - 1);
                    Piece pieceM1M3 = CheckPiece(oriRow - 1, oriCol - 3);

                    if (pieceP1P1 != null && desRow - oriRow == 2 && desCol - oriCol == 2)
                    {
                        pieceP1P1.SetIsEaten(true);

                        if (pieceP3P3 != null && desRow - oriRow == 4 && desCol - oriCol == 4)
                        {
                            pieceP3P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceP3P1 != null && desRow - oriRow == 4 && desCol - oriCol == 0)
                        {
                            pieceP3P1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceP1P3 != null && desRow - oriRow == 0 && desCol - oriCol == 4)
                        {
                            pieceP1P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }

                        oriPiece.SetPosition(destination);
                        return true;
                    }
                    else if (pieceP1M1 != null && desRow - oriRow == 2 && desCol - oriCol == -2)
                    {
                        pieceP1M1.SetIsEaten(true);
                        if (pieceP3M3 != null && desRow - oriRow == 4 && desCol - oriCol == -4)
                        {
                            pieceP3M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceP3M1 != null && desRow - oriRow == 4 && desCol - oriCol == 0)
                        {
                            pieceP3M1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceP1M3 != null && desRow - oriRow == 0 && desCol - oriCol == -4)
                        {
                            pieceP1M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }

                        oriPiece.SetPosition(destination);
                        return true;
                    }
                    else if (pieceM1P1 != null && desRow - oriRow == -2 && desCol - oriCol == 2)
                    {
                        pieceM1P1.SetIsEaten(true);
                        if (pieceM3P3 != null && desRow - oriRow == -4 && desCol - oriCol == 4)
                        {
                            pieceM3P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceM3P1 != null && desRow - oriRow == -4 && desCol - oriCol == 0)
                        {
                            pieceM3P1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceM1P3 != null && desRow - oriRow == 0 && desCol - oriCol == 4)
                        {
                            pieceM1P3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }

                        oriPiece.SetPosition(destination);
                        return true;
                    }
                    else if (pieceM1M1 != null && desRow - oriRow == -2 && desCol - oriCol == -2)
                    {
                        pieceM1M1.SetIsEaten(true);
                        if (pieceM3M3 != null && desRow - oriRow == -4 && desCol - oriCol == -4)
                        {
                            pieceM3M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceM3M1 != null && desRow - oriRow == -4 && desCol - oriCol == 0)
                        {
                            pieceM3M1.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }
                        else if (pieceM1M3 != null && desRow - oriRow == 0 && desCol - oriCol == -4)
                        {
                            pieceM1M3.SetIsEaten(true);
                            oriPiece.SetPosition(destination);
                            return true;
                        }

                        oriPiece.SetPosition(destination);
                        return true;
                    }
                    else
                    {
                        oriPiece.SetPosition(destination);
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
