Imports System.IO
Imports System.Runtime.InteropServices
Module Cheat_Functions

    '*******************************************************************************
    '* This File contains Structures and Imports for Cheat_Functions.dll           *
    '* It also contains some functions for reading/writing to show how to          *
    '* use these functions. I will comment those, so that the next person to use   *
    '* this code, who ever they might be, will be able to, and hopefully not have  *
    '* any of the annoying pinvoke issues I had.                                   *
    '*******************************************************************************

    '*******************************************************************************
    '* DO NOT CHANGE THESE STRUCTURES OR FUNCTION DEFINITIONS, THEY WORK PERFECTLY *
    '* They are not Commented, as they are straight forward, and changing them     *
    '* Will do nothing to help you with your Program                               *
    '*******************************************************************************

    <StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure SNES9xCheat
        Public address As UInteger
        Public byte1 As Byte
        Public saved_byte As Byte
        <MarshalAs(UnmanagedType.I1)> Public enabled As Boolean
        <MarshalAs(UnmanagedType.I1)> Public saved As Boolean
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=22)> Public name As String
    End Structure

    <StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Structure SNES9xCheatData
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=150)> Public c As SNES9xCheat()
        Public num_cheats As UInteger

    End Structure

    
    <DllImport(".\Cheat_Functions.dll", CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, entrypoint:="_Z16S9xLoadCheatFilePKc")> _
    Public Function S9xLoadCheatFile(ByVal filename As String) As Integer
    End Function
    <DllImport(".\Cheat_Functions.dll", CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, entrypoint:="_Z10GetDataPtrv")> _
    Public Function GetDataPTR() As IntPtr
    End Function
    <DllImport(".\Cheat_Functions.dll", CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, entrypoint:="_Z16S9xSaveCheatFilePKc")> _
    Public Function S9xSaveCheatFile(ByVal filename As String) As Integer
    End Function

    '***********************************************************************************
    '* Example Functions                                                               *
    '* These functions show how to use these import/export functions.                  *
    '* They were written by Gavin_Darkglider who also put together Cheat_Functions.dll *
    '* They can be removed as they arent actually needed.                              *
    '***********************************************************************************
    Public Sub testSnes9x_Load()
        'This function will load a Snes 9x Cheat file, into a structure named cheat.

        'Define File to load
        Dim file As String = "C:\Users\Diane\Desktop\snes9x\Cheats\Super Mario World (U) [!].cht"
        'Create structure variable.
        Dim Cheats As New SNES9xCheatData
        'Load File in dll, fills variable in dll with the data.

        If Not S9xLoadCheatFile(file) = -1 Then
            'If file exists, fill Structure from Dll, using a pointer to the actual variable in the dll
            Cheats = System.Runtime.InteropServices.Marshal.PtrToStructure(GetDataPTR(), GetType(SNES9xCheatData))
        Else
            MsgBox("File: " & file & " Not Found")
            Exit Sub
        End If

        'Use structure here.... eg. create messagebox with number of cheats in file
        'I would suggest a loop of some kind to retrieve data from structure.
        MsgBox(Cheats.num_cheats)
    End Sub

    Public Sub testSnes9xSave()

        'this function will load file a, pass back the structure, and save in file b. it
        'should essentually copy the file, but by recreating the file.

        'Define variables, and structures.
        'You have to define this way because vb.net does not allow making presized arrays in structures :(
        'So We have to define it with the pointer in the dll
        Dim Cheats As SNES9xCheatData = System.Runtime.InteropServices.Marshal.PtrToStructure(GetDataPTR(), GetType(SNES9xCheatData))
        Dim Cheats2 As New SNES9xCheatData

        Dim file1 As String = "..\Super Mario World (U) [!].cht"
        Dim file2 As String = ".\snes9x\try.cht"

        'load file1 in dll and pass back structure, if file doesnt exist
        'Let User know, and exit sub

        If Not S9xLoadCheatFile(file1) = -1 Then
            Cheats = System.Runtime.InteropServices.Marshal.PtrToStructure(GetDataPTR(), GetType(SNES9xCheatData))
        Else
            MsgBox("File: " & file1 & " Not Found")
            Exit Sub
        End If

        'Fill Cheats2 with data, not needed, but to show that we are saving new data
        Cheats2 = Cheats

        'Fill Pointer in dll with new data, and make sure to replace old data using getdataptr()
        'to get pointer value, also make sure we clear the structure in the db, and fill with data
        'from cheats2 structure 

        System.Runtime.InteropServices.Marshal.StructureToPtr(Cheats2, GetDataPTR(), True)

        'Save File 2, and check status

        If Not S9xSaveCheatFile(file2) = -1 Then
            MsgBox("Snes9x Cht file: " & file2 & " Created Successfully")
        Else
            MsgBox("File: " & file2 & " Could Not Be Created")
            Exit Sub
        End If
    End Sub
End Module

