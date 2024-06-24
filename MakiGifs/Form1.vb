Imports System.IO

Public Class Form1
    Private Sub reloj2()
        Dim rnd As New Random()
        Timer2.Interval = rnd.Next(0, 400001)
        Timer2.Enabled = True
        PictureBox1.Visible = False
    End Sub

    Private Sub accion()
        Randomize()
        Timer1.Interval = 10000
        Timer1.Enabled = True
        Dim directorio As String = (Application.StartupPath & "\gifs")
        Dim archivos() As String = Directory.GetFiles(directorio)
        If archivos.Length <= 0 Then
            MsgBox("ERROR! No hay gifs")
        Else
            posicion()
            Dim rnd As New Random()
            Dim indice As Integer = rnd.Next(0, archivos.Length)
            Dim nombreAleatorio As String = Path.GetFileName(archivos(indice))
            Dim gif As Image = Image.FromFile(Application.StartupPath & "\gifs\" & nombreAleatorio)
            Dim ancho As Integer = gif.Width
            Dim alto As Integer = gif.Height
            Me.BackgroundImage = Nothing
            Me.BackColor = SystemColors.Control
            Label1.Visible = False
            Button1.Visible = False
            FormBorderStyle = FormBorderStyle.None
            PictureBox1.Visible = True
            PictureBox1.Image = gif
            PictureBox1.Width = ancho
            PictureBox1.Height = alto
            Me.Width = ancho
            Me.Height = alto
            ShowInTaskbar = False
            Me.TransparencyKey = SystemColors.Control
        End If
    End Sub

    Private Sub posicion()
        Dim Random As New Random()
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim randomX As Integer = Random.Next(0, screenWidth - Me.Width)
        Dim randomY As Integer = Random.Next(0, screenHeight - Me.Height)
        Me.Location = New Point(randomX, randomY)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.BackgroundImage = Nothing
        Me.BackColor = SystemColors.Control
        ShowInTaskbar = False
        Me.TransparencyKey = SystemColors.Control
        Label1.Visible = False
        Button1.Visible = False
        FormBorderStyle = FormBorderStyle.None
        PictureBox2.Visible = False
        Dim rnd As New Random()
        Dim tiempoEspera As Integer = rnd.Next(1, 400001)
        Threading.Thread.Sleep(tiempoEspera)
        Timer3.Interval = rnd.Next(0, 400001)
        Timer3.Enabled = True
        accion()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        reloj2()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        accion()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Timer3.Enabled = False
        Dim for2 As New Form2
        for2.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class