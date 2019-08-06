module Update

open Model
open Message
open Fabulous
open System

let update msg model =
    let updateStatus guid status =
        let existingTodo = Map.find guid model.Todos 
        let updatedTodo = { existingTodo with Status = status }
        let updatedTodos = Map.add guid updatedTodo model.Todos
        { model with Todos = updatedTodos }
    
    match msg with
    | Add ->
        let newID = (Guid.NewGuid())
        let newItem =
            { Content = model.TextInputField
              Status  = Status.Todo } 
        { model with Todos = Map.add newID newItem model.Todos  }, Cmd.none
    | Remove guid ->
        let newTodos = Map.remove guid model.Todos
        { model with Todos = newTodos }, Cmd.none
    | MarkComplete guid ->
        updateStatus guid Status.Complete, Cmd.none
    | MarkIncomplete guid ->
        updateStatus guid Status.Todo, Cmd.none
    | InputTextChanged text ->
        {model with TextInputField = text}, Cmd.none