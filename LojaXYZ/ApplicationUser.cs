using Microsoft.AspNetCore.Identity;


namespace LojaXYZ.Entidades
{
    public class ApplicationUser : IdentityUser
    {
        public int Idade { get; set; }
        public string Celular { get; set; }
    }
}