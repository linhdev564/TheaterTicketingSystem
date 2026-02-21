<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlHeader = New Panel()
        btnSeatAssignments = New Button()
        btnBookings = New Button()
        btnPerformances = New Button()
        pnlContent = New Panel()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        '
        ' pnlHeader
        '
        pnlHeader.Controls.Add(btnSeatAssignments)
        pnlHeader.Controls.Add(btnBookings)
        pnlHeader.Controls.Add(btnPerformances)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1000, 52)
        pnlHeader.TabIndex = 0
        '
        ' btnSeatAssignments
        '
        btnSeatAssignments.Location = New Point(324, 10)
        btnSeatAssignments.Name = "btnSeatAssignments"
        btnSeatAssignments.Size = New Size(150, 32)
        btnSeatAssignments.TabIndex = 2
        btnSeatAssignments.Text = "Gán ghế"
        btnSeatAssignments.UseVisualStyleBackColor = True
        '
        ' btnBookings
        '
        btnBookings.Location = New Point(168, 10)
        btnBookings.Name = "btnBookings"
        btnBookings.Size = New Size(150, 32)
        btnBookings.TabIndex = 1
        btnBookings.Text = "Đặt vé"
        btnBookings.UseVisualStyleBackColor = True
        '
        ' btnPerformances
        '
        btnPerformances.Location = New Point(12, 10)
        btnPerformances.Name = "btnPerformances"
        btnPerformances.Size = New Size(150, 32)
        btnPerformances.TabIndex = 0
        btnPerformances.Text = "Suất diễn"
        btnPerformances.UseVisualStyleBackColor = True
        '
        ' pnlContent
        '
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Location = New Point(0, 52)
        pnlContent.Name = "pnlContent"
        pnlContent.Size = New Size(1000, 598)
        pnlContent.TabIndex = 1
        '
        ' frmMain
        '
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 650)
        Controls.Add(pnlContent)
        Controls.Add(pnlHeader)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Theater Ticketing System"
        pnlHeader.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnPerformances As Button
    Friend WithEvents btnBookings As Button
    Friend WithEvents btnSeatAssignments As Button
    Friend WithEvents pnlContent As Panel
End Class
