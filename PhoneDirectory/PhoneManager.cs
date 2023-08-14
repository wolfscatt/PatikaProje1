public class PhoneManager : IPhoneService
{
    private List<PhoneDirectory> _phoneList;

    public PhoneManager(List<PhoneDirectory> phoneList)
    {
        this._phoneList = phoneList;
    }

    public void Add()
    {
        Console.Write("Lütfen İsim Giriniz: ");
        var firstName = Console.ReadLine();

        Console.Write("Lütfen Soy İsim Giriniz: ");
        var lastName = Console.ReadLine();

        Console.Write("Lütfen Telefon Numarası Giriniz: ");
        var phoneNumber = Console.ReadLine();

        var phoneDirectory = new PhoneDirectory(firstName, lastName, phoneNumber);

        _phoneList.Add(phoneDirectory);
        Console.WriteLine($"Kaydedilen kişi\n{phoneDirectory}");

    }

    public void Delete()
    {
        Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
        var nameSurname = Console.ReadLine().ToLower();

        var deleteNumber = _phoneList
            .Where(item => item.FirstName.ToLower().Contains(nameSurname) || item.LastName.ToLower().Contains(nameSurname)).ToList();

        if (deleteNumber.Count > 0 )
        {
            foreach (var item in deleteNumber)
            {
                Console.Write($"{item.FirstName} {item.LastName} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                var approve = Console.ReadLine();
                if (approve == "y" || approve == "Y")
                {
                    deleteNumber.FirstOrDefault(item => _phoneList.Remove(item));
                    break;
                }
                else if (approve == "n" || approve == "N")
                {
                    break;
                }
            }
        }
        else
        {
            Console.Write("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n  * Silmeyi sonlandırmak için : (1)\r\n  * Yeniden denemek için      : (2)");
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                return;
            }
            else if (choice == "2")
            {
                Delete();
            }
        }
    }

    public void Read()
    {
        Console.WriteLine("Telefon Rehberi\r\n  **********************************************");

        foreach (var item in _phoneList)
        {
            Console.WriteLine(item);
        }
    }

    public void Search()
    {
        Console.Write("Arama yapmak istediğiniz tipi seçiniz.\r\n **********************************************\nİsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
        var searchKeyword = Convert.ToInt32(Console.ReadLine());
        if (searchKeyword == 1)
        {
            Console.Write("Aramak istediğiniz ismi ya da soyismi yazınız: ");
            var searchName = Console.ReadLine().ToLower();
            var search = _phoneList.Where(item => item.FirstName.ToLower().Contains(searchName) || item.LastName.ToLower().Contains(searchName)).ToList();

            if (search.Count > 0)
            {
                Console.WriteLine("Arama Sonuçlarınız:\r\n **********************************************");
                search.ForEach(item => Console.WriteLine(item));
            }
            else
            {
                Console.WriteLine("Aradığınız kişi rehberde bulunamadı!");
            }

        }
        else if (searchKeyword == 2)
        {
            Console.Write("Aramak istediğiniz telefon numarasını yazınız: ");
            var searchNumber = Console.ReadLine();
            var search = _phoneList.Where(item => item.PhoneNumber.Contains(searchNumber)).ToList();

            if (search.Count > 0)
            {
                Console.WriteLine("Arama Sonuçlarınız:\r\n **********************************************");
                search.ForEach(item => Console.WriteLine(item));
            }
            else
            {
                Console.WriteLine("Aradığınız kişi rehberde bulunamadı!");
            }
        }
    }

    public void Update()
    {
        Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
        var nameSurname = Console.ReadLine().ToLower();

        var search = _phoneList.Where(item => item.FirstName.ToLower().Contains(nameSurname) || item.LastName.ToLower().Contains(nameSurname)).ToList();

        if (search.Count > 0)
        {
            foreach (var item in search)
            {
                Console.Write($"{item.FirstName} {item.LastName} isimli kişinin numarası {item.PhoneNumber}, güncellemek istiyor musunuz? (y/n)");
                var approve = Console.ReadLine();
                if (approve == "y" || approve == "Y")
                {
                    Console.Write("Güncellemek istediğiniz telefon numarasını giriniz: ");
                    var phone = Console.ReadLine();
                    item.PhoneNumber = phone;
                    Console.WriteLine($"Güncellenen kişi bilgileri:\nFirstName: {item.FirstName}\nLastName: {item.LastName}\nPhone Number: {item.PhoneNumber}");
                    break;
                }
                else if (approve == "n" || approve == "N")
                {
                    break;
                }
            }
           
        }
        else
        {
            Console.Write("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n  * Güncellemeyi sonlandırmak için : (1)\r\n  * Yeniden denemek için      : (2)");
            var choice = Console.ReadLine();
            if (choice == "1")
            {
                return;
            }
            else if (choice == "2")
            {
                Update();
            }
        }

        
    }
}
