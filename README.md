# qutest

Comments:

Matrix is converted to a list of words (horizontal + vertical) for simplicity and to search the words faster.

Each word of the wordstream is searched in the list of words derived from the matrix in a performant way. If there are any occurrences for the word, a method checks
if it has to be included in the top ten list and adds it.

For the sake of simplicity, only ten words are included in the top ten. It means that words with the same amount of occurrences than the last one won't be included.
