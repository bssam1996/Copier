﻿Imports System.IO
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
End Class
