
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class FormDataKatalog

    ' SAAT FORM DIBUKA
    Private Sub FormDataKatalog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboStatus.Items.Clear()
        cboStatus.Items.Add("Aktif")
        cboStatus.Items.Add("Tidak Aktif")
        cboStatus.SelectedIndex = 0

        txtKatalogID.ReadOnly = True

        TampilkanIDBerikutnya()
        TampilData()

    End Sub

    ' MEMASTIKAN KONEKSI DATABASE TERBUKA
    Private Function PastikanKoneksi() As Boolean

        Try
            BukaKoneksi()

            If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
                MessageBox.Show("Koneksi ke database gagal!")
                Return False
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show("Gagal menghubungkan database: " & ex.Message)
            Return False
        End Try

    End Function

    ' MENAMPILKAN ID KATALOG BERIKUTNYA
    Private Sub TampilkanIDBerikutnya()

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "SELECT IFNULL(MAX(KatalogID), 0) + 1 FROM katalog"

            Using cmd As New MySqlCommand(query, conn)

                Dim idBerikutnya As Integer =
                    Convert.ToInt32(cmd.ExecuteScalar())

                txtKatalogID.Text = idBerikutnya.ToString()

            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal mengambil ID katalog: " & ex.Message)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    ' VALIDASI INPUT
    Private Function ValidasiInput() As Boolean

        If txtNamaModel.Text.Trim() = "" Then
            MessageBox.Show("Nama model harus diisi!")
            txtNamaModel.Focus()
            Return False
        End If

        If txtDeskripsi.Text.Trim() = "" Then
            MessageBox.Show("Deskripsi model harus diisi!")
            txtDeskripsi.Focus()
            Return False
        End If

        If txtGambar.Text.Trim() = "" Then
            MessageBox.Show("Gambar model harus diisi!")
            txtGambar.Focus()
            Return False
        End If

        If cboStatus.SelectedIndex = -1 Then
            MessageBox.Show("Pilih status katalog terlebih dahulu!")
            cboStatus.Focus()
            Return False
        End If

        Return True

    End Function

    ' MEMERIKSA NAMA MODEL DUPLIKAT
    Private Function NamaDuplikat(nama As String, Optional id As String = "") As Boolean

        Try
            If Not PastikanKoneksi() Then Return True

            Dim query As String =
                "SELECT COUNT(*) FROM katalog " &
                "WHERE LOWER(TRIM(nama_model)) = LOWER(TRIM(@nama))"

            If id <> "" Then
                query &= " AND KatalogID <> @id"
            End If

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nama", nama.Trim())

                If id <> "" Then
                    cmd.Parameters.AddWithValue("@id", id)
                End If

                Dim jumlah As Integer =
                    Convert.ToInt32(cmd.ExecuteScalar())

                Return jumlah > 0

            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memeriksa nama model: " & ex.Message)
            Return True

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Function

    ' MENAMPILKAN DATA KATALOG
    Private Sub TampilData()

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "SELECT KatalogID, nama_model, deskripsi, gambar, status " &
                "FROM katalog ORDER BY KatalogID"

            Dim dt As New DataTable()

            Using da As New MySqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using

            dgvKatalog.DataSource = dt

            dgvKatalog.ReadOnly = True
            dgvKatalog.AllowUserToAddRows = False
            dgvKatalog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvKatalog.MultiSelect = False
            dgvKatalog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If dgvKatalog.Columns.Count > 0 Then
                dgvKatalog.Columns("KatalogID").HeaderText = "ID Katalog"
                dgvKatalog.Columns("nama_model").HeaderText = "Nama Model"
                dgvKatalog.Columns("deskripsi").HeaderText = "Deskripsi"
                dgvKatalog.Columns("gambar").HeaderText = "Gambar"
                dgvKatalog.Columns("status").HeaderText = "Status"
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    ' TOMBOL TAMBAH
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click

        If Not ValidasiInput() Then Exit Sub

        If NamaDuplikat(txtNamaModel.Text) Then
            MessageBox.Show("Nama model sudah terdaftar!")
            txtNamaModel.Focus()
            Exit Sub
        End If

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "INSERT INTO katalog (nama_model, deskripsi, gambar, status) " &
                "VALUES (@nama, @deskripsi, @gambar, @status)"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nama", txtNamaModel.Text.Trim())
                cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim())
                cmd.Parameters.AddWithValue("@gambar", txtGambar.Text.Trim())
                cmd.Parameters.AddWithValue("@status", cboStatus.Text)

                cmd.ExecuteNonQuery()

            End Using

            MessageBox.Show("Data katalog berhasil ditambahkan!")

            KosongkanForm()
            TampilData()

        Catch ex As Exception
            MessageBox.Show("Gagal menambahkan data: " & ex.Message)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    ' MEMILIH DATA DARI TABEL
    Private Sub dgvKatalog_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKatalog.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim baris As DataGridViewRow = dgvKatalog.Rows(e.RowIndex)

        txtKatalogID.Text = baris.Cells("KatalogID").Value.ToString()
        txtNamaModel.Text = baris.Cells("nama_model").Value.ToString()
        txtDeskripsi.Text = baris.Cells("deskripsi").Value.ToString()
        txtGambar.Text = baris.Cells("gambar").Value.ToString()
        cboStatus.Text = baris.Cells("status").Value.ToString()

    End Sub

    ' TOMBOL UBAH
    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click

        If txtKatalogID.Text = "" Then
            MessageBox.Show("Pilih data yang ingin diubah!")
            Exit Sub
        End If

        If Not ValidasiInput() Then Exit Sub

        If NamaDuplikat(txtNamaModel.Text, txtKatalogID.Text) Then
            MessageBox.Show("Nama model sudah digunakan oleh data lain!")
            txtNamaModel.Focus()
            Exit Sub
        End If

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "UPDATE katalog SET nama_model = @nama, " &
                "deskripsi = @deskripsi, gambar = @gambar, status = @status " &
                "WHERE KatalogID = @id"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@id", txtKatalogID.Text)
                cmd.Parameters.AddWithValue("@nama", txtNamaModel.Text.Trim())
                cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim())
                cmd.Parameters.AddWithValue("@gambar", txtGambar.Text.Trim())
                cmd.Parameters.AddWithValue("@status", cboStatus.Text)

                Dim hasil As Integer = cmd.ExecuteNonQuery()

                If hasil > 0 Then
                    MessageBox.Show("Data katalog berhasil diubah!")
                Else
                    MessageBox.Show("Tidak ada data yang berhasil diubah!")
                End If

            End Using

            KosongkanForm()
            TampilData()

        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data: " & ex.Message)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    ' TOMBOL HAPUS
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

        If txtKatalogID.Text = "" Then
            MessageBox.Show("Pilih data yang ingin dihapus!")
            Exit Sub
        End If

        Dim konfirmasi As DialogResult = MessageBox.Show(
            "Apakah kamu yakin ingin menghapus katalog ini?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If konfirmasi = DialogResult.No Then Exit Sub

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "DELETE FROM katalog WHERE KatalogID = @id"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@id", txtKatalogID.Text)

                Dim hasil As Integer = cmd.ExecuteNonQuery()

                If hasil > 0 Then
                    MessageBox.Show("Data katalog berhasil dihapus!")
                Else
                    MessageBox.Show("Data katalog tidak ditemukan!")
                End If

            End Using

            KosongkanForm()
            TampilData()

        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show(
                    "Data katalog tidak dapat dihapus karena masih digunakan oleh data lain!",
                    "Gagal Menghapus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )
            Else
                MessageBox.Show("Gagal menghapus data: " & ex.Message)
            End If

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    ' MENGOSONGKAN INPUT DAN MENAMPILKAN ID BERIKUTNYA
    Private Sub KosongkanForm()

        txtNamaModel.Clear()
        txtDeskripsi.Clear()
        txtGambar.Clear()
        cboStatus.SelectedIndex = 0

        dgvKatalog.ClearSelection()

        TampilkanIDBerikutnya()

    End Sub

    ' TOMBOL CLEAR
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        KosongkanForm()

    End Sub

    ' TOMBOL HOME
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click

        Dim menu As New FormMenuOwner()
        menu.Show()
        Me.Close()

    End Sub

End Class
