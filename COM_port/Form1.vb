Imports System.IO.Ports
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim COM1 As IO.Ports.SerialPort = Nothing
        Dim COM1 As SerialPort
        Dim i, z, NumSym As Integer
        Dim s1 As String
        NumSym = CInt(TextBox3.Text)
        z = 1

        If CheckBox1.Checked = True Then
            Form2.Show()
            Form2.TextBox1.Text = ""
            Try
                COM1 = My.Computer.Ports.OpenSerialPort(TextBox1.Text)
                For i = 1 To NumSym
                    COM1.DtrEnable = True
                    s1 = Form2.TextBox1.Text
                    s1 = s1 + CStr(z) + ". " + " True  " + TimeString
                    z += 1
                    s1 = s1 + Chr(13) + Chr(10)
                    Form2.TextBox1.Text = CStr(s1)
                    Threading.Thread.Sleep(CInt(TextBox2.Text))

                    COM1.DtrEnable = False
                    s1 = Form2.TextBox1.Text
                    s1 = s1 + CStr(z) + ". " + " False  " + TimeString
                    z += 1
                    s1 = s1 + Chr(13) + Chr(10)
                    Form2.TextBox1.Text = CStr(s1)
                    Threading.Thread.Sleep(CInt(TextBox2.Text))
                Next i
                COM1.Close()
            Catch ex As Exception
                MsgBox("Что-то пошло не так, прога ушла в исключение :-(", vbCritical)
                GoTo lb1
            End Try
            MsgBox("Прога выполнена!", vbInformation)
lb1:
        Else
            Form2.TextBox1.Text = ""
            Form2.Visible = False
            Try
                COM1 = My.Computer.Ports.OpenSerialPort(TextBox1.Text)

                For i = 1 To NumSym
                    COM1.DtrEnable = True
                    Threading.Thread.Sleep(CInt(TextBox2.Text))

                    COM1.DtrEnable = False
                    Threading.Thread.Sleep(CInt(TextBox2.Text))
                Next i
                COM1.Close()
            Catch ex As Exception
                MsgBox("Что-то пошло не так, прога ушла в исключение :-(", vbCritical)
                GoTo lb2
            End Try
            MsgBox("Прога выполнена!", vbInformation)
lb2:
        End If
    End Sub

End Class
