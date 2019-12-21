﻿namespace Interstellar.MacOS.WebKit
open System
open System.Threading
open AppKit
open Interstellar
open Interstellar.MacOS.WebKit.Internal
open Foundation

module BrowserApp =
    let runAsync mainCtx (app: BrowserApp) = async {
        do! Async.SwitchToContext mainCtx
        let windowCreator : BrowserWindowCreator = fun config -> upcast new BrowserWindow(config)
        do! app.onStart mainCtx windowCreator
        do! Async.SwitchToContext mainCtx
    }

    let run app = Async.Start <| runAsync SynchronizationContext.Current app