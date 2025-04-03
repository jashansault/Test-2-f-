// Define the discriminated union for Genre
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Define the Director record type
type Director = {
    Name: string
    Movies: int
}

// Define the Movie record type
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

// Create director instances
let sianHeder = { Name = "Sian Heder"; Movies = 9 }
let kennethBranagh = { Name = "Kenneth Branagh"; Movies = 23 }
let adamMcKay = { Name = "Adam McKay"; Movies = 27 }
let ryusukeHamaguchi = { Name = "Ryusuke Hamaguchi"; Movies = 16 }
let denisVilleneuve = { Name = "Denis Villeneuve"; Movies = 24 }
let reinaldoGreen = { Name = "Reinaldo Marcus Green"; Movies = 15 }
let paulAnderson = { Name = "Paul Thomas Anderson"; Movies = 49 }
let guillermoDelToro = { Name = "Guillermo Del Toro"; Movies = 22 }

// Create movie instances according to the table
let movies = [
    { Name = "CODA"; RunLength = 111; Genre = Drama; Director = sianHeder; IMDBRating = 8.1 }
    { Name = "Belfast"; RunLength = 98; Genre = Comedy; Director = kennethBranagh; IMDBRating = 7.3 }
    { Name = "Don’t Look Up"; RunLength = 138; Genre = Comedy; Director = adamMcKay; IMDBRating = 7.2 }
    { Name = "Drive My Car"; RunLength = 179; Genre = Drama; Director = ryusukeHamaguchi; IMDBRating = 7.6 }
    { Name = "Dune"; RunLength = 155; Genre = Fantasy; Director = denisVilleneuve; IMDBRating = 8.1 }
    { Name = "King Richard"; RunLength = 144; Genre = Sport; Director = reinaldoGreen; IMDBRating = 7.5 }
    { Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy; Director = paulAnderson; IMDBRating = 7.4 }
    { Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller; Director = guillermoDelToro; IMDBRating = 7.1 }
]

// Filter movies with IMDB Rating > 7.4
let probableOscarWinners = 
    movies 
    |> List.filter (fun movie -> movie.IMDBRating > 7.4)

// Convert run length to "Xh Ymin" format
let convertRunLength (minutes: int) =
    let hours = minutes / 60
    let remainingMinutes = minutes % 60
    $"{hours}h {remainingMinutes}min"

// Apply conversion to all movies
let moviesWithConvertedRunLength = 
    movies 
    |> List.map (fun movie -> convertRunLength movie.RunLength)

// Print probable Oscar winners
printfn "Probable Oscar Winners (IMDB Rating > 7.4):"
probableOscarWinners 
|> List.iter (fun movie -> printfn "- %s (%.1f)" movie.Name movie.IMDBRating)

// Print converted run lengths
printfn "\nMovies with Converted Run Lengths:"
movies 
|> List.iter (fun movie -> 
    let converted = convertRunLength movie.RunLength
    printfn "- %s: %s" movie.Name converted)