Imports System.IO
Imports System.Text

Public Class DaemonPatcher
    ' Methods
    Public Shared Function AdressPatch(ByVal PEpath As String, ByVal adress As Integer, ByVal Newbyte As String) As Boolean
        Dim flag As Boolean
        Try
            Dim hex As String = DaemonPatcher.ByteArrayToString(File.ReadAllBytes(PEpath)).Remove((adress * 2), Newbyte.Length).Insert((adress * 2), Newbyte)
            File.WriteAllBytes(PEpath, DaemonPatcher.StringToByteArray(hex))
            flag = True
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            Interaction.MsgBox("Error", MsgBoxStyle.Critical, Nothing)
            flag = False
            Return flag
        End Try
        Return flag
    End Function

    Private Shared Function ByteArrayToString(ByVal ba As Byte()) As String
        Dim builder As New StringBuilder((ba.Length * 2))
        Dim num As Byte
        For Each num In ba
            builder.AppendFormat("{0:x2}", num)
        Next
        Return builder.ToString
    End Function

    Public Shared Function SequencePatch(ByVal PEpath As String, ByVal seq As String, ByVal Newbyte As String) As Boolean
        Dim hex As String = DaemonPatcher.ByteArrayToString(File.ReadAllBytes(PEpath))
        If (seq.Length = Newbyte.Length) Then
            Dim flag As Boolean
            Try
                hex = hex.Replace(seq.ToLower, Newbyte)
                File.WriteAllBytes(PEpath, DaemonPatcher.StringToByteArray(hex))
                Return True
            Catch exception1 As Exception
                Interaction.MsgBox("Error", MsgBoxStyle.Critical, Nothing)
                flag = False
                Return flag
            End Try
            Return flag
        End If
        Interaction.MsgBox(("Erreur :" & Environment.NewLine & "Nombre de bytes incorrect"), MsgBoxStyle.DefaultButton1, Nothing)
        Return False
    End Function

    Private Shared Function StringToByteArray(ByVal hex As String) As Byte()
        Dim length As Integer = hex.Length
        Dim buffer As Byte() = New Byte((((length / 2) - 1) + 1) - 1) {}
        Dim num3 As Integer = (length - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            buffer((i / 2)) = Convert.ToByte(hex.Substring(i, 2), &H10)
            i = (i + 2)
        Loop
        Return buffer
    End Function

End Class

