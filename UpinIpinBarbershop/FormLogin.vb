Imports MySql.Data.MySqlClient

Public Class FormLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            BukaKoneksi()

            If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
                Exit Sub
            End If

            Dim query As String = "SELECT UserID, username, role FROM users " &
                                  "WHERE username = @username " &
                                  "AND password_hash = SHA2(@password, 256)"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@password", txtPassword.Text)

                Using reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then

                        Dim role As String = reader("role").ToString()

                        reader.Close()
                        conn.Close()

                        MessageBox.Show("Login berhasil!")

                        If role = "Owner" Then
                            Dim menu As New FormMenuOwner()
                            menu.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Login pelanggan belum tersedia.")
                        End If

                    Else
                        MessageBox.Show("Username atau password salah!")
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)

            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

End Class