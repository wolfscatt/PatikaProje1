
// Entity
public class PhoneDirectory
{
    private string? firstName;
    private string? lastName;
    private string phoneNumber;

    public string? FirstName 
    {
        get => firstName; 
        set => firstName = value; 
    }    
    public string? LastName 
    {
        get => lastName; 
        set => lastName = value; 
    }    
    public string PhoneNumber 
    {
        get => phoneNumber;
        set
        {
            if (value.Length == 10)
                phoneNumber = value;
            else
                Console.WriteLine("Telefon Numarası başında 0 olmadan 10 Haneli girilmelidir!");
        } 
    }

    public PhoneDirectory()
    {
        
    }

    public PhoneDirectory(string? firstName, string? lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        //return $"Name:{firstName,19}\nSurname:{lastName,16}\nPhone Number:{phoneNumber,11}";
        return $"Name:{firstName,-15}\nSurname:{lastName,-15}\nPhone Number:{phoneNumber}";
    }
}