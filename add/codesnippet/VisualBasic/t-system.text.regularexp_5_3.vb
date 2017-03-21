Imports System
Imports System.Text.RegularExpressions

Public Module Test

    Public Sub Main()
        ' Define a regular expression for repeated words.
        Dim rx As New Regex("\b(?<word>\w+)\s+(\k<word>)\b", _
               RegexOptions.Compiled Or RegexOptions.IgnoreCase)

        ' Define a test string.        
        Dim text As String = "The the quick brown fox  fox jumped over the lazy dog dog."
        
        ' Find matches.
        Dim matches As MatchCollection = rx.Matches(text)

        ' Report the number of matches found.
        Console.WriteLine("{0} matches found in:", matches.Count)
        Console.WriteLine("   {0}", text)

        ' Report on each match.
        For Each match As Match In matches
            Dim groups As GroupCollection = match.Groups
            Console.WriteLine("'{0}' repeated at positions {1} and {2}", _ 
                              groups.Item("word").Value, _
                              groups.Item(0).Index, _
                              groups.Item(1).Index)
        Next
    End Sub
End Module
' The example produces the following output to the console:
'       3 matches found in:
'          The the quick brown fox  fox jumped over the lazy dog dog.
'       'The' repeated at positions 0 and 4
'       'fox' repeated at positions 20 and 25
'       'dog' repeated at positions 50 and 54