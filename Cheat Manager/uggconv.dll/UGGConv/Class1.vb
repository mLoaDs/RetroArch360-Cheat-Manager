Public Class UGGconv
    'This is a coversion of the UGGConverter Opensource App Functions Converted from C.
    'These Functions make up the bulk of the app. Technichally they are rewritten
    'By me, but I didnt do the original work.
    'Tested working, and ported by Gavin_Darkglider
	'Original Work Done by WyrmCorp

    ' Required C function replacements    
    ' Created By Code converter, Fixed by Gavin_Darkglider
    ' These functions work for this application, and probably
    ' will not for others in the same way as the original C functions,
	' If you decide to use them for another application, I cannot guarantee
	' they will work as the original C version
	
    Private Function IsXDigit(ByVal character As Char) As Boolean
        If Char.IsDigit(character) Then
            Return True
        ElseIf "ABCDEFabcdef".IndexOf(character) > -1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function StrChr(ByVal stringToSearch As String, ByVal charToFind As Char) As Integer
        Dim index As Integer = stringToSearch.IndexOf(charToFind)
        If index > -1 Then
            Return index
        Else
            Return Nothing
        End If
    End Function
    'Game genie conversion Constants.

    Const GAME_GENIE_MAX_STRLEN As Integer = 12
    Const genesisChars As String = "ABCDEFGHJKLMNPRSTVWXYZ0123456789"

    'Utility Functions
    Public Sub testgg()
        'Test GG Functions with set values for comparison. Used UGGConv open source app to generate mem address, and codes.
        'As this is what I converted the code from. Values match 100%
        Dim try1 As String = ""
        gameGenieEncodeGameBoy("3915:C9:35", try1)
        MsgBox(try1 & "=C99-15C-3BE", , "Game Boy Encode Test")
        gameGenieDecodeGameBoy("C99-15C-3BE", try1)
        MsgBox(try1 & "=3915:C9:35", , "Game Boy Decode Test")
        try1 = ""
        gameGenieEncodeMegadrive("010024:6754", try1)
        MsgBox(try1 & "=LTAA-CR3E", , "Genesis Encode Test")
        gameGenieDecodeMegadrive("LTAA-CR3E", try1)
        MsgBox(try1 & "=010024:6754", , "Genesis Decode Test")
        try1 = ""
        gameGenieEncodeSNES("0780F7:CF", try1)
        MsgBox(try1 & "=AE6E-DF2A", , "Snes Encode Test")
        gameGenieDecodeSNES("AE6E-DF2A", try1)
        MsgBox(try1 & "=0780F7:CF", , "Snes Decode Test")
        try1 = ""
        gameGenieEncodeNES("E0A8:01:03", try1)
        MsgBox(try1 & "=PEZVAALA", , "nes Encode Test")
        try1 = ""
        gameGenieDecodeNES("PEZVAALA", try1)
        MsgBox(try1 & "=E0A8:01:03", , "nes Decode Test")
    End Sub
    Private Function hexDigit(ByVal value As Integer) As String
        ' Get Decimal bit value, and convert it in to a Hexadecimal bit
        ' 0 - F 
        Select Case UCase(value)
            Case 0
                Return "0"
            Case 1
                Return "1"
            Case 2
                Return "2"
            Case 3
                Return "3"
            Case 4
                Return "4"
            Case 5
                Return "5"
            Case 6
                Return "6"
            Case 7
                Return "7"
            Case 8
                Return "8"
            Case 9
                Return "9"
            Case 10
                Return "A"
            Case 11
                Return "B"
            Case 12
                Return "C"
            Case 13
                Return "D"
            Case 14
                Return "E"
            Case 15
                Return "F"
        End Select
        Return "-1"
    End Function

    Private Function hexValue(ByVal digit As String) As Integer
        'Convert Hex Value to String. NES uses Decimal Value, where all other
        'Functions use Hex value. This acomadates for both
        Select Case UCase(digit)
            Case "0"
                Return 0
            Case "1"
                Return 1
            Case "2"
                Return 2
            Case "3"
                Return 3
            Case "4"
                Return 4
            Case "5"
                Return 5
            Case "6"
                Return 6
            Case "7"
                Return 7
            Case "8"
                Return 8
            Case "9"
                Return 9
            Case "A", "10"
                Return 10
            Case "B", "11"
                Return 11
            Case "C", "12"
                Return 12
            Case "D", "13"
                Return 13
            Case "E", "14"
                Return 14
            Case "F", "15"
                Return 15
        End Select
        Return -1
    End Function

    Private Function hexByteValue(ByVal x As String, ByVal y As String) As Integer
        'Creates hex byte from value x and value y. eg. FF AF 10 ....
        Return (hexValue(x) << 4) + hexValue(y)
    End Function


    '********************************************************************
    ' *
    ' * SNES ROUTINES
    ' * Converted, Finished And Working :)
    ' * gameGenieDecodeSNES(ByVal gin As String, ByRef out As String) Get Memory Address from GG
    ' * gameGenieEncodeSNES(ByVal gin As String, ByRef out As String) Create GG From Memory Address
    ' *******************************************************************

    Private Function mapSnesChar(ByVal hex As String) As String
        'Create Propper Character for hex value for Game Genie code
        ' on SNES
        Select Case Char.ToUpper(hex)
            Case "0"
                Return "D"
            Case "1"
                Return "F"
            Case "2"
                Return "4"
            Case "3"
                Return "7"
            Case "4"
                Return "0"
            Case "5"
                Return "9"
            Case "6"
                Return "1"
            Case "7"
                Return "5"
            Case "8"
                Return "6"
            Case "9"
                Return "B"
            Case "A"
                Return "C"
            Case "B"
                Return "8"
            Case "C"
                Return "A"
            Case "D"
                Return "2"
            Case "E"
                Return "3"
            Case "F"
                Return "E"
            Case Else
        End Select
        Return "-1"
    End Function

    Private Function unmapSnesChar(ByVal genie As String) As String
        'Create hex value for Game Genie code SNES
        'Character for hex value 
        Select Case Char.ToUpper(genie)
            Case "D"
                Return "0"
            Case "F"
                Return "1"
            Case "4"
                Return "2"
            Case "7"
                Return "3"
            Case "0"
                Return "4"
            Case "9"
                Return "5"
            Case "1"
                Return "6"
            Case "5"
                Return "7"
            Case "6"
                Return "8"
            Case "B"
                Return "9"
            Case "C"
                Return "A"
            Case "8"
                Return "B"
            Case "A"
                Return "C"
            Case "2"
                Return "D"
            Case "3"
                Return "E"
            Case "E"
                Return "F"
            Case Else
        End Select
        Return "-1"
    End Function




    Public Function gameGenieDecodeSNES(ByVal gin As String, ByRef out As String) As Integer
        'Converts Gamegenie code to ROM Address
        'The Snes Proaction replay can use these addressses as codes.

        Dim value As Integer
        Dim address As Integer
        Dim transposed As Integer

        'If Not IsXDigit(gin.Chars(0)) OrElse Not IsXDigit(gin.Chars(1)) OrElse Not IsXDigit(gin.Chars(2)) OrElse Not IsXDigit(gin.Chars(3)) OrElse gin.Chars(4) <> "-" OrElse Not IsXDigit(gin.Chars(5)) OrElse Not IsXDigit(gin.Chars(6)) OrElse Not IsXDigit(gin.Chars(7)) OrElse Not IsXDigit(gin.Chars(8)) OrElse AscW(gin.Chars(9)) <> 0 Then
        'Return -1
        'End If

        value = hexByteValue(unmapSnesChar(gin.Chars(0)), unmapSnesChar(gin.Chars(1)))

        transposed = hexValue(unmapSnesChar(gin.Chars(8))) + (hexValue(unmapSnesChar(gin.Chars(7))) << 4) + (hexValue(unmapSnesChar(gin.Chars(6))) << 8) + (hexValue(unmapSnesChar(gin.Chars(5))) << 12) + (hexValue(unmapSnesChar(gin.Chars(3))) << 16) + (hexValue(unmapSnesChar(gin.Chars(2))) << 20)

        address = 0
        address = address Or (((transposed And (&HC00000 >> (2 * 0))) << (2 * 0)) >> (2 * 4))
        address = address Or (((transposed And (&HC00000 >> (2 * 1))) << (2 * 1)) >> (2 * 5))
        address = address Or (((transposed And (&HC00000 >> (2 * 2))) << (2 * 2)) >> (2 * 8))
        address = address Or (((transposed And (&HC00000 >> (2 * 3))) << (2 * 3)) >> (2 * 9))
        address = address Or (((transposed And (&HC00000 >> (2 * 4))) << (2 * 4)) >> (2 * 7))
        address = address Or (((transposed And (&HC00000 >> (2 * 5))) << (2 * 5)) >> (2 * 0))
        address = address Or (((transposed And (&HC00000 >> (2 * 6))) << (2 * 6)) >> (2 * 1))
        address = address Or (((transposed And (&HC00000 >> (2 * 7))) << (2 * 7)) >> (2 * 10))
        address = address Or (((transposed And (&HC00000 >> (2 * 8))) << (2 * 8)) >> (2 * 11))
        address = address Or (((transposed And (&HC00000 >> (2 * 9))) << (2 * 9)) >> (2 * 2))
        address = address Or (((transposed And (&HC00000 >> (2 * 10))) << (2 * 10)) >> (2 * 3))
        address = address Or (((transposed And (&HC00000 >> (2 * 11))) << (2 * 11)) >> (2 * 6))
        out = String.Format("{0:X6}:{1:X2}", address, value)
        Return 0
    End Function

    Public Function gameGenieEncodeSNES(ByVal gin As String, ByRef out As String) As Integer
        'Create Game Genie code for SNES from Action Replay Code, or From ROM address
        'Snes is the only system this will work for.
        Dim value As Integer
        Dim address As Integer
        Dim transposed As Integer
        'If Not IsXDigit(gin.Chars(0)) OrElse Not IsXDigit(gin.Chars(1)) OrElse Not IsXDigit(gin.Chars(2)) OrElse Not IsXDigit(gin.Chars(3)) OrElse Not IsXDigit(gin.Chars(4)) OrElse Not IsXDigit(gin.Chars(5)) OrElse gin.Chars(6) <> ":" OrElse Not IsXDigit(gin.Chars(7)) OrElse Not IsXDigit(gin.Chars(8)) OrElse IsXDigit(gin.Chars(9)) <> 0 Then
        'Return -1
        'End If
        value = hexByteValue(mapSnesChar(gin.Chars(7)), mapSnesChar(gin.Chars(8)))
        Dim address1() As String = Split(gin, ":"), address2 As String = " "
        address2 = address1(0)

        address = Convert.ToInt32(address2, 16)
        transposed = 0
        transposed = transposed Or (((address And (&HC00000 >> (2 * 4))) << (2 * 4)) >> (2 * 0))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 5))) << (2 * 5)) >> (2 * 1))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 8))) << (2 * 8)) >> (2 * 2))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 9))) << (2 * 9)) >> (2 * 3))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 7))) << (2 * 7)) >> (2 * 4))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 0))) << (2 * 0)) >> (2 * 5))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 1))) << (2 * 1)) >> (2 * 6))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 10))) << (2 * 10)) >> (2 * 7))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 11))) << (2 * 11)) >> (2 * 8))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 2))) << (2 * 2)) >> (2 * 9))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 3))) << (2 * 3)) >> (2 * 10))
        transposed = transposed Or (((address And (&HC00000 >> (2 * 6))) << (2 * 6)) >> (2 * 11))
        out = String.Format("{0:X2}{1}{2}-{3}{4}{5}{6}", value, mapSnesChar(hexDigit((transposed And &HF00000) >> 20)), mapSnesChar(hexDigit((transposed And &HF0000) >> 16)), mapSnesChar(hexDigit((transposed And &HF000) >> 12)), mapSnesChar(hexDigit((transposed And &HF00) >> 8)), mapSnesChar(hexDigit((transposed And &HF0) >> 4)), mapSnesChar(hexDigit((transposed And &HF))))

        Return 0
    End Function

    '********************************************************************
    ' *
    ' * NES ROUTINES Finished. Appear to be working
    ' * gameGenieDecodeNES(ByVal gin As String, ByRef out As String) As Integer - Find Memory Address
    ' * gameGenieEncodeNES(ByVal gin As String, ByRef out As String) As Integer -Create from memory address
    ' * Finished and Working :)
    ' *******************************************************************

    Private Function mapNesChar(ByVal hex As String) As String
        Select Case Char.ToUpper(hex)
            Case "0"
                Return "A"
            Case "1"
                Return "P"
            Case "2"
                Return "Z"
            Case "3"
                Return "L"
            Case "4"
                Return "G"
            Case "5"
                Return "I"
            Case "6"
                Return "T"
            Case "7"
                Return "Y"
            Case "8"
                Return "E"
            Case "9"
                Return "O"
            Case "A"
                Return "X"
            Case "B"
                Return "U"
            Case "C"
                Return "K"
            Case "D"
                Return "S"
            Case "E"
                Return "V"
            Case "F"
                Return "N"
            Case Else
        End Select
        Return ""
    End Function

    Private Function unmapNesChar(ByVal genie As String) As SByte
        Select Case Char.ToUpper(genie)
            Case "A"
                Return "0"
            Case "P"
                Return "1"
            Case "Z"
                Return "2"
            Case "L"
                Return "3"
            Case "G"
                Return "4"
            Case "I"
                Return "5"
            Case "T"
                Return "6"
            Case "Y"
                Return "7"
            Case "E"
                Return "8"
            Case "O"
                Return "9"
            Case "X"
                Return "10"
            Case "U"
                Return "11"
            Case "K"
                Return "12"
            Case "S"
                Return "13"
            Case "V"
                Return "14"
            Case "N"
                Return "15"
        End Select
        Return ""
    End Function

    Private Function isNesChar(ByVal c As String) As Integer
        If Not InStr("APZLGITYEOXUKSVN-", Char.ToUpper(c)) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function gameGenieDecodeNES(ByVal gin As String, ByRef out As String) As Integer
        Dim address As Integer = 0
        Dim value As Integer = 0
        Dim check As Integer = 0
        Dim haveCheck As Integer = 0
        Dim data() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Dim i As Integer

        If gin.Length = 8 Then
            haveCheck = 1
        ElseIf gin.Length = 6 Then
            haveCheck = 0
        Else
            Return -1
        End If
        For i = 0 To gin.Length - 1
            If Not isNesChar(gin.Chars(i)) Then
                Return -1
            End If
        Next i

        For i = 0 To 5
            data(i) = hexValue(unmapNesChar(gin.Chars(i)))
        Next i
        If haveCheck <> 0 Then
            data(6) = hexValue(unmapNesChar(gin.Chars(6)))
            data(7) = hexValue(unmapNesChar(gin.Chars(7)))
        End If

        address = &H8000 ' force high bit on
        address = address Or (data(1) And 8) << 4
        address = address Or (data(2) And 7) << 4
        address = address Or (data(3) And 7) << 12
        address = address Or (data(3) And 8) << 0
        address = address Or (data(4) And 7) << 0
        address = address Or (data(4) And 8) << 8
        address = address Or (data(5) And 7) << 8
        If haveCheck <> 0 Then
            value = value Or (data(0) And 7) << 0
            value = value Or (data(0) And 8) << 4
            value = value Or (data(1) And 7) << 4
            value = value Or (data(7) And 8) << 0
            check = check Or (data(6) And 7) << 0
            check = check Or (data(6) And 8) << 0
            check = check Or (data(6) And 8) << 4
            check = check Or (data(7) And 7) << 4
        Else
            value = value Or (data(0) And 7) << 0
            value = value Or (data(0) And 8) << 4
            value = value Or (data(1) And 7) << 4
            value = value Or (data(5) And 8) << 0
        End If

        If haveCheck <> 0 Then
            out = String.Format("{0:X4}:{1:X2}:{2:X2}", address, value, check)
        Else
            out = String.Format("{0:X4}:{1:X2}", address, value)
        End If

        Return 0
    End Function

    Public Function gameGenieEncodeNES(ByVal gin As String, ByRef out As String) As Integer
        Dim address As Integer = &H8000
        Dim value As Integer = 0
        Dim check As Integer = 0
        Dim haveCheck As Integer = 0
        Dim data() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Dim i As Integer

        If gin.Length = 10 AndAlso gin.Chars(4) = ":" AndAlso gin.Chars(7) = ":" Then
            haveCheck = 1
        ElseIf gin.Length = 7 AndAlso gin.Chars(4) = ":" Then
            haveCheck = 0
        Else
            Return -1
        End If
        For i = 0 To gin.Length - 1
            If gin.Chars(i) <> ":" AndAlso Not IsXDigit(gin.Chars(i)) Then
                Return -1
            End If
        Next i
        Dim address1() As String = Split(gin, ":"), address2 As String = " ", Value1 As String = " ", Check1 As String = " "
        If haveCheck <> 0 Then
            address2 = address1(0)
            Value1 = address1(1)
            Check1 = address1(2)
            address = Convert.ToInt32(address2, 16)
            value = Convert.ToInt32(Value1, 16)
            check = Convert.ToInt32(Check1, 16)
        Else
            address2 = address1(0)
            Value1 = address1(1)
            address = Convert.ToInt32(address2, 16)
            value = Convert.ToInt32(Value1, 16)
        End If

        '   Encode address with transposition cipher. 
        '   * Do not encode the high address bit (optional, Galoob isn't
        '   * consistent but usually doesn't.
        '   
        data(1) = data(1) Or (address >> 4) And 8
        data(2) = data(2) Or (address >> 4) And 7
        data(3) = data(3) Or (address >> 12) And 7
        data(3) = data(3) Or (address >> 0) And 8
        data(4) = data(4) Or (address >> 0) And 7
        data(4) = data(4) Or (address >> 8) And 8
        data(5) = data(5) Or (address >> 8) And 7
        If haveCheck <> 0 Then
            data(0) = data(0) Or (value >> 0) And 7
            data(0) = data(0) Or (value >> 4) And 8
            data(1) = data(1) Or (value >> 4) And 7
            data(7) = data(7) Or (value >> 0) And 8
            data(6) = data(6) Or (check >> 0) And 7
            data(6) = data(6) Or (check >> 0) And 8
            data(6) = data(6) Or (check >> 4) And 8
            data(7) = data(7) Or (check >> 4) And 7
        Else
            data(0) = data(0) Or (value >> 0) And 7
            data(0) = data(0) Or (value >> 4) And 8
            data(1) = data(1) Or (value >> 4) And 7
            data(5) = data(5) Or (value >> 0) And 8
        End If

        If haveCheck <> 0 Then
            out = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}", mapNesChar(hexDigit(data(0))), mapNesChar(hexDigit(data(1))), mapNesChar(hexDigit(data(2))), mapNesChar(hexDigit(data(3))), mapNesChar(hexDigit(data(4))), mapNesChar(hexDigit(data(5))), mapNesChar(hexDigit(data(6))), mapNesChar(hexDigit(data(7))))
        Else
            out = String.Format("{0}{1}{2}{3}{4}{5}", mapNesChar(hexDigit(data(0))), mapNesChar(hexDigit(data(1))), mapNesChar(hexDigit(data(2))), mapNesChar(hexDigit(data(3))), mapNesChar(hexDigit(data(4))), mapNesChar(hexDigit(data(5))))
        End If

        Return 0
    End Function

    '********************************************************************
    ' *
    ' * MEGADRIVE/Genesis  ROUTINES
    ' * Finished
    ' ********************************************************************



    Private Function isGenesisChar(ByVal c As String) As Integer
        If Not InStr(genesisChars, Char.ToUpper(c)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function genesisValue(ByVal c As String) As Integer
        Return StrChr(genesisChars, UCase(c)) - genesisChars.Length
    End Function

    Public Function gameGenieDecodeMegadrive(ByVal gin As String, ByRef out As String) As Integer
        Dim address As Integer = 0
        Dim value As Integer = 0
        Dim data(7) As Integer
        Dim i As Integer

        If gin.Length <> 9 OrElse gin.Chars(4) <> "-" Then
            Return -1
        End If
        For i = 0 To 8
            If gin.Chars(i) <> "-" AndAlso Not isGenesisChar(gin.Chars(i)) Then
                Return -1
            End If
        Next i

        For i = 0 To 3
            data(i) = genesisValue(gin.Chars(i))
        Next i
        For i = 5 To 8
            data(i - 1) = genesisValue(gin.Chars(i))
        Next i

        address = 0
        address = address Or (data(3) And &HF) << 20
        address = address Or (data(4) And &H1E) << 15
        address = address Or (data(1) And &H3) << 14
        address = address Or (data(2) And &H1F) << 9
        address = address Or (data(3) And &H10) << 4
        address = address Or (data(6) And &H7) << 5
        address = address Or (data(7) And &H1F)

        value = 0
        value = value Or (data(5) And &H1) << 15
        value = value Or (data(6) And &H18) << 10
        value = value Or (data(4) And &H1) << 12
        value = value Or (data(5) And &H1E) << 7
        value = value Or (data(0) And &H1F) << 3
        value = value Or (data(1) And &H16) >> 2

        out = String.Format("{0:X6}:{1:X4}", address, value)

        Return 0
    End Function

    Public Function gameGenieEncodeMegadrive(ByVal gin As String, ByRef out As String) As Integer
        Dim address As Integer = 0
        Dim value As Integer = 0
        Dim data() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Dim i As Integer

        If gin.Length <> 11 OrElse gin.Chars(6) <> ":" Then
            Return -1
        End If
        For i = 0 To 10
            If gin.Chars(i) <> ":" AndAlso Not IsXDigit(gin.Chars(i)) Then
                Return -1
            End If
        Next i

        Dim address1() As String = Split(gin, ":"), address2 As String = " "
        address2 = address1(0)
        value = Convert.ToInt32(address1(1), 16)

        address = Convert.ToInt32(address2, 16)

        data(3) = data(3) Or (address >> 20) And &HF
        data(4) = data(4) Or (address >> 15) And &H1E
        data(1) = data(1) Or (address >> 14) And &H3
        data(2) = data(2) Or (address >> 9) And &H1F
        data(3) = data(3) Or (address >> 4) And &H10
        data(6) = data(6) Or (address >> 5) And &H7
        data(7) = data(7) Or (address And &H1F)

        data(5) = data(5) Or (value >> 15) And &H1
        data(6) = data(6) Or (value >> 10) And &H18
        data(4) = data(4) Or (value >> 12) And &H1
        data(5) = data(5) Or (value >> 7) And &H1E
        data(0) = data(0) Or (value >> 3) And &H1F
        data(1) = data(1) Or (value << 2) And &H16

        For i = 0 To 3
            out &= genesisChars.Chars(data(i))
        Next i
        out &= "-"
        For i = 5 To 8
            out &= genesisChars.Chars(data(i - 1))
        Next i
        out = out.Substring(0, 9)

        Return 0
    End Function

    '********************************************************************
    ' *
    ' * GAME BOY / GAME GEAR  ROUTINES
    ' *
    ' ********************************************************************

    Public Function gameGenieDecodeGameBoy(ByVal gin As String, ByRef out As String) As Integer
        Dim address As Integer = 0
        Dim value As Integer = 0
        Dim check As Integer = 0
        Dim haveCheck As Integer = 0
        Dim i As Integer

        If gin.Length = 11 AndAlso gin.Chars(3) = "-" AndAlso gin.Chars(7) = "-" Then
            haveCheck = 1
        ElseIf gin.Length = 7 AndAlso gin.Chars(3) = "-" Then
            haveCheck = 0
        Else
            Return -1
        End If
        For i = 0 To gin.Length - 1
            If gin.Chars(i) <> "-" AndAlso Not IsXDigit(gin.Chars(i)) Then
                Return -1
            End If
        Next i
        If hexValue(gin.Chars(6)) < 8 Then
            Return -1
        End If

        value = hexByteValue(gin.Chars(0), gin.Chars(1))

        address = (hexValue(gin.Chars(2)) << 8) Or (hexValue(gin.Chars(4)) << 4) Or hexValue(gin.Chars(5)) Or ((Not hexValue(gin.Chars(6)) And &HF) << 12)

        If haveCheck <> 0 Then
            check = hexByteValue(gin.Chars(8), gin.Chars(10))
            check = Not check
            check = (((check And &HFC) >> 2) Or ((check And &H3) << 6)) Xor &H45
            out = String.Format("{0:X4}:{1:X2}:{2:X2}", address, value, check)
        Else
            out = String.Format("{0:X4}:{1:X2}", address, value)
        End If

        Return 0
    End Function

    Public Function gameGenieEncodeGameBoy(ByVal Gin As String, ByRef out As String) As Integer
        Dim address As Integer = 0
        Dim value As Integer = 0
        Dim check As Integer = 0
        Dim haveCheck As Integer = 0
        Dim i As Integer

        If Gin.Length = 10 AndAlso Gin.Chars(4) = ":" AndAlso Gin.Chars(7) = ":" Then
            haveCheck = 1
        ElseIf Gin.Length = 7 AndAlso Gin.Chars(4) = ":" Then
            haveCheck = 0
        Else
            Return -1
        End If
        For i = 0 To Gin.Length - 1
            If Gin.Chars(i) <> ":" AndAlso Not IsXDigit(Gin.Chars(i)) Then
                Return -1
            End If
        Next i
        If hexValue(Gin.Chars(0)) > 7 Then
            Return -1
        End If

        out = UCase(Gin.Chars(5)) & UCase(Gin.Chars(6)) & UCase(Gin.Chars(1)) & "-" & UCase(Gin.Chars(2)) & UCase(Gin.Chars(3)) & hexDigit(Not hexValue(Gin.Chars(0)) And &HF)
        out = out.Substring(0, 7)

        If haveCheck <> 0 Then
            check = hexByteValue(Gin.Chars(7), Gin.Chars(9))
            check = Not check
            check = (((check And &HFC) >> 2) Or ((check And &H3) << 6)) Xor &H45

            check = hexByteValue(Gin.Chars(8), Gin.Chars(9))
            check = check Xor &H45
            check = Not (((check And &HC0) >> 6) Or ((check And &H3F) << 2))
            i = (check And &HF0) >> 4
            out = out & "-" & hexDigit(i And &HF) & hexDigit((i Xor 8) And &HF) & hexDigit(check And &HF)
            out = out.Substring(0, 11)
        End If

        Return 0
    End Function

End Class
