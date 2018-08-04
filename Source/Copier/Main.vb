Imports System.IO
Public Class Main
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public abort As Boolean
    Dim d As Double = 0
    Function GetFolderSize(ByVal DirPath As String, ByVal includeSubFolders As Boolean) As Long
        Try
            Dim size As Long = 0
            Dim diBase As New DirectoryInfo(DirPath)
            Dim files() As FileInfo
            If includeSubFolders Then
                files = diBase.GetFiles("*", SearchOption.AllDirectories)
            Else
                files = diBase.GetFiles("*", SearchOption.TopDirectoryOnly)
            End If
            Dim ie As IEnumerator = files.GetEnumerator
            While ie.MoveNext And Not abort

                size += DirectCast(ie.Current, FileInfo).Length
            End While
            Return size
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
            Return -1
        End Try
    End Function
    Public Sub manualgetsize()
        d = 0
        For Each item In ItemsList.Items
            If File.Exists(item.ToString) Or Directory.Exists(item.ToString) Then
                Dim a As Double
                Dim b As String
                Dim di As New IO.DirectoryInfo(item.ToString)
                Dim sdi As New IO.DirectoryInfo(di.ToString)
                If (Directory.Exists(item.ToString)) Then
                    b = sdi.ToString
                    a = GetFolderSize(b, True) / 1024 / 1024
                ElseIf (File.Exists(item.ToString)) Then
                    Dim c = My.Computer.FileSystem.GetFileInfo(item.ToString)
                    a = c.Length / 1024 / 1024
                End If
                d += a
                b = d & " MB"
                If d > 1000 Then
                    b = "(" & Format(d / 1024, "Fixed") & "GB)"
                ElseIf d < 1 Then
                    b = "(" & Format(d * 1024, "Fixed") & "KB)"
                End If
                b = Format(b, "Fixed")
                TotalSizeLabel.Text = "Total Size: " & b
            End If
        Next

    End Sub
    Public Sub getsize(ByVal path As String)
        If AutomaticCheckSizeToolStripMenuItem.Checked = True Then
            Dim a As Double
            Dim b As String
            Dim di As New IO.DirectoryInfo(path)
            Dim sdi As New IO.DirectoryInfo(di.ToString)
            If (Directory.Exists(path)) Then
                b = sdi.ToString
                a = GetFolderSize(b, True) / 1024 / 1024
            ElseIf (File.Exists(path)) Then
                Dim c = My.Computer.FileSystem.GetFileInfo(path)
                a = c.Length / 1024 / 1024
            End If
            d += a
            b = d & " MB"
            If d > 1000 Then
                b = "(" & Format(d / 1024, "Fixed") & "GB)"
            ElseIf d < 1 Then
                b = "(" & Format(d * 1024, "Fixed") & "KB)"
            End If
            b = Format(b, "Fixed")
            TotalSizeLabel.Text = "Total Size: " & b
        End If
    End Sub
    Public Sub subtractsize(ByVal path As String)
        If AutomaticCheckSizeToolStripMenuItem.Checked = True Then
            Dim a As Double
            Dim b As String
            Dim di As New IO.DirectoryInfo(path)
            Dim sdi As New IO.DirectoryInfo(di.ToString)
            If (Directory.Exists(path)) Then
                b = sdi.ToString
                a = GetFolderSize(b, True) / 1024 / 1024
            ElseIf (File.Exists(path)) Then
                Dim c = My.Computer.FileSystem.GetFileInfo(path)
                a = c.Length / 1024 / 1024
            End If
            d -= a
            b = d & " MB"
            If d > 1000 Then
                b = "(" & Format(d / 1024, "Fixed") & "GB)"
            ElseIf d < 1 Then
                b = "(" & Format(d * 1024, "Fixed") & "KB)"
            End If
            b = Format(b, "Fixed")
            TotalSizeLabel.Text = "Total Size: " & b
        End If
    End Sub
    Private Sub TopPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles TopPanel1.MouseDown, StatusLabel.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub TopPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TopPanel1.MouseMove, StatusLabel.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub TopPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles TopPanel1.MouseUp, StatusLabel.MouseUp
        drag = False
    End Sub

    Private Sub EndButton_Click(sender As Object, e As EventArgs) Handles EndButton.Click
        End
    End Sub

    Private Sub MaximizeButton_Click(sender As Object, e As EventArgs) Handles MaximizeButton.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub MinimizeButton_Click(sender As Object, e As EventArgs) Handles MinimizeButton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs) Handles MenuButton.Click
        If OptionPanel1.Width = 200 Then
            While OptionPanel1.Width > 50
                OptionPanel1.Width -= 2
                MenuButton.Location = New Point(MenuButton.Location.X - 2, MenuButton.Location.Y)
                ItemsList.Location = New Point(ItemsList.Location.X - 2, ItemsList.Location.Y)
                TotalItemsLabel.Location = New Point(TotalItemsLabel.Location.X - 2, TotalItemsLabel.Location.Y)
                ItemsList.Width = ItemsList.Width + 2
                System.Threading.Thread.Sleep(2)
            End While
        Else
            While OptionPanel1.Width < 200
                OptionPanel1.Width += 2
                MenuButton.Location = New Point(MenuButton.Location.X + 2, MenuButton.Location.Y)
                ItemsList.Location = New Point(ItemsList.Location.X + 2, ItemsList.Location.Y)
                TotalItemsLabel.Location = New Point(TotalItemsLabel.Location.X + 2, TotalItemsLabel.Location.Y)
                ItemsList.Width = ItemsList.Width - 2
                System.Threading.Thread.Sleep(2)
            End While
        End If
    End Sub

    Private Sub CopierIcon_Click(sender As Object, e As EventArgs) Handles CopierIcon.Click
        About.ShowDialog()
    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        Try
            If ItemsList.Items.Count <> 0 Then
                Dim f() As String = ItemsList.Items.Cast(Of Object).Select(Function(o) ItemsList.GetItemText(o)).ToArray
                Dim d As New DataObject(DataFormats.FileDrop, f)
                Clipboard.SetDataObject(d, True)
                StatusLabel.Text = "Status: Copied"
                StatusLabel.ForeColor = Color.LightGreen
            Else
                StatusLabel.Text = "Status: Failed"
                StatusLabel.ForeColor = Color.Red
                MsgBox("Empty list!", MsgBoxStyle.Critical, "Copy Error")
            End If
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
            StatusLabel.Text = "Status: Failed"
            StatusLabel.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub TansparencyTrackBar_Scroll(sender As Object, e As EventArgs) Handles TansparencyTrackBar.Scroll
        Try
            TransparencyLevel.Text = TansparencyTrackBar.Value
            Me.Opacity = TansparencyTrackBar.Value / 100
        Catch ex As Exception
            TansparencyTrackBar.Value = 100
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub checksizemanual_Click(sender As Object, e As EventArgs) Handles checksizemanual.Click
        If ItemsList.Items.Count <> 0 Then
            Dim gettingsize As System.Threading.Thread = New System.Threading.Thread(AddressOf manualgetsize)
            gettingsize.Start()
        End If
    End Sub
    Private Sub AutomaticCheckSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomaticCheckSizeToolStripMenuItem.Click
        AutomaticCheckSizeToolStripMenuItem.Checked = Not AutomaticCheckSizeToolStripMenuItem.Checked
        If AutomaticCheckSizeToolStripMenuItem.Checked = True Then
            manualgetsize()
        End If
    End Sub
    Private Sub AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Click
        Try
            If AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text.Contains("Add") Then
                'For Windows explorer
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\", True).CreateSubKey("directory")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\", True).CreateSubKey("Background")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\shell") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\", True).CreateSubKey("shell")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\shell\Copier") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\shell\", True).CreateSubKey("Copier")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\shell\Copier\command") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\shell\Copier\", True).CreateSubKey("command")
                End If
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\directory\Background\shell\Copier", "", "Open Copier")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\directory\Background\shell\Copier", "Icon", Application.ExecutablePath)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\directory\Background\shell\Copier\command", "", Application.ExecutablePath)
                'For folders
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\shell") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\", True).CreateSubKey("shell")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\shell\Copier") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\shell\", True).CreateSubKey("Copier")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\shell\Copier\command") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\shell\Copier\", True).CreateSubKey("command")
                End If
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\directory\shell\Copier", "", "Open Copier")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\directory\shell\Copier", "Icon", Application.ExecutablePath)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\directory\shell\Copier\command", "", Application.ExecutablePath)
                'For Files
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\shell") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\", True).CreateSubKey("shell")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\shell\Copier") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\shell\", True).CreateSubKey("Copier")
                End If
                If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\shell\Copier\command") Is Nothing Then
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\shell\Copier\", True).CreateSubKey("command")
                End If
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\*\shell\Copier", "", "Open Copier")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\*\shell\Copier", "Icon", Application.ExecutablePath)
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Classes\*\shell\Copier\command", "", Application.ExecutablePath)
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Checked = True
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text = "Remove Copier to right click context menu of windows"
            Else
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\Classes\*\shell\Copier")
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\Classes\directory\shell\Copier")
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\Classes\directory\Background\shell\Copier")
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Checked = False
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text = "Add Copier to right click context menu of windows"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            PasteClipboardToolStripMenuItem.PerformClick()
        Catch
        End Try
    End Sub
    Private Sub checkclipboard_CheckedChanged(sender As Object, e As EventArgs) Handles checkclipboard.CheckedChanged
        Timer1.Enabled = checkclipboard.Checked
    End Sub
    Private Sub PasteClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteClipboardToolStripMenuItem.Click
        Try
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent(DataFormats.FileDrop) Then
                Dim filePaths As String() = CType(data.GetData(DataFormats.FileDrop), String())
                For i As Integer = 0 To filePaths.Count - 1
                    If ItemsList.Items.Contains(filePaths(i)) Then
                        Continue For
                    End If
                    If Directory.Exists(filePaths(i)) Or File.Exists(filePaths(i)) Then
                        ItemsList.Items.Add(filePaths(i))
                        getsize(filePaths(i))
                        StatusLabel.Text = "Status: Changed"
                        StatusLabel.ForeColor = Color.Blue
                        TotalItemsLabel.Text = "Total items to copy: " & ItemsList.Items.Count
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Couldn't paste your clipboard due to following details:-" + vbNewLine + ex.Message, MsgBoxStyle.Critical, "Paste Error")
        End Try
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        Try
            If My.Computer.Network.IsAvailable Then
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/bssam1996/Copier/master/Version")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim newestversion As String = sr.ReadToEnd()
                Dim modnewestversion As String = newestversion.Replace(".", "")
                Dim currentversion As String = Application.ProductVersion
                currentversion = currentversion.Replace(".", "")
                If Integer.Parse(modnewestversion) <= Integer.Parse(currentversion) Then
                    MsgBox("You are up to date!", MsgBoxStyle.Information, "Version is up to date")
                Else
                    If MsgBox("Update Found Version : " + newestversion + vbNewLine + "Would you like to update now?", vbInformation + vbYesNo) = MsgBoxResult.Yes Then
                        updateform.ShowDialog()
                    End If
                End If
            Else
                MsgBox("Please Check your network!", MsgBoxStyle.Critical, "Network Unavailable")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            Me.TitleLabel.Text = "Copier V" + Application.ProductVersion
            If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Copier") Is Nothing Then
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\", True).CreateSubKey("Copier")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "", """" & Application.ExecutablePath & """")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "Path", """" & Application.StartupPath & """")
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "3")
            Else
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "").ToString = "1" Then
                    System.Threading.Thread.Sleep(2000)
                    Dim location As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "", Nothing).ToString
                    location = location.Replace(Chr(34), "")
                    My.Computer.FileSystem.CopyFile(Application.ExecutablePath, location, True)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "2")
                    Process.Start(location)
                    End
                ElseIf My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "").ToString = "2" Then
                    System.Threading.Thread.Sleep(2000)
                    System.IO.Directory.Delete(Application.StartupPath + "\update", True)
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "3")
                Else
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "", """" & Application.ExecutablePath & """")
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "Path", """" & Application.StartupPath & """")
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "3")
                End If
            End If
        Catch
        End Try
        Try
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                If Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\copier.exe") Is Nothing Then
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\", True).CreateSubKey("copier.exe")
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\copier.exe", "", """" & Application.ExecutablePath & """")
                    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\copier.exe", "Path", """" & Application.StartupPath & """")
                Else
                    If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "").ToString = "3" Then
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\copier.exe", "", """" & Application.ExecutablePath & """")
                        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\copier.exe", "Path", """" & Application.StartupPath & """")
                    End If
                End If
            End If
        Catch
        End Try
        Try
            If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\Background\shell\Copier") Is Nothing Or
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\directory\shell\Copier") Is Nothing Or
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Classes\*\shell\Copier") Is Nothing Then
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text = "Add Copier to right click context menu of windows"
            Else
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Checked = True
                AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text = "Remove Copier to right click context menu of windows"
            End If
        Catch
        End Try
    End Sub
    Private Sub ImportListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportListToolStripMenuItem.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Dim lines() As String = IO.File.ReadAllLines(OpenFileDialog1.FileName)
                Dim fault As String = ""
                For i As Integer = 0 To lines.Count - 1
                    If Directory.Exists(lines(i)) Or File.Exists(lines(i)) Then
                        ItemsList.Items.Add(lines(i))
                        getsize(lines(i))
                    Else
                        fault &= "- " & lines(i) & vbNewLine
                    End If
                Next
                If fault <> "" Then
                    MsgBox("These files/folders couldn't be found:-" & vbNewLine & fault, MsgBoxStyle.Exclamation, "Importing error")
                End If
                TotalItemsLabel.Text = "Total items to copy: " & ItemsList.Items.Count
            End If
        Catch ex As Exception
            MsgBox("There was an error occured while saving" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ExportListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportListToolStripMenuItem.Click
        Try
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim myWriter As New IO.StreamWriter(SaveFileDialog1.FileName)
                For i As Integer = 0 To ItemsList.Items.Count - 1
                    myWriter.WriteLine(ItemsList.Items(i).ToString)
                Next
                myWriter.Close()
            End If
        Catch ex As Exception
            MsgBox("There was an error occured while saving" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub alwaysontopcheck_CheckedChanged(sender As Object, e As EventArgs) Handles alwaysontopcheck.CheckedChanged
        Me.TopMost = (alwaysontopcheck.Checked)
    End Sub
    Private Sub ItemsList_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemsList.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ItemsList.SelectedItems.Count <> 0 Then
                DeleteThisItemToolStripMenuItem.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            CopyButton.PerformClick()
        ElseIf e.Modifiers = Keys.Shift And e.KeyCode = Keys.Delete Then
            If ItemsList.Items.Count <> 0 Then
                ClearAllToolStripMenuItem.PerformClick()
            End If
        ElseIf e.Modifiers = Keys.Control And e.KeyCode = Keys.V Then
            Try
                PasteClipboardToolStripMenuItem.PerformClick()
            Catch ex As Exception
                MsgBox("Couldn't paste your clipboard due to following details:-" + vbNewLine + ex.Message, MsgBoxStyle.Critical, "Paste Error")
            End Try

        End If
    End Sub
    Private Sub ListContextMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ListContextMenuStrip.Opening
        Try
            ClearAllToolStripMenuItem.Enabled = (ItemsList.Items.Count <> 0)
            ExportListToolStripMenuItem.Enabled = (ItemsList.Items.Count <> 0)
            DeleteThisItemToolStripMenuItem.Enabled = (ItemsList.SelectedItems.Count <> 0)
            PasteClipboardToolStripMenuItem.Enabled = (Clipboard.GetDataObject.GetDataPresent(DataFormats.FileDrop))
        Catch
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

    Private Sub EndToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EndToolStripMenuItem.Click
        End
    End Sub

    Private Sub DeleteThisItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteThisItemToolStripMenuItem.Click
        Try
            checkclipboard.Checked = False
            For i As Integer = 0 To ItemsList.SelectedItems.Count - 1
                If Directory.Exists(ItemsList.SelectedItems(0).ToString) Or File.Exists(ItemsList.SelectedItems(0).ToString) Then
                    subtractsize(ItemsList.SelectedItems(0).ToString)
                End If
                ItemsList.Items.RemoveAt(ItemsList.SelectedIndices(0))
            Next
            If ItemsList.Items.Count <> 0 Then
                StatusLabel.Text = "Status: Changed"
                StatusLabel.ForeColor = Color.Blue
            Else
                StatusLabel.Text = "Status: Null"
                StatusLabel.ForeColor = Color.Black
            End If
            TotalItemsLabel.Text = "Total items to copy: " & ItemsList.Items.Count
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        Try
            checkclipboard.Checked = False
            ItemsList.Items.Clear()
            TotalItemsLabel.Text = "Total items to copy: " & ItemsList.Items.Count
            StatusLabel.Text = "Status: Null"
            StatusLabel.ForeColor = Color.Black
            TotalSizeLabel.Text = "Total Size: 0"
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub ItemsList_DragEnter(sender As Object, e As DragEventArgs) Handles ItemsList.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ItemsList_DragDrop(sender As Object, e As DragEventArgs) Handles ItemsList.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
                For i As Integer = 0 To filePaths.Count - 1
                    If ItemsList.Items.Contains(filePaths(i)) Then
                        MsgBox("Duplicated items are not allowed!" & vbNewLine & "Item is " & filePaths(i), MsgBoxStyle.Critical, "Duplicated item")
                        Continue For
                    End If
                    If Directory.Exists(filePaths(i)) Or File.Exists(filePaths(i)) Then
                        ItemsList.Items.Add(filePaths(i))
                        getsize(filePaths(i))
                    End If
                Next
                StatusLabel.Text = "Status: Changed"
                StatusLabel.ForeColor = Color.Blue
                TotalItemsLabel.Text = "Total items to copy: " & ItemsList.Items.Count
            End If
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class