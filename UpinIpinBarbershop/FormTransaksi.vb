
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class FormTransaksi

    Private Const OWNER_ID As Integer = 1
    Private formSiap As Boolean = False

    ' ==============================
    ' FORM LOAD
    ' ==============================
    Private Sub FormTransaksi_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        formSiap = False

        BukaKoneksi()

        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            MessageBox.Show("Database tidak dapat dihubungkan.")
            Return
        End If

        txtNomorTransaksi.ReadOnly = True
        txtHarga.ReadOnly = True
        txtGrandTotal.ReadOnly = True

        txtNamaPelanggan.Enabled = False

        numJumlah.Minimum = 1
        numJumlah.Maximum = 100
        numJumlah.Value = 1

        dtpTanggal.Value = DateTime.Now

        AturDataGridView()
        IsiComboPelanggan()
        IsiComboLayanan()
        IsiComboPembayaran()

        txtHarga.Text = "0"
        txtGrandTotal.Text = "0"

        BuatNomorTransaksi()

        formSiap = True

    End Sub


    ' ==============================
    ' MEMASTIKAN KONEKSI DATABASE
    ' ==============================
    Private Function PastikanKoneksi() As Boolean

        Try
            If conn Is Nothing OrElse
               conn.State <> ConnectionState.Open Then

                BukaKoneksi()

            End If

            Return conn IsNot Nothing AndAlso
                   conn.State = ConnectionState.Open

        Catch ex As Exception

            MessageBox.Show(
                "Koneksi database gagal: " & ex.Message
            )

            Return False

        End Try

    End Function


    ' ==============================
    ' MENGATUR DATAGRIDVIEW
    ' ==============================
    Private Sub AturDataGridView()

        dgvDetailTransaksi.Columns.Clear()

        dgvDetailTransaksi.AllowUserToAddRows = False
        dgvDetailTransaksi.ReadOnly = True
        dgvDetailTransaksi.MultiSelect = False
        dgvDetailTransaksi.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect

        dgvDetailTransaksi.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        dgvDetailTransaksi.Columns.Add(
            "LayananID",
            "ID Layanan"
        )

        dgvDetailTransaksi.Columns.Add(
            "NamaLayanan",
            "Nama Layanan"
        )

        dgvDetailTransaksi.Columns.Add(
            "Jumlah",
            "Quantity"
        )

        dgvDetailTransaksi.Columns.Add(
            "Harga",
            "Unit Price"
        )

        dgvDetailTransaksi.Columns.Add(
            "Subtotal",
            "Subtotal"
        )

        dgvDetailTransaksi.Columns("LayananID").Visible = False

        dgvDetailTransaksi.Columns("Harga").DefaultCellStyle.Format = "N0"
        dgvDetailTransaksi.Columns("Subtotal").DefaultCellStyle.Format = "N0"

    End Sub


    ' ==============================
    ' MENGISI COMBOBOX PELANGGAN
    ' ==============================
    Private Sub IsiComboPelanggan()

        Try
            Dim dt As New DataTable()

            Dim kolomID As DataColumn =
                dt.Columns.Add("UserID", GetType(Integer))

            kolomID.AllowDBNull = True

            dt.Columns.Add(
                "NamaTampilan",
                GetType(String)
            )

            ' Pilihan pelanggan umum
            Dim row As DataRow = dt.NewRow()

            row("UserID") = DBNull.Value
            row("NamaTampilan") = "Pelanggan Umum"

            dt.Rows.Add(row)

            ' Mengambil pelanggan terdaftar
            Dim sql As String =
                "SELECT UserID, nama AS NamaTampilan " &
                "FROM users " &
                "WHERE role = 'Pelanggan' " &
                "ORDER BY nama"

            Using cmd As New MySqlCommand(sql, conn)

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(dt)

                End Using

            End Using

            cboPelanggan.DataSource = Nothing
            cboPelanggan.DataSource = dt

            cboPelanggan.DisplayMember = "NamaTampilan"
            cboPelanggan.ValueMember = "UserID"

            cboPelanggan.SelectedIndex = 0

            txtNamaPelanggan.Clear()
            txtNamaPelanggan.Enabled = True

        Catch ex As Exception

            MessageBox.Show(
                "Gagal mengambil data pelanggan: " & ex.Message
            )

        End Try

    End Sub


    ' ==============================
    ' PILIH PELANGGAN
    ' ==============================
    Private Sub cboPelanggan_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboPelanggan.SelectedIndexChanged

        If Not formSiap Then Return

        If cboPelanggan.SelectedIndex = 0 Then

            txtNamaPelanggan.Enabled = True
            txtNamaPelanggan.Clear()
            txtNamaPelanggan.Focus()

        Else

            txtNamaPelanggan.Enabled = False
            txtNamaPelanggan.Clear()

        End If

    End Sub


    ' ==============================
    ' MENGISI COMBOBOX LAYANAN
    ' ==============================
    Private Sub IsiComboLayanan()

        Try
            Dim dt As New DataTable()

            Dim sql As String =
                "SELECT LayananID, nama_layanan, harga " &
                "FROM layanan " &
                "WHERE status = 'Aktif' " &
                "ORDER BY nama_layanan"

            Using cmd As New MySqlCommand(sql, conn)

                Using adapter As New MySqlDataAdapter(cmd)

                    adapter.Fill(dt)

                End Using

            End Using

            cboLayanan.DataSource = Nothing
            cboLayanan.DataSource = dt

            cboLayanan.DisplayMember = "nama_layanan"
            cboLayanan.ValueMember = "LayananID"

            cboLayanan.SelectedIndex = -1

            txtHarga.Text = "0"

        Catch ex As Exception

            MessageBox.Show(
                "Gagal mengambil data layanan: " & ex.Message
            )

        End Try

    End Sub


    ' ==============================
    ' MENGISI COMBOBOX PEMBAYARAN
    ' ==============================
    Private Sub IsiComboPembayaran()

        cboMetodePembayaran.Items.Clear()

        cboMetodePembayaran.Items.Add("Cash")
        cboMetodePembayaran.Items.Add("QRIS")

        cboMetodePembayaran.SelectedIndex = -1

        cboStatusPembayaran.Items.Clear()

        cboStatusPembayaran.Items.Add("Lunas")
        cboStatusPembayaran.Items.Add("Belum Lunas")

        cboStatusPembayaran.SelectedIndex = -1

    End Sub


    ' ==============================
    ' MEMBUAT NOMOR TRANSAKSI
    ' ==============================
    Private Sub BuatNomorTransaksi()

        If Not PastikanKoneksi() Then Return

        Try
            Dim tanggal As String =
                dtpTanggal.Value.ToString("yyyyMMdd")

            Dim prefix As String =
                "ORD-" & tanggal & "-"

            Dim sql As String =
                "SELECT IFNULL(MAX(" &
                "CAST(SUBSTRING_INDEX(nomor_transaksi, '-', -1) AS UNSIGNED)" &
                "), 0) + 1 " &
                "FROM transaksi " &
                "WHERE nomor_transaksi LIKE @prefix"

            Dim nomorUrut As Integer

            Using cmd As New MySqlCommand(sql, conn)

                cmd.Parameters.AddWithValue(
                    "@prefix",
                    prefix & "%"
                )

                nomorUrut = Convert.ToInt32(
                    cmd.ExecuteScalar()
                )

            End Using

            txtNomorTransaksi.Text =
                prefix & nomorUrut.ToString("0000")

        Catch ex As Exception

            MessageBox.Show(
                "Gagal membuat nomor transaksi: " & ex.Message
            )

        End Try

    End Sub


    ' ==============================
    ' PERUBAHAN TANGGAL TRANSAKSI
    ' ==============================
    Private Sub dtpTanggal_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles dtpTanggal.ValueChanged

        If Not formSiap Then Return

        BuatNomorTransaksi()

    End Sub


    ' ==============================
    ' MENAMPILKAN HARGA LAYANAN
    ' ==============================
    Private Sub cboLayanan_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboLayanan.SelectedIndexChanged

        Try
            If cboLayanan.SelectedIndex = -1 Then

                txtHarga.Text = "0"
                Return

            End If

            Dim baris As DataRowView =
                TryCast(cboLayanan.SelectedItem, DataRowView)

            If baris IsNot Nothing Then

                Dim harga As Decimal =
                    Convert.ToDecimal(baris("harga"))

                txtHarga.Text = harga.ToString("N0")

            End If

        Catch

            txtHarga.Text = "0"

        End Try

    End Sub


    ' ==============================
    ' TOMBOL TAMBAH LAYANAN
    ' ==============================

    Private Sub btnTambahLayanan_Click(
    sender As Object,
    e As EventArgs
) Handles btnTambahLayanan.Click

        If cboLayanan.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih layanan terlebih dahulu.")
            cboLayanan.Focus()
            Return
        End If

        If numJumlah.Value < 1 Then
            MessageBox.Show("Jumlah layanan minimal 1.")
            Return
        End If

        Try
            Dim baris As DataRowView =
            TryCast(cboLayanan.SelectedItem, DataRowView)

            If baris Is Nothing Then Return

            Dim idLayanan As Integer =
            Convert.ToInt32(baris("LayananID"))

            Dim namaLayanan As String =
            baris("nama_layanan").ToString()

            Dim harga As Decimal =
            Convert.ToDecimal(baris("harga"))

            Dim jumlahTambahan As Integer =
            Convert.ToInt32(numJumlah.Value)

            Dim layananDitemukan As Boolean = False

            ' Memeriksa apakah layanan sudah ada di DataGridView
            For Each row As DataGridViewRow In dgvDetailTransaksi.Rows

                If Convert.ToInt32(
                row.Cells("LayananID").Value
            ) = idLayanan Then

                    ' Menambahkan quantity lama dengan quantity baru
                    Dim jumlahLama As Integer =
                    Convert.ToInt32(row.Cells("Jumlah").Value)

                    Dim jumlahBaru As Integer =
                    jumlahLama + jumlahTambahan

                    ' Menghitung subtotal baru
                    Dim subtotalBaru As Decimal =
                    harga * jumlahBaru

                    row.Cells("Jumlah").Value = jumlahBaru
                    row.Cells("Harga").Value = harga
                    row.Cells("Subtotal").Value = subtotalBaru

                    layananDitemukan = True

                    Exit For

                End If

            Next

            ' Jika layanan belum ada, tambahkan baris baru
            If Not layananDitemukan Then

                Dim subtotal As Decimal =
                harga * jumlahTambahan

                dgvDetailTransaksi.Rows.Add(
                idLayanan,
                namaLayanan,
                jumlahTambahan,
                harga,
                subtotal
            )

            End If

            ' Menghitung ulang total transaksi
            HitungGrandTotal()

            ' Mengosongkan pilihan layanan
            cboLayanan.SelectedIndex = -1
            numJumlah.Value = 1
            txtHarga.Text = "0"

            MessageBox.Show(
            "Layanan berhasil ditambahkan.",
            "Berhasil",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

        Catch ex As Exception

            MessageBox.Show(
            "Gagal menambahkan layanan: " & ex.Message
        )

        End Try

    End Sub

    ' ==============================
    ' MENGHITUNG GRAND TOTAL
    ' ==============================
    Private Sub HitungGrandTotal()

        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvDetailTransaksi.Rows

            If Not row.IsNewRow Then

                total += Convert.ToDecimal(
                    row.Cells("Subtotal").Value
                )

            End If

        Next

        txtGrandTotal.Text = total.ToString("N0")

    End Sub


    ' ==============================
    ' TOMBOL HAPUS LAYANAN
    ' ==============================
    Private Sub btnHapusLayanan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHapusLayanan.Click

        If dgvDetailTransaksi.SelectedRows.Count = 0 Then

            MessageBox.Show("Pilih layanan yang ingin dihapus.")
            Return

        End If

        Dim konfirmasi As DialogResult =
            MessageBox.Show(
                "Yakin ingin menghapus layanan ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If konfirmasi = DialogResult.Yes Then

            dgvDetailTransaksi.Rows.Remove(
                dgvDetailTransaksi.SelectedRows(0)
            )

            HitungGrandTotal()

        End If

    End Sub


    ' ==============================
    ' VALIDASI TRANSAKSI
    ' ==============================
    Private Function ValidasiTransaksi() As Boolean

        If cboPelanggan.SelectedIndex = -1 Then

            MessageBox.Show("Silakan pilih pelanggan.")
            cboPelanggan.Focus()
            Return False

        End If

        ' Validasi pelanggan umum
        If cboPelanggan.SelectedIndex = 0 AndAlso
           String.IsNullOrWhiteSpace(txtNamaPelanggan.Text) Then

            MessageBox.Show(
                "Nama pelanggan umum harus diisi."
            )

            txtNamaPelanggan.Focus()
            Return False

        End If

        ' Validasi layanan
        If dgvDetailTransaksi.Rows.Count = 0 Then

            MessageBox.Show(
                "Tambahkan minimal satu layanan."
            )

            cboLayanan.Focus()
            Return False

        End If

        ' Validasi metode pembayaran
        If cboMetodePembayaran.SelectedIndex = -1 Then

            MessageBox.Show(
                "Pilih metode pembayaran."
            )

            cboMetodePembayaran.Focus()
            Return False

        End If

        ' Validasi status pembayaran
        If cboStatusPembayaran.SelectedIndex = -1 Then

            MessageBox.Show(
                "Pilih status pembayaran."
            )

            cboStatusPembayaran.Focus()
            Return False

        End If

        If String.IsNullOrWhiteSpace(txtNomorTransaksi.Text) Then

            MessageBox.Show(
                "Nomor transaksi belum tersedia."
            )

            Return False

        End If

        Return True

    End Function


    ' ==============================
    ' TOMBOL SIMPAN TRANSAKSI
    ' ==============================
    Private Sub btnSimpan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        If Not ValidasiTransaksi() Then Return

        If Not PastikanKoneksi() Then

            MessageBox.Show("Koneksi database gagal.")
            Return

        End If

        Dim transaksiDB As MySqlTransaction = Nothing

        Try
            ' Menentukan data pelanggan
            Dim userID As Object = DBNull.Value
            Dim namaPelangganManual As Object = DBNull.Value

            If cboPelanggan.SelectedIndex = 0 Then

                namaPelangganManual =
                    txtNamaPelanggan.Text.Trim()

            Else

                If cboPelanggan.SelectedValue Is Nothing OrElse
                   Convert.IsDBNull(cboPelanggan.SelectedValue) Then

                    MessageBox.Show(
                        "Data pelanggan tidak valid."
                    )

                    Return

                End If

                userID = Convert.ToInt32(
                    cboPelanggan.SelectedValue
                )

            End If

            ' Menghitung total transaksi
            Dim total As Decimal = 0

            For Each row As DataGridViewRow In dgvDetailTransaksi.Rows

                total += Convert.ToDecimal(
                    row.Cells("Subtotal").Value
                )

            Next

            If total <= 0 Then

                MessageBox.Show(
                    "Total transaksi harus lebih dari 0."
                )

                Return

            End If

            Dim nomorTransaksi As String =
                txtNomorTransaksi.Text.Trim()

            ' Memulai transaksi database
            transaksiDB = conn.BeginTransaction()

            ' Memastikan nomor transaksi belum digunakan
            Dim sqlCek As String =
                "SELECT COUNT(*) FROM transaksi " &
                "WHERE nomor_transaksi = @nomor"

            Using cmdCek As New MySqlCommand(
                sqlCek,
                conn,
                transaksiDB
            )

                cmdCek.Parameters.AddWithValue(
                    "@nomor",
                    nomorTransaksi
                )

                Dim jumlah As Integer =
                    Convert.ToInt32(cmdCek.ExecuteScalar())

                If jumlah > 0 Then

                    transaksiDB.Rollback()
                    transaksiDB = Nothing

                    MessageBox.Show(
                        "Nomor transaksi sudah digunakan. " &
                        "Silakan buat nomor transaksi baru."
                    )

                    BuatNomorTransaksi()
                    Return

                End If

            End Using

            ' ==============================
            ' MENYIMPAN TRANSAKSI UTAMA
            ' ==============================
            Dim sqlTransaksi As String =
                "INSERT INTO transaksi " &
                "(nomor_transaksi, tanggal_transaksi, UserID, " &
                "nama_pelanggan_manual, OwnerID, total_biaya, " &
                "metode_pembayaran, status_pembayaran) " &
                "VALUES " &
                "(@nomor, @tanggal, @userID, @namaManual, " &
                "@ownerID, @total, @metode, @status)"

            Dim idTransaksi As Long

            Using cmd As New MySqlCommand(
                sqlTransaksi,
                conn,
                transaksiDB
            )

                cmd.Parameters.AddWithValue(
                    "@nomor",
                    nomorTransaksi
                )

                cmd.Parameters.AddWithValue(
                    "@tanggal",
                    dtpTanggal.Value
                )

                cmd.Parameters.AddWithValue(
                    "@userID",
                    userID
                )

                cmd.Parameters.AddWithValue(
                    "@namaManual",
                    namaPelangganManual
                )

                cmd.Parameters.AddWithValue(
                    "@ownerID",
                    OWNER_ID
                )

                cmd.Parameters.AddWithValue(
                    "@total",
                    total
                )

                cmd.Parameters.AddWithValue(
                    "@metode",
                    cboMetodePembayaran.Text
                )

                cmd.Parameters.AddWithValue(
                    "@status",
                    cboStatusPembayaran.Text
                )

                cmd.ExecuteNonQuery()

                idTransaksi = cmd.LastInsertedId

            End Using

            ' ==============================
            ' MENYIMPAN DETAIL TRANSAKSI
            ' ==============================
            Dim sqlDetail As String =
                "INSERT INTO detail_transaksi " &
                "(TransaksiID, LayananID, jumlah, " &
                "harga_saat_transaksi, subtotal) " &
                "VALUES " &
                "(@transaksiID, @layananID, @jumlah, " &
                "@harga, @subtotal)"

            For Each row As DataGridViewRow In dgvDetailTransaksi.Rows

                Using cmdDetail As New MySqlCommand(
                    sqlDetail,
                    conn,
                    transaksiDB
                )

                    cmdDetail.Parameters.AddWithValue(
                        "@transaksiID",
                        idTransaksi
                    )

                    cmdDetail.Parameters.AddWithValue(
                        "@layananID",
                        Convert.ToInt32(
                            row.Cells("LayananID").Value
                        )
                    )

                    cmdDetail.Parameters.AddWithValue(
                        "@jumlah",
                        Convert.ToInt32(
                            row.Cells("Jumlah").Value
                        )
                    )

                    cmdDetail.Parameters.AddWithValue(
                        "@harga",
                        Convert.ToDecimal(
                            row.Cells("Harga").Value
                        )
                    )

                    cmdDetail.Parameters.AddWithValue(
                        "@subtotal",
                        Convert.ToDecimal(
                            row.Cells("Subtotal").Value
                        )
                    )

                    cmdDetail.ExecuteNonQuery()

                End Using

            Next

            ' Menyimpan seluruh perubahan
            transaksiDB.Commit()

            MessageBox.Show(
                "Transaksi berhasil disimpan!" &
                vbCrLf &
                "Nomor Transaksi: " & nomorTransaksi,
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            BersihkanForm()

        Catch ex As Exception

            If transaksiDB IsNot Nothing Then

                Try
                    transaksiDB.Rollback()
                Catch
                End Try

            End If

            MessageBox.Show(
                "Transaksi gagal disimpan: " & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally

            If transaksiDB IsNot Nothing Then
                transaksiDB.Dispose()
            End If

        End Try

    End Sub


    ' ==============================
    ' MEMBERSIHKAN FORM
    ' ==============================
    Private Sub BersihkanForm()

        dgvDetailTransaksi.Rows.Clear()

        If cboPelanggan.Items.Count > 0 Then

            cboPelanggan.SelectedIndex = 0

        End If

        txtNamaPelanggan.Clear()
        txtNamaPelanggan.Enabled = True

        cboLayanan.SelectedIndex = -1

        numJumlah.Value = 1

        txtHarga.Text = "0"
        txtGrandTotal.Text = "0"

        cboMetodePembayaran.SelectedIndex = -1
        cboStatusPembayaran.SelectedIndex = -1

        dtpTanggal.Value = DateTime.Now

        BuatNomorTransaksi()

    End Sub


    ' ==============================
    ' TOMBOL CLEAR
    ' ==============================
    Private Sub btnClear_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnClear.Click

        Dim konfirmasi As DialogResult =
            MessageBox.Show(
                "Yakin ingin mengosongkan seluruh data transaksi?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If konfirmasi = DialogResult.Yes Then

            BersihkanForm()

        End If

    End Sub


    ' ==============================
    ' TOMBOL HOME
    ' ==============================
    Private Sub btnHome_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHome.Click

        Dim menu As New FormMenuOwner()

        menu.Show()

        Me.Close()

    End Sub

End Class
