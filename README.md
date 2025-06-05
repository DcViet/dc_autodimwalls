
# Auto Dimension Walls – Revit Add-in

Tự động tạo kích thước (dimensions) cho các tường trong mô hình Revit. Add-in giúp tiết kiệm thời gian và đảm bảo độ chính xác khi triển khai bản vẽ kiến trúc.

---

## 🚀 Tính năng chính

- Tự động tạo dimension theo mặt ngoài hoặc trung tâm tường.
- Hỗ trợ tường nội thất và ngoại thất.
- Loại trừ các loại tường mỏng (như vách kính, vách ngăn nhẹ).
- Tùy chỉnh dễ dàng qua mã nguồn.
- Giao diện Ribbon thân thiện trong Revit.

---

## 🏗️ Yêu cầu hệ thống

- **Revit**: 2022 hoặc mới hơn  
- **.NET Framework**: 4.8  
- **Visual Studio**: 2022  
- **Windows**: 10/11

---

## 🛠️ Cài đặt

### 1. Build Add-in
- Mở giải pháp bằng Visual Studio.
- Build dự án (Release).
- File DLL được tạo ở thư mục:  
  `AutoDimensionWalls\bin\Release\AutoDimensionWalls.dll`

### 2. Tạo file `.addin`
Tạo file `AutoDimensionWalls.addin` tại: ```%AppData%\Autodesk\Revit\Addins\2022\\```


Nội dung:

```xml
<RevitAddIns>
  <AddIn Type="Command">
    <Name>AutoDimensionWalls</Name>
    <Assembly>C:\Path\To\Your\DLL\AutoDimensionWalls.dll</Assembly>
    <AddInId>F02B5DB5-2350-4E6C-8AF2-24B9EF4D6B23</AddInId>
    <FullClassName>AutoDimensionWalls.Commands.AutoDimensionCommand</FullClassName>
    <VendorId>ADW</VendorId>
    <VendorDescription>Auto Tools for Revit</VendorDescription>
  </AddIn>
</RevitAddIns>
```

---

## 🧪 Cách sử dụng

1. Mở Revit → Tải một project có các tường cần dimension.
2. Chọn tab **Auto Tools** → Nhấn nút **Auto Dimension**.
3. Add-in sẽ tự động đặt kích thước theo quy tắc đã lập trình.

---

## 📁 Cấu trúc thư mục

```
AutoDimensionWalls/
│
├── Commands/
│   └── AutoDimensionCommand.cs
├── Helpers/
│   └── WallUtils.cs
│   └── DimensionUtils.cs
├── UI/
│   └── Ribbon.cs
├── App.cs
├── AutoDimensionWalls.addin
├── README.md
```

---

## 📌 Lưu ý kỹ thuật

* Tường được lọc theo WallType và Category.
* Các Reference được tạo bằng `doc.Create.NewDimension()`.
* Kích thước được vẽ theo `ViewPlan`.








