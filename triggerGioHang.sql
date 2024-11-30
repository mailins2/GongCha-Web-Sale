CREATE TRIGGER trg_InsertGioHangSanPham
ON giohang_sanpham
AFTER INSERT
AS
BEGIN
    UPDATE giohang
    SET tongtien = tongtien + i.tongtiensp
    FROM giohang g
    INNER JOIN inserted i ON g.magh = i.magh;
END;
go
CREATE TRIGGER trg_UpdateGioHangSanPham
ON giohang_sanpham
AFTER UPDATE
AS
BEGIN
    -- Trừ tổng tiền cũ
    UPDATE giohang
    SET tongtien = tongtien - d.tongtiensp
    FROM giohang g
    INNER JOIN deleted d ON g.magh = d.magh;

    -- Cộng tổng tiền mới
    UPDATE giohang
    SET tongtien = tongtien + i.tongtiensp
    FROM giohang g
    INNER JOIN inserted i ON g.magh = i.magh;
END;
go
CREATE TRIGGER trg_DeleteGioHangSanPham
ON giohang_sanpham
AFTER DELETE
AS
BEGIN
    UPDATE giohang
    SET tongtien = tongtien - d.tongtiensp
    FROM giohang g
    INNER JOIN deleted d ON g.magh = d.magh;
END;

