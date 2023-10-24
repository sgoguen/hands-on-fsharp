type TodoItem() =
    member val Task = "" with get, set
    member val IsDone = false with get, set
    member this.Toggle() = this.IsDone <- not this.IsDone
    override this.ToString() = sprintf "%s %s" this.Task (if this.IsDone then "[DONE]" else "")

type TodoList() =
    let mutable items = []
    let mutable showCompleted = true

    member this.NewItem(task) =
        let item = new TodoItem(Task=task)
        items <- item :: items
        item
    member this.ToggleShowCompleted() = showCompleted <- not showCompleted

    member this.Items =
        if showCompleted then
            items
        else
            items |> List.filter (fun i -> not i.IsDone)

let list = new TodoList()
let buyMilk = list.NewItem("Buy milk")
buyMilk.Task <- "Buy skim milk"
buyMilk
let buyEggs = list.NewItem("Buy eggs")
printfn "List: %A" list.Items
buyMilk.Toggle()
printfn "List: %A" list.Items
list.ToggleShowCompleted()
printfn "List: %A" list.Items