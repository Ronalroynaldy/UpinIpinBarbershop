<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaksiProduk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.lblNomorTransaksi = New System.Windows.Forms.Label()
        Me.txtNomorTransaksi = New System.Windows.Forms.TextBox()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.lblNamaPelanggan = New System.Windows.Forms.Label()
        Me.txtNamaPelanggan = New System.Windows.Forms.TextBox()
        Me.gbDataProduk = New System.Windows.Forms.GroupBox()
        Me.lblProduk = New System.Windows.Forms.Label()
        Me.cmbProduk = New System.Windows.Forms.ComboBox()
        Me.lblHarga = New System.Windows.Forms.Label()
        Me.txtHarga = New System.Windows.Forms.TextBox()
        Me.lblStok = New System.Windows.Forms.Label()
        Me.txtStok = New System.Windows.Forms.TextBox()
        Me.lblJumlah = New System.Windows.Forms.Label()
        Me.nudJumlah = New System.Windows.Forms.NumericUpDown()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.btnTambahProduk = New System.Windows.Forms.Button()
        Me.gbDaftarProduk = New System.Windows.Forms.GroupBox()
        Me.dgvKeranjang = New System.Windows.Forms.DataGridView()
        Me.btnHapusItem = New System.Windows.Forms.Button()
        Me.colNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNamaProduk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbMetodePembayaran = New System.Windows.Forms.GroupBox()
        Me.cmbMetodePembayaran = New System.Windows.Forms.ComboBox()
        Me.gbStatusPembayaran = New System.Windows.Forms.GroupBox()
        Me.cmbStatusPembayaran = New System.Windows.Forms.ComboBox()
        Me.lblTotalPembayaran = New System.Windows.Forms.Label()
        Me.lblGrandTotal = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnTransaksiBaru = New System.Windows.Forms.Button()
        Me.btnBersihkan = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.gbDataProduk.SuspendLayout()
        CType(Me.nudJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDaftarProduk.SuspendLayout()
        CType(Me.dgvKeranjang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMetodePembayaran.SuspendLayout()
        Me.gbStatusPembayaran.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudul.Location = New System.Drawing.Point(144, 14)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(505, 25)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "Transaksi Penjualan Produk - Upin Ipin Barbershop"
        '
        'lblNomorTransaksi
        '
        Me.lblNomorTransaksi.AutoSize = True
        Me.lblNomorTransaksi.Location = New System.Drawing.Point(34, 64)
        Me.lblNomorTransaksi.Name = "lblNomorTransaksi"
        Me.lblNomorTransaksi.Size = New System.Drawing.Size(111, 16)
        Me.lblNomorTransaksi.TabIndex = 1
        Me.lblNomorTransaksi.Text = "Nomor Transaksi"
        '
        'txtNomorTransaksi
        '
        Me.txtNomorTransaksi.Location = New System.Drawing.Point(167, 64)
        Me.txtNomorTransaksi.Name = "txtNomorTransaksi"
        Me.txtNomorTransaksi.Size = New System.Drawing.Size(177, 22)
        Me.txtNomorTransaksi.TabIndex = 2
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Location = New System.Drawing.Point(527, 64)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(58, 16)
        Me.lblTanggal.TabIndex = 3
        Me.lblTanggal.Text = "Tanggal"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.Location = New System.Drawing.Point(610, 64)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(160, 22)
        Me.dtpTanggal.TabIndex = 4
        '
        'lblNamaPelanggan
        '
        Me.lblNamaPelanggan.AutoSize = True
        Me.lblNamaPelanggan.Location = New System.Drawing.Point(34, 101)
        Me.lblNamaPelanggan.Name = "lblNamaPelanggan"
        Me.lblNamaPelanggan.Size = New System.Drawing.Size(113, 16)
        Me.lblNamaPelanggan.TabIndex = 5
        Me.lblNamaPelanggan.Text = "Nama Pelanggan"
        '
        'txtNamaPelanggan
        '
        Me.txtNamaPelanggan.Location = New System.Drawing.Point(167, 101)
        Me.txtNamaPelanggan.Name = "txtNamaPelanggan"
        Me.txtNamaPelanggan.Size = New System.Drawing.Size(603, 22)
        Me.txtNamaPelanggan.TabIndex = 6
        '
        'gbDataProduk
        '
        Me.gbDataProduk.Controls.Add(Me.btnTambahProduk)
        Me.gbDataProduk.Controls.Add(Me.txtSubtotal)
        Me.gbDataProduk.Controls.Add(Me.lblSubtotal)
        Me.gbDataProduk.Controls.Add(Me.nudJumlah)
        Me.gbDataProduk.Controls.Add(Me.lblJumlah)
        Me.gbDataProduk.Controls.Add(Me.txtStok)
        Me.gbDataProduk.Controls.Add(Me.lblStok)
        Me.gbDataProduk.Controls.Add(Me.txtHarga)
        Me.gbDataProduk.Controls.Add(Me.lblHarga)
        Me.gbDataProduk.Controls.Add(Me.cmbProduk)
        Me.gbDataProduk.Controls.Add(Me.lblProduk)
        Me.gbDataProduk.Location = New System.Drawing.Point(37, 140)
        Me.gbDataProduk.Name = "gbDataProduk"
        Me.gbDataProduk.Size = New System.Drawing.Size(733, 130)
        Me.gbDataProduk.TabIndex = 7
        Me.gbDataProduk.TabStop = False
        Me.gbDataProduk.Text = "Data Produk"
        '
        'lblProduk
        '
        Me.lblProduk.AutoSize = True
        Me.lblProduk.Location = New System.Drawing.Point(16, 35)
        Me.lblProduk.Name = "lblProduk"
        Me.lblProduk.Size = New System.Drawing.Size(50, 16)
        Me.lblProduk.TabIndex = 0
        Me.lblProduk.Text = "Produk"
        '
        'cmbProduk
        '
        Me.cmbProduk.FormattingEnabled = True
        Me.cmbProduk.Location = New System.Drawing.Point(117, 32)
        Me.cmbProduk.Name = "cmbProduk"
        Me.cmbProduk.Size = New System.Drawing.Size(229, 24)
        Me.cmbProduk.TabIndex = 1
        '
        'lblHarga
        '
        Me.lblHarga.AutoSize = True
        Me.lblHarga.Location = New System.Drawing.Point(18, 67)
        Me.lblHarga.Name = "lblHarga"
        Me.lblHarga.Size = New System.Drawing.Size(45, 16)
        Me.lblHarga.TabIndex = 2
        Me.lblHarga.Text = "Harga"
        '
        'txtHarga
        '
        Me.txtHarga.Location = New System.Drawing.Point(117, 67)
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(229, 22)
        Me.txtHarga.TabIndex = 3
        '
        'lblStok
        '
        Me.lblStok.AutoSize = True
        Me.lblStok.Location = New System.Drawing.Point(18, 102)
        Me.lblStok.Name = "lblStok"
        Me.lblStok.Size = New System.Drawing.Size(34, 16)
        Me.lblStok.TabIndex = 4
        Me.lblStok.Text = "Stok"
        '
        'txtStok
        '
        Me.txtStok.Location = New System.Drawing.Point(117, 99)
        Me.txtStok.Name = "txtStok"
        Me.txtStok.Size = New System.Drawing.Size(229, 22)
        Me.txtStok.TabIndex = 5
        '
        'lblJumlah
        '
        Me.lblJumlah.AutoSize = True
        Me.lblJumlah.Location = New System.Drawing.Point(430, 35)
        Me.lblJumlah.Name = "lblJumlah"
        Me.lblJumlah.Size = New System.Drawing.Size(50, 16)
        Me.lblJumlah.TabIndex = 6
        Me.lblJumlah.Text = "Jumlah"
        '
        'nudJumlah
        '
        Me.nudJumlah.Location = New System.Drawing.Point(509, 34)
        Me.nudJumlah.Name = "nudJumlah"
        Me.nudJumlah.Size = New System.Drawing.Size(181, 22)
        Me.nudJumlah.TabIndex = 7
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(432, 67)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(56, 16)
        Me.lblSubtotal.TabIndex = 8
        Me.lblSubtotal.Text = "Subtotal"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(509, 67)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(181, 22)
        Me.txtSubtotal.TabIndex = 9
        '
        'btnTambahProduk
        '
        Me.btnTambahProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTambahProduk.Location = New System.Drawing.Point(509, 102)
        Me.btnTambahProduk.Name = "btnTambahProduk"
        Me.btnTambahProduk.Size = New System.Drawing.Size(181, 23)
        Me.btnTambahProduk.TabIndex = 8
        Me.btnTambahProduk.Text = "+ Tambah Produk"
        Me.btnTambahProduk.UseVisualStyleBackColor = True
        '
        'gbDaftarProduk
        '
        Me.gbDaftarProduk.Controls.Add(Me.btnHapusItem)
        Me.gbDaftarProduk.Controls.Add(Me.dgvKeranjang)
        Me.gbDaftarProduk.Location = New System.Drawing.Point(37, 276)
        Me.gbDaftarProduk.Name = "gbDaftarProduk"
        Me.gbDaftarProduk.Size = New System.Drawing.Size(733, 128)
        Me.gbDaftarProduk.TabIndex = 8
        Me.gbDaftarProduk.TabStop = False
        Me.gbDaftarProduk.Text = "Daftar Produk"
        '
        'dgvKeranjang
        '
        Me.dgvKeranjang.AllowUserToAddRows = False
        Me.dgvKeranjang.AllowUserToDeleteRows = False
        Me.dgvKeranjang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvKeranjang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvKeranjang.ColumnHeadersHeight = 29
        Me.dgvKeranjang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvKeranjang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNo, Me.colNamaProduk, Me.colHarga, Me.colJumlah, Me.colSubtotal})
        Me.dgvKeranjang.Location = New System.Drawing.Point(6, 21)
        Me.dgvKeranjang.MultiSelect = False
        Me.dgvKeranjang.Name = "dgvKeranjang"
        Me.dgvKeranjang.ReadOnly = True
        Me.dgvKeranjang.RowHeadersVisible = False
        Me.dgvKeranjang.RowHeadersWidth = 51
        Me.dgvKeranjang.RowTemplate.Height = 24
        Me.dgvKeranjang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKeranjang.Size = New System.Drawing.Size(605, 123)
        Me.dgvKeranjang.TabIndex = 0
        '
        'btnHapusItem
        '
        Me.btnHapusItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHapusItem.Location = New System.Drawing.Point(617, 77)
        Me.btnHapusItem.Name = "btnHapusItem"
        Me.btnHapusItem.Size = New System.Drawing.Size(110, 23)
        Me.btnHapusItem.TabIndex = 1
        Me.btnHapusItem.Text = "Hapus Item"
        Me.btnHapusItem.UseVisualStyleBackColor = True
        '
        'colNo
        '
        Me.colNo.HeaderText = "No"
        Me.colNo.MinimumWidth = 6
        Me.colNo.Name = "colNo"
        Me.colNo.ReadOnly = True
        '
        'colNamaProduk
        '
        Me.colNamaProduk.HeaderText = "Nama Produk"
        Me.colNamaProduk.MinimumWidth = 6
        Me.colNamaProduk.Name = "colNamaProduk"
        Me.colNamaProduk.ReadOnly = True
        '
        'colHarga
        '
        Me.colHarga.HeaderText = "Harga Satuan"
        Me.colHarga.MinimumWidth = 6
        Me.colHarga.Name = "colHarga"
        Me.colHarga.ReadOnly = True
        '
        'colJumlah
        '
        Me.colJumlah.HeaderText = "Jumlah"
        Me.colJumlah.MinimumWidth = 6
        Me.colJumlah.Name = "colJumlah"
        Me.colJumlah.ReadOnly = True
        '
        'colSubtotal
        '
        Me.colSubtotal.HeaderText = "Subtotal"
        Me.colSubtotal.MinimumWidth = 6
        Me.colSubtotal.Name = "colSubtotal"
        Me.colSubtotal.ReadOnly = True
        '
        'gbMetodePembayaran
        '
        Me.gbMetodePembayaran.Controls.Add(Me.cmbMetodePembayaran)
        Me.gbMetodePembayaran.Location = New System.Drawing.Point(43, 422)
        Me.gbMetodePembayaran.Name = "gbMetodePembayaran"
        Me.gbMetodePembayaran.Size = New System.Drawing.Size(241, 53)
        Me.gbMetodePembayaran.TabIndex = 9
        Me.gbMetodePembayaran.TabStop = False
        Me.gbMetodePembayaran.Text = "Metode Pembayaran"
        '
        'cmbMetodePembayaran
        '
        Me.cmbMetodePembayaran.FormattingEnabled = True
        Me.cmbMetodePembayaran.Location = New System.Drawing.Point(6, 23)
        Me.cmbMetodePembayaran.Name = "cmbMetodePembayaran"
        Me.cmbMetodePembayaran.Size = New System.Drawing.Size(222, 24)
        Me.cmbMetodePembayaran.TabIndex = 0
        Me.cmbMetodePembayaran.Text = "cash"
        '
        'gbStatusPembayaran
        '
        Me.gbStatusPembayaran.Controls.Add(Me.cmbStatusPembayaran)
        Me.gbStatusPembayaran.Location = New System.Drawing.Point(307, 424)
        Me.gbStatusPembayaran.Name = "gbStatusPembayaran"
        Me.gbStatusPembayaran.Size = New System.Drawing.Size(218, 51)
        Me.gbStatusPembayaran.TabIndex = 10
        Me.gbStatusPembayaran.TabStop = False
        Me.gbStatusPembayaran.Text = "Status Pembayaran"
        '
        'cmbStatusPembayaran
        '
        Me.cmbStatusPembayaran.FormattingEnabled = True
        Me.cmbStatusPembayaran.Location = New System.Drawing.Point(6, 21)
        Me.cmbStatusPembayaran.Name = "cmbStatusPembayaran"
        Me.cmbStatusPembayaran.Size = New System.Drawing.Size(204, 24)
        Me.cmbStatusPembayaran.TabIndex = 11
        Me.cmbStatusPembayaran.Text = "Lunas"
        '
        'lblTotalPembayaran
        '
        Me.lblTotalPembayaran.AutoSize = True
        Me.lblTotalPembayaran.Location = New System.Drawing.Point(576, 424)
        Me.lblTotalPembayaran.Name = "lblTotalPembayaran"
        Me.lblTotalPembayaran.Size = New System.Drawing.Size(119, 16)
        Me.lblTotalPembayaran.TabIndex = 11
        Me.lblTotalPembayaran.Text = "Total Pembayaran"
        '
        'lblGrandTotal
        '
        Me.lblGrandTotal.AutoSize = True
        Me.lblGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandTotal.Location = New System.Drawing.Point(641, 450)
        Me.lblGrandTotal.Name = "lblGrandTotal"
        Me.lblGrandTotal.Size = New System.Drawing.Size(86, 25)
        Me.lblGrandTotal.TabIndex = 12
        Me.lblGrandTotal.Text = "Rp 0,00"
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(167, 481)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(117, 23)
        Me.btnSimpan.TabIndex = 13
        Me.btnSimpan.Text = "Simpan Transaksi"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnTransaksiBaru
        '
        Me.btnTransaksiBaru.Location = New System.Drawing.Point(342, 481)
        Me.btnTransaksiBaru.Name = "btnTransaksiBaru"
        Me.btnTransaksiBaru.Size = New System.Drawing.Size(108, 23)
        Me.btnTransaksiBaru.TabIndex = 14
        Me.btnTransaksiBaru.Text = "Transaksi Baru"
        Me.btnTransaksiBaru.UseVisualStyleBackColor = True
        '
        'btnBersihkan
        '
        Me.btnBersihkan.Location = New System.Drawing.Point(510, 481)
        Me.btnBersihkan.Name = "btnBersihkan"
        Me.btnBersihkan.Size = New System.Drawing.Size(107, 23)
        Me.btnBersihkan.TabIndex = 15
        Me.btnBersihkan.Text = "Bersihkan"
        Me.btnBersihkan.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(713, 481)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(75, 23)
        Me.btnHome.TabIndex = 16
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'FormTransaksiProduk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 507)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnBersihkan)
        Me.Controls.Add(Me.btnTransaksiBaru)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.lblGrandTotal)
        Me.Controls.Add(Me.lblTotalPembayaran)
        Me.Controls.Add(Me.gbStatusPembayaran)
        Me.Controls.Add(Me.gbMetodePembayaran)
        Me.Controls.Add(Me.gbDaftarProduk)
        Me.Controls.Add(Me.gbDataProduk)
        Me.Controls.Add(Me.txtNamaPelanggan)
        Me.Controls.Add(Me.lblNamaPelanggan)
        Me.Controls.Add(Me.dtpTanggal)
        Me.Controls.Add(Me.lblTanggal)
        Me.Controls.Add(Me.txtNomorTransaksi)
        Me.Controls.Add(Me.lblNomorTransaksi)
        Me.Controls.Add(Me.lblJudul)
        Me.Name = "FormTransaksiProduk"
        Me.Text = "FormTransaksiProduk"
        Me.gbDataProduk.ResumeLayout(False)
        Me.gbDataProduk.PerformLayout()
        CType(Me.nudJumlah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDaftarProduk.ResumeLayout(False)
        CType(Me.dgvKeranjang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMetodePembayaran.ResumeLayout(False)
        Me.gbStatusPembayaran.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblNomorTransaksi As Label
    Friend WithEvents txtNomorTransaksi As TextBox
    Friend WithEvents lblTanggal As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents lblNamaPelanggan As Label
    Friend WithEvents txtNamaPelanggan As TextBox
    Friend WithEvents gbDataProduk As GroupBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtHarga As TextBox
    Friend WithEvents lblHarga As Label
    Friend WithEvents cmbProduk As ComboBox
    Friend WithEvents lblProduk As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents nudJumlah As NumericUpDown
    Friend WithEvents lblJumlah As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents btnTambahProduk As Button
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents gbDaftarProduk As GroupBox
    Friend WithEvents dgvKeranjang As DataGridView
    Friend WithEvents btnHapusItem As Button
    Friend WithEvents colNo As DataGridViewTextBoxColumn
    Friend WithEvents colNamaProduk As DataGridViewTextBoxColumn
    Friend WithEvents colHarga As DataGridViewTextBoxColumn
    Friend WithEvents colJumlah As DataGridViewTextBoxColumn
    Friend WithEvents colSubtotal As DataGridViewTextBoxColumn
    Friend WithEvents gbMetodePembayaran As GroupBox
    Friend WithEvents cmbMetodePembayaran As ComboBox
    Friend WithEvents gbStatusPembayaran As GroupBox
    Friend WithEvents cmbStatusPembayaran As ComboBox
    Friend WithEvents lblTotalPembayaran As Label
    Friend WithEvents lblGrandTotal As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnTransaksiBaru As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents btnHome As Button
End Class
