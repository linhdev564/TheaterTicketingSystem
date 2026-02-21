<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSeatAssignment
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
        PanelTop = New Panel()
        btnReload = New Button()
        btnSave = New Button()
        lblSelectedCount = New Label()
        lblInfo = New Label()
        cboBooking = New ComboBox()
        lblBooking = New Label()
        pnlSeats = New Panel()
        btnCancelBooking = New Button()
        PanelTop.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelTop
        ' 
        PanelTop.Controls.Add(btnCancelBooking)
        PanelTop.Controls.Add(btnReload)
        PanelTop.Controls.Add(btnSave)
        PanelTop.Controls.Add(lblSelectedCount)
        PanelTop.Controls.Add(lblInfo)
        PanelTop.Controls.Add(cboBooking)
        PanelTop.Controls.Add(lblBooking)
        PanelTop.Dock = DockStyle.Top
        PanelTop.Location = New Point(0, 0)
        PanelTop.Name = "PanelTop"
        PanelTop.Size = New Size(1000, 80)
        PanelTop.TabIndex = 0
        ' 
        ' btnReload
        ' 
        btnReload.Location = New Point(700, 12)
        btnReload.Name = "btnReload"
        btnReload.Size = New Size(120, 29)
        btnReload.TabIndex = 5
        btnReload.Text = "Tải lại"
        btnReload.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(826, 12)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(150, 29)
        btnSave.TabIndex = 4
        btnSave.Text = "Lưu"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lblSelectedCount
        ' 
        lblSelectedCount.AutoSize = True
        lblSelectedCount.Location = New Point(700, 51)
        lblSelectedCount.Name = "lblSelectedCount"
        lblSelectedCount.Size = New Size(93, 20)
        lblSelectedCount.TabIndex = 3
        lblSelectedCount.Text = "Đã chọn: 0/0"
        ' 
        ' lblInfo
        ' 
        lblInfo.AutoSize = True
        lblInfo.Location = New Point(12, 51)
        lblInfo.Name = "lblInfo"
        lblInfo.Size = New Size(0, 20)
        lblInfo.TabIndex = 2
        ' 
        ' cboBooking
        ' 
        cboBooking.DropDownStyle = ComboBoxStyle.DropDownList
        cboBooking.FormattingEnabled = True
        cboBooking.Location = New Point(130, 12)
        cboBooking.Name = "cboBooking"
        cboBooking.Size = New Size(200, 28)
        cboBooking.TabIndex = 1
        ' 
        ' lblBooking
        ' 
        lblBooking.AutoSize = True
        lblBooking.Location = New Point(12, 15)
        lblBooking.Name = "lblBooking"
        lblBooking.Size = New Size(80, 20)
        lblBooking.TabIndex = 0
        lblBooking.Text = "Booking #:"
        ' 
        ' pnlSeats
        ' 
        pnlSeats.AutoScroll = True
        pnlSeats.Dock = DockStyle.Fill
        pnlSeats.Location = New Point(0, 80)
        pnlSeats.Name = "pnlSeats"
        pnlSeats.Size = New Size(1000, 570)
        pnlSeats.TabIndex = 1
        ' 
        ' btnCancelBooking
        ' 
        btnCancelBooking.Location = New Point(356, 12)
        btnCancelBooking.Name = "btnCancelBooking"
        btnCancelBooking.Size = New Size(135, 29)
        btnCancelBooking.TabIndex = 6
        btnCancelBooking.Text = "Hủy Booking"
        btnCancelBooking.UseVisualStyleBackColor = True
        ' 
        ' frmSeatAssignment
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 650)
        Controls.Add(pnlSeats)
        Controls.Add(PanelTop)
        Name = "frmSeatAssignment"
        Text = "Gán ghế"
        PanelTop.ResumeLayout(False)
        PanelTop.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents lblBooking As Label
    Friend WithEvents cboBooking As ComboBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents lblSelectedCount As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents pnlSeats As Panel
    Friend WithEvents btnCancelBooking As Button
End Class
