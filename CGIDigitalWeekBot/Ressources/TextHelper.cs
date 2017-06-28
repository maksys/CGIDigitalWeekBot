using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGIDigitalWeekBot
{
    public static class TextHelper
    {

        #region DICTIONNAIRES DES REPONSES
        public static Dictionary<int, string> FormulesQuefaire = new Dictionary<int, string>() {
            { 0,"Comment puis-je vous aider"},
            { 1,"Que puis-je faire pour vous"},
            { 2,"A quoi puis-je vous être utile"},
            { 3,"Comment vous rendre service"}
        };

        public static Dictionary<int, string> FormulesEnchante = new Dictionary<int, string>() {
            { 0,"Enchanté de vous connaitre"},
            { 1,"Ravi de vous rencontrer"},
            { 2,"Je suis enchanté"},
            { 3,"Content de vous connaitre"},
            { 4,"Heureux de faire votre connaissance"},
            { 5,"Enchanté de faire votre connaissance"},
            { 6,"Ravi de vous connaitre"}
        };
        public static Dictionary<int, string> FormulesTonNom = new Dictionary<int, string>() {
            { 0,"Quel est votre prénom"},
            { 1,"Comment vous nommez vous"},
            { 2,"Comment dois-je vous appeler"},
            { 3,"Comment vous appeler vous"}
        };
        public static Dictionary<int, string> FormulesMonNom = new Dictionary<int, string>() {
            { 0,"Je m'appel"},
            { 1,"Mon prénom est"},
            { 2,"Je me nomme"},
            { 3,"Je suis"},
            { 4,"Ont m'appel"},
            { 5,"Je me prénomme"}
        };
        public static Dictionary<int, string> FormulesAurevoir = new Dictionary<int, string>() {
            { 0,"Au revoir et à bientôt"},
            { 1,"Merci de votre visite"},
            { 2,"Ce fut un plaisir d'échanger avec vous"},
            { 3,"Au revoir, j'espère que nous nous recroiserons"},
            { 4,"C'était un enchantement de discuter avec vous"},
            { 5,"Au plaisir"}
        };

        public static Dictionary<int, string> FormulesMerci = new Dictionary<int, string>() {
            { 0,"Je vous en prie"},
            { 1,"Voyons, je suis la pour ça"},
            { 2,"C'est un plaisir de vous être agréable"},
            { 3,"Mais non le plaisir est pour moi"},
            { 4,"De rien"},
            { 5,"Ne soyez pas bête, je suis la pour ça"}
        };
        
        public static Dictionary<int, string> FormulesMemePrenom = new Dictionary<int, string>() {
            { 0,"Je suis joyeux à l'idée que vous ayez le même prénom que moi"},
            { 1,"Comme c'est drôle, nous avons le même prénom"},
            { 2,"Avec le même prénom nous nous ressemblons un peu"},
            { 3,"J'adore l'idée de m'appeler comme vous"},
            { 4,"Quel joli prénom vous avez là"},
            { 5,"Ne soyez pas bête, je suis la pour ça"}
        };
        
        public static Dictionary<int, string> FormulesPrezSalon = new Dictionary<int, string>() {
            { 0,"CGI participe à la Digital Week pour exposer ses savoir faire au travers de cinq stands de démonstration"},
            { 1,"Nous avons des stands pour présenter nos savoir faire sur l'innovation et les tendances des SI"},
            { 2,"Des démonstrations vont vous permettre de découvrir des produits innovants ainsi que des produits incontournables"},
            { 3,"Nous présentons des solutions intégrées aussi bien que de solution propriété de CGI"},
            { 4,"CGI présente des démonstrations de ses produits et de ses savoir faire"},
            { 5,"Mes collègues et moi même présentons des innovations, des produits ainsi que des briques fondamentales pour les systèmes d'information"}
        };
        #endregion


        





        public static string GetRndText(Dictionary<int, string> rsxText)
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int formuleNb = rd.Next(0, rsxText.Count);
            string message = rsxText[formuleNb];
            return message;
        }
    }
}