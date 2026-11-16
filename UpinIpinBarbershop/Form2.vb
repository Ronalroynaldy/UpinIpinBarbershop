
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class FormTransaksiProduk

    ' ==========================================
    ' KONFIGURASI DATABASE
    ' ==========================================

    Private ReadOnly CONN_STR As String =
    "server=localhost;" &
    "user id=root;" &
    "password=;" &
    "database=db_upin_ipin_barbershop;" &
    "SslMode=Disabled;"

    ' Referensi Form Menu Owner
    Public Property HomeForm As FormMenuOwner

    Private sedangMemuat As Boolean = False

    ' ==========================================
    ' FORM LOAD
    ' ==========================================

    Private Sub FormTransaksiProduk_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        sedangMemuat = True

        Try
            ' Pengaturan input
            txtNomorTransaksi.ReadOnly = True
            txtHarga.ReadOnly = True
            txtStok.ReadOnly = True
            txtSubtotal.ReadOnly = True

            nudJumlah.Minimum = 1
            nudJumlah.Maximum = 999
            nudJumlah.Value = 1

            dtpTanggal.Value = Date.Today

            ' Pengaturan ComboBox pembayaran
            cmbMetodePembayaran.Items.Clear()
            cmbMetodePembayaran.Items.Add("Cash")
            cmbMetodePembayaran.Items.Add("QRIS")
            cmbMetodePembayaran.SelectedIndex = 0

            cmbStatusPembayaran.Items.Clear()
            cmbStatusPembayaran.Items.Add("Lunas")
            cmbStatusPembayaran.Items.Add("Belum Lunas")
            cmbStatusPembayaran.SelectedIndex = 0

            ' Pengaturan DataGridView
            AturDataGridView()

            ' Memuat data produk
            MuatProduk()

            ' Membuat nomor transaksi sementara
            TampilkanNomorTransaksi()

            ' Tampilan awal total
            lblGrandTotal.Text = "Rp 0,00"

        Catch ex As Exception
            MessageBox.Show(
                "Gagal memuat form: " & ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        Finally
            sedangMemuat = False
        End Try

    End Sub

    ' ==========================================
    ' PENGATURAN DATAGRIDVIEW
    ' ==========================================

    Private Sub AturDataGridView()

        dgvKeranjang.AllowUserToAddRows = False
        dgvKeranjang.AllowUserToDeleteRows = False
        dgvKeranjang.ReadOnly = True
        dgvKeranjang.RowHeadersVisible = False
        dgvKeranjang.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect
        dgvKeranjang.MultiSelect = False
        dgvKeranjang.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill

        ' Jika kolom belum dibuat melalui Designer,
        ' buat kolom secara otomatis.
        If dgvKeranjang.Columns.Count = 0 Then

            dgvKeranjang.Columns.Add("colNo", "No")
            dgvKeranjang.Columns.Add(
                "colNamaProduk", "Nama Produk"
            )
            dgvKeranjang.Columns.Add(
                "colHarga", "Harga Satuan"
            )
            dgvKeranjang.Columns.Add(
                "colJumlah", "Jumlah"
            )
            dgvKeranjang.Columns.Add(
                "colSubtotal", "Subtotal"
            )

        End If

        dgvKeranjang.Columns("colNo").FillWeight = 40
        dgvKeranjang.Columns("colNamaProduk").FillWeight = 130
        dgvKeranjang.Columns("colHarga").FillWeight = 100
        dgvKeranjang.Columns("colJumlah").FillWeight = 60
        dgvKeranjang.Columns("colSubtotal").FillWeight = 100

        dgvKeranjang.Columns("colHarga").
            DefaultCellStyle.Format = "N0"

        dgvKeranjang.Columns("colSubtotal").
            DefaultCellStyle.Format = "N0"

    End Sub

    ' ==========================================
    ' MEMUAT DATA PRODUK KE COMBOBOX
    ' ==========================================

    Private Sub MuatProduk()

        Dim dt As New DataTable()

        Dim sql As String =
            "SELECT ProdukID, " &
            "nama_produk AS NamaProduk, " &
            "harga_jual AS HargaJual, " &
            "stok AS Stok " &
            "FROM produk " &
            "WHERE status = 'Aktif' " &
            "ORDER BY nama_produk ASC"

        Using cn As New MySqlConnection(CONN_STR)

            Using cmd As New MySqlCommand(sql, cn)

                cn.Open()

                Using reader As MySqlDataReader =
                    cmd.ExecuteReader()

                    dt.Load(reader)

                End Using

            End Using

        End Using

        cmbProduk.DataSource = Nothing
        cmbProduk.DisplayMember = "NamaProduk"
        cmbProduk.ValueMember = "ProdukID"
        cmbProduk.DataSource = dt
        cmbProduk.SelectedIndex = -1

    End Sub

    ' ==========================================
    ' MEMILIH PRODUK
    ' ==========================================

    Private Sub cmbProduk_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbProduk.SelectedIndexChanged

        If Not sedangMemuat Then
            HitungSubtotalInput()
        End If

    End Sub

    Private Sub nudJumlah_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles nudJumlah.ValueChanged

        If Not sedangMemuat Then
            HitungSubtotalInput()
        End If

    End Sub

    ' ==========================================
    ' MENGHITUNG SUBTOTAL INPUT
    ' ==========================================

    Private Sub HitungSubtotalInput()

        Dim barang As DataRowView =
            TryCast(cmbProduk.SelectedItem, DataRowView)

        If barang Is Nothing Then

            txtHarga.Clear()
            txtStok.Clear()
            txtSubtotal.Clear()

            Return

        End If

        Dim harga As Decimal =
            Convert.ToDecimal(barang("HargaJual"))

        Dim stok As Integer =
            Convert.ToInt32(barang("Stok"))

        Dim jumlah As Integer =
            Convert.ToInt32(nudJumlah.Value)

        Dim subtotal As Decimal =
            harga * jumlah

        txtHarga.Text = harga.ToString("N0")
        txtStok.Text = stok.ToString()
        txtSubtotal.Text = subtotal.ToString("N0")

    End Sub

    ' ==========================================
    ' TOMBOL TAMBAH PRODUK
    ' ==========================================

    Private Sub btnTambahProduk_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTambahProduk.Click

        Dim barang As DataRowView =
            TryCast(cmbProduk.SelectedItem, DataRowView)

        If barang Is Nothing Then

            MessageBox.Show("Pilih produk terlebih dahulu.")
            cmbProduk.Focus()
            Return

        End If

        Dim produkID As Integer =
            Convert.ToInt32(barang("ProdukID"))

        Dim namaProduk As String =
            Convert.ToString(barang("NamaProduk"))

        Dim harga As Decimal =
            Convert.ToDecimal(barang("HargaJual"))

        Dim stok As Integer =
            Convert.ToInt32(barang("Stok"))

        Dim jumlah As Integer =
            Convert.ToInt32(nudJumlah.Value)

        ' Periksa stok produk
        If jumlah > stok Then

            MessageBox.Show(
                "Stok tidak mencukupi." &
                vbCrLf &
                "Stok tersedia: " & stok,
                "Peringatan"
            )

            Return

        End If

        ' Cek apakah produk sudah ada di keranjang
        For Each row As DataGridViewRow In dgvKeranjang.Rows

            If Convert.ToInt32(row.Tag) = produkID Then

                Dim jumlahLama As Integer =
                    Convert.ToInt32(row.Cells("colJumlah").Value)

                Dim jumlahBaru As Integer =
                    jumlahLama + jumlah

                If jumlahBaru > stok Then

                    MessageBox.Show(
                        "Jumlah pembelian melebihi stok tersedia." &
                        vbCrLf &
                        "Stok tersedia: " & stok
                    )

                    Return

                End If

                row.Cells("colJumlah").Value = jumlahBaru

                row.Cells("colSubtotal").Value =
                    harga * jumlahBaru

                HitungGrandTotal()
                BersihkanInputProduk()

                Return

            End If

        Next

        ' Tambahkan produk baru ke keranjang
        Dim subtotal As Decimal =
            harga * jumlah

        Dim index As Integer =
            dgvKeranjang.Rows.Add(
                dgvKeranjang.Rows.Count + 1,
                namaProduk,
                harga,
                jumlah,
                subtotal
            )

        ' Simpan ProdukID pada Tag baris
        dgvKeranjang.Rows(index).Tag = produkID

        HitungGrandTotal()

        BersihkanInputProduk()

    End Sub

    ' ==========================================
    ' TOMBOL HAPUS ITEM
    ' ==========================================

    Private Sub btnHapusItem_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHapusItem.Click

        If dgvKeranjang.SelectedRows.Count = 0 Then

            MessageBox.Show(
                "Pilih produk yang ingin dihapus."
            )

            Return

        End If

        Dim index As Integer =
            dgvKeranjang.SelectedRows(0).Index

        dgvKeranjang.Rows.RemoveAt(index)

        AturNomorBaris()
        HitungGrandTotal()

    End Sub

    ' ==========================================
    ' MENGATUR ULANG NOMOR BARIS
    ' ==========================================

    Private Sub AturNomorBaris()

        For i As Integer = 0 To dgvKeranjang.Rows.Count - 1

            dgvKeranjang.Rows(i).Cells("colNo").Value = i + 1

        Next

    End Sub

    ' ==========================================
    ' MENGHITUNG GRAND TOTAL
    ' ==========================================

    Private Sub HitungGrandTotal()

        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgvKeranjang.Rows

            total += Convert.ToDecimal(
                row.Cells("colSubtotal").Value
            )

        Next

        lblGrandTotal.Text =
            "Rp " & total.ToString("N0")

    End Sub

    ' ==========================================
    ' MEMBERSIHKAN INPUT PRODUK
    ' ==========================================

    Private Sub BersihkanInputProduk()

        cmbProduk.SelectedIndex = -1

        txtHarga.Clear()
        txtStok.Clear()
        txtSubtotal.Clear()

        nudJumlah.Value = 1

    End Sub

    Private Sub btnBersihkan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBersihkan.Click

        BersihkanInputProduk()

    End Sub

    ' ==========================================
    ' MEMBUAT NOMOR TRANSAKSI
    ' ==========================================

    Private Sub TampilkanNomorTransaksi()

        Try

            Using cn As New MySqlConnection(CONN_STR)

                Dim sql As String =
                    "SELECT COALESCE(MAX(TransaksiProdukID), 0) + 1 " &
                    "FROM transaksi_produk"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim idBerikutnya As Long =
                        Convert.ToInt64(cmd.ExecuteScalar())

                    txtNomorTransaksi.Text =
                        "TRP-" &
                        dtpTanggal.Value.ToString("yyyyMMdd") &
                        "-" &
                        idBerikutnya.ToString("D4")

                End Using

            End Using

        Catch ex As Exception

            txtNomorTransaksi.Text = "Otomatis saat simpan"

        End Try

    End Sub

    ' ==========================================
    ' MENGAMBIL ID OWNER
    ' ==========================================

    Private Function AmbilOwnerID(
        cn As MySqlConnection,
        tr As MySqlTransaction
    ) As Integer

        Dim sql As String =
            "SELECT UserID FROM users " &
            "WHERE role = 'Owner' " &
            "ORDER BY UserID LIMIT 1"

        Using cmd As New MySqlCommand(sql, cn, tr)

            Dim hasil As Object = cmd.ExecuteScalar()

            If hasil Is Nothing OrElse IsDBNull(hasil) Then

                Throw New Exception(
                    "Data akun Owner tidak ditemukan."
                )

            End If

            Return Convert.ToInt32(hasil)

        End Using

    End Function

    ' ==========================================
    ' TOMBOL SIMPAN TRANSAKSI
    ' ==========================================

    Private Sub btnSimpan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSimpan.Click

        ' Validasi keranjang
        If dgvKeranjang.Rows.Count = 0 Then

            MessageBox.Show(
                "Tambahkan minimal satu produk."
            )

            cmbProduk.Focus()
            Return

        End If

        ' Validasi pembayaran
        If cmbMetodePembayaran.SelectedIndex = -1 Then

            MessageBox.Show("Pilih metode pembayaran.")
            Return

        End If

        If cmbStatusPembayaran.SelectedIndex = -1 Then

            MessageBox.Show("Pilih status pembayaran.")
            Return

        End If

        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgvKeranjang.Rows

            total += Convert.ToDecimal(
                row.Cells("colSubtotal").Value
            )

        Next

        If total <= 0D Then

            MessageBox.Show("Total pembayaran tidak valid.")
            Return

        End If

        Dim konfirmasi As DialogResult =
            MessageBox.Show(
                "Simpan transaksi produk ini?" &
                vbCrLf &
                "Total: Rp " & total.ToString("N0"),
                "Konfirmasi Transaksi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If konfirmasi <> DialogResult.Yes Then
            Return
        End If

        btnSimpan.Enabled = False

        Dim nomorFinal As String = ""
        Dim transaksiBerhasil As Boolean = False

        Try

            Using cn As New MySqlConnection(CONN_STR)

                cn.Open()

                Using tr As MySqlTransaction =
                    cn.BeginTransaction()

                    Try

                        ' Ambil akun Owner
                        Dim ownerID As Integer =
                            AmbilOwnerID(cn, tr)

                        ' Buat nomor sementara yang unik
                        Dim nomorSementara As String =
                            "TMP-" &
                            Guid.NewGuid().ToString("N").
                            Substring(0, 24)

                        Dim transaksiID As Long

                        ' ==================================
                        ' SIMPAN TRANSAKSI UTAMA
                        ' ==================================

                        Dim sqlHeader As String =
                            "INSERT INTO transaksi_produk " &
                            "(nomor_transaksi, tanggal_transaksi, " &
                            "OwnerID, nama_pelanggan, total_biaya, " &
                            "metode_pembayaran, status_pembayaran) " &
                            "VALUES " &
                            "(@nomor, @tanggal, @owner, @pelanggan, " &
                            "@total, @metode, @status)"

                        Using cmd As New MySqlCommand(
                            sqlHeader, cn, tr
                        )

                            cmd.Parameters.AddWithValue(
                                "@nomor", nomorSementara
                            )

                            cmd.Parameters.AddWithValue(
                                "@tanggal", dtpTanggal.Value
                            )

                            cmd.Parameters.AddWithValue(
                                "@owner", ownerID
                            )

                            If String.IsNullOrWhiteSpace(
                                txtNamaPelanggan.Text
                            ) Then

                                cmd.Parameters.AddWithValue(
                                    "@pelanggan", DBNull.Value
                                )

                            Else

                                cmd.Parameters.AddWithValue(
                                    "@pelanggan",
                                    txtNamaPelanggan.Text.Trim()
                                )

                            End If

                            cmd.Parameters.AddWithValue(
                                "@total", total
                            )

                            cmd.Parameters.AddWithValue(
                                "@metode",
                                cmbMetodePembayaran.Text
                            )

                            cmd.Parameters.AddWithValue(
                                "@status",
                                cmbStatusPembayaran.Text
                            )

                            cmd.ExecuteNonQuery()

                            transaksiID = cmd.LastInsertedId

                        End Using

                        ' Buat nomor transaksi final
                        nomorFinal =
                            "TRP-" &
                            dtpTanggal.Value.ToString("yyyyMMdd") &
                            "-" &
                            transaksiID.ToString("D4")

                        ' ==================================
                        ' UPDATE NOMOR TRANSAKSI
                        ' ==================================

                        Using cmd As New MySqlCommand(
                            "UPDATE transaksi_produk " &
                            "SET nomor_transaksi = @nomor " &
                            "WHERE TransaksiProdukID = @id",
                            cn,
                            tr
                        )

                            cmd.Parameters.AddWithValue(
                                "@nomor", nomorFinal
                            )

                            cmd.Parameters.AddWithValue(
                                "@id", transaksiID
                            )

                            cmd.ExecuteNonQuery()

                        End Using

                        ' ==================================
                        ' SIMPAN DETAIL DAN KURANGI STOK
                        ' ==================================

                        For Each row As DataGridViewRow In
                            dgvKeranjang.Rows

                            Dim produkID As Integer =
                                Convert.ToInt32(row.Tag)

                            Dim jumlah As Integer =
                                Convert.ToInt32(
                                    row.Cells("colJumlah").Value
                                )

                            Dim harga As Decimal =
                                Convert.ToDecimal(
                                    row.Cells("colHarga").Value
                                )

                            Dim subtotal As Decimal =
                                Convert.ToDecimal(
                                    row.Cells("colSubtotal").Value
                                )

                            ' Simpan detail transaksi
                            Dim sqlDetail As String =
                                "INSERT INTO detail_transaksi_produk " &
                                "(TransaksiProdukID, ProdukID, jumlah, " &
                                "harga_saat_transaksi, subtotal) " &
                                "VALUES " &
                                "(@transaksi, @produk, @jumlah, " &
                                "@harga, @subtotal)"

                            Using cmd As New MySqlCommand(
                                sqlDetail, cn, tr
                            )

                                cmd.Parameters.AddWithValue(
                                    "@transaksi", transaksiID
                                )

                                cmd.Parameters.AddWithValue(
                                    "@produk", produkID
                                )

                                cmd.Parameters.AddWithValue(
                                    "@jumlah", jumlah
                                )

                                cmd.Parameters.AddWithValue(
                                    "@harga", harga
                                )

                                cmd.Parameters.AddWithValue(
                                    "@subtotal", subtotal
                                )

                                cmd.ExecuteNonQuery()

                            End Using

                            ' Kurangi stok secara aman
                            Dim sqlStok As String =
                                "UPDATE produk " &
                                "SET stok = stok - @jumlah " &
                                "WHERE ProdukID = @produk " &
                                "AND status = 'Aktif' " &
                                "AND stok >= @jumlah"

                            Using cmd As New MySqlCommand(
                                sqlStok, cn, tr
                            )

                                cmd.Parameters.AddWithValue(
                                    "@jumlah", jumlah
                                )

                                cmd.Parameters.AddWithValue(
                                    "@produk", produkID
                                )

                                Dim hasil As Integer =
                                    cmd.ExecuteNonQuery()

                                If hasil = 0 Then

                                    Throw New Exception(
                                        "Stok produk tidak mencukupi " &
                                        "atau produk sudah tidak aktif. " &
                                        "Silakan periksa kembali stok."
                                    )

                                End If

                            End Using

                        Next

                        ' Semua berhasil, simpan perubahan
                        tr.Commit()

                        transaksiBerhasil = True

                    Catch

                        ' Batalkan seluruh proses jika gagal
                        tr.Rollback()

                        Throw

                    End Try

                End Using

            End Using

            MessageBox.Show(
                "Transaksi berhasil disimpan!" &
                vbCrLf &
                "Nomor Transaksi: " & nomorFinal &
                vbCrLf &
                "Total: Rp " & total.ToString("N0") &
                vbCrLf &
                "Stok produk berhasil diperbarui.",
                "Transaksi Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ' Muat ulang stok terbaru
            MuatProduk()

            ' Siapkan transaksi berikutnya
            ResetTransaksi()

        Catch ex As Exception

            MessageBox.Show(
                "Transaksi gagal disimpan." &
                vbCrLf &
                ex.Message,
                "Kesalahan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally

            btnSimpan.Enabled = True

        End Try

    End Sub

    ' ==========================================
    ' RESET TRANSAKSI BARU
    ' ==========================================

    Private Sub ResetTransaksi()

        dgvKeranjang.Rows.Clear()

        txtNamaPelanggan.Clear()

        cmbMetodePembayaran.SelectedIndex = 0
        cmbStatusPembayaran.SelectedIndex = 0

        BersihkanInputProduk()

        dtpTanggal.Value = Date.Today

        HitungGrandTotal()
        TampilkanNomorTransaksi()

    End Sub

    Private Sub btnTransaksiBaru_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTransaksiBaru.Click

        If dgvKeranjang.Rows.Count > 0 Then

            Dim hasil As DialogResult =
                MessageBox.Show(
                    "Mulai transaksi baru? " &
                    "Data keranjang saat ini akan dihapus.",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )

            If hasil <> DialogResult.Yes Then
                Return
            End If

        End If

        ResetTransaksi()

    End Sub

    ' ==========================================
    ' KEMBALI KE MENU OWNER
    ' ==========================================

    Private Sub btnHome_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHome.Click

        Me.Close()

    End Sub

    Private Sub FormTransaksiProduk_FormClosing(
        sender As Object,
        e As FormClosingEventArgs
    ) Handles Me.FormClosing

        If HomeForm IsNot Nothing AndAlso
            Not HomeForm.IsDisposed Then

            HomeForm.Show()

        End If

    End Sub

End Class
