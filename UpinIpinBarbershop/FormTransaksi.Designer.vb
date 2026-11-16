<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTransaksi))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNomorTransaksi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboPelanggan = New System.Windows.Forms.ComboBox()
        Me.gbPilihLayanan = New System.Windows.Forms.GroupBox()
        Me.btnTambahLayanan = New System.Windows.Forms.Button()
        Me.txtHarga = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numJumlah = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboLayanan = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbDaftarLayanan = New System.Windows.Forms.GroupBox()
        Me.btnHapusLayanan = New System.Windows.Forms.Button()
        Me.dgvDetailTransaksi = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboMetodePembayaran = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboStatusPembayaran = New System.Windows.Forms.ComboBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.txtNamaPelanggan = New System.Windows.Forms.TextBox()
        Me.gbPilihLayanan.SuspendLayout()
        CType(Me.numJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDaftarLayanan.SuspendLayout()
        CType(Me.dgvDetailTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(71, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Order Transaction Form - Upin Ipin Barbershop"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(29, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 15)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Order Number"
        '
        'txtNomorTransaksi
        '
        Me.txtNomorTransaksi.Location = New System.Drawing.Point(121, 65)
        Me.txtNomorTransaksi.Name = "txtNomorTransaksi"
        Me.txtNomorTransaksi.ReadOnly = True
        Me.txtNomorTransaksi.Size = New System.Drawing.Size(154, 20)
        Me.txtNomorTransaksi.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(281, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Order Date"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggal.Location = New System.Drawing.Point(353, 65)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(119, 20)
        Me.dtpTanggal.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(29, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Pelanggan"
        '
        'cboPelanggan
        '
        Me.cboPelanggan.FormattingEnabled = True
        Me.cboPelanggan.Location = New System.Drawing.Point(121, 99)
        Me.cboPelanggan.Name = "cboPelanggan"
        Me.cboPelanggan.Size = New System.Drawing.Size(154, 21)
        Me.cboPelanggan.TabIndex = 33
        '
        'gbPilihLayanan
        '
        Me.gbPilihLayanan.Controls.Add(Me.btnTambahLayanan)
        Me.gbPilihLayanan.Controls.Add(Me.txtHarga)
        Me.gbPilihLayanan.Controls.Add(Me.Label6)
        Me.gbPilihLayanan.Controls.Add(Me.numJumlah)
        Me.gbPilihLayanan.Controls.Add(Me.Label5)
        Me.gbPilihLayanan.Controls.Add(Me.cboLayanan)
        Me.gbPilihLayanan.Controls.Add(Me.Label4)
        Me.gbPilihLayanan.Location = New System.Drawing.Point(32, 126)
        Me.gbPilihLayanan.Name = "gbPilihLayanan"
        Me.gbPilihLayanan.Size = New System.Drawing.Size(439, 97)
        Me.gbPilihLayanan.TabIndex = 34
        Me.gbPilihLayanan.TabStop = False
        Me.gbPilihLayanan.Text = "Tambah Layanan"
        '
        'btnTambahLayanan
        '
        Me.btnTambahLayanan.Image = CType(resources.GetObject("btnTambahLayanan.Image"), System.Drawing.Image)
        Me.btnTambahLayanan.Location = New System.Drawing.Point(279, 68)
        Me.btnTambahLayanan.Name = "btnTambahLayanan"
        Me.btnTambahLayanan.Size = New System.Drawing.Size(147, 23)
        Me.btnTambahLayanan.TabIndex = 41
        Me.btnTambahLayanan.Text = "Tambah Layanan"
        Me.btnTambahLayanan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTambahLayanan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTambahLayanan.UseVisualStyleBackColor = True
        '
        'txtHarga
        '
        Me.txtHarga.Location = New System.Drawing.Point(89, 50)
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.ReadOnly = True
        Me.txtHarga.Size = New System.Drawing.Size(154, 20)
        Me.txtHarga.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(7, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Unit Price"
        '
        'numJumlah
        '
        Me.numJumlah.Location = New System.Drawing.Point(306, 23)
        Me.numJumlah.Name = "numJumlah"
        Me.numJumlah.Size = New System.Drawing.Size(120, 20)
        Me.numJumlah.TabIndex = 37
        Me.numJumlah.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(249, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Quantity"
        '
        'cboLayanan
        '
        Me.cboLayanan.FormattingEnabled = True
        Me.cboLayanan.Location = New System.Drawing.Point(89, 22)
        Me.cboLayanan.Name = "cboLayanan"
        Me.cboLayanan.Size = New System.Drawing.Size(154, 21)
        Me.cboLayanan.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(7, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 15)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Layanan"
        '
        'gbDaftarLayanan
        '
        Me.gbDaftarLayanan.Controls.Add(Me.btnHapusLayanan)
        Me.gbDaftarLayanan.Controls.Add(Me.dgvDetailTransaksi)
        Me.gbDaftarLayanan.Location = New System.Drawing.Point(32, 229)
        Me.gbDaftarLayanan.Name = "gbDaftarLayanan"
        Me.gbDaftarLayanan.Size = New System.Drawing.Size(438, 150)
        Me.gbDaftarLayanan.TabIndex = 35
        Me.gbDaftarLayanan.TabStop = False
        Me.gbDaftarLayanan.Text = "Daftar Layanan"
        '
        'btnHapusLayanan
        '
        Me.btnHapusLayanan.Image = CType(resources.GetObject("btnHapusLayanan.Image"), System.Drawing.Image)
        Me.btnHapusLayanan.Location = New System.Drawing.Point(279, 115)
        Me.btnHapusLayanan.Name = "btnHapusLayanan"
        Me.btnHapusLayanan.Size = New System.Drawing.Size(147, 23)
        Me.btnHapusLayanan.TabIndex = 38
        Me.btnHapusLayanan.Text = "Hapus Layanan"
        Me.btnHapusLayanan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapusLayanan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHapusLayanan.UseVisualStyleBackColor = True
        '
        'dgvDetailTransaksi
        '
        Me.dgvDetailTransaksi.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetailTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetailTransaksi.Location = New System.Drawing.Point(10, 19)
        Me.dgvDetailTransaksi.Name = "dgvDetailTransaksi"
        Me.dgvDetailTransaksi.Size = New System.Drawing.Size(416, 88)
        Me.dgvDetailTransaksi.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(29, 389)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Grand Total"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Location = New System.Drawing.Point(338, 389)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Size = New System.Drawing.Size(132, 20)
        Me.txtGrandTotal.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(30, 427)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 17)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Payment Method"
        '
        'cboMetodePembayaran
        '
        Me.cboMetodePembayaran.FormattingEnabled = True
        Me.cboMetodePembayaran.Location = New System.Drawing.Point(33, 453)
        Me.cboMetodePembayaran.Name = "cboMetodePembayaran"
        Me.cboMetodePembayaran.Size = New System.Drawing.Size(194, 21)
        Me.cboMetodePembayaran.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(273, 427)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 17)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Payment Status"
        '
        'cboStatusPembayaran
        '
        Me.cboStatusPembayaran.FormattingEnabled = True
        Me.cboStatusPembayaran.Location = New System.Drawing.Point(277, 453)
        Me.cboStatusPembayaran.Name = "cboStatusPembayaran"
        Me.cboStatusPembayaran.Size = New System.Drawing.Size(194, 21)
        Me.cboStatusPembayaran.TabIndex = 41
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(234, 499)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 42
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(316, 499)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 43
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(397, 499)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(75, 23)
        Me.btnHome.TabIndex = 44
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'txtNamaPelanggan
        '
        Me.txtNamaPelanggan.Enabled = False
        Me.txtNamaPelanggan.Location = New System.Drawing.Point(284, 98)
        Me.txtNamaPelanggan.Name = "txtNamaPelanggan"
        Me.txtNamaPelanggan.Size = New System.Drawing.Size(188, 20)
        Me.txtNamaPelanggan.TabIndex = 45
        '
        'FormTransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 537)
        Me.Controls.Add(Me.txtNamaPelanggan)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cboStatusPembayaran)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboMetodePembayaran)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtGrandTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gbDaftarLayanan)
        Me.Controls.Add(Me.gbPilihLayanan)
        Me.Controls.Add(Me.cboPelanggan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpTanggal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNomorTransaksi)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormTransaksi"
        Me.Text = "FormTransaksi"
        Me.gbPilihLayanan.ResumeLayout(False)
        Me.gbPilihLayanan.PerformLayout()
        CType(Me.numJumlah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDaftarLayanan.ResumeLayout(False)
        CType(Me.dgvDetailTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNomorTransaksi As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cboPelanggan As ComboBox
    Friend WithEvents gbPilihLayanan As GroupBox
    Friend WithEvents cboLayanan As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtHarga As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents numJumlah As NumericUpDown
    Friend WithEvents btnTambahLayanan As Button
    Friend WithEvents gbDaftarLayanan As GroupBox
    Friend WithEvents dgvDetailTransaksi As DataGridView
    Friend WithEvents btnHapusLayanan As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboMetodePembayaran As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboStatusPembayaran As ComboBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents txtNamaPelanggan As TextBox
End Class
