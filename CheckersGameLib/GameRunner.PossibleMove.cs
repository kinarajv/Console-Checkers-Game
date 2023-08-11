namespace CheckersGameLib;

public partial class GameRunner
{
    public List<Position> GetPossibleMove(ICheckersPiece piece)
    {
        int initRow = piece.GetPosition().GetRow();
        int initCol = piece.GetPosition().GetColumn();

        List<Position> positions = new List<Position>();

        foreach (var position in _moveset.SingleMove(piece))
        {
            int row = position.GetRow();
            int col = position.GetColumn();
            ICheckersPiece p = CheckPiece(row, col);
            if (p == null)
            {
                if (row >= 0 && row < GetBoardBoundary() && col >= 0 && col < GetBoardBoundary())
                {
                    positions.Add(position);
                }
            }
        }

        foreach (var position in _moveset.SingleJumpMove(piece))
        {
            int row = position.GetRow();
            int col = position.GetColumn();

            if (!IsBlocked(initRow, initCol, row, col))
            {
                if (IsEnemyBefore(initRow, initCol, row, col))
                {
                    if (row >= 0 && row < GetBoardBoundary() && col >= 0 && col < GetBoardBoundary())
                    {
                        positions.Add(position);
                    }
                }
            }
        }

        foreach (var position in _moveset.DoubleJumpMove(piece))
        {
            int row = position.GetRow();
            int col = position.GetColumn();

            if (!IsBlocked(initRow, initCol, row, col))
            {
                if (IsEnemyBefore(initRow, initCol, row, col))
                {
                    if (row >= 0 && row < GetBoardBoundary() && col >= 0 && col < GetBoardBoundary())
                    {
                        positions.Add(position);
                    }
                }
            }
        }

        if (positions.Count > 0)
        {
            return positions;
        }
        return null;
    }

