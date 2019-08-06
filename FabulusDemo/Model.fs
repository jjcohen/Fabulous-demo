module Model

open System

type TodoID = Guid

type Status = 
    | Todo
    | Complete

type Todo =
    { Content : string
      Status   : Status }

type Model = 
    { Todos          : Map<TodoID, Todo>
      TextInputField : string }