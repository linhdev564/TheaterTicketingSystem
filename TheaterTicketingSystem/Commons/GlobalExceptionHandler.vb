Public Class GlobalExceptionHandler

    Public Shared Sub Register()
        AddHandler Application.ThreadException,
            Sub(sender, e)
                AppLogger.LogError(e.Exception, "UI Thread Exception")
                MessageBox.Show(
                    $"Đã xảy ra lỗi: {e.Exception.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Sub

        AddHandler AppDomain.CurrentDomain.UnhandledException,
            Sub(sender, e)
                Dim ex = TryCast(e.ExceptionObject, Exception)
                If ex IsNot Nothing Then
                    AppLogger.LogError(ex, "Unhandled Thread Exception")
                    MessageBox.Show(
                        $"Đã xảy ra lỗi nghiêm trọng: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Sub

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)
    End Sub

End Class