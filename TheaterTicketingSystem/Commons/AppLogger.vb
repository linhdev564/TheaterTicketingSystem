Imports System.IO

Public Class AppLogger
    Private Shared ReadOnly _logDir As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
    Private Shared ReadOnly _lock As New Object()

    Public Shared Sub LogError(ex As Exception, Optional context As String = "")
        Try
            If Not Directory.Exists(_logDir) Then
                Directory.CreateDirectory(_logDir)
            End If

            Dim fileName = Path.Combine(_logDir, $"error_{DateTime.Now:yyyy-MM-dd}.log")
            Dim entry = $"
                    ========== {DateTime.Now:yyyy-MM-dd HH:mm:ss} ==========
                    Context  : {context}
                    Exception: {ex.GetType().FullName}
                    Message  : {ex.Message}
                    Stack    : {ex.StackTrace}
                    "
            If ex.InnerException IsNot Nothing Then
                entry &= $"Inner    : {ex.InnerException.Message}
                    "
            End If

            SyncLock _lock
                File.AppendAllText(fileName, entry)
            End SyncLock
        Catch
            ' bỏ qua
        End Try
    End Sub
End Class