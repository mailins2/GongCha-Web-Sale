CREATE TRIGGER trg_InsertGioHangSanPham
ON giohang_sanpham
AFTER INSERT
AS
BEGIN
    UPDATE giohangs
    SET tongtien = tongtien + i.tongtiensp
    FROM giohangs g
    INNER JOIN inserted i ON g.magh = i.magh;
END;
go
CREATE TRIGGER trg_UpdateGioHangSanPham
ON giohang_sanpham
AFTER UPDATE
AS
BEGIN
    -- Trừ tổng tiền cũ
    UPDATE giohangs
    SET tongtien = tongtien - d.tongtiensp
    FROM giohangs g
    INNER JOIN deleted d ON g.magh = d.magh;

    -- Cộng tổng tiền mới
    UPDATE giohangs
    SET tongtien = tongtien + i.tongtiensp
    FROM giohangs g
    INNER JOIN inserted i ON g.magh = i.magh;
END;
go
CREATE TRIGGER trg_DeleteGioHangSanPham
ON giohang_sanpham
AFTER DELETE
AS
BEGIN
    UPDATE giohangs
    SET tongtien = tongtien - d.tongtiensp
    FROM giohangs g
    INNER JOIN deleted d ON g.magh = d.magh;
END;

drop trigger trg_InsertGioHangSanPham
drop trigger trg_UpdateGioHangSanPham
drop trigger trg_DeleteGioHangSanPham

