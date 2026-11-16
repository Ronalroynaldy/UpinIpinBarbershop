
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class FormDataLayanan

    ' SAAT FORM DIBUKA
    Private Sub FormDataLayanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboStatus.Items.Clear()
        cboStatus.Items.Add("Aktif")
        cboStatus.Items.Add("Tidak Aktif")
        cboStatus.SelectedIndex = 0

        txtLayananID.ReadOnly = True

        numHarga.Minimum = 0
        numHarga.Maximum = 9999999999D
        numHarga.DecimalPlaces = 2

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

    ' MENAMPILKAN ID LAYANAN BERIKUTNYA
    Private Sub TampilkanIDBerikutnya()

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "SELECT IFNULL(MAX(LayananID), 0) + 1 FROM layanan"

            Using cmd As New MySqlCommand(query, conn)

                Dim idBerikutnya As Integer =
                    Convert.ToInt32(cmd.ExecuteScalar())

                txtLayananID.Text = idBerikutnya.ToString()

            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal mengambil ID layanan: " & ex.Message)

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    ' VALIDASI INPUT
    Private Function ValidasiInput() As Boolean

        If txtNamaLayanan.Text.Trim() = "" Then
            MessageBox.Show("Nama layanan harus diisi!")
            txtNamaLayanan.Focus()
            Return False
        End If

        If txtDeskripsi.Text.Trim() = "" Then
            MessageBox.Show("Deskripsi layanan harus diisi!")
            txtDeskripsi.Focus()
            Return False
        End If

        If numHarga.Value <= 0 Then
            MessageBox.Show("Harga layanan harus lebih dari 0!")
            numHarga.Focus()
            Return False
        End If

        If cboStatus.SelectedIndex = -1 Then
            MessageBox.Show("Pilih status layanan terlebih dahulu!")
            cboStatus.Focus()
            Return False
        End If

        Return True

    End Function

    ' MEMERIKSA NAMA LAYANAN DUPLIKAT
    Private Function NamaDuplikat(nama As String, Optional id As String = "") As Boolean

        Try
            If Not PastikanKoneksi() Then Return True

            Dim query As String =
                "SELECT COUNT(*) FROM layanan " &
                "WHERE LOWER(TRIM(nama_layanan)) = LOWER(TRIM(@nama))"

            If id <> "" Then
                query &= " AND LayananID <> @id"
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
            MessageBox.Show("Gagal memeriksa nama layanan: " & ex.Message)
            Return True

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Function

    ' MENAMPILKAN DATA LAYANAN
    Private Sub TampilData()

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "SELECT LayananID, nama_layanan, deskripsi, harga, status " &
                "FROM layanan ORDER BY LayananID"

            Dim dt As New DataTable()

            Using da As New MySqlDataAdapter(query, conn)
                da.Fill(dt)
            End Using

            dgvLayanan.DataSource = dt

            dgvLayanan.ReadOnly = True
            dgvLayanan.AllowUserToAddRows = False
            dgvLayanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvLayanan.MultiSelect = False
            dgvLayanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If dgvLayanan.Columns.Count > 0 Then
                dgvLayanan.Columns("LayananID").HeaderText = "ID Layanan"
                dgvLayanan.Columns("nama_layanan").HeaderText = "Nama Layanan"
                dgvLayanan.Columns("deskripsi").HeaderText = "Deskripsi"
                dgvLayanan.Columns("harga").HeaderText = "Harga"
                dgvLayanan.Columns("status").HeaderText = "Status"
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

        If NamaDuplikat(txtNamaLayanan.Text) Then
            MessageBox.Show("Nama layanan sudah terdaftar!")
            txtNamaLayanan.Focus()
            Exit Sub
        End If

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "INSERT INTO layanan (nama_layanan, deskripsi, harga, status) " &
                "VALUES (@nama, @deskripsi, @harga, @status)"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nama", txtNamaLayanan.Text.Trim())
                cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim())
                cmd.Parameters.AddWithValue("@harga", numHarga.Value)
                cmd.Parameters.AddWithValue("@status", cboStatus.Text)

                cmd.ExecuteNonQuery()

            End Using

            MessageBox.Show("Data layanan berhasil ditambahkan!")

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
    Private Sub dgvLayanan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLayanan.CellClick

        If e.RowIndex < 0 Then Exit Sub

        Dim baris As DataGridViewRow = dgvLayanan.Rows(e.RowIndex)

        txtLayananID.Text = baris.Cells("LayananID").Value.ToString()
        txtNamaLayanan.Text = baris.Cells("nama_layanan").Value.ToString()
        txtDeskripsi.Text = baris.Cells("deskripsi").Value.ToString()
        numHarga.Value = Convert.ToDecimal(baris.Cells("harga").Value)
        cboStatus.Text = baris.Cells("status").Value.ToString()

    End Sub

    ' TOMBOL UBAH
    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click

        If txtLayananID.Text = "" Then
            MessageBox.Show("Pilih data yang ingin diubah!")
            Exit Sub
        End If

        If Not ValidasiInput() Then Exit Sub

        If NamaDuplikat(txtNamaLayanan.Text, txtLayananID.Text) Then
            MessageBox.Show("Nama layanan sudah digunakan oleh data lain!")
            txtNamaLayanan.Focus()
            Exit Sub
        End If

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "UPDATE layanan SET nama_layanan = @nama, " &
                "deskripsi = @deskripsi, harga = @harga, status = @status " &
                "WHERE LayananID = @id"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@id", txtLayananID.Text)
                cmd.Parameters.AddWithValue("@nama", txtNamaLayanan.Text.Trim())
                cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim())
                cmd.Parameters.AddWithValue("@harga", numHarga.Value)
                cmd.Parameters.AddWithValue("@status", cboStatus.Text)

                Dim hasil As Integer = cmd.ExecuteNonQuery()

                If hasil > 0 Then
                    MessageBox.Show("Data layanan berhasil diubah!")
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

        If txtLayananID.Text = "" Then
            MessageBox.Show("Pilih data yang ingin dihapus!")
            Exit Sub
        End If

        Dim konfirmasi As DialogResult = MessageBox.Show(
            "Apakah kamu yakin ingin menghapus layanan ini?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If konfirmasi = DialogResult.No Then Exit Sub

        Try
            If Not PastikanKoneksi() Then Exit Sub

            Dim query As String =
                "DELETE FROM layanan WHERE LayananID = @id"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@id", txtLayananID.Text)

                Dim hasil As Integer = cmd.ExecuteNonQuery()

                If hasil > 0 Then
                    MessageBox.Show("Data layanan berhasil dihapus!")
                Else
                    MessageBox.Show("Data layanan tidak ditemukan!")
                End If

            End Using

            KosongkanForm()
            TampilData()

        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show(
                    "Data layanan tidak dapat dihapus karena masih digunakan pada transaksi!",
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

        txtNamaLayanan.Clear()
        txtDeskripsi.Clear()
        numHarga.Value = 0
        cboStatus.SelectedIndex = 0

        dgvLayanan.ClearSelection()

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
