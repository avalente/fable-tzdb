# Fable.TZDB 

This is a Fable wrapper for the [tzdb](https://github.com/vvo/tzdb/) library. 

### Usage

1. Add the nuget package `Fable.TZDB`, e.g. using `paket` as a dotnet tool:

    ```
    dotnet paket add Fable.TZDB -p <your fable project>.fsproj
    ```

1. Add the npm dependency, e.g.:

    ```
    npm add @vvo/tzdb
    ```

1. In your F# source file open the namespace:

    ```lang=fsharp
    open Fable.TZDB
    ```

1. Use the `tzdb` object:
    ```lang=fsharp
    let timeZones = tzdb.getTimeZones()
    let tz = timeZones |> Array.find (fun x -> x.name = "Europe/Rome")
    console.log(tz)
    ```

    the code above generates an output similar to:

    ```lang=javascript
    {name: 'Europe/Rome', alternativeName: 'Central European Time', group: Array(1), continentCode: 'EU', continentName: 'Europe', …}
    abbreviation: "CET"
    alternativeName: "Central European Time"
    continentCode: "EU"
    continentName: "Europe"
    countryCode: "IT"
    countryName: "Italy"
    currentTimeFormat: "+02:00 Central European Time - Rome, Milan, Naples, Turin"
    currentTimeOffsetInMinutes: 120
    group: ['Europe/Rome']
    mainCities: (4) ['Rome', 'Milan', 'Naples', 'Turin']
    name: "Europe/Rome"
    rawFormat: "+01:00 Central European Time - Rome, Milan, Naples, Turin"
    rawOffsetInMinutes: 60
    [[Prototype]]: Object
    ```

### Create the package

To create the package in debug mode (used by the example) just issue on the command line:

```
dotnet pack
```

To create the package in release mode:

```
dotnet pack -c Release
```

#### Example

A working example can be found in the `example` directory. Refer to its `README` file for further informations.
