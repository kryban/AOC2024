## Day 4: Ceres Search
"Looks like the Chief's not here. Next!" 
One of The Historians pulls out a device and pushes the only button on it. 
After a brief flash, you recognize the interior of the Ceres monitoring station!

As the search for the Chief continues, a small Elf who lives on the station tugs on 
your shirt; 
she'd like to know if you could help her with her word search (your puzzle input). S
he only has to find one word: XMAS.

This word search allows words to be horizontal, vertical, diagonal, 
written backwards, or even overlapping other words. 
's a little unusual, though, as you don't merely need to find one instance of XMAS
you need to find all of them. 
Here are a few ways XMAS might appear, where irrelevant characters have 
been replaced with .:


`..X...`</br>
`.SAMX.`</br>
`.A..A.`</br>
`XMAS.S`</br>
`.X....`</br>
The actual word search will be full of letters instead. For example:

`MMMSXXMASM`</br>
`MSAMXMSMSA`</br>
`AMXSXMAAMM`</br>
`MSAMASMSMX`</br>
`XMASAMXAMM`</br>
`XXAMMXXAMA`</br>
`SMSMSASXSS`</br>
`SAXAMASAAA`</br>
`MAMMMXMMMM`</br>
`MXMXAXMASX`</br>
In this word search, XMAS occurs a total of 18 times; 
here's the same word search again, 
but where letters not involved in any XMAS have been replaced with .:

`....XXMAS.`</br>
`.SAMXMS...`</br>
`...S..A...`</br>
`..A.A.MS.X`</br>
`XMASAMX.MM`</br>
`X.....XA.A`</br>
`S.S.S.S.SS`</br>
`.A.A.A.A.A`</br>
`..M.M.M.MM`</br>
`.X.X.XMASX`</br>

hv = 3 </br>
ha = 2 </br>
vv = 1 </br>
va = 2 </br>
drv = 1 </br>
dra = 4 </br>
dlv = 1 </br>
dla = 4 </br>

Take a look at the little Elf's word search. How many times does XMAS appear?

## Part Two
The Elf looks quizzically at you. Did you misunderstand the assignment?

Looking for the instructions, you flip over the word search to find that this isn't actually 
an XMAS puzzle; it's an X-MAS puzzle in which you're supposed to find two MAS in the 
shape of an X. One way to achieve that is like this:

`M.S`</br>
`.A.`</br>
`M.S`</br>

Irrelevant characters have again been replaced with . in the above diagram. 
Within the X, each MAS can be written forwards or backwards.

Here's the same example from before, 
but this time all of the X-MASes have been kept instead:

`.M.S......`</br>
`..A..MSMS.`</br>
`.M.S.MAA..`</br>
`..A.ASMSM.`</br>
`.M.S.M....`</br>
`..........`</br>
`S.S.S.S.S.`</br>
`.A.A.A.A..`</br>
`M.M.M.M.M.`</br>
`..........`</br>
In this example, an X-MAS appears 9 times.

Flip the word search from the instructions back over to the word 
search side and try again. How many times does an X-MAS appear?