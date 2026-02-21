Public Module Program
    <STAThread>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        GlobalExceptionHandler.Register()

        Application.Run(New frmMain())
    End Sub
End Module