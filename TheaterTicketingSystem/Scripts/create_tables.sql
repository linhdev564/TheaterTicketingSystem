-- ============================================================
-- TheaterTicketingSystem — PostgreSQL Database Schema
-- ============================================================

-- Bảng: Performances (Suất diễn)
CREATE TABLE IF NOT EXISTS "Performances" (
    "Id"            SERIAL          PRIMARY KEY,
    "Name"          VARCHAR(200)    NOT NULL,
    "StartTime"     TIMESTAMP       NOT NULL,
    "Duration"      INTEGER         NOT NULL DEFAULT 0,
    "IsDeleted"     BOOLEAN         NOT NULL DEFAULT FALSE,
    "CreatedAt"     TIMESTAMP       NOT NULL DEFAULT NOW(),
    "UpdatedAt"     TIMESTAMP       NULL
);

-- Bảng: Bookings (Đặt vé)
CREATE TABLE IF NOT EXISTS "Bookings" (
    "Id"              SERIAL          PRIMARY KEY,
    "PerformanceId"   INTEGER         NOT NULL,
    "CustomerName"    VARCHAR(200)    NOT NULL,
    "PhoneNumber"     VARCHAR(20)     NOT NULL,
    "SeatType"        INTEGER         NOT NULL DEFAULT 0,
    "Quantity"        INTEGER         NOT NULL DEFAULT 1,
    "UnitPrice"       NUMERIC(18,2)   NOT NULL DEFAULT 0,
    "TotalPrice"      NUMERIC(18,2)   NOT NULL DEFAULT 0,
    "IsDeleted"       BOOLEAN         NOT NULL DEFAULT FALSE,
    "CreatedAt"       TIMESTAMP       NOT NULL DEFAULT NOW(),
    "UpdatedAt"       TIMESTAMP       NULL,

    CONSTRAINT "FK_Bookings_Performances"
        FOREIGN KEY ("PerformanceId")
        REFERENCES "Performances" ("Id")
        ON DELETE RESTRICT
);

-- Bảng: SeatAssignments (Gán ghế)
CREATE TABLE IF NOT EXISTS "SeatAssignments" (
    "Id"              SERIAL          PRIMARY KEY,
    "PerformanceId"   INTEGER         NOT NULL,
    "BookingId"       INTEGER         NOT NULL,
    "Row"             VARCHAR(5)      NOT NULL,
    "Number"          INTEGER         NOT NULL,
    "IsDeleted"       BOOLEAN         NOT NULL DEFAULT FALSE,
    "CreatedAt"       TIMESTAMP       NOT NULL DEFAULT NOW(),
    "UpdatedAt"       TIMESTAMP       NULL,

    CONSTRAINT "FK_SeatAssignments_Performances"
        FOREIGN KEY ("PerformanceId")
        REFERENCES "Performances" ("Id")
        ON DELETE RESTRICT,

    CONSTRAINT "FK_SeatAssignments_Bookings"
        FOREIGN KEY ("BookingId")
        REFERENCES "Bookings" ("Id")
        ON DELETE RESTRICT
);

-- Indexes để tăng tốc query thường dùng
CREATE INDEX IF NOT EXISTS "IX_Bookings_PerformanceId"
    ON "Bookings" ("PerformanceId");

CREATE INDEX IF NOT EXISTS "IX_SeatAssignments_PerformanceId"
    ON "SeatAssignments" ("PerformanceId");

CREATE INDEX IF NOT EXISTS "IX_SeatAssignments_BookingId"
    ON "SeatAssignments" ("BookingId");

-- Unique constraint: mỗi ghế chỉ được gán 1 lần (chưa xóa mềm) trong cùng suất diễn
CREATE UNIQUE INDEX IF NOT EXISTS "UX_SeatAssignments_Seat_Active"
    ON "SeatAssignments" ("PerformanceId", "Row", "Number")
    WHERE "IsDeleted" = FALSE;