Imports System.IO

Public Class Form1
    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
                For i As Integer = 0 To filePaths.Count - 1
                    If ListBox1.Items.Contains(filePaths(i)) Then
                        MsgBox("Duplicated items are not allowed!" & vbNewLine & "Item is " & filePaths(i), MsgBoxStyle.Critical, "Duplicated item")
                        Continue For
                    End If
                    If Directory.Exists(filePaths(i)) Then
                        ListBox1.Items.Add(filePaths(i))
                    ElseIf File.Exists(filePaths(i)) Then
                        ListBox1.Items.Add(filePaths(i))
                    End If
                Next
                Label2.Text = "Status: Changed"
                Label2.ForeColor = Color.Blue
                Label1.Text = "Total items to copy: " & ListBox1.Items.Count
            End If
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ListBox1.Items.Count <> 0 Then
                Dim f() As String = ListBox1.Items.Cast(Of Object).Select(Function(o) ListBox1.GetItemText(o)).ToArray
                Dim d As New DataObject(DataFormats.FileDrop, f)
                Clipboard.SetDataObject(d, True)
                Label2.Text = "Status: Copied"
                Label2.ForeColor = Color.Green
            Else
                Label2.Text = "Status: Failed"
                Label2.ForeColor = Color.Red
                MsgBox("Empty list!", MsgBoxStyle.Critical, "Copy Error")
            End If
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
            Label2.Text = "Status: Failed"
            Label2.ForeColor = Color.Red
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
            For i As Integer = 0 To ListBox1.SelectedItems.Count - 1
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndices(0))
            Next
            If ListBox1.Items.Count <> 0 Then
                Label2.Text = "Status: Changed"
                Label2.ForeColor = Color.Blue
            Else
                Label2.Text = "Status: Null"
                Label2.ForeColor = Color.Black
            End If
            Label1.Text = "Total items to copy: " & ListBox1.Items.Count
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        Try
            checkclipboard.Checked = False
            ListBox1.Items.Clear()
            Label1.Text = "Total items to copy: " & ListBox1.Items.Count
            Label2.Text = "Status: Null"
            Label2.ForeColor = Color.Black
        Catch ex As Exception
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ContextMenuStrip2_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        Try
            ClearAllToolStripMenuItem.Enabled = (ListBox1.Items.Count <> 0)
            ExportListToolStripMenuItem.Enabled = (ListBox1.Items.Count <> 0)
            DeleteThisItemToolStripMenuItem.Enabled = (ListBox1.SelectedItems.Count <> 0)
            PasteClipboardToolStripMenuItem.Enabled = (Clipboard.GetDataObject.GetDataPresent(DataFormats.FileDrop))
        Catch
        End Try
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ListBox1.SelectedItems.Count <> 0 Then
                DeleteThisItemToolStripMenuItem.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        ElseIf e.Modifiers = Keys.Shift And e.KeyCode = Keys.Delete Then
            If ListBox1.Items.Count <> 0 Then
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

    Private Sub alwaysontopcheck_CheckedChanged(sender As Object, e As EventArgs) Handles alwaysontopcheck.CheckedChanged
        Me.TopMost = (alwaysontopcheck.Checked)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Try
            Label4.Text = TrackBar1.Value
            Me.Opacity = TrackBar1.Value / 100
        Catch ex As Exception
            TrackBar1.Value = 100
            MsgBox("There was an error occured" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub ExportListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportListToolStripMenuItem.Click
        Try
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                Dim myWriter As New IO.StreamWriter(SaveFileDialog1.FileName)
                For i As Integer = 0 To ListBox1.Items.Count - 1
                    myWriter.WriteLine(ListBox1.Items(i).ToString)
                Next
                myWriter.Close()
            End If
        Catch ex As Exception
            MsgBox("There was an error occured while saving" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ImportListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportListToolStripMenuItem.Click
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                Dim lines() As String = IO.File.ReadAllLines(OpenFileDialog1.FileName)
                Dim fault As String = ""
                For i As Integer = 0 To lines.Count - 1
                    If Directory.Exists(lines(i)) Or File.Exists(lines(i)) Then
                        ListBox1.Items.Add(lines(i))
                    Else
                        fault &= "- " & lines(i) & vbNewLine
                    End If
                Next
                If fault <> "" Then
                    MsgBox("These files/folders couldn't be found:-" & vbNewLine & fault, MsgBoxStyle.Exclamation, "Importing error")
                End If
                Label1.Text = "Total items to copy: " & ListBox1.Items.Count
            End If
        Catch ex As Exception
            MsgBox("There was an error occured while saving" & vbNewLine & "Details :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = "Copier V" + Application.ProductVersion
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

    Private Sub PasteClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteClipboardToolStripMenuItem.Click
        Try
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent(DataFormats.FileDrop) Then
                Dim filePaths As String() = CType(data.GetData(DataFormats.FileDrop), String())
                For i As Integer = 0 To filePaths.Count - 1
                    If ListBox1.Items.Contains(filePaths(i)) Then
                        Continue For
                    End If
                    If Directory.Exists(filePaths(i)) Then
                        ListBox1.Items.Add(filePaths(i))
                        Label2.Text = "Status: Changed"
                        Label2.ForeColor = Color.Blue
                        Label1.Text = "Total items to copy: " & ListBox1.Items.Count
                    ElseIf File.Exists(filePaths(i)) Then
                        ListBox1.Items.Add(filePaths(i))
                        Label2.Text = "Status: Changed"
                        Label2.ForeColor = Color.Blue
                        Label1.Text = "Total items to copy: " & ListBox1.Items.Count
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Couldn't paste your clipboard due to following details:-" + vbNewLine + ex.Message, MsgBoxStyle.Critical, "Paste Error")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles checkclipboard.CheckedChanged
        Timer1.Enabled = checkclipboard.Checked
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent(DataFormats.FileDrop) Then
                Dim filePaths As String() = CType(data.GetData(DataFormats.FileDrop), String())
                For i As Integer = 0 To filePaths.Count - 1
                    If ListBox1.Items.Contains(filePaths(i)) Then
                        Continue For
                    End If
                    If Directory.Exists(filePaths(i)) Then
                        ListBox1.Items.Add(filePaths(i))
                        Label2.Text = "Status: Changed"
                        Label2.ForeColor = Color.Blue
                        Label1.Text = "Total items to copy: " & ListBox1.Items.Count
                    ElseIf File.Exists(filePaths(i)) Then
                        ListBox1.Items.Add(filePaths(i))
                        Label2.Text = "Status: Changed"
                        Label2.ForeColor = Color.Blue
                        Label1.Text = "Total items to copy: " & ListBox1.Items.Count
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Click
        Try
            If AddCopierToRightClickContextMenuOfWindowsToolStripMenuItem.Text.Contains("Add") Then
                'For Windows explorer
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
End Class
