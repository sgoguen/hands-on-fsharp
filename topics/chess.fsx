type Position = { Row: int; Column: int }

module Position = 
  let isValid (p: Position) = p.Row >= 0 && p.Row < 8 && p.Column >= 0 && p.Column < 8

type PieceType = King | Queen | Rook | Bishop | Knight | Pawn
type Color = Black | White
type Piece = PieceType * Color
type Board = Map<Position, Piece>

type Move = { From: Position; To: Position }

type GameStatus = 
    | Ongoing of playerTurn: Color
    | Checkmate of Color
    | Stalemate

type GameState = { Board: Board; History: Move list; State: GameState }

type MakeMove = GameState -> Move -> MoveResult
and MoveResult = 
    | ValidMove of GameState
    | InvalidMove of string

let possibleMoves (t: PieceType) (c: Color) (p: Position): Position Set = 
    let horizontalMoves = [ for i in 0..7 do yield { Row = i; Column = p.Column } ]
    let verticalMoves = [ for i in 0..7 do yield { Row = p.Row; Column = i } ]
    let diagonalMovesUpRight = [ for i in 0..7 do yield { Row = p.Row + i; Column = p.Column + i } ]
    let diagonalMovesUpLeft = [ for i in 0..7 do yield { Row = p.Row + i; Column = p.Column - i } ]
    let fromOffsets offsets = 
        Set.ofList [ for (x, y) in offsets do 
                        let r = { Row = p.Row + x; Column = p.Column + y }
                        if Position.isValid r then
                          yield r ]
    match t with
    | King -> 
        fromOffsets [for i in -1..1 do for j in -1..1 do yield (i, j) ]
    | Queen ->
        Set.ofList (horizontalMoves @ verticalMoves @ diagonalMovesUpRight @ diagonalMovesUpLeft)
    | Rook ->
        Set.ofList (horizontalMoves @ verticalMoves)
    | Bishop ->
        Set.ofList (diagonalMovesUpRight @ diagonalMovesUpLeft)
    | Knight ->
        fromOffsets [(2, 1); (2, -1); (-2, 1); (-2, -1); (1, 2); (1, -2); (-1, 2); (-1, -2)]
    | Pawn ->
        let offsets = if c = White then [(1, 0); (2, 0); (1, 1); (1, -1)] else [(-1, 0); (-2, 0); (-1, 1); (-1, -1)]
        fromOffsets offsets


    // | Queen -> 
    //     let moves = [ { Row = 1; Column = 1 }; { Row = 1; Column = 0 }; { Row = 1; Column = -1 }; { Row = 0; Column = 1 }; { Row = 0; Column = -1 }; { Row = -1; Column = 1 }; { Row = -1; Column = 0 }; { Row = -1; Column = -1 } ]
    //     moves |> List.map (fun m -> { Row = p.Row + m.Row; Column = p.Column + m.Column })
    // | Rook -> 
    //     let moves = [ { Row = 1; Column = 0 }; { Row = 0; Column = 1 }; { Row = 0; Column = -1 }; { Row = -1; Column = 0 } ]
    //     moves |> List.map (fun m -> { Row = p.Row + m.Row; Column = p.Column + m.Column })
    // | Bishop -> 
    //     let moves = [ { Row = 1; Column = 1 }; { Row = 1; Column = -1 }; { Row = -1; Column = 1 }; { Row = -1; Column = -1 } ]
    //     moves |> List.map (fun m -> { Row = p.Row + m.Row; Column = p.Column + m.Column })
    // | Knight -> 
    //     let moves = [ { Row = 2; Column = 1 }; { Row = 2; Column = -1 }; { Row = -2; Column = 1 }; { Row = -2; Column = -1 }; { Row = 1; Column = 2 }; { Row = 1; Column = -2 }; { Row = -1

// let isValidMove board playerTurn move = 
//     let position = board |> Map.tryFind move.From
//     match position with
//     | None -> InvalidMove "No piece at that position"
//     | Some(pieceType, color) ->
//         InvalidMove "Not your turn"
//         // if color <> playerTurn then InvalidMove "Not your turn"
//         // else
//         //     let piece = pieceType, color
//         //     let validMoves = getValidMoves piece board
//         //     if validMoves |> List.exists (fun m -> m = move.To) then ValidMove board
//         //     else InvalidMove "Invalid move"