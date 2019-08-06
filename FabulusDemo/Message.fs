module Message

open System

type Msg = 
    | Add 
    | Remove of Guid
    | MarkComplete of Guid
    | MarkIncomplete of Guid
    | InputTextChanged of string