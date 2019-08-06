// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace FabulusDemo

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module App = 
    open Update
    open View
    open Model

    let initModel =
        { Todos = Map.empty
          TextInputField = "" }

    let init () = initModel, Cmd.none

    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app