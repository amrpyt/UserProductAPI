using System.ComponentModel.DataAnnotations;  // تأكد من إضافة هذه المكتبة لتحديد المفتاح

namespace UserProductAPI.Models
{
    public class Purchase
    {
        [Key]  // هذا يحدد UserProductID كمفتاح أساسي
        public int UserProductID { get; set; }

        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
