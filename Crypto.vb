Imports System.Text

Module Crypto
    Public Function MD5(ByVal strToHash As String) As String
        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""
        Dim b As Byte

        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult
    End Function

    Public Function ROTN_Forward(ByVal InputData As String, ByVal NumKey As Integer) As String

        Dim i As Long, OutChar As String

        For i = 1 To Len(InputData)
            OutChar = Asc(Mid(InputData, i, 1)) + NumKey
            While OutChar > 255
                OutChar = OutChar - 256
            End While
            ROTN_Forward = ROTN_Forward + Chr(OutChar)
        Next

    End Function

    Public Function ROTN_Backward(ByVal InputData As String, ByVal NumKey As Integer) As String

        Dim i As Long, OutChar As String

        For i = 1 To Len(InputData)
            OutChar = Asc(Mid(InputData, i, 1)) - NumKey
            While OutChar < 0
                OutChar = OutChar + 256
            End While
            ROTN_Backward = ROTN_Backward + Chr(OutChar)
        Next

    End Function

    Public Function RC4(ByVal message As String, ByVal password As String) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cipher As New StringBuilder
        Dim returnCipher As String = String.Empty
        Dim sbox As Integer() = New Integer(256) {}
        Dim key As Integer() = New Integer(256) {}
        Dim intLength As Integer = password.Length
        Dim a As Integer = 0
        While a <= 255
            Dim ctmp As Char = (password.Substring((a Mod intLength),
            1).ToCharArray()(0))
            key(a) = Microsoft.VisualBasic.Strings.Asc(ctmp)
            sbox(a) = a
            System.Math.Max(System.Threading.Interlocked.Increment(a), a - 1)
        End While
        Dim x As Integer = 0
        Dim b As Integer = 0
        While b <= 255
            x = (x + sbox(b) + key(b)) Mod 256
            Dim tempSwap As Integer = sbox(b)
            sbox(b) = sbox(x)
            sbox(x) = tempSwap
            System.Math.Max(System.Threading.Interlocked.Increment(b), b - 1)
        End While
        a = 1
        While a <= message.Length
            Dim itmp As Integer = 0
            i = (i + 1) Mod 256
            j = (j + sbox(i)) Mod 256
            itmp = sbox(i)
            sbox(i) = sbox(j)
            sbox(j) = itmp
            Dim k As Integer = sbox((sbox(i) + sbox(j)) Mod 256)
            Dim ctmp As Char = message.Substring(a - 1, 1).ToCharArray()(0)
            itmp = Asc(ctmp)
            Dim cipherby As Integer = itmp Xor k
            cipher.Append(Chr(cipherby))
            System.Math.Max(System.Threading.Interlocked.Increment(a), a - 1)
        End While
        returnCipher = cipher.ToString
        cipher.Length = 0
        Return returnCipher
    End Function
End Module
