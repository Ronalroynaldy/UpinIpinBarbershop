Public Class FormMenuOwner
    Private Sub FormMenuOwner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDataLayanan_Click(sender As Object, e As EventArgs) Handles btnLayanan.Click

        Dim form As New FormDataLayanan()
        form.Show()
        Me.Hide()

    End Sub
    Private Sub btnDataKatalog_Click(sender As Object, e As EventArgs) Handles btnKatalog.Click

        Dim form As New FormDataKatalog()
        form.Show()
        Me.Hide()

    End Sub
    Private Sub btnTransaksi_Click(sender As Object, e As EventArgs) Handles btnTransaksi.Click
        Dim form As New FormTransaksi()
        form.Show()
        Me.Hide()
    End Sub

    Private Sub btnTransaksiProduk_Click(
    sender As Object,
    e As EventArgs
) Handles btnTransaksiProduk.Click

        Dim frm As New FormTransaksiProduk()

        frm.HomeForm = Me

        Me.Hide()
        frm.Show()

    End Sub
End Class