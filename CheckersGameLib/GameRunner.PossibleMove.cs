namespace CheckersGameLib;

public partial class GameRunner
{
    // Get Any available move for a player's piece
    public List<Position> GetPossibleMove(Piece piece)
    {
        int row = piece.GetPosition().GetRow();
        int column = piece.GetPosition().GetColumn();
        PieceColor black = PieceColor.Black;
        Rank basic = Rank.Basic;
        List<Position> posList = new List<Position>();
        if (piece.GetRank().Equals(basic))
        {
            if (piece.GetPieceColor().Equals(black))
            {
                Piece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                Piece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                if (pSingleP1P1 != null)
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black))
                    {
                        Piece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row + 2 < GetBoardBoundary() && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row + 2, column + 2));

                            Piece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null)
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row + 4 < GetBoardBoundary() && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null)
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row + 4 < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleP1M1 != null)
                {
                    if (!pSingleP1M1.GetPieceColor().Equals(black))
                    {
                        Piece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row + 2 < GetBoardBoundary() && column - 2 >= 0)
                        {
                            posList.Add(new Position(row + 2, column - 2));

                            Piece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null)
                            {
                                if (!pDoubleP3M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row + 4 < GetBoardBoundary() && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                            if (pDoubleP3M1 != null)
                            {
                                if (!pDoubleP3M1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row + 4 < GetBoardBoundary() && column >= 0)
                                    {
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleP1P1 == null)
                {
                    if (row + 1 < GetBoardBoundary() && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                }
                if (pSingleP1M1 == null)
                {
                    if (row + 1 < GetBoardBoundary() && column - 1 >= 0)
                    {
                        posList.Add(new Position(row + 1, column - 1));
                    }
                }
            }
            else
            {
                Piece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                Piece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleM1P1 != null)
                {
                    if (pSingleM1P1.GetPieceColor().Equals(black))
                    {
                        Piece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row - 2 >= 0 && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row - 2, column + 2));

                            Piece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null)
                            {
                                if (pDoubleM3P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row - 4 >= 0 && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null)
                            {
                                if (pDoubleM3P1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row - 4 >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleM1M1 != null)
                {
                    if (pSingleM1M1.GetPieceColor().Equals(black))
                    {
                        Piece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row - 2 >= 0 && column - 2 >= 0)
                        {
                            posList.Add(new Position(row - 2, column - 2));

                            Piece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null)
                            {
                                if (pDoubleM3M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row - 4 >= 0 && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null)
                            {
                                if (pDoubleM3M1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row + 4 < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleM1P1 == null)
                {
                    if (row - 1 >= 0 && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row - 1, column + 1));
                    }
                }
                if (pSingleM1M1 == null)
                {
                    if (row - 1 >= 0 && column - 1 >= 0)
                    {
                        posList.Add(new Position(row - 1, column - 1));
                    }
                }
            }
        }
        else
        {
            if (piece.GetPieceColor().Equals(black))
            {
                Piece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                Piece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                Piece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                Piece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleP1P1 != null)
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black))
                    {
                        Piece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row + 2 < GetBoardBoundary() && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row + 2, column + 2));

                            Piece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row + 4 < GetBoardBoundary() && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null)
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleP1P3 = CheckPiece(row + 1, column + 3);
                            if (pDoubleP1P3 != null)
                            {
                                if (!pDoubleP1P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 0, column + 4));
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleP1M1 != null)
                {
                    if (!pSingleP1M1.GetPieceColor().Equals(black))
                    {
                        Piece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row < GetBoardBoundary() && column >= 0)
                        {
                            posList.Add(new Position(row + 2, column - 2));

                            Piece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null)
                                if (!pDoubleP3M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row < GetBoardBoundary() && column >= 0)
                                    {
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                        }

                        Piece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                        if (pDoubleP3M1 != null)
                        {
                            if (!pDoubleP3M1.GetPieceColor().Equals(black))
                            {
                                Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary())
                                {
                                    if (!posList.Contains(new Position(row + 4, column + 0)))
                                    {
                                        posList.Add(new Position(row + 4, column + 0));
                                    }
                                }

                            }
                        }

                        Piece pDoubleP1M3 = CheckPiece(row + 1, column - 3);
                        if (pDoubleP1M3 != null)
                        {
                            if (!pDoubleP1M3.GetPieceColor().Equals(black))
                            {
                                Piece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                if (pEatP0M4 == null && row < GetBoardBoundary() && column >= 0)
                                {
                                    posList.Add(new Position(row + 0, column - 4));
                                }

                            }
                        }
                    }
                }

                if (pSingleM1P1 != null)
                {
                    if (!pSingleM1P1.GetPieceColor().Equals(black))
                    {
                        Piece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row >= 0 && column < GetBoardBoundary())
                        {
                            posList.Add(new Position(row - 2, column + 2));

                            Piece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null)
                            {
                                if (!pDoubleM3P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null)
                            {
                                if (!pDoubleM3P1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleM1P3 = CheckPiece(row - 1, column + 3);
                            if (pDoubleM1P3 != null)
                            {
                                if (!pDoubleM1P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 0, column + 4));
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleM1M1 != null)
                {
                    if (!pSingleM1M1.GetPieceColor().Equals(black))
                    {
                        Piece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row >= 0 && column >= 0)
                        {
                            posList.Add(new Position(row - 2, column - 2));

                            Piece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null)
                            {
                                if (!pDoubleM3M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row >= 0 && column >= 0)
                                    {
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null)
                            {
                                if (!pDoubleM3M1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleM1M3 = CheckPiece(row - 1, column - 3);
                            if (pDoubleM1M3 != null)
                            {
                                if (!pDoubleM1M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                    if (pEatP0M4 == null && row < GetBoardBoundary() && column >= 0)
                                    {
                                        posList.Add(new Position(row + 0, column - 4));
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleP1P1 == null)
                {
                    if (row + 1 < GetBoardBoundary() && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                }
                if (pSingleP1M1 == null)
                {

                    if (row + 1 < GetBoardBoundary() && column - 1 >= 0)
                    {
                        posList.Add(new Position(row + 1, column - 1));
                    }
                }
                if (pSingleM1P1 == null)
                {

                    if (row - 1 >= 0 && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row - 1, column + 1));
                    }
                }
                if (pSingleM1M1 == null)
                {

                    if (row - 1 >= 0 && column - 1 >= 0)
                    {
                        posList.Add(new Position(row - 1, column - 1));
                    }
                }
            }
            else
            {
                Piece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                Piece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                Piece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                Piece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleP1P1 != null)
                {
                    if (pSingleP1P1.GetPieceColor().Equals(black))
                    {
                        Piece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row + 2 < GetBoardBoundary() && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row + 2, column + 2));

                            Piece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null)
                            {
                                if (pDoubleP3P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row + 4 < GetBoardBoundary() && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null)
                            {
                                if (pDoubleP3P1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleP1P3 = CheckPiece(row + 1, column + 3);
                            if (pDoubleP1P3 != null)
                            {
                                if (pDoubleP1P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 0, column + 4));
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleP1M1 != null)
                {
                    if (pSingleP1M1.GetPieceColor().Equals(black))
                    {
                        Piece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row < GetBoardBoundary() && column >= 0)
                        {
                            posList.Add(new Position(row + 2, column - 2));

                            Piece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null)
                                if (pDoubleP3M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row < GetBoardBoundary() && column >= 0)
                                    {
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                        }

                        Piece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                        if (pDoubleP3M1 != null)
                        {
                            if (pDoubleP3M1.GetPieceColor().Equals(black))
                            {
                                Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary())
                                {
                                    if (!posList.Contains(new Position(row + 4, column + 0)))
                                    {
                                        posList.Add(new Position(row + 4, column + 0));
                                    }
                                }

                            }
                        }

                        Piece pDoubleP1M3 = CheckPiece(row + 1, column - 3);
                        if (pDoubleP1M3 != null)
                        {
                            if (pDoubleP1M3.GetPieceColor().Equals(black))
                            {
                                Piece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                if (pEatP0M4 == null && row < GetBoardBoundary() && column >= 0)
                                {
                                    posList.Add(new Position(row + 0, column - 4));
                                }

                            }
                        }
                    }
                }

                if (pSingleM1P1 != null)
                {
                    if (pSingleM1P1.GetPieceColor().Equals(black))
                    {
                        Piece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row >= 0 && column < GetBoardBoundary())
                        {
                            posList.Add(new Position(row - 2, column + 2));

                            Piece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null)
                            {
                                if (pDoubleM3P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null)
                            {
                                if (pDoubleM3P1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleM1P3 = CheckPiece(row - 1, column + 3);
                            if (pDoubleM1P3 != null)
                            {
                                if (pDoubleM1P3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 0, column + 4));
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleM1M1 != null)
                {
                    if (pSingleM1M1.GetPieceColor().Equals(black))
                    {
                        Piece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row >= 0 && column >= 0)
                        {
                            posList.Add(new Position(row - 2, column - 2));

                            Piece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null)
                            {
                                if (pDoubleM3M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row >= 0 && column >= 0)
                                    {
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null)
                            {
                                if (pDoubleM3M1.GetPieceColor().Equals(black))
                                {
                                    Piece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleM1M3 = CheckPiece(row - 1, column - 3);
                            if (pDoubleM1M3 != null)
                            {
                                if (pDoubleM1M3.GetPieceColor().Equals(black))
                                {
                                    Piece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                    if (pEatP0M4 == null && row < GetBoardBoundary() && column >= 0)
                                    {
                                        posList.Add(new Position(row + 0, column - 4));
                                    }

                                }
                            }
                        }
                    }
                }

                if (pSingleP1P1 == null)
                {
                    if (row + 1 < GetBoardBoundary() && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                }
                if (pSingleP1M1 == null)
                {

                    if (row + 1 < GetBoardBoundary() && column - 1 >= 0)
                    {
                        posList.Add(new Position(row + 1, column - 1));
                    }
                }
                if (pSingleM1P1 == null)
                {

                    if (row - 1 >= 0 && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row - 1, column + 1));
                    }
                }
                if (pSingleM1M1 == null)
                {

                    if (row - 1 >= 0 && column - 1 >= 0)
                    {
                        posList.Add(new Position(row - 1, column - 1));
                    }
                }
            }
        }
        return posList;
    }
}
