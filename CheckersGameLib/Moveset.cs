// namespace CheckersGameLib;

// public class Moveset
// {

//     public List<Position> SingleMove(ICheckersPiece piece)
//     {
//         int row = piece.GetPosition().GetRow();
//         int col = piece.GetPosition().GetColumn();
//         List<Position> positions = new List<Position>();
//         if (piece.GetRank().Equals(Rank.Basic))
//         {
//             if (piece.GetPieceColor().Equals(PieceColor.Black))
//             {
//                 positions.Add(new Position(row + 1, col + 1));
//                 positions.Add(new Position(row + 1, col - 1));
//             }
//             else
//             {
//                 positions.Add(new Position(row - 1, col + 1));
//                 positions.Add(new Position(row - 1, col - 1));
//             }
//         }
//         else
//         {
//             positions.Add(new Position(row + 1, col + 1));
//             positions.Add(new Position(row + 1, col - 1));
//             positions.Add(new Position(row - 1, col + 1));
//             positions.Add(new Position(row - 1, col - 1));
//         }
//         return positions;
//     }

//     public List<Position> SingleJumpMove(ICheckersPiece piece)
//     {
//         int row = piece.GetPosition().GetRow();
//         int col = piece.GetPosition().GetColumn();
//         List<Position> positions = new List<Position>();
//         if (piece.GetRank().Equals(Rank.Basic))
//         {
//             if (piece.GetPieceColor().Equals(PieceColor.Black))
//             {
//                 positions.Add(new Position(row + 2, col + 2));
//                 positions.Add(new Position(row + 2, col - 2));
//             }
//             else
//             {
//                 positions.Add(new Position(row - 2, col + 2));
//                 positions.Add(new Position(row - 2, col - 2));
//             }
//         }
//         else
//         {
//             positions.Add(new Position(row + 2, col + 2));
//             positions.Add(new Position(row + 2, col - 2));
//             positions.Add(new Position(row - 2, col + 2));
//             positions.Add(new Position(row - 2, col - 2));
//         }
//         return positions;
//     }

//     public List<Position> DoubleJumpMove(ICheckersPiece piece)
//     {
//         int row = piece.GetPosition().GetRow();
//         int col = piece.GetPosition().GetColumn();
//         List<Position> positions = new List<Position>();
//         if (piece.GetRank().Equals(Rank.Basic))
//         {
//             if (piece.GetPieceColor().Equals(PieceColor.Black))
//             {
//                 positions.Add(new Position(row + 4, col + 4));
//                 positions.Add(new Position(row + 4, col - 4));
//                 positions.Add(new Position(row + 4, col - 0));
//             }
//             else
//             {
//                 positions.Add(new Position(row - 4, col + 4));
//                 positions.Add(new Position(row - 4, col - 4));
//                 positions.Add(new Position(row - 4, col - 0));
//             }
//         }
//         else
//         {
//             positions.Add(new Position(row + 4, col + 4));
//             positions.Add(new Position(row + 4, col - 4));
//             positions.Add(new Position(row - 4, col + 4));
//             positions.Add(new Position(row - 4, col - 4));
//             positions.Add(new Position(row + 4, col));
//             positions.Add(new Position(row - 4, col));
//             positions.Add(new Position(row, col - 4));
//             positions.Add(new Position(row, col + 4));
//         }
//         return positions;
//     }
// }
