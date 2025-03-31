
# ExamManager

ระบบจัดการข้อสอบด้วย ASP.NET Core Razor Pages และ SQLite

## 🔧 ความต้องการ (Requirements)
- .NET SDK 8.0 ขึ้นไป
- Visual Studio / VS Code
- EF Core Tools (`dotnet tool install --global dotnet-ef`)

## 📁 โครงสร้างโปรเจกต์
- `Pages/` : Razor Pages สำหรับเพิ่ม/แสดงข้อสอบ
- `Models/` : คลาสโมเดล `Exam`, `Choice`
- `Data/` : `AppDbContext.cs` สำหรับ Entity Framework
- `Migrations/` : ประวัติการเปลี่ยนแปลง schema
- `exam.db` : ฐานข้อมูล SQLite

## ▶️ วิธีใช้งาน (Run Project)

### 1. Clone โปรเจกต์
```bash
git clone https://github.com/your-username/ExamManager.git
cd ExamManager
```

### 2. สร้างหรืออัปเดตฐานข้อมูล
```bash
dotnet ef database update
```

### 3. รันโปรเจกต์
```bash
dotnet run
```

### 4. เปิดในเบราว์เซอร์
- หน้า `/AddExam` ใช้เพิ่มข้อสอบและตัวเลือก 4 ข้อ
- หน้า `/Index` แสดงรายการข้อสอบ พร้อมปุ่มลบและรันหมายเลขอัตโนมัติ
- ไม่มีการบันทึกคำตอบ (ไม่มีเฉลยตาม requirement)
---
