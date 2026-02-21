<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBooking
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        lblRemainingSeats = New Label()
        btnReset = New Button()
        btnBook = New Button()
        lblTotalValue = New Label()
        lblTotal = New Label()
        lblUnitPriceValue = New Label()
        lblUnitPrice = New Label()
        numQuantity = New NumericUpDown()
        lblQuantity = New Label()
        cboSeatType = New ComboBox()
        lblSeatType = New Label()
        txtCustomerName = New TextBox()
        lblCustomer = New Label()
        txtPhoneNumber = New TextBox()
        lblPhoneNumber = New Label()
        cboPerformance = New ComboBox()
        lblPerformance = New Label()
        Panel1.SuspendLayout()
        CType(numQuantity, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblRemainingSeats)
        Panel1.Controls.Add(btnReset)
        Panel1.Controls.Add(btnBook)
        Panel1.Controls.Add(lblTotalValue)
        Panel1.Controls.Add(lblTotal)
        Panel1.Controls.Add(lblUnitPriceValue)
        Panel1.Controls.Add(lblUnitPrice)
        Panel1.Controls.Add(numQuantity)
        Panel1.Controls.Add(lblQuantity)
        Panel1.Controls.Add(cboSeatType)
        Panel1.Controls.Add(lblSeatType)
        Panel1.Controls.Add(txtCustomerName)
        Panel1.Controls.Add(lblCustomer)
        Panel1.Controls.Add(txtPhoneNumber)
        Panel1.Controls.Add(lblPhoneNumber)
        Panel1.Controls.Add(cboPerformance)
        Panel1.Controls.Add(lblPerformance)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(640, 240)
        Panel1.TabIndex = 0
        ' 
        ' lblRemainingSeats
        ' 
        lblRemainingSeats.AutoSize = True
        lblRemainingSeats.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRemainingSeats.Location = New Point(557, 19)
        lblRemainingSeats.Name = "lblRemainingSeats"
        lblRemainingSeats.Size = New Size(37, 20)
        lblRemainingSeats.TabIndex = 16
        lblRemainingSeats.Text = "Ghế"
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(304, 195)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(150, 29)
        btnReset.TabIndex = 15
        btnReset.Text = "Đặt lại"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' btnBook
        ' 
        btnBook.Location = New Point(460, 195)
        btnBook.Name = "btnBook"
        btnBook.Size = New Size(150, 29)
        btnBook.TabIndex = 14
        btnBook.Text = "Đặt vé"
        btnBook.UseVisualStyleBackColor = True
        ' 
        ' lblTotalValue
        ' 
        lblTotalValue.AutoSize = True
        lblTotalValue.Location = New Point(460, 168)
        lblTotalValue.Name = "lblTotalValue"
        lblTotalValue.Size = New Size(17, 20)
        lblTotalValue.TabIndex = 13
        lblTotalValue.Text = "0"
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(312, 168)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(75, 20)
        lblTotal.TabIndex = 12
        lblTotal.Text = "Tổng tiền:"
        ' 
        ' lblUnitPriceValue
        ' 
        lblUnitPriceValue.AutoSize = True
        lblUnitPriceValue.Location = New Point(130, 168)
        lblUnitPriceValue.Name = "lblUnitPriceValue"
        lblUnitPriceValue.Size = New Size(17, 20)
        lblUnitPriceValue.TabIndex = 11
        lblUnitPriceValue.Text = "0"
        ' 
        ' lblUnitPrice
        ' 
        lblUnitPrice.AutoSize = True
        lblUnitPrice.Location = New Point(18, 168)
        lblUnitPrice.Name = "lblUnitPrice"
        lblUnitPrice.Size = New Size(65, 20)
        lblUnitPrice.TabIndex = 10
        lblUnitPrice.Text = "Đơn giá:"
        ' 
        ' numQuantity
        ' 
        numQuantity.Location = New Point(460, 124)
        numQuantity.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numQuantity.Name = "numQuantity"
        numQuantity.Size = New Size(150, 27)
        numQuantity.TabIndex = 8
        numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Location = New Point(312, 126)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(91, 20)
        lblQuantity.TabIndex = 9
        lblQuantity.Text = "Số lượng vé:"
        ' 
        ' cboSeatType
        ' 
        cboSeatType.DropDownStyle = ComboBoxStyle.DropDownList
        cboSeatType.FormattingEnabled = True
        cboSeatType.Location = New Point(130, 123)
        cboSeatType.Name = "cboSeatType"
        cboSeatType.Size = New Size(150, 28)
        cboSeatType.TabIndex = 6
        ' 
        ' lblSeatType
        ' 
        lblSeatType.AutoSize = True
        lblSeatType.Location = New Point(18, 126)
        lblSeatType.Name = "lblSeatType"
        lblSeatType.Size = New Size(69, 20)
        lblSeatType.TabIndex = 7
        lblSeatType.Text = "Loại ghế:"
        ' 
        ' txtCustomerName
        ' 
        txtCustomerName.Location = New Point(130, 53)
        txtCustomerName.Name = "txtCustomerName"
        txtCustomerName.Size = New Size(480, 27)
        txtCustomerName.TabIndex = 2
        ' 
        ' lblCustomer
        ' 
        lblCustomer.AutoSize = True
        lblCustomer.Location = New Point(18, 56)
        lblCustomer.Name = "lblCustomer"
        lblCustomer.Size = New Size(89, 20)
        lblCustomer.TabIndex = 3
        lblCustomer.Text = "Khách hàng:"
        ' 
        ' txtPhoneNumber
        ' 
        txtPhoneNumber.Location = New Point(130, 86)
        txtPhoneNumber.Name = "txtPhoneNumber"
        txtPhoneNumber.Size = New Size(480, 27)
        txtPhoneNumber.TabIndex = 4
        ' 
        ' lblPhoneNumber
        ' 
        lblPhoneNumber.AutoSize = True
        lblPhoneNumber.Location = New Point(18, 89)
        lblPhoneNumber.Name = "lblPhoneNumber"
        lblPhoneNumber.Size = New Size(100, 20)
        lblPhoneNumber.TabIndex = 5
        lblPhoneNumber.Text = "Số điện thoại:"
        ' 
        ' cboPerformance
        ' 
        cboPerformance.DropDownStyle = ComboBoxStyle.DropDownList
        cboPerformance.FormattingEnabled = True
        cboPerformance.Location = New Point(130, 16)
        cboPerformance.Name = "cboPerformance"
        cboPerformance.Size = New Size(410, 28)
        cboPerformance.TabIndex = 0
        ' 
        ' lblPerformance
        ' 
        lblPerformance.AutoSize = True
        lblPerformance.Location = New Point(18, 19)
        lblPerformance.Name = "lblPerformance"
        lblPerformance.Size = New Size(74, 20)
        lblPerformance.TabIndex = 1
        lblPerformance.Text = "Suất diễn:"
        ' 
        ' frmBooking
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(640, 240)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "frmBooking"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Đặt vé"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(numQuantity, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboPerformance As ComboBox
    Friend WithEvents lblPerformance As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents lblCustomer As Label
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents lblPhoneNumber As Label
    Friend WithEvents cboSeatType As ComboBox
    Friend WithEvents lblSeatType As Label
    Friend WithEvents numQuantity As NumericUpDown
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblUnitPrice As Label
    Friend WithEvents lblUnitPriceValue As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalValue As Label
    Friend WithEvents btnBook As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents lblRemainingSeats As Label
End Class
