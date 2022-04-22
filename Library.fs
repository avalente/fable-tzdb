module Fable.TZDB

open System
open Fable.Core

type TimeZoneName =
    string

type RawTimeZone = 
    {
        name : TimeZoneName
        alternativeName: string
        group: string[]
        continentCode: string
        continentName: string
        countryName: string
        countryCode: string
        mainCities: string[]
        rawOffsetInMinutes: float
        abbreviation: string
        rawFormat: string
    }

type TimeZone = 
    {
        name : TimeZoneName
        alternativeName: string
        group: string[]
        continentCode: string
        continentName: string
        countryName: string
        countryCode: string
        mainCities: string[]
        rawOffsetInMinutes: float
        abbreviation: string
        rawFormat: string
        currentTimeOffsetInMinutes: float
        currentTimeFormat: string
    }

type TimeZoneOptions =
    {
        includeUtc : bool option
    }

type TZDB =
    abstract getTimeZones: ?opts: TimeZoneOptions -> TimeZone[]
    abstract rawTimeZones : RawTimeZone[]
    abstract timeZonesNames : TimeZoneName[]

[<ImportAll("@vvo/tzdb")>]
let tzdb : TZDB = jsNative
