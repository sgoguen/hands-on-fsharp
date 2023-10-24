type TodoItem = { Description: string; IsDone: bool }

type TodoList = TodoItem list

module TodoItem = 
    let create task = { Description = task; IsDone = false }
    let toggleComplete item = { item with IsDone = not item.IsDone }
    let setDesc newDescription item = { item with Description = newDescription }

module TodoList =
    let create(): TodoList = []
    let newItem task list = TodoItem.create task :: list
    let show onlyCompleted list = 
        if onlyCompleted then List.filter (fun i -> i.IsDone) list else list
    let updateList updateItem index (list: TodoList) = 
        //  Find the item
        let item = List.item index list
        //  Create a new toggled item
        let newItem = updateItem item
        //  Replace the item in the list by creating a new list
        List.updateAt index newItem list

    let toggleComplete index list = 
        updateList TodoItem.toggleComplete index list
    let setDesc index newDescription list =
        updateList (TodoItem.setDesc newDescription) index list

let list = TodoList.create()
            |> TodoList.newItem "Buy milk"
            |> TodoList.newItem "Buy eggs"
            |> TodoList.newItem "Buy bread"
            |> TodoList.toggleComplete 1
            |> TodoList.setDesc 2 "Buy whole wheat bread"
            |> TodoList.show true

module V1 = 

    type UndoableTodoList() = 
        let mutable listHistory = [TodoList.create()]
        let getList() = listHistory |> List.head
        member this.NewItem(task) = 
            listHistory <- (getList() |> TodoList.newItem task) :: listHistory
            this
        member this.ToggleComplete(index) =
            listHistory <- (getList() |> TodoList.toggleComplete index) :: listHistory
            this
        member this.SetDesc(index, newDescription) =
            listHistory <- (getList() |> TodoList.setDesc index newDescription) :: listHistory
            this
        member this.Undo() =
            listHistory <- match listHistory with
                            | [] -> [TodoList.create()]
                            | [last] -> [last]
                            | _ :: rest -> rest
            this


module V2 =

    type UpdateCommands =
        | NewItem of string
        | ToggleComplete of int
        | SetDesc of int * string

    module TodoList = 
        let executeCommand command list = 
            match command with
            | NewItem task -> TodoList.newItem task list
            | ToggleComplete index -> TodoList.toggleComplete index list
            | SetDesc(index, newDescription) -> TodoList.setDesc index newDescription list
        let executeCommands commands list = 
            (list, commands) ||> List.fold (fun list command -> executeCommand command list)
        
    type UndoableTodoList() =
        let mutable commandHistory = []
        member this.NewItem(task) = 
            commandHistory <- NewItem task :: commandHistory
            this
        member this.ToggleComplete(index) =
            commandHistory <- ToggleComplete index :: commandHistory
            this
        member this.SetDesc(index, newDescription) =
            commandHistory <- SetDesc(index, newDescription) :: commandHistory
            this
        member this.GetList() = 
            TodoList.create() |> List.rev |> TodoList.executeCommands commandHistory
        member this.Undo() =
            match commandHistory with
            | [] -> this
            | _ :: rest -> 
                commandHistory <- rest
                this