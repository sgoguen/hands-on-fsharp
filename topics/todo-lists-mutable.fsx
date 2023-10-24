module ImperativeList =

  type TodoItem =
      { mutable Description: string
        mutable IsDone: bool }

  type TodoList = System.Collections.Generic.List<TodoItem>


  module TodoItem =
      let create task = { Description = task; IsDone = false }

      let toggleComplete item =
          item.IsDone <- not item.IsDone
          item

      let setDesc newDescription item =
          item.Description <- newDescription
          item

  module TodoList =
      let create () : TodoList =
          System.Collections.Generic.List<TodoItem>()

      let newItem task (list: TodoList) =
          list.Add(TodoItem.create task)
          list

      let show onlyCompleted (list: TodoList) =
          if onlyCompleted then
              Seq.filter (fun i -> i.IsDone) list
          else
              list

      let inline updateList updateItem index (list: TodoList) =
          list[index] <- updateItem list.[index]
          list

      let toggleComplete index list =
          updateList TodoItem.toggleComplete index list

      let setDesc index newDescription list =
          updateList (TodoItem.setDesc newDescription) index list

let list =
    TodoList.create ()
    |> TodoList.newItem "Buy milk"
    |> TodoList.newItem "Buy eggs"
    |> TodoList.newItem "Buy bread"
    |> TodoList.toggleComplete 1
    |> TodoList.setDesc 2 "Buy whole wheat bread"
    |> TodoList.show false
    |> Seq.toList
