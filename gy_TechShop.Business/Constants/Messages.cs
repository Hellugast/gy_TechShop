using gy_TechShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string MaintenanceTime = "Sistem bakımdadır.";
        public static string ProductCountOfCategoryError = "İlgili kategoride ürün sayısı geçersizdir.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün bulunmaktadır.";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır.";
        public static string UserRegistered = "Kullanıcı kaydı gerçekleştirildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string PasswordError = "Hatalı parola.";
        public static string UserAlreadyExists = "Kullanıcı zaten bulunmaktadır.";
        public static string AccessTokenCreated = "Yetkilendime anahtarı oluşturuldu.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandNotFound = "Marka bulunamadı.";
        public static string ProductNotFound = "Ürün bulunamadı.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductUpdated = "Ürün güncellendi.";
    }
}
