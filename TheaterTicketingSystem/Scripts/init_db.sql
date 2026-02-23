-- tạo db - TheaterDB

-- Performances
CREATE TABLE IF NOT EXISTS "Performances" (
    "Id"            SERIAL          PRIMARY KEY,
    "Name"          VARCHAR(200)    NOT NULL,
    "StartTime"     TIMESTAMP       NOT NULL,
    "Duration"      INTEGER         NOT NULL DEFAULT 0,
    "CreatedAt"     TIMESTAMP       NOT NULL DEFAULT NOW(),
    "UpdatedAt"     TIMESTAMP       NULL,
    "IsDeleted"     BOOLEAN         NOT NULL DEFAULT FALSE
);

-- Bookings
CREATE TABLE IF NOT EXISTS "Bookings" (
    "Id"              SERIAL          PRIMARY KEY,
    "PerformanceId"   INTEGER         NOT NULL,
    "CustomerName"    VARCHAR(200)    NOT NULL,
    "PhoneNumber"     VARCHAR(20)     NOT NULL,
    "SeatType"        INTEGER         NOT NULL DEFAULT 0,
    "Quantity"        INTEGER         NOT NULL DEFAULT 1,
    "UnitPrice"       NUMERIC(18,2)   NOT NULL DEFAULT 0,
    "TotalPrice"      NUMERIC(18,2)   NOT NULL DEFAULT 0,
    "CreatedAt"       TIMESTAMP       NOT NULL DEFAULT NOW(),
    "UpdatedAt"       TIMESTAMP       NULL,
    "IsDeleted"       BOOLEAN         NOT NULL DEFAULT FALSE,

    CONSTRAINT "FK_Bookings_Performances"
        FOREIGN KEY ("PerformanceId")
        REFERENCES "Performances" ("Id")
        ON DELETE RESTRICT
);

-- SeatAssignments
CREATE TABLE IF NOT EXISTS "SeatAssignments" (
    "Id"              SERIAL          PRIMARY KEY,
    "PerformanceId"   INTEGER         NOT NULL,
    "BookingId"       INTEGER         NOT NULL,
    "Row"             VARCHAR(5)      NOT NULL,
    "Number"          INTEGER         NOT NULL,
    "CreatedAt"       TIMESTAMP       NOT NULL DEFAULT NOW(),
    "UpdatedAt"       TIMESTAMP       NULL,
    "IsDeleted"       BOOLEAN         NOT NULL DEFAULT FALSE,

    CONSTRAINT "FK_SeatAssignments_Performances"
        FOREIGN KEY ("PerformanceId")
        REFERENCES "Performances" ("Id")
        ON DELETE RESTRICT,

    CONSTRAINT "FK_SeatAssignments_Bookings"
        FOREIGN KEY ("BookingId")
        REFERENCES "Bookings" ("Id")
        ON DELETE RESTRICT
);

-- Index
CREATE INDEX IF NOT EXISTS "IX_Bookings_PerformanceId"
    ON "Bookings" ("PerformanceId");

CREATE INDEX IF NOT EXISTS "IX_SeatAssignments_PerformanceId"
    ON "SeatAssignments" ("PerformanceId");

CREATE INDEX IF NOT EXISTS "IX_SeatAssignments_BookingId"
    ON "SeatAssignments" ("BookingId");

-- Test data
INSERT INTO "Performances" ("Name", "StartTime", "Duration")
VALUES
    ('Xuất chiếu A', '2026-02-25 10:00:00', 120),
    ('Xuất chiếu B', '2026-02-26 19:30:00', 150),
    ('Xuất chiếu C', '2026-03-01 18:00:00', 120),
    ('Xuất chiếu D', '2026-03-03 20:00:00', 90);