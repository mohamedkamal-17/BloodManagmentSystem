namespace BloodManagment.domain.Entities
{
    public enum InventoryStatus
    {
        Normal,         // المخزون في مستوى آمن
        Low,            // المخزون منخفض ويحتاج تنبيه
        Critical,       // المخزون خطير ويحتاج توفير عاجل
        OutOfStock,     // المخزون نفد تمامًا
        Overloaded      // مخزون زائد عن الحاجة 
    }

}
