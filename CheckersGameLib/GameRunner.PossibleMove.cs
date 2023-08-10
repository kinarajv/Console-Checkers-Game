namespace CheckersGameLib;

public partial class GameRunner
{
    // Get Any available move for a player's piece
    public List<Position> GetPossibleMove(ICheckersPiece piece)
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
                ICheckersPiece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                ICheckersPiece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                if (pSingleP1P1 != null)
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black))
                    {
                        ICheckersPiece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row + 2 < GetBoardBoundary() && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row + 2, column + 2));

                            ICheckersPiece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null)
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row + 4 < GetBoardBoundary() && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null)
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P0 = CheckPiece(row + 4, column + 0);
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
                        ICheckersPiece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row + 2 < GetBoardBoundary() && column - 2 >= 0)
                        {
                            posList.Add(new Position(row + 2, column - 2));

                            ICheckersPiece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null)
                            {
                                if (!pDoubleP3M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row + 4 < GetBoardBoundary() && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                            if (pDoubleP3M1 != null)
                            {
                                if (!pDoubleP3M1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P0 = CheckPiece(row + 4, column + 0);
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
                ICheckersPiece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                ICheckersPiece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleM1P1 != null)
                {
                    if (pSingleM1P1.GetPieceColor().Equals(black))
                    {
                        ICheckersPiece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row - 2 >= 0 && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row - 2, column + 2));

                            ICheckersPiece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null)
                            {
                                if (pDoubleM3P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row - 4 >= 0 && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null)
                            {
                                if (pDoubleM3P1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P0 = CheckPiece(row - 4, column + 0);
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
                        ICheckersPiece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row - 2 >= 0 && column - 2 >= 0)
                        {
                            posList.Add(new Position(row - 2, column - 2));

                            ICheckersPiece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null)
                            {
                                if (pDoubleM3M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row - 4 >= 0 && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null)
                            {
                                if (pDoubleM3M1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P0 = CheckPiece(row - 4, column + 0);
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
                ICheckersPiece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                ICheckersPiece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                ICheckersPiece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                ICheckersPiece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleP1P1 != null)
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black))
                    {
                        ICheckersPiece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row + 2 < GetBoardBoundary() && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row + 2, column + 2));

                            ICheckersPiece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null)
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row + 4 < GetBoardBoundary() && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null)
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row + 4 < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }

                            ICheckersPiece pDoubleP1P3 = CheckPiece(row + 1, column + 3);
                            if (pDoubleP1P3 != null)
                            {
                                if (!pDoubleP1P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row < GetBoardBoundary() && column + 4 < GetBoardBoundary())
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
                        ICheckersPiece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row + 2 < GetBoardBoundary() && column - 2 >= 0)
                        {
                            posList.Add(new Position(row + 2, column - 2));

                            ICheckersPiece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null)
                                if (!pDoubleP3M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row + 4 < GetBoardBoundary() && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                        }

                        ICheckersPiece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                        if (pDoubleP3M1 != null)
                        {
                            if (!pDoubleP3M1.GetPieceColor().Equals(black))
                            {
                                ICheckersPiece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                if (pEatP4P0 == null && row + 4 < GetBoardBoundary() && column < GetBoardBoundary())
                                {
                                    if (!posList.Contains(new Position(row + 4, column + 0)))
                                    {
                                        posList.Add(new Position(row + 4, column + 0));
                                    }
                                }

                            }
                        }

                        ICheckersPiece pDoubleP1M3 = CheckPiece(row + 1, column - 3);
                        if (pDoubleP1M3 != null)
                        {
                            if (!pDoubleP1M3.GetPieceColor().Equals(black))
                            {
                                ICheckersPiece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                if (pEatP0M4 == null && row < GetBoardBoundary() && column - 4 >= 0)
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
                        ICheckersPiece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row - 2 >= 0 && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row - 2, column + 2));

                            ICheckersPiece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null)
                            {
                                if (!pDoubleM3P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row - 4 >= 0 && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null)
                            {
                                if (!pDoubleM3P1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row - 4 >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM1P3 = CheckPiece(row - 1, column + 3);
                            if (pDoubleM1P3 != null)
                            {
                                if (!pDoubleM1P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row >= 0 && column + 4 < GetBoardBoundary())
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
                        ICheckersPiece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row >= 0 && column >= 0)
                        {
                            posList.Add(new Position(row - 2, column - 2));

                            ICheckersPiece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null)
                            {
                                if (!pDoubleM3M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row >= 0 && column >= 0)
                                    {
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null)
                            {
                                if (!pDoubleM3M1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM1M3 = CheckPiece(row - 1, column - 3);
                            if (pDoubleM1M3 != null)
                            {
                                if (!pDoubleM1M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP0M4 = CheckPiece(row + 0, column - 4);
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
                ICheckersPiece pSingleP1P1 = CheckPiece(row + 1, column + 1);
                ICheckersPiece pSingleP1M1 = CheckPiece(row + 1, column - 1);
                ICheckersPiece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                ICheckersPiece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleP1P1 != null)
                {
                    if (pSingleP1P1.GetPieceColor().Equals(black))
                    {
                        ICheckersPiece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row + 2 < GetBoardBoundary() && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row + 2, column + 2));

                            ICheckersPiece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null)
                            {
                                if (pDoubleP3P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row + 4 < GetBoardBoundary() && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null)
                            {
                                if (pDoubleP3P1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row + 4 < GetBoardBoundary() && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }

                            ICheckersPiece pDoubleP1P3 = CheckPiece(row + 1, column + 3);
                            if (pDoubleP1P3 != null)
                            {
                                if (pDoubleP1P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row < GetBoardBoundary() && column + 4 < GetBoardBoundary())
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
                        ICheckersPiece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row + 2 < GetBoardBoundary() && column - 2 >= 0)
                        {
                            posList.Add(new Position(row + 2, column - 2));

                            ICheckersPiece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null)
                                if (pDoubleP3M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row + 4 < GetBoardBoundary() && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                        }

                        ICheckersPiece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                        if (pDoubleP3M1 != null)
                        {
                            if (pDoubleP3M1.GetPieceColor().Equals(black))
                            {
                                ICheckersPiece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                if (pEatP4P0 == null && row + 4 < GetBoardBoundary() && column < GetBoardBoundary())
                                {
                                    if (!posList.Contains(new Position(row + 4, column + 0)))
                                    {
                                        posList.Add(new Position(row + 4, column + 0));
                                    }
                                }

                            }
                        }

                        ICheckersPiece pDoubleP1M3 = CheckPiece(row + 1, column - 3);
                        if (pDoubleP1M3 != null)
                        {
                            if (pDoubleP1M3.GetPieceColor().Equals(black))
                            {
                                ICheckersPiece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                if (pEatP0M4 == null && row < GetBoardBoundary() && column - 4 >= 0)
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
                        ICheckersPiece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row - 2 >= 0 && column + 2 < GetBoardBoundary())
                        {
                            posList.Add(new Position(row - 2, column + 2));

                            ICheckersPiece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null)
                            {
                                if (pDoubleM3P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row - 4 >= 0 && column + 4 < GetBoardBoundary())
                                    {
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null)
                            {
                                if (pDoubleM3P1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row - 4 >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM1P3 = CheckPiece(row - 1, column + 3);
                            if (pDoubleM1P3 != null)
                            {
                                if (pDoubleM1P3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row >= 0 && column + 4 < GetBoardBoundary())
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
                        ICheckersPiece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row - 2 >= 0 && column - 2 >= 0)
                        {
                            posList.Add(new Position(row - 2, column - 2));

                            ICheckersPiece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null)
                            {
                                if (pDoubleM3M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row - 4 >= 0 && column - 4 >= 0)
                                    {
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null)
                            {
                                if (pDoubleM3M1.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row + 4 >= 0 && column < GetBoardBoundary())
                                    {
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            ICheckersPiece pDoubleM1M3 = CheckPiece(row - 1, column - 3);
                            if (pDoubleM1M3 != null)
                            {
                                if (pDoubleM1M3.GetPieceColor().Equals(black))
                                {
                                    ICheckersPiece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                    if (pEatP0M4 == null && row < GetBoardBoundary() && column - 4 >= 0)
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
        if (posList.Count > 0)
        {
            return posList;
        }
        return null;
    }

    public List<Position> GetPossibleMove1(ICheckersPiece piece)
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
                if (CheckPiece(row, col) == null)
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

            if (Math.Abs(row - initRow) == 4 && Math.Abs(col - initCol) == 4)
            {
                if (!IsBlocked(initRow, initCol, row, col))
                {
                    if (CheckPiece(row, col) == null)
                    {
                        if (row >= 0 && row < GetBoardBoundary() && col >= 0 && col < GetBoardBoundary())
                        {
                            positions.Add(position);
                        }
                    }
                }
            }
            else if (row - initRow == 0)
            {
                int rowPlus = initRow + 2;
                int colPlus = initCol + 2;
                if (!IsBlocked(initRow, initCol, rowPlus, colPlus))
                {
                    if (rowPlus >= 0 && rowPlus < GetBoardBoundary() && colPlus >= 0 && colPlus < GetBoardBoundary())
                    {
                        initRow = rowPlus - 1;
                        initCol = colPlus - 1;
                        rowPlus += 2;
                        colPlus -= 2;
                        if (!IsBlocked(initRow, initCol, rowPlus, colPlus))
                        {
                            if (CheckPiece(rowPlus, colPlus) == null)
                            {
                                if (rowPlus >= 0 && rowPlus < GetBoardBoundary() && colPlus >= 0 && colPlus < GetBoardBoundary())
                                {
                                    positions.Add(position);
                                }
                            }
                        }
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

        int currRow = initRow + rowInc;
        int currCol = initCol + colInc;

        while (currRow != targetRow && currCol != targetCol)
        {
            ICheckersPiece initPiece = CheckPiece(initRow, initCol);
            ICheckersPiece pathPiece = CheckPiece(currRow, currCol);
            if (pathPiece != null)
            {
                if (pathPiece.GetPieceColor().Equals(initPiece.GetPieceColor()))
                {
                    return true;
                }
            }
        }
        return false;
    }
}