namespace BloodManagment.domain.Entities
{
    public enum BloodUnitStatus
    {
        Available,      // الوحدة صالحة وموجودة في المخزون
        Reserved,       // الوحدة محجوزة لطلب مريض
        Used,           // تم استخدامها في تبرع لمريض
        Expired,        // انتهت صلاحيتها
        Damaged,        // غير صالحة بسبب تلف أو خطأ تخزين
        InTransit       // في طريقها من/إلى مركز أو مستشفى
    }

}
