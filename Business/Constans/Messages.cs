using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductListed = "Ürün listelendi.";
        public static string ProductDeleted  = "Ürün silindi.";
        public static string ProductUpdated = "Ürün Güncellendi.";
        public static string ReturnRentalError = "Bu Araç Daha Teslim Edilmemiştir.";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);
        public static string AuthorizationDenied= "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = " token başarıyla oluşturuldu";
        public static string CarIsNotAvailable = "Araba mevcut değil";
        public static string ErrorRentalUpdate = "Araç şu anda kirada değil, sonlandırma başarısız";
        public static string SuccessRentalUpdate = "Kiralama başarı ile sonlandırıldı";
        public static string creditCardAdded = "Kredi kartı başarı ile eklendi";
        public static string RentalError = "Araç şu anda kiralanamaz";
        public static string creditCardDeleted = "Kredi kartı başarı ile silindi";
    }
}
