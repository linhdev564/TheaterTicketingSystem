Public Class frmMain
    Private _activeForm As Form

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ShowChildForm(New frmPerformanceMaster())
        Catch ex As Exception
            AppLogger.LogError(ex, "frmMain_Load")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowChildForm(child As Form)
        If _activeForm IsNot Nothing Then
            _activeForm.Close()
            _activeForm.Dispose()
            _activeForm = Nothing
        End If

        _activeForm = child
        child.TopLevel = False
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill

        pnlContent.Controls.Clear()
        pnlContent.Controls.Add(child)
        child.Show()
    End Sub

    Private Sub btnPerformances_Click(sender As Object, e As EventArgs) Handles btnPerformances.Click
        Try
            ShowChildForm(New frmPerformanceMaster())
        Catch ex As Exception
            AppLogger.LogError(ex, "btnPerformances_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBookings_Click(sender As Object, e As EventArgs) Handles btnBookings.Click
        Try
            ShowChildForm(New frmBooking())
        Catch ex As Exception
            AppLogger.LogError(ex, "btnBookings_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSeatAssignments_Click(sender As Object, e As EventArgs) Handles btnSeatAssignments.Click
        Try
            ShowChildForm(New frmSeatAssignment())
        Catch ex As Exception
            AppLogger.LogError(ex, "btnSeatAssignments_Click")
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
