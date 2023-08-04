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
                if (pSingleP1P1 != null) // Klo di serong + 11 ada
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black)) // Klo di serong + 11 merah
                    {
                        Piece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 22 merah
                        {
                            pSingleP1P1.SetIsEaten(true);
                            posList.Add(new Position(row + 2, column + 2));
                            Piece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleP3P3.SetIsEaten(true);
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleP3P1.SetIsEaten(true);
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
                else if (pSingleP1M1 != null) // Klo di serong +1-1 ada
                {
                    if (!pSingleP1M1.GetPieceColor().Equals(black)) // Klo di serong +1-1 merah
                    {
                        Piece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row < GetBoardBoundary() && column >= 0) // Klo di serong + 22 merah
                        {
                            pSingleP1M1.SetIsEaten(true);
                            posList.Add(new Position(row + 2, column - 2));
                            Piece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3M3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleP3M3.SetIsEaten(true);
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                            if (pDoubleP3M1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleP3M1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleP3M1.SetIsEaten(true);
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
                else
                {
                    if (row < GetBoardBoundary() && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                    else if (row < GetBoardBoundary() && column - 1 >= 0)
                    {

                    }
                    posList.Add(new Position(row + 1, column - 1));
                }
            }
            else
            {
                Piece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                Piece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleM1P1 != null) // Klo di serong -11 ada
                {
                    if (pSingleM1P1.GetPieceColor().Equals(black)) // Klo di serong -11 merah
                    {
                        Piece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong -22 merah
                        {
                            pSingleM1P1.SetIsEaten(true);
                            posList.Add(new Position(row - 2, column + 2));
                            Piece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null) // Klo di serong -33 ada
                            {
                                if (pDoubleM3P3.GetPieceColor().Equals(black)) // Klo di serong -33 merah
                                {
                                    Piece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong -44 kosong
                                    {
                                        pDoubleM3P3.SetIsEaten(true);
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null) // Klo di serong -31 ada
                            {
                                if (pDoubleM3P1.GetPieceColor().Equals(black)) // Klo di serong -31 merah
                                {
                                    Piece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong -40 kosong
                                    {
                                        pDoubleM3P1.SetIsEaten(true);
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
                else if (pSingleM1M1 != null) // Klo di serong +1-1 ada
                {
                    if (pSingleM1M1.GetPieceColor().Equals(black)) // Klo di serong -1-1 merah
                    {
                        Piece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row < GetBoardBoundary() && column >= 0) // Klo di serong -2-2 merah
                        {
                            pSingleM1M1.SetIsEaten(true);
                            posList.Add(new Position(row - 2, column - 2));
                            Piece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null) // Klo di serong + 33 ada
                            {
                                if (pDoubleM3M3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleM3M3.SetIsEaten(true);
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null) // Klo di serong + 31 ada
                            {
                                if (pDoubleM3M1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleM3M1.SetIsEaten(true);
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
                else
                {
                    if (row - 1 >= 0 && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row - 1, column + 1));
                    }
                    else if (row - 1 >= 0 && column - 1 < GetBoardBoundary())
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
                if (pSingleP1P1 != null) // Klo di serong + 11 ada
                {
                    if (!pSingleP1P1.GetPieceColor().Equals(black)) // Klo di serong + 11 merah
                    {
                        Piece pEatP2P2 = CheckPiece(row + 2, column + 2);
                        if (pEatP2P2 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 22 merah
                        {
                            pSingleP1P1.SetIsEaten(true);
                            posList.Add(new Position(row + 2, column + 2));
                            Piece pDoubleP3P3 = CheckPiece(row + 3, column + 3);
                            if (pDoubleP3P3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3P3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatP4P4 = CheckPiece(row + 4, column + 4);
                                    if (pEatP4P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleP3P3.SetIsEaten(true);
                                        posList.Add(new Position(row + 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleP3P1 = CheckPiece(row + 3, column + 1);
                            if (pDoubleP3P1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleP3P1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleP3P1.SetIsEaten(true);
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleP1P3 = CheckPiece(row + 1, column + 3);
                            if (pDoubleP1P3 != null) // Klo di serong + 13 ada
                            {
                                if (!pDoubleP1P3.GetPieceColor().Equals(black)) // Klo di serong +13 merah
                                {
                                    Piece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong +30 kosong
                                    {
                                        pDoubleP1P3.SetIsEaten(true);
                                        posList.Add(new Position(row + 0, column + 4));
                                    }

                                }
                            }
                        }
                    }
                }
                else if (pSingleP1M1 != null) // Klo di serong +1-1 ada
                {
                    if (!pSingleP1M1.GetPieceColor().Equals(black)) // Klo di serong +1-1 merah
                    {
                        Piece pEatP2M2 = CheckPiece(row + 2, column - 2);
                        if (pEatP2M2 == null && row < GetBoardBoundary() && column >= 0) // Klo di serong + 22 merah
                        {
                            pSingleP1M1.SetIsEaten(true);
                            posList.Add(new Position(row + 2, column - 2));
                            Piece pDoubleP3M3 = CheckPiece(row + 3, column - 3);
                            if (pDoubleP3M3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleP3M3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatP4M4 = CheckPiece(row + 4, column - 4);
                                    if (pEatP4M4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleP3M3.SetIsEaten(true);
                                        posList.Add(new Position(row + 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleP3M1 = CheckPiece(row + 3, column - 1);
                            if (pDoubleP3M1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleP3M1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatP4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatP4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleP3M1.SetIsEaten(true);
                                        if (!posList.Contains(new Position(row + 4, column + 0)))
                                        {
                                            posList.Add(new Position(row + 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleP1M3 = CheckPiece(row + 1, column - 3);
                            if (pDoubleP1M3 != null) // Klo di serong + 13 ada
                            {
                                if (!pDoubleP1M3.GetPieceColor().Equals(black)) // Klo di serong +13 merah
                                {
                                    Piece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                    if (pEatP0M4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong +30 kosong
                                    {
                                        pDoubleP1M3.SetIsEaten(true);
                                        posList.Add(new Position(row + 0, column - 4));
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    if (row < GetBoardBoundary() && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row + 1, column + 1));
                    }
                    else if (row < GetBoardBoundary() && column - 1 >= 0)
                    {

                    }
                    posList.Add(new Position(row + 1, column - 1));
                }
            }
            else
            {
                Piece pSingleM1P1 = CheckPiece(row - 1, column + 1);
                Piece pSingleM1M1 = CheckPiece(row - 1, column - 1);
                if (pSingleM1P1 != null) // Klo di serong -11 ada
                {
                    if (!pSingleM1P1.GetPieceColor().Equals(black)) // Klo di serong -11 merah
                    {
                        Piece pEatM2P2 = CheckPiece(row - 2, column + 2);
                        if (pEatM2P2 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong -22 merah
                        {
                            pSingleM1P1.SetIsEaten(true);
                            posList.Add(new Position(row - 2, column + 2));
                            Piece pDoubleM3P3 = CheckPiece(row - 3, column + 3);
                            if (pDoubleM3P3 != null) // Klo di serong -33 ada
                            {
                                if (!pDoubleM3P3.GetPieceColor().Equals(black)) // Klo di serong -33 merah
                                {
                                    Piece pEatM4P4 = CheckPiece(row - 4, column + 4);
                                    if (pEatM4P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong -44 kosong
                                    {
                                        pDoubleM3P3.SetIsEaten(true);
                                        posList.Add(new Position(row - 4, column + 4));
                                    }

                                }
                            }

                            Piece pDoubleM3P1 = CheckPiece(row - 3, column + 1);
                            if (pDoubleM3P1 != null) // Klo di serong -31 ada
                            {
                                if (!pDoubleM3P1.GetPieceColor().Equals(black)) // Klo di serong -31 merah
                                {
                                    Piece pEatM4P0 = CheckPiece(row - 4, column + 0);
                                    if (pEatM4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong -40 kosong
                                    {
                                        pDoubleM3P1.SetIsEaten(true);
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleM1P3 = CheckPiece(row - 1, column + 3);
                            if (pDoubleM1P3 != null) // Klo di serong + 13 ada
                            {
                                if (!pDoubleM1P3.GetPieceColor().Equals(black)) // Klo di serong +13 merah
                                {
                                    Piece pEatP0P4 = CheckPiece(row + 0, column + 4);
                                    if (pEatP0P4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong +30 kosong
                                    {
                                        pDoubleM1P3.SetIsEaten(true);
                                        posList.Add(new Position(row + 0, column + 4));
                                    }

                                }
                            }
                        }
                    }
                }
                else if (pSingleM1M1 != null) // Klo di serong +1-1 ada
                {
                    if (!pSingleM1M1.GetPieceColor().Equals(black)) // Klo di serong -1-1 merah
                    {
                        Piece pEatM2M2 = CheckPiece(row - 2, column - 2);
                        if (pEatM2M2 == null && row < GetBoardBoundary() && column >= 0) // Klo di serong -2-2 merah
                        {
                            pSingleM1M1.SetIsEaten(true);
                            posList.Add(new Position(row - 2, column - 2));
                            Piece pDoubleM3M3 = CheckPiece(row - 3, column - 3);
                            if (pDoubleM3M3 != null) // Klo di serong + 33 ada
                            {
                                if (!pDoubleM3M3.GetPieceColor().Equals(black)) // Klo di serong + 33 merah
                                {
                                    Piece pEatM4M4 = CheckPiece(row - 4, column - 4);
                                    if (pEatM4M4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 44 kosong
                                    {
                                        pDoubleM3M3.SetIsEaten(true);
                                        posList.Add(new Position(row - 4, column - 4));
                                    }

                                }
                            }

                            Piece pDoubleM3M1 = CheckPiece(row - 3, column - 1);
                            if (pDoubleM3M1 != null) // Klo di serong + 31 ada
                            {
                                if (!pDoubleM3M1.GetPieceColor().Equals(black)) // Klo di serong + 31 merah
                                {
                                    Piece pEatM4P0 = CheckPiece(row + 4, column + 0);
                                    if (pEatM4P0 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong + 40 kosong
                                    {
                                        pDoubleM3M1.SetIsEaten(true);
                                        if (!posList.Contains(new Position(row - 4, column + 0)))
                                        {
                                            posList.Add(new Position(row - 4, column + 0));
                                        }
                                    }

                                }
                            }

                            Piece pDoubleM1M3 = CheckPiece(row - 1, column - 3);
                            if (pDoubleM1M3 != null) // Klo di serong + 13 ada
                            {
                                if (!pDoubleM1M3.GetPieceColor().Equals(black)) // Klo di serong +13 merah
                                {
                                    Piece pEatP0M4 = CheckPiece(row + 0, column - 4);
                                    if (pEatP0M4 == null && row < GetBoardBoundary() && column < GetBoardBoundary()) // Klo di serong +30 kosong
                                    {
                                        pDoubleM1M3.SetIsEaten(true);
                                        posList.Add(new Position(row + 0, column - 4));
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    if (row - 1 >= 0 && column + 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row - 1, column + 1));
                    }
                    else if (row - 1 >= 0 && column - 1 < GetBoardBoundary())
                    {
                        posList.Add(new Position(row - 1, column - 1));
                    }
                }
            }
        }
        return posList;
    }

    // Make Move    
    public bool MakeMove(Position origin, Position destination)
    {
        bool isValid = false;
        int originRow = origin.GetRow();
        int originCol = origin.GetColumn();

        foreach (var kvp in _playerPieces)
        {
            var pieceList = kvp.Value.ToList();
            foreach (var piece in pieceList)
            {
                // System.Console.WriteLine(pieceList.GetPosition() == origin);
                int ownedRow = piece.GetPosition().GetRow();
                int ownedCol = piece.GetPosition().GetColumn();
                if (originRow == ownedRow && originCol == ownedCol)
                {
                    piece.SetPosition(destination);
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                break;
            }
        }
        System.Console.WriteLine($"Origin: {origin.GetRow()}, {origin.GetColumn()}");
        System.Console.WriteLine($"Destination: {destination.GetRow()}, {destination.GetColumn()}");

        return isValid;
    }
}
