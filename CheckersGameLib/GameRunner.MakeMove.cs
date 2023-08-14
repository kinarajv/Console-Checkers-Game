namespace CheckersGameLib;

public partial class GameRunner
{
    // Make Move    
    /// <summary>
    /// Method for player to move a piece, from its origin position to possible and desired destination
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="destination"></param>
    /// <returns>True if move a piece success, otherwise false</returns>
    public bool MakeMove(Position origin, Position destination)
    {
        int oriRow = origin.GetRow();
        int oriCol = origin.GetColumn();
        int desRow = destination.GetRow();
        int desCol = destination.GetColumn();
        ICheckersPiece oriPiece = CheckPiece(oriRow, oriCol);
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
                    ICheckersPiece pieceP1P1 = CheckPiece(oriRow + 1, oriCol + 1);
                    ICheckersPiece pieceP3P3 = CheckPiece(oriRow + 3, oriCol + 3);
                    ICheckersPiece pieceP3P1 = CheckPiece(oriRow + 3, oriCol + 1);
                    ICheckersPiece pieceP1P3 = CheckPiece(oriRow + 1, oriCol + 3);

                    ICheckersPiece pieceP1M1 = CheckPiece(oriRow + 1, oriCol - 1);
                    ICheckersPiece pieceP3M3 = CheckPiece(oriRow + 3, oriCol - 3);
                    ICheckersPiece pieceP3M1 = CheckPiece(oriRow + 3, oriCol - 1);
                    ICheckersPiece pieceP1M3 = CheckPiece(oriRow + 1, oriCol - 3);

                    ICheckersPiece pieceM1P1 = CheckPiece(oriRow - 1, oriCol + 1);
                    ICheckersPiece pieceM3P3 = CheckPiece(oriRow - 3, oriCol + 3);
                    ICheckersPiece pieceM3P1 = CheckPiece(oriRow - 3, oriCol + 1);
                    ICheckersPiece pieceM1P3 = CheckPiece(oriRow - 1, oriCol + 3);

                    ICheckersPiece pieceM1M1 = CheckPiece(oriRow - 1, oriCol - 1);
                    ICheckersPiece pieceM3M3 = CheckPiece(oriRow - 3, oriCol - 3);
                    ICheckersPiece pieceM3M1 = CheckPiece(oriRow - 3, oriCol - 1);
                    ICheckersPiece pieceM1M3 = CheckPiece(oriRow - 1, oriCol - 3);

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