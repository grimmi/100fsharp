(*
#Task: Write a function get_honor which accepts a username from someone at Codewars and returns an integer containing the user's honor. If input is invalid, raise an error.

###If you want/don't want your username to be in the tests, ask me in the discourse area. There can't be too many though because the server may time out.

#Example¹:

>>> get_honor('dpleshkov')
4418
>>> get_honor('jhoffner')
21949
F# examples
>>> GetHonor('dpleshkov')
4418
>>> GetHonor('jhoffner')
21949
¹ Honor may or may not be current to the user

#Libraries/Recommendations:

Fsharp:

open System.Net: use this namespace for opening a webpage(It's just a suggestion).
open System.Text.RegularExpressions: this namepsace will give you access to Regex.
##Python:

urllib.request.urlopen: Opens up a webpage.
re: The RegEx library for Python.
bs4(BeautifulSoup): A tool for scraping HTML and XML.
#Notes:

While this kata is in beta, please vote on it and give your rank assessment.
Feel free to voice your comments and concerns in the discourse area.
There is no example tests. Sorry, the honor may vary from time to time. I apologize for the inconvenience.

taken from: https://www.codewars.com/kata/58a9cff7ae929e4ad1000050/train/fsharp
*)

open System.Net
open System.Text.RegularExpressions

let GetHonor username =
    let pattern = "(onor:</b>)([\d]+)";
    use client = new WebClient()
    let cwText = client.DownloadString(sprintf "https://www.codewars.com/users/%s" username)
    let r = Regex(pattern, RegexOptions.IgnoreCase)

    let matches = r.Matches cwText
    let group = (matches.Item 0).Groups.[2]
    group.Value |> int

let x = GetHonor "arlegrim"