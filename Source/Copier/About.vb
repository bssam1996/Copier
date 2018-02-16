Public Class About

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = "Version : " & System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.facebook.com/bassam.hesham.mahmoud")
        LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True
    End Sub
End Class