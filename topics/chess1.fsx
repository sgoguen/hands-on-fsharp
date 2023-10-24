module Chess

type Position = { Row: int; Column: int }

module Position = 
  let isValid (p: Position) = p.Row >= 0 && p.Row < 8 && p.Column >= 0 && p.Column < 8

type PieceType = King | Queen | Rook | Bishop | Knight | Pawn

type Color = Black | White

module PieceType = 
  let availableMoves (t: PieceType) (c: Color) (p: Position) (hasPiece: Position -> Color option)= 
    let horizontalMoves = lazy [ for i in 0..7 do yield { Row = i; Column = p.Column } ]
    let verticalMoves = lazy [ for i in 0..7 do yield { Row = p.Row; Column = i } ]
    let diagonalMovesUpRight = lazy [ for i in 0..7 do yield { Row = p.Row + i; Column = p.Column + i } ]
    let diagonalMovesUpLeft = lazy [ for i in 0..7 do yield { Row = p.Row + i; Column = p.Column - i } ]
    let offsetsToMoves offsets = 
        Set.ofList [ for (x, y) in offsets do 
                        let r = { Row = p.Row + x; Column = p.Column + y }
                        if Position.isValid r then
                          yield r ]
    match t with
    | King -> 
      // A KING can move one square in any direction (horizontally, vertically, or diagonally)
        offsetsToMoves [for i in -1..1 do for j in -1..1 do yield (i, j) ]
    | Queen ->
        // A QUEEN can move any number of squares in any direction (horizontally, vertically, or diagonally)
        Set.ofList (horizontalMoves.Value @ verticalMoves.Value @ diagonalMovesUpRight.Value @ diagonalMovesUpLeft.Value)
    | Rook ->
        // A ROOK can move any number of squares horizontally or vertically
        Set.ofList (horizontalMoves.Value @ verticalMoves.Value)
    | Bishop ->
        // A BISHOP can move any number of squares diagonally
        Set.ofList (diagonalMovesUpRight.Value @ diagonalMovesUpLeft.Value)
    | Knight ->
        // A KNIGHT can move in an "L" shape: two squares in a horizontal or vertical direction, then move one square horizontally or vertically. It can jump over other pieces.
        offsetsToMoves [(2, 1); (2, -1); (-2, 1); (-2, -1); (1, 2); (1, -2); (-1, 2); (-1, -2)]
    | Pawn ->
        // A PAWN can move one square forward, if that square is unoccupied. 
        // If it has not yet moved, a PAWN also has the option of moving two squares forward, 
        //  provided both squares are unoccupied. A PAWN cannot move backwards. 
        // A PAWN can move one square forward diagonally to capture an opponent's piece. 
        // A PAWN cannot capture a piece directly in front of it.
        let hasAnyPieceAt (pos): bool = hasPiece pos |> Option.isSome
        let hasEnemyPieceAt (pos): bool = hasPiece pos |> Option.exists (fun c -> c <> c)
        // offsetsToMoves (if c = White then [(1, 0); (2, 0); (1, 1); (1, -1)] else [(-1, 0); (-2, 0); (-1, 1); (-1, -1)])
        let attackOffsets = 
            (if c = White then [(1, 1); (1, -1)] else [(-1, 1); (-1, -1)])
            |> List.filter (fun (x, y) -> hasEnemyPieceAt { Row = p.Row + x; Column = p.Column + y })
                  
        let regularOffsets = if c = White then [(1, 0); (2, 0)] else [(-1, 0); (-2, 0)]
        // let offsets = if c = White then [(1, 0); (2, 0); (1, 1); (1, -1)] else [(-1, 0); (-2, 0); (-1, 1); (-1, -1)]



type Piece = PieceType * Color

let a1 = (Queen, White)
let a2 = (King, White)

type Board = Map<Position, Piece>