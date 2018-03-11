Imports System.Net
Public Class updateform
    Dim whereToSave As String
    Delegate Sub ChangeTextsSafe(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)
    Delegate Sub DownloadCompleteSafe(ByVal cancelled As Boolean)
    Public Sub DownloadComplete(ByVal cancelled As Boolean)
        Button1.Enabled = False
        If cancelled Then
            Me.Label4.Text = "Cancelled"
            MessageBox.Show("Download aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me.Label4.Text = "Successfully downloaded"
            MessageBox.Show("Successfully downloaded!", "All OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\SOFTWARE\Copier", "ulevel", "1")
            Process.Start(Application.StartupPath + "\update\copier.exe")
            BackgroundWorker1.Dispose()
            End
        End If
        Me.ProgressBar1.Value = 0
        Me.Label5.Text = "Downloading: "
        Me.Label6.Text = "Save to: "
        Me.Label3.Text = "File size: "
        Me.Label2.Text = "Download speed: "
    End Sub
    Public scversion As String

    Public Sub ChangeTexts(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)
        Try
            Me.Label3.Text = "File Size: " & Math.Round((length / 1024), 2) & " KB"
            Me.Label5.Text = "Downloading: " & "https://github.com/bssam1996/Copier/raw/master/EXE%20File/Copier.exe"
            Me.Label4.Text = "Downloaded " & Math.Round((position / 1024), 2) & " KB of " & Math.Round((length / 1024), 2) & "KB (" & Me.ProgressBar1.Value & "%)"
            If speed = -1 Then
                Me.Label2.Text = "Speed: calculating..."
            Else
                Me.Label2.Text = "Speed: " & Math.Round((speed / 1024), 2) & " KB/s"
            End If
            Me.ProgressBar1.Value = percent
        Catch ex As Exception
            MsgBox("There is an error occurred." & vbNewLine & "Details:" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Update Problem")
            BackgroundWorker1.CancelAsync()
        End Try
    End Sub
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If System.IO.Directory.Exists(Application.StartupPath + "\update") = False Then
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\update")
            End If
            Me.whereToSave = Application.StartupPath + "\update"
            Me.Label6.Text = "Save to: " & Me.whereToSave
            Me.BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MsgBox("There is an error occurred." & vbNewLine & "Details:" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Update Problem")
            Me.Hide()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim theResponse As HttpWebResponse
            Dim theRequest As HttpWebRequest
            Try
                theRequest = WebRequest.Create("https://raw.githubusercontent.com/bssam1996/Copier/master/EXE%20File/Copier.exe")
                theResponse = theRequest.GetResponse
            Catch ex As Exception

                MessageBox.Show("An error occurred while downloading file. Possibe causes:" & ControlChars.CrLf &
                                "1) File doesn't exist" & ControlChars.CrLf &
                                "2) Remote server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

                Me.Invoke(cancelDelegate, True)

                Exit Sub
            End Try
            Dim length As Long = theResponse.ContentLength
            Dim safedelegate As New ChangeTextsSafe(AddressOf ChangeTexts)
            Me.Invoke(safedelegate, length, 0, 0, 0)
            Dim writeStream As New IO.FileStream(Me.whereToSave + "\Copier.exe", IO.FileMode.Create)
            Dim nRead As Integer
            Dim speedtimer As New Stopwatch
            Dim currentspeed As Double = -1
            Dim readings As Integer = 0
            Do
                If BackgroundWorker1.CancellationPending Then
                    Exit Do
                End If
                speedtimer.Start()
                Dim readBytes(4095) As Byte
                Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
                nRead += bytesread
                Dim percent As Short = (nRead * 100) / length
                Me.Invoke(safedelegate, length, nRead, percent, currentspeed)
                If bytesread = 0 Then Exit Do
                writeStream.Write(readBytes, 0, bytesread)
                speedtimer.Stop()
                readings += 1
                If readings >= 5 Then
                    currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                    speedtimer.Reset()
                    readings = 0
                End If
            Loop
            theResponse.GetResponseStream.Close()
            writeStream.Close()
            If Me.BackgroundWorker1.CancellationPending Then
                My.Computer.FileSystem.DeleteFile(Me.whereToSave)
                Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
                Me.Invoke(cancelDelegate, True)
                Exit Sub
            End If
            Dim completeDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
            Me.Invoke(completeDelegate, False)
        Catch ex As Exception
            MsgBox("There is an error occurred." & vbNewLine & "Details:" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Update Problem")
        End Try
    End Sub
    Private Sub Form5_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        BackgroundWorker1.CancelAsync()
    End Sub
End Class