    private bool IsBlocked(int initRow, int initCol, int targetRow, int targetCol)
    {
        int rowDiff = targetRow - initRow;
        int colDiff = targetCol - initCol;

        int rowInc = rowDiff > 0 ? 1 : -1;
        int colInc = colDiff > 0 ? 1 : -1;

        int currRow = initRow + rowInc; // 7 => 6
        int currCol = initCol + colInc; // 6 => 6

        if (Math.Abs(rowDiff) == 4 && colDiff == 0)
        {
            currCol = initCol + 1; // 6 => 7
            while (currRow != initRow + (3 * rowInc) && currCol != initCol + 3)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow += rowInc; // 5, 4
                currCol++; // 8, 9
            }
            currRow -= rowInc; // 5
            currCol--; // 8
            while (currRow != targetRow + rowInc && currCol != initCol - 1)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow += rowInc; // 4, 3, 2
                currCol--; // 7, 6, 5
            }
            currRow = initRow + rowInc; // 7
            while (currRow != initRow + (3 * rowInc) && currCol != initCol - 3)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow += rowInc; // 5, 6
                currCol--; // 2, 1
            }
            currRow -= rowInc;
            currCol++;
            while (currRow != targetRow + rowInc && currCol != initCol + 1)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow += rowInc; // 6, 7, 8
                currCol++; // 3, 4, 5
            }
        }
        else if (rowDiff == 0 && Math.Abs(colDiff) == 4)
        {
            currRow = initRow + 1;
            while (currRow != initRow + 3 && currCol != initCol + (3 * colInc))
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow++;
                currCol += colInc;
            }
            currRow--;
            currCol -= colInc;
            while (currRow != initRow - 1 && currCol != targetCol + colInc)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow--;
                currCol += colInc;
            }
            currCol = initCol + colInc;
            while (currRow != initRow - 3 && currCol != initCol + (3 * colInc))
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow--;
                currCol += colInc;
            }
            currRow++;
            currCol -= colInc;
            while (currRow != initRow + 1 && currCol != targetCol + colInc)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow++;
                currCol += colInc;
            }
        }
        else
        {
            while (currRow != targetRow + rowInc && currCol != targetCol + colInc)
            {
                IPiece initPiece = CheckPiece(initRow, initCol);
                IPiece pathPiece = CheckPiece(currRow, currCol);
                if (pathPiece != null)
                {
                    if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                    {
                        return true;
                    }
                }
                currRow += rowInc;
                currCol += colInc;
            }
        }
        return false;
    }

    private bool IsEnemyBefore(int row, int col, int targetRow, int targetCol)
    {
        int rowDiff = targetRow - row;
        int colDiff = targetCol - col;

        int rowInc = rowDiff > 0 ? 1 : -1;
        int colInc = colDiff > 0 ? 1 : -1;

        int newestRow = row + rowInc;
        int newestCol = col + colInc;
        IPiece p = CheckPiece(row, col);

        if (Math.Abs(rowDiff) == 2 && Math.Abs(colDiff) == 2)
        {
            IPiece pFirstJump = CheckPiece(newestRow, newestCol);
            if (pFirstJump != null && !pFirstJump.GetPieceColor().Equals(p.GetPieceColor()))
            {
                newestRow += rowInc;
                newestCol += colInc;
                if (CheckPiece(newestRow, newestCol) == null)
                {
                    return true;
                }
            }
        }
        else if (Math.Abs(rowDiff) == 4 && Math.Abs(colDiff) == 4)
        {
            IPiece pFirstJump = CheckPiece(newestRow, newestCol);
            if (pFirstJump != null && !pFirstJump.GetPieceColor().Equals(p.GetPieceColor()))
            {
                newestRow += rowInc;
                newestCol += colInc;
                if (CheckPiece(newestRow, newestCol) == null)
                {
                    newestRow += rowInc;
                    newestCol += colInc;
                    IPiece pSecondJump = CheckPiece(newestRow, newestCol);
                    if (pSecondJump != null && !pSecondJump.GetPieceColor().Equals(p.GetPieceColor()))
                    {
                        newestRow += rowInc;
                        newestCol += colInc;
                        if (CheckPiece(newestRow, newestCol) == null)
                        {
                            return true;
                        }
                    }

                }
            }
        }
        else if (Math.Abs(rowDiff) == 4 && colDiff == 0)
        {
            int newestColP = col + 1;
            int newestColM = col - 1;
            IPiece pFirstPJump = CheckPiece(newestRow, newestColP);
            if (pFirstPJump != null && !pFirstPJump.GetPieceColor().Equals(p.GetPieceColor()))
            {
                newestRow += rowInc;
                newestColP++;
                if (CheckPiece(newestRow, newestColP) == null)
                {
                    newestRow += rowInc;
                    newestColP--;
                    IPiece pSecondJump = CheckPiece(newestRow, newestColP);
                    if (pSecondJump != null && !pSecondJump.GetPieceColor().Equals(p.GetPieceColor()))
                    {
                        newestRow += rowInc;
                        newestColP--;
                        if (CheckPiece(newestRow, newestColP) == null)
                        {
                            return true;
                        }
                    }
                }
            }

            IPiece pFirstMJump = CheckPiece(newestRow, newestColM);
            if (pFirstMJump != null && !pFirstMJump.GetPieceColor().Equals(p.GetPieceColor()))
            {
                newestRow += rowInc;
                newestColM--;
                if (CheckPiece(newestRow, newestColM) == null)
                {
                    newestRow += rowInc;
                    newestColM++;
                    IPiece pSecondJump = CheckPiece(newestRow, newestColM);
                    if (pSecondJump != null && !pSecondJump.GetPieceColor().Equals(p.GetPieceColor()))
                    {
                        newestRow += rowInc;
                        newestColM++;
                        if (CheckPiece(newestRow, newestColM) == null)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        else if (rowDiff == 0 && Math.Abs(colDiff) == 4)
        {
            int newestRowP = row + 1;
            int newestRowM = row - 1;

            IPiece pFirstPJump = CheckPiece(newestRowP, newestCol);
            if (pFirstPJump != null && !pFirstPJump.GetPieceColor().Equals(p.GetPieceColor()))
            {
                newestRowP++;
                newestCol += colInc;
                if (CheckPiece(newestRowP, newestCol) == null)
                {
                    newestRowP--;
                    newestCol += colInc;
                    IPiece pSecondJump = CheckPiece(newestRowP, newestCol);
                    if (pSecondJump != null && !pSecondJump.GetPieceColor().Equals(p.GetPieceColor()))
                    {
                        newestRowP--;
                        newestCol += colInc;
                        if (CheckPiece(newestRowP, newestCol) == null)
                        {
                            return true;
                        }
                    }
                }
            }

            IPiece pFirstMJump = CheckPiece(newestRowM, newestCol);
            if (pFirstMJump != null && !pFirstMJump.GetPieceColor().Equals(p.GetPieceColor()))
            {
                newestRowM--;
                newestCol += colInc;
                if (CheckPiece(newestRowM, newestCol) == null)
                {
                    newestRowM++;
                    newestCol += colInc;
                    IPiece pSecondJump = CheckPiece(newestRowM, newestCol);
                    if (pSecondJump != null && !pSecondJump.GetPieceColor().Equals(p.GetPieceColor()))
                    {
                        newestRowM++;
                        newestCol += colInc;
                        if (CheckPiece(newestRowM, newestCol) == null)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}