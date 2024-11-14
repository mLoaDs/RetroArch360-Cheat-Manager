Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

Module modHash
    ' Function to obtain the desired hash of a file

    Function hash_generator(ByVal hash_type As String, ByVal file_name As String)

        ' We declare the variable : hash
        Dim hash
        If hash_type.ToLower = "md5" Then
            ' Initializes a md5 hash object
            hash = MD5.Create
        ElseIf hash_type.ToLower = "sha1" Then
            ' Initializes a SHA-1 hash object
            hash = SHA1.Create()
        ElseIf hash_type.ToLower = "sha256" Then
            ' Initializes a SHA-256 hash object
            hash = SHA256.Create()
        Else
            MsgBox("Unknown type of hash : " & hash_type, MsgBoxStyle.Critical)
            Return False
        End If

        ' We declare a variable to be an array of bytes
        Dim hashValue() As Byte

        ' We create a FileStream for the file passed as a parameter
        Dim fileStream As FileStream = File.OpenRead(file_name)
        ' We position the cursor at the beginning of stream
        fileStream.Position = 0
        ' We calculate the hash of the file
        hashValue = hash.ComputeHash(fileStream)
        ' The array of bytes is converted into hexadecimal before it can be read easily
        Dim hash_hex = PrintByteArray(hashValue)

        ' We close the open file
        fileStream.Close()

        ' The hash is returned
        Return hash_hex

    End Function
    ' We traverse the array of bytes and converting each byte in hexadecimal
    Public Function PrintByteArray(ByVal array() As Byte)

        Dim hex_value As String = ""

        ' We traverse the array of bytes
        Dim i As Integer
        For i = 0 To array.Length - 1

            ' We convert each byte in hexadecimal
            hex_value += array(i).ToString("X2")

        Next i

        ' We return the string in lowercase
        Return hex_value.ToLower

    End Function

    Public Function sha_256_Gen(ByVal file_name As String) As String
        Return hash_generator("sha256", file_name)
    End Function


    Public Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() ' Files in directory
        Dim fileName As String ' Name of File
        Dim DirPercent As Integer, lastcount As Integer, I As Integer 'Progress Bar variables

        If Not targetDirectory = "" Then
            If Directory.Exists(targetDirectory) Then
                fileEntries = Directory.GetFiles(targetDirectory & "\")

                'Simple Progressl
                DirPercent = fileEntries.Count / 100
                lastcount = 0
                frmProgress.ProgressBar1.Value = 0
                frmProgress.Show()

                'Give a nice message to the user
                MsgBox("Scanning " & targetDirectory)

                ' Process the list of files found in the directory with loop.
                For Each fileName In fileEntries
                    'Manage Progress bar
                    If I = lastcount + DirPercent Then
                        lastcount = I
                        If Not frmProgress.ProgressBar1.Value = 100 Then
                            frmProgress.ProgressBar1.Value += 1
                        End If
                    End If

                    'Update Database
                    modDB.UpdateSystemfromFile(sha_256_Gen(fileName), Right(fileName, 4))

                    'Increment Progressbar incrementor
                    I += 1

                    'Ensure progress bar reaches 100%
                    If I = fileEntries.Count Then frmProgress.ProgressBar1.Value = 100
                Next fileName
            Else
                'Display error message if directory doesnt exist
                MsgBox("Scan Path " & targetDirectory & " Does not exist")
            End If
        End If
        'close progress bar
        frmProgress.Close()
    End Sub
End Module
