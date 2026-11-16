Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BukaKoneksi()

        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            MessageBox.Show("Koneksi database berhasil!")
        End If
    End Sub

End Class