open System

type TodoItem =
    { Description: string
      IsDone: bool
      CompletedOn: DateTime option }

type TodoList = TodoItem list

type TodoListCommand =
    | NewItem of string
    | ToggleComplete of int
    | SetDesc of int * string


module TodoItem =
    let create task =
        { Description = task
          IsDone = false
          CompletedOn = None }

    let toggleComplete item =
        let nowDone = not item.IsDone
        { item with
            IsDone = nowDone
            CompletedOn = if nowDone then Some(DateTime.Now) else None }

    let setDesc newDescription item =
        { item with Description = newDescription }



module List = 
  let inline updateItem changeItem index list = 
    let oldValue = List.item index list
    let newValue = changeItem oldValue 
    List.updateAt index newValue list

module TodoList =
    let create(): TodoList = []
    let newItem task list = 
        let newItem = TodoItem.create task
        newItem :: list
    let show allItems list = 
        if allItems then list else List.filter (fun i -> not i.IsDone) list
    let toggleComplete = 
      List.updateItem TodoItem.toggleComplete 
    let setDescription newDescription = 
      List.updateItem (TodoItem.setDesc newDescription)

    let executeCommand command list =
        match command with
        | NewItem task -> newItem task list
        | ToggleComplete index -> toggleComplete index list
        | SetDesc (index, newDescription) -> setDescription newDescription index list

    let executeCommands commands list =
        List.fold (fun list command -> executeCommand command list) list commands

module Example = 
  let list = TodoList.create()
             |> TodoList.newItem "Buy milk"
             |> TodoList.newItem "Buy eggs"
             |> TodoList.newItem "Buy bread"
             |> TodoList.toggleComplete 1
             |> TodoList.setDescription "Buy whole wheat bread" 2
             |> TodoList.show true

  let commands = [ NewItem "Buy milk"
                   NewItem "Buy eggs"
                   NewItem "Buy bread"
                   ToggleComplete 1
                   SetDesc(2, "Buy whole wheat bread") ]

  let list2 = TodoList.create() 
              |> TodoList.executeCommands commands 