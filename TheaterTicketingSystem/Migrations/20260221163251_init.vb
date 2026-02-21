Imports System
Imports Microsoft.EntityFrameworkCore.Migrations
Imports Microsoft.VisualBasic
Imports Npgsql.EntityFrameworkCore.PostgreSQL.Metadata

Namespace Global.TheaterTicketingSystem.Migrations
    ''' <inheritdoc />
    Partial Public Class init
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="Performances",
                columns:=Function(table) New With {
                    .Id = table.Column(Of Integer)(type:="integer", nullable:=False).
                        Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    .Name = table.Column(Of String)(type:="text", nullable:=False),
                    .StartTime = table.Column(Of Date)(type:="timestamp without time zone", nullable:=False),
                    .Duration = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .CreatedAt = table.Column(Of Date)(type:="timestamp without time zone", nullable:=False),
                    .UpdatedAt = table.Column(Of Date)(type:="timestamp without time zone", nullable:=True),
                    .IsDeleted = table.Column(Of Boolean)(type:="boolean", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Performances", Function(x) x.Id)
                End Sub)

            migrationBuilder.CreateTable(
                name:="Bookings",
                columns:=Function(table) New With {
                    .Id = table.Column(Of Integer)(type:="integer", nullable:=False).
                        Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    .PerformanceId = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .CustomerName = table.Column(Of String)(type:="text", nullable:=False),
                    .PhoneNumber = table.Column(Of String)(type:="character varying(20)", maxLength:=20, nullable:=False),
                    .SeatType = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .Quantity = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .UnitPrice = table.Column(Of Decimal)(type:="numeric", nullable:=False),
                    .TotalPrice = table.Column(Of Decimal)(type:="numeric", nullable:=False),
                    .CreatedAt = table.Column(Of Date)(type:="timestamp without time zone", nullable:=False),
                    .UpdatedAt = table.Column(Of Date)(type:="timestamp without time zone", nullable:=True),
                    .IsDeleted = table.Column(Of Boolean)(type:="boolean", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Bookings", Function(x) x.Id)
                    table.ForeignKey(
                        name:="FK_Bookings_Performances_PerformanceId",
                        column:=Function(x) x.PerformanceId,
                        principalTable:="Performances",
                        principalColumn:="Id",
                        onDelete:=ReferentialAction.Cascade)
                End Sub)

            migrationBuilder.CreateTable(
                name:="SeatAssignments",
                columns:=Function(table) New With {
                    .Id = table.Column(Of Integer)(type:="integer", nullable:=False).
                        Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    .PerformanceId = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .BookingId = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .Row = table.Column(Of String)(type:="text", nullable:=True),
                    .Number = table.Column(Of Integer)(type:="integer", nullable:=False),
                    .CreatedAt = table.Column(Of Date)(type:="timestamp without time zone", nullable:=False),
                    .UpdatedAt = table.Column(Of Date)(type:="timestamp without time zone", nullable:=True),
                    .IsDeleted = table.Column(Of Boolean)(type:="boolean", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_SeatAssignments", Function(x) x.Id)
                    table.ForeignKey(
                        name:="FK_SeatAssignments_Bookings_BookingId",
                        column:=Function(x) x.BookingId,
                        principalTable:="Bookings",
                        principalColumn:="Id",
                        onDelete:=ReferentialAction.Cascade)
                    table.ForeignKey(
                        name:="FK_SeatAssignments_Performances_PerformanceId",
                        column:=Function(x) x.PerformanceId,
                        principalTable:="Performances",
                        principalColumn:="Id",
                        onDelete:=ReferentialAction.Cascade)
                End Sub)

            migrationBuilder.CreateIndex(
                name:="IX_Bookings_PerformanceId",
                table:="Bookings",
                column:="PerformanceId")

            migrationBuilder.CreateIndex(
                name:="IX_SeatAssignments_BookingId",
                table:="SeatAssignments",
                column:="BookingId")

            migrationBuilder.CreateIndex(
                name:="IX_SeatAssignments_PerformanceId",
                table:="SeatAssignments",
                column:="PerformanceId")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="SeatAssignments")

            migrationBuilder.DropTable(
                name:="Bookings")

            migrationBuilder.DropTable(
                name:="Performances")
        End Sub
    End Class
End Namespace
