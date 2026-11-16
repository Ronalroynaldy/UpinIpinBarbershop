Imports MySql.Data.MySqlClient

Module Koneksi

    Public conn As MySqlConnection

    Public Sub BukaKoneksi()
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection(
                    "Server=localhost;Port=3306;" &
                    "Database=db_upin_ipin_barbershop;" &
                    "Uid=root;Pwd=;CharSet=utf8mb4;"
                )
            End If

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

        Catch ex As Exception
            MessageBox.Show("Koneksi gagal: " & ex.Message)
        End Try
    End Sub

End Module