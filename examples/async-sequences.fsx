#r "nuget: FSharp.Control.AsyncSeq, 3.2.1"
open FSharp.Control

let countTo n =
    asyncSeq {
        for i in 1..n do
            yield i
    }

let delayEach (ms:int) (source: AsyncSeq<_>) =
    asyncSeq {
        for i in source do
            do! Async.Sleep(ms)
            yield i
    }

countTo 10
|> delayEach 100
|> AsyncSeq.iter (fun i -> printfn "%d" i)
|> Async.StartAsTask
