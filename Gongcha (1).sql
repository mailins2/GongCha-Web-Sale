create database QL_GONGCHA 
go
use QL_GONGCHA 
-- Bảng loại tài khoản
CREATE TABLE loaitk (
    maloaitk INT NOT NULL PRIMARY KEY,
    tenloaitk NVARCHAR(10)
);

-- Bảng tài khoản
CREATE TABLE taikhoan (
    matk INT NOT NULL PRIMARY KEY,
    tentk VARCHAR(10) UNIQUE not null,
    matkhau CHAR(20) not null, -- chỉ bao gồm 10 kí tự số và chữ 
    hoten NVARCHAR(30),
    ngaysinh DATE,
    gioitinh NVARCHAR(5),
    diachi NVARCHAR(100), 
    email VARCHAR(50) UNIQUE CHECK (email LIKE '%_@__%.__%'), 
    sdt CHAR(10) UNIQUE,
    hinh NVARCHAR(MAX),
    maloaitk INT NOT NULL,
    CONSTRAINT fk_taikhoan_loaitk FOREIGN KEY (maloaitk) REFERENCES loaitk (maloaitk)
);

-- Bảng loại sản phẩm
CREATE TABLE loaisp (
    maloaisp INT NOT NULL PRIMARY KEY,
    tenloaisp NVARCHAR(MAX)
);

-- Bảng sản phẩm
CREATE TABLE sanpham (
    masp INT NOT NULL,
    tensp NVARCHAR(MAX),
    maloaisp INT,
    hinh NVARCHAR(MAX),
    mota NVARCHAR(MAX),
    CONSTRAINT pk_sanpham PRIMARY KEY (masp),
    CONSTRAINT fk_sanpham_loaisp FOREIGN KEY (maloaisp) REFERENCES loaisp (maloaisp)
);

create table banggia(
	masp INT NOT NULL,
    size CHAR(1) NOT NULL CHECK (size IN ('M', 'L')) DEFAULT 'M',
	dongia DECIMAL(10, 2) not null,
	constraint pk_banggia primary key (masp,size),
	CONSTRAINT fk_banggia_sanpham FOREIGN KEY (masp) REFERENCES sanpham (masp)
)
-- Bảng topping
CREATE TABLE topping (
    matp INT NOT NULL PRIMARY KEY,
    tentp NVARCHAR(MAX),
    dongia DECIMAL(10, 2)not null,
    hinh NVARCHAR(MAX)
);

CREATE TABLE giohang (
    magh INT not null PRIMARY KEY,    -- Mã giỏ hàng
    matk INT NOT NULL,                      -- Mã tài khoản
    ngaytao DATETIME DEFAULT(GETDATE()),         -- Ngày tạo giỏ hàng
    tongtien DECIMAL(10, 2) DEFAULT 0,      -- Tổng tiền trong giỏ hàng
    CONSTRAINT fk_giohang_taikhoan FOREIGN KEY (matk) REFERENCES taikhoan(matk)
);

CREATE TABLE giohang_sanpham (
    magh INT,                               -- Mã giỏ hàng
    masp INT,                               -- Mã sản phẩm
    size CHAR(1) CHECK (size IN ('M', 'L')), -- Kích cỡ (M/L)
    duong INT CHECK (duong BETWEEN 0 AND 100), -- Mức đường (%)
    da INT CHECK (da BETWEEN 0 AND 100),       -- Mức đá (%)
    soluong INT DEFAULT 1,                  -- Số lượng ly
    tongtiensp DECIMAL(10, 2),              -- Tổng tiền cho sản phẩm
	 matp INT ,
    CONSTRAINT pk_giohang_sanpham PRIMARY KEY (magh, masp, size,matp), -- Khóa chính
    CONSTRAINT fk_giohang_sanpham_gh FOREIGN KEY (magh) REFERENCES giohang(magh),
    CONSTRAINT fk_giohang_sanpham_sp FOREIGN KEY (masp) REFERENCES sanpham(masp),
	CONSTRAINT fk_giohang_topping FOREIGN KEY (matp) REFERENCES topping(matp)
);



-- Bảng trạng thái đơn hàng (nếu cần trạng thái chi tiết hơn)
CREATE TABLE trangthaidonhang (
    matrangthai INT NOT NULL PRIMARY KEY,
    tentrangthai NVARCHAR(50)
);

-- Bảng đơn hàng
CREATE TABLE donhang (
    madh INT NOT NULL PRIMARY KEY,
    tgdat DATETIME DEFAULT (GETDATE()),
    matk INT NOT NULL,
    ghichu NVARCHAR(MAX),
    matrangthai  INT ,
	thanhtoan int CHECK (thanhtoan IN (0, 1)), -- đã thanh toán chưa 
    CONSTRAINT fk_donhang_taikhoan FOREIGN KEY (matk) REFERENCES taikhoan (matk),
	CONSTRAINT fk_donhang_trangthaidonhang FOREIGN KEY (matrangthai) REFERENCES trangthaidonhang (matrangthai)
);

-- Bảng chi tiết đơn hàng
CREATE TABLE chitietdh (
    madh INT NOT NULL,
    masp INT NOT NULL,
    size CHAR(1),
    matp INT,
    soluong INT DEFAULT 1,
    thutu INT DEFAULT 1,
    tongtiensp DECIMAL(10, 2),
	CONSTRAINT pk_ctdh PRIMARY KEY (madh, masp, size,matp),
    CONSTRAINT fk_ctdh_donhang FOREIGN KEY (madh) REFERENCES donhang (madh),
    CONSTRAINT fk_ctdh_sanpham FOREIGN KEY (masp) REFERENCES sanpham (masp),
    CONSTRAINT fk_ctdh_topping FOREIGN KEY (matp) REFERENCES topping (matp)
);

-- Bảng hóa đơn
CREATE TABLE hoadon (
    mahd INT NOT NULL PRIMARY KEY,
    madh INT NOT NULL,
    tongtien DECIMAL(10, 2),
    giamgia DECIMAL(10, 2),
    thanhtien DECIMAL(10, 2),
    matk INT NOT NULL,
    CONSTRAINT fk_hoadon_donhang FOREIGN KEY (madh) REFERENCES donhang (madh),
    CONSTRAINT fk_hoadon_taikhoan FOREIGN KEY (matk) REFERENCES taikhoan (matk)
);

create table danhgia(   -- đánh giá sản phẩm 
	madh int not null,
	matk int not null,
	masp int not null,
	ngaydg datetime, -- ngay danh gia
	sosao int not null check(sosao in(1,5)) default(5),
	noidung nvarchar(max),
	constraint pk_danhgia primary key (madh, masp),
	CONSTRAINT fk_danhgia_taikhoan FOREIGN KEY (matk) REFERENCES taikhoan (matk),
	CONSTRAINT fk_danhgia_donhang FOREIGN KEY (madh) REFERENCES donhang (madh),
	CONSTRAINT fk_danhgia_sanpham FOREIGN KEY (masp) REFERENCES sanpham (masp)
)
