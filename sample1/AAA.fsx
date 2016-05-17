let rnd = System.Random()
let dice sides = rnd.Next(1, sides+1)

type Unit = 
    | Fighter 
    | Bomber 
    | HeavyBomber 
    | Artillery 
    | Infantry 
    | Tank 
    | Truck 
    | Battleship 
    | Destroyer 
    | Submarine 
    | Transport

let attack unit = 
    match unit with
    | Fighter -> 3
    | Bomber -> 4
    | HeavyBomber -> 4
    | Artillery -> 1
    | Infantry -> 1
    | Tank -> 3
    | Battleship -> 4
    | Destroyer -> 3
    | Submarine -> 1
    | _ -> 0

let attack_hit unit = (dice 6) <= (attack unit)
let attack_hits units = units |> List.filter (fun u -> (attack_hit u)) |> List.length

let defense unit = 
    match unit with
    | Fighter -> 4
    | Bomber -> 1
    | HeavyBomber -> 1
    | Artillery -> 1
    | Infantry -> 2
    | Tank -> 2
    | Battleship -> 4
    | Destroyer -> 3
    | Submarine -> 1
    | _ -> 0

let defense_hit unit = (dice 6) <= (defense unit)
let defense_hits units = units |> List.filter (fun u -> (defense_hit u)) |> List.length

let battle attackers defenders = (attack_hits attackers, defense_hits defenders)
