type TodoItem(task) = 
    member val Task : string = task with get, set
    member val IsDone : bool = false with get, set
    member this.Toggle() = this.IsDone <- not this.IsDone
    override this.ToString() = sprintf "%s %s" this.Task (if this.IsDone then "[DONE]" else "")

type TodoList() =
    let list = System.Collections.Generic.List<TodoItem>()
    let mutable showCompleted = true
    member this.NewItem(task) =
        let item = new TodoItem(task)
        list.Add(item)
        this
    member this.ToggleShowCompleted() = 
        showCompleted <- not showCompleted
        this
    member this.Items =
        if showCompleted then
            [ for i in list -> i ]
        else
            [ for i in list do if not i.IsDone then yield i ]
    member this.SetDesc(index, newDescription) =
        list[index].Task <- newDescription
        this
    member this.ToggleComplete(index) =
        list[index].Toggle()
        this

let list = TodoList().NewItem("Buy Milk").NewItem("Buy Eggs").NewItem("Buy Bread")
            .ToggleComplete(1).SetDesc(2, "Buy whole wheat bread").Items