---
marp: true
---
<!-- class: lead -->

![bg left:33%](../images/chalk-board.jpg)

# Chalking Up Ideas with Types

---

# The Triumvirate Types

- Tuples - Combines multiple values
  - Corresponds to AND in logic
  - `type Person = string * int`
  - `let person = ("John", 25)`
- Unions - Provides a choice of values 
  - Corresponds to OR in logic
  - `type Result = Success of Person | Error of string`
  - `let result = Success ("John", 25)`
- Functions - Maps input values to output values
  - Corresponds to IMPLIES in logic
  - `type AgePerson = Person -> Person`
  - `let ageOneYear (name, age) = (name, age + 1)`

---

# Modeling A Chess Board

```fsharp
type Row = int
type Column = int
type Position = Row * Column 
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
    | InvalidMove
``` 

[Chess Board Code](./chess.fsx)

---

# An Initial Model for a Fast Casual Restaurant

```fsharp
type Base = Rice | Lettuce | Quinoa
type Protein = Chicken | Beef | Tofu | Falafel
type Topping = Tomatoes | Olives | Feta | Cucumber
type Sauce = Tzatziki | Hummus | Vinaigrette

type Bowl = {
    Base: Base
    Proteins: Protein list
    Toppings: Topping list
    Sauce: Sauce list
}
```

---

# Translated into a Generic Restaurant Model

```fsharp
type MenuItem = {
    Name: string
    OptionGroups: OptionGroup list
}
and MenuOptionGroup = {
    Name: string
    Options: MenuOption list
}
and MenuOption = {
    Name: string
    AdditionalPrice: decimal
}
```




---

```fsharp
// Definition of a generic List type
type 'a List =
    | Empty
    | Node of 'a * 'a List

val append : 'a List -> 'a List -> 'a List
val reverse : 'a List -> 'a List
val map : ('a -> 'b) -> 'a List -> 'b List
val filter : ('a -> bool) -> 'a List -> 'a List
val fold : ('a -> 'b -> 'a) -> 'a -> 'b List -> 'a
val find : ('a -> bool) -> 'a List -> 'a option

```

---

```fsharp
type Role = Admin | User | Guest

type Permission = Read | Write | Execute

type AccessRule = {
    Role: Role
    Permissions: Permission set
}
```

---

```fsharp
type UIComponent = 
    | Button of Label: string
    | TextBox of Placeholder: string
    | Dropdown of Options: string list

type UserAction =
    | Click
    | Input of string
    | Select of string
```

---

