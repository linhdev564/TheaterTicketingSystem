*********** Theater Ticketing System

Hệ thống quản lý đặt vé và gán ghế cho rạp hát, xây dựng bằng **VB.NET WinForms** + **Entity Framework Core** + **PostgreSQL**.

---

*********** Yêu cầu hệ thống

| Thành phần    | Phiên bản |
|---|---|
| .NET SDK      | 8.0 trở lên |
| PostgreSQL    | 14.x trở lên |
| Visual Studio | 2022 / 2026 |

---

*********** Cách chạy chương trình

### Bước 1 — Cài đặt PostgreSQL
Tải và cài đặt từ [https://www.postgresql.org/download/].

### Bước 2 — Tạo database
Mở **pgAdmin**, click phải lên **Databases** → **Create → Database** → đặt tên `TheaterDB` → **Save**.

### Bước 3 — Chạy script khởi tạo
Click phải lên database `TheaterDB` → **Query Tool** → mở file `Scripts/init_db.sql` → nhấn **F5**.

### Bước 4 — Cấu hình connection string
Connection string được cấu hình trong `Data/TheaterContext.vb`: Thay `Password` cho phù hợp với PostgreSQL trên máy local.

### Bước 5 — Build & Run
Mở solution trong Visual Studio → **F5** hoặc **Ctrl+F5**.

---

*********** các lưu ý và giả định giới hạn


## Cơ sở dữ liệu

### Sơ đồ bảng

| Bảng              | Mô tả |
|---|---|
| `Performances`    | Suất diễn (tên, thời gian bắt đầu, thời lượng) |
| `Bookings`        | Đặt vé (FK → Performances) |
| `SeatAssignments` | Gán ghế (FK → Bookings, Performances) |

### Quan hệ

---

## Giả định & Giới hạn

1. Mỗi suất diễn có tối đa **100 ghế** (10 hàng A–J × 10 cột), cấu hình trong `AppConstants.DefaultTotalSeats`. |
2. Mỗi suất diễn có tối đa **3 hạng ghế**: Standard (100.000), Couple(200.000), Vip(150.000), cấu hình trong `Commons/PricingHelper.vb`. |
3. Tất cả suất diễn dùng chung sơ đồ ghế 10×10. Không hỗ trợ cấu hình sơ đồ riêng cho từng suất. |
4. Mỗi booking chỉ thuộc **một hạng ghế** duy nhất. |
5. Số lượng vé đặt không được vượt quá số ghế còn trống của suất diễn. |

---

## Công nghệ sử dụng

- **VB.NET** — WinForms (.NET 8)
- **Entity Framework Core** — ORM
- **Npgsql** — PostgreSQL provider
- **PostgreSQL** — Cơ sở dữ liệu