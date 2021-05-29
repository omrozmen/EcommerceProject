using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string Error = "Hatalı İşlem yaptınız";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string ProductImageMustBeExist = "Ürün resmi zorunludur";
        public static string ProductHaveNoImage = "Böyle bir resim yok";
    }
}
