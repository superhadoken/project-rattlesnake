#load "Library1.fs"
open project.rattlesnake.data
open System.IO
open System

type Observation = { Date:DateTime; HomeTeam: string; AwayTeam: string; HomeGoals: int; AwayGoals: int}

let toObservation (csvData:string) = 
    let columns = csvData.Split(',')
    let date = columns.[0]
    let homeTeam = columns.[1]
    let awayTeam = columns.[2]
    let homeGoals = columns.[3]
    let awayGoals = columns.[4]
    {Date=DateTime.Parse(date); HomeTeam=homeTeam; AwayTeam=awayTeam; HomeGoals=Convert.ToInt32(homeGoals); AwayGoals=Convert.ToInt32(awayGoals);}

let reader path =
    let data = File.ReadAllLines path
    data.[1..]
    |> Array.map toObservation

let trainingPath = @"C:\Users\Chris Hey\Documents\Projects\Git\project-rattlesnake\data\TestSample.csv"
let trainingData = reader trainingPath