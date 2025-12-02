namespace AskeOgViktorProjekt.Data // Namespace matches the folder
{
   
 public class User
    {
        // Primary Key (EF Core recognizes 'Id' or 'UserID' by convention)
        public int Id { get; set; }
       
        // Example user properties
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
