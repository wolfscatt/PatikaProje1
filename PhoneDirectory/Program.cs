
using System;
using System.Linq;

var phoneNumbers = new List<PhoneDirectory>()
{
    new PhoneDirectory("Ömer Faruk", "BİNGÖL", "5536972626"),
    new PhoneDirectory("Burcu", "EKŞİ", "5461282913"),
    new PhoneDirectory("Ahmet", "DEVE", "5912856512"),
    new PhoneDirectory("Leyla", "DAĞ", "5123567824"),
    new PhoneDirectory("Murat", "DENİZ", "5347896081"),
};

var phoneManager = new PhoneManager(phoneNumbers);

while (true)
{
    Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz :) \r\n  *******************************************\n (1) Yeni Numara Kaydetmek (2) Varolan Numarayı Silmek (3) Varolan Numarayı Güncelleme (4) Rehberi Listelemek (5) Rehberde Arama Yapmak﻿ (6) Çıkış : ");
    var selectProcess = Convert.ToInt32(Console.ReadLine());

    switch (selectProcess)
    {
        case 1:
            phoneManager.Add();
            break;
        case 2:
            phoneManager.Delete();
            break;
        case 3:
            phoneManager.Update();
            break;
        case 4:
            phoneManager.Read();
            break;
        case 5:
            phoneManager.Search();
            break;
        default:
            Console.WriteLine("Yanlış Seçim!");
            break;
    }

    if (selectProcess == 6)
        break;
}
