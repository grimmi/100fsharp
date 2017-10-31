type EpisodeInfo = { name: string; show: string; season: int; number: int; aired: string }
type MovieInfo = { name: string; year: int }

type Video =
|Episode of EpisodeInfo
|Movie of MovieInfo

let printMovie movie =
    printfn "%s (%d)" movie.name movie.year

let printEpisode episode =
    printfn "[%dx%d] %s - %s (%s)" episode.season episode.number episode.show episode.name episode.aired

let printVideo video =
    match video with
    |Episode e -> printEpisode e
    |Movie m -> printMovie m


let movie = Movie({ name = "Predator"; year = 1980 })
let episode = Episode({ name = "Pilot"; show = "HIMYM"; season = 1; number = 1; aired = "2007-05-03"})

printVideo movie
printVideo episode
