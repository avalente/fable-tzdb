module App

open Browser.Dom
open Fable.TZDB
open Browser
open Browser.Types
open Fable.Core.JsInterop

let addToDL (key : string) (value : 't) (dl : Element) =
    let k = document.createElement "dt"
    k.innerText <- key
    dl.appendChild k |> ignore

    let v = document.createElement "dd"
    v.innerText <- string value
    dl.appendChild v |> ignore

let body = document.querySelector("body")

let h = document.createElement "h1"
h.innerHTML <- "TZDB bindings example"
body.appendChild h |> ignore

let p = document.createElement "p"
p.innerHTML <- sprintf "There are %d time zones available" tzdb.timeZonesNames.Length
body.appendChild p |> ignore

let i = document.createElement "input" :?> HTMLInputElement
i.placeholder <- "Type to search"
i.autofocus <- true
i.onkeyup <- (fun ev -> 
    let target = ev.target :?> HTMLInputElement
    let text = target.value
    let zones = tzdb.getTimeZones() |> Array.filter(fun x -> x.name.ToLower().Contains(text.ToLower()))
    let list = document.querySelector("ul")
    list.innerHTML <- ""
    for z in zones do
        let x = document.createElement "li"
        x?style?cursor <- "pointer"
        x.onclick <- (fun _ ->
            let dl = document.querySelector "dl"
            dl.innerHTML <- ""
            dl |> addToDL "name" z.name
            dl |> addToDL "abbreviation" z.abbreviation
            dl |> addToDL "alternativeName" z.alternativeName
            dl |> addToDL "group" z.group
            dl |> addToDL "continentCode" z.continentCode
            dl |> addToDL "continentName" z.continentName
            dl |> addToDL "countryName" z.countryName
            dl |> addToDL "countryCode" z.countryCode
            dl |> addToDL "mainCities" z.mainCities
            dl |> addToDL "rawOffsetInMinutes" z.rawOffsetInMinutes
            dl |> addToDL "rawFormat" z.rawFormat
            dl |> addToDL "currentTimeOffsetInMinutes" z.currentTimeOffsetInMinutes
            dl |> addToDL "currentTimeFormat" z.currentTimeFormat
        )
        x.innerText <- z.name
        list.appendChild x |> ignore

)
body.appendChild i |> ignore

let c = document.createElement "div"
c?style?margin <- "5px 0 0 0"
c?style?display <- "flex"

let d = document.createElement("div")
d?style?border <- "solid 1px lightgrey"
d?style?height <- "400px"
d?style?width <- "400px"
d?style?overflow <- "auto"

let l = document.createElement("ul")
d.appendChild l |> ignore
c.appendChild d |> ignore

let d' = document.createElement "div"
d'?style?border <- "solid 1px lightgrey"
d'?style?height <- "400px"
d'?style?width <- "400px"
d'?style?overflow <- "auto"
d'?style?padding <- "0 0 0 10px"
let v = document.createElement("dl")
d'.appendChild v |> ignore
c.appendChild d' |> ignore

body.appendChild c |> ignore
