namespace Core.Secure.Business.Domain.AggregatesModel.CommonAggregate;

public enum OrderStatus
{
    PROCESSING,             // กำลังดำเนินการ สำหรับ Parent Order Status (ORDERED, PENDING_PAYMENT, PICK_AND_PACK, PICKUP, IN_TRANSIT, DELIVERED, CONFIRM_GOODS_RECEIVED, OPEN_DISPUTE)
    ORDERED,                // ออเดอร์ใหม่
    [Obsolete("Use specific canceled status instead")]
    CANCELED,
    CANCELED_BY_SELLER,     // ปฏิเสธออเดอร์จาก Seller
    CANCELED_BY_SHIPPING,   // ปฏิเสธออเดอร์จาก Shipping
    PENDING_PAYMENT,        // รอการชำระเงิน
    PAID,                   // ชำระเงินสำเร็จ
    PAYMENT_FAILED,         // ชำระเงินไม่สำเร็จ
    PICK_AND_PACK,          // จัดเตรียมสินค้า
    PICKUP,                 // รับสินค้า
    IN_TRANSIT,             // จัดส่งสินค้า
    DELIVERED,              // ถึงที่หมาย
    CONFIRM_GOODS_RECEIVED, // ตรวจสอบสินค้า
    COMPLETED,              // สำเร็จ
    OPEN_DISPUTE,           // รอพิจารณา/ออเดอร์มีปัญหา
    DISPUTE_RESOLVED,       // ออเดอร์มีปัญหาสำเร็จ
    DISPUTE_REJECTED        // ออเดอร์มีปัญหาไม่ยอมรับ
}

public enum OrderStatusGroup
{
    PAID,                   // ชำระเงินสำเร็จ
    PICK_AND_PACK,          // จัดเตรียมสินค้า
    IN_TRANSIT,             // จัดส่งสินค้า (PICK_UP, IN_TRANSIT)
    DELIVERED,              // ถึงที่หมาย
    COMPLETED,              // สำเร็จ
    OPEN_DISPUTE,           // รอพิจารณา/ออเดอร์มีปัญหา
    DISPUTE_RESOLVED,       // ออเดอร์มีปัญหาสำเร็จ
    CANCELED,               // ยกเลิก (PAYMENT_FAILED, CANCELED_BY_SELLER, CANCELED_BY_SHIPPING)
}