module View

open Model
open Message
open Fabulous.XamarinForms
open Xamarin.Forms
open System

let todoView dispatch (guid, todo) =

    let button todo =
        match todo.Status with
        | Todo ->
            View.Button(text = "Done", command = (fun() -> guid |> MarkComplete |> dispatch ))
        | Complete ->
            View.Button(text = "Not done", command = (fun() -> guid |> MarkIncomplete |> dispatch ))

    View.StackLayout(
        orientation = StackOrientation.Horizontal,
        children = [
            View.Label(text = todo.Content)
            button todo
            View.Button(text = "Remove", command = (fun() -> guid |> Remove |> dispatch))
        ]
    )

let todosToListView dispatch (todos:Map<Guid, Todo>) =
    todos
    |> Map.toList
    |> List.map (todoView dispatch)

let view (model: Model) dispatch =
    View.ContentPage(
        content = View.StackLayout(padding = 20.0, verticalOptions = LayoutOptions.Center,
        children = [
            View.Label(text = "My todos")
            View.Entry(textChanged = (fun t -> t.NewTextValue |> InputTextChanged |> dispatch ))
            View.Button(text = "Add", command = (fun () -> Add |> dispatch))
            View.ListView(items = todosToListView dispatch model.Todos)
        ]))