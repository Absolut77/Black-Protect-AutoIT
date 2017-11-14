Module ReadFile
    Public Function ReadFile(ByVal Filepath As String) As String
        Dim Result As String = Nothing
        If Filepath Is Nothing Then
            Throw New Exception("File not found !")
        Else
            FileOpen(1, Filepath, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            Result = Space(LOF(1))
            FileGet(1, Result)
            FileClose(1)
        End If
        Return Result
    End Function
End Module
