using System.ComponentModel.DataAnnotations;


namespace API_Web.Entities
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public String Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public String Pass { get; set; }
        public string NomComplet => Nom + " " + Prenom;

        public Utilisateur(int id, string prenom, string nom, string email, string pass)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            Email = email;
            Pass = pass;
        }

        public void changePass()
        {
            this.Pass = "muchSecure";
        }

        public bool isPassSecure()
        {
            if (Pass.Length > 6)
            {
                return true;
            }
            return false;
        }

    }
}
