<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenuOwner
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLayanan = New System.Windows.Forms.Button()
        Me.btnKatalog = New System.Windows.Forms.Button()
        Me.btnPelanggan = New System.Windows.Forms.Button()
        Me.btnTransaksi = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnTransaksiProduk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(183, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Upin Ipin Barbershop"
        '
        'btnLayanan
        '
        Me.btnLayanan.Location = New System.Drawing.Point(104, 110)
        Me.btnLayanan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLayanan.Name = "btnLayanan"
        Me.btnLayanan.Size = New System.Drawing.Size(156, 43)
        Me.btnLayanan.TabIndex = 8
        Me.btnLayanan.Text = "Data Layanan"
        Me.btnLayanan.UseVisualStyleBackColor = True
        '
        'btnKatalog
        '
        Me.btnKatalog.Location = New System.Drawing.Point(321, 110)
        Me.btnKatalog.Margin = New System.Windows.Forms.Padding(4)
        Me.btnKatalog.Name = "btnKatalog"
        Me.btnKatalog.Size = New System.Drawing.Size(156, 43)
        Me.btnKatalog.TabIndex = 9
        Me.btnKatalog.Text = "Data Katalog"
        Me.btnKatalog.UseVisualStyleBackColor = True
        '
        'btnPelanggan
        '
        Me.btnPelanggan.Location = New System.Drawing.Point(210, 245)
        Me.btnPelanggan.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPelanggan.Name = "btnPelanggan"
        Me.btnPelanggan.Size = New System.Drawing.Size(156, 43)
        Me.btnPelanggan.TabIndex = 11
        Me.btnPelanggan.Text = "Data Pelanggan"
        Me.btnPelanggan.UseVisualStyleBackColor = True
        '
        'btnTransaksi
        '
        Me.btnTransaksi.Location = New System.Drawing.Point(104, 180)
        Me.btnTransaksi.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTransaksi.Name = "btnTransaksi"
        Me.btnTransaksi.Size = New System.Drawing.Size(156, 43)
        Me.btnTransaksi.TabIndex = 10
        Me.btnTransaksi.Text = "Transaksi"
        Me.btnTransaksi.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnLogin.Location = New System.Drawing.Point(472, 272)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(123, 39)
        Me.btnLogin.TabIndex = 12
        Me.btnLogin.Text = "Logout"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnTransaksiProduk
        '
        Me.btnTransaksiProduk.Location = New System.Drawing.Point(321, 180)
        Me.btnTransaksiProduk.Name = "btnTransaksiProduk"
        Me.btnTransaksiProduk.Size = New System.Drawing.Size(156, 43)
        Me.btnTransaksiProduk.TabIndex = 13
        Me.btnTransaksiProduk.Text = "Transaksi Produk"
        Me.btnTransaksiProduk.UseVisualStyleBackColor = True
        '
        'FormMenuOwner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 326)
        Me.Controls.Add(Me.btnTransaksiProduk)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.btnPelanggan)
        Me.Controls.Add(Me.btnTransaksi)
        Me.Controls.Add(Me.btnKatalog)
        Me.Controls.Add(Me.btnLayanan)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMenuOwner"
        Me.Text = " "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnLayanan As Button
    Friend WithEvents btnKatalog As Button
    Friend WithEvents btnPelanggan As Button
    Friend WithEvents btnTransaksi As Button
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnTransaksiProduk As Button
End Class
