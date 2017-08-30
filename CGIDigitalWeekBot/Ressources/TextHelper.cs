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
            { 2,"En quoi puis-je vous être utile"},
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
            { 0,"Je suis joyeuse à l'idée que vous ayez le même prénom que moi"},
            { 1,"Comme c'est drôle, nous avons le même prénom"},
            { 2,"Avec le même prénom nous nous ressemblons un peu"},
            { 3,"J'adore l'idée de m'appeler comme vous"},
            { 4,"Quel joli prénom vous avez là"},
            { 5,"Ne soyez pas bête, je suis la pour ça"}
        };
        public static Dictionary<int, string> FormulesDejaVu = new Dictionary<int, string>() {
            { 0,"Nous nous sommes déjà présentés"},
            { 1,"Nous avons déjà fait connaissance"},
            { 2,"Re bonjour"}
        };

        public static Dictionary<int, string> FormulesPrezSalon = new Dictionary<int, string>() {
            { 0,"CGI participe à la Digital Week pour exposer ses savoir faire au travers de cinq stands de démonstration."},
            { 1,"Nous avons des stands pour présenter nos savoir faire sur l'innovation et les tendances des S I."},
            { 2,"Des démonstrations vont vous permettre de découvrir des produits innovants ainsi que des produits incontournables."},
            { 3,"Nous présentons des solutions intégrées aussi bien que de solution propriété de CGI."},
            { 4,"CGI présente des démonstrations de ses produits et de ses savoir faire."},
            { 5,"Mes collègues et moi même présentons des innovations, des produits ainsi que des briques fondamentales pour les systèmes d'information."}
        };


        public static Dictionary<int, string> ListeStands = new Dictionary<int, string>() {
            { 0,"Nous proposons six stands autour de notre solution Maeva, de l'Api managemente, du Block Chaine, des Objets connectés, des Chat Bot et enfin de notre partenariat avec le Village CA."},
            { 1,"Nous disposons de six espaces de démonstration sur les thèmes suivants ; Tchat Bot, Internet des Objets, Api mamangemente, Block Chaine et Maeva plus un espace débié à notre partenariat avec le Village Crédit Agricole."},
            { 2,"Vous pouvez voir des démonstration sur les objets connecté, Maeva, L'api managemente, Le Block Chaine, les Tchat Boat et bien sur notre pratenariat avec le Village Crédit Agricole."},
            { 3,"Six espaces sont à votre disposition pour découvrir notre partanariat avec le village, notre solution maeva, les tchats bots, l'Api Managemente, les Block Chaine et les objets connectés."}
        };


        public static Dictionary<int, string> OrientationIOT = new Dictionary<int, string>() {
            { 0,"Le stand des objects connectés est juste sur votre droite mais les objets sont répartis sur chaque stand."},
            { 1,"La demonstration des objets connectés est en face des escaliers."},
            { 2,"les objets connectés sont sur tous les stands et les informations centralisée à gauche des portes."},
            { 3,"L'espace de démonstration est situé immédiatement sur votre droite."}
        };
        public static Dictionary<int, string> OrientationChatBot = new Dictionary<int, string>() {
            { 0,"Le tchat boat est devant vous. Le stand de présentation est à votre droite."},
            { 1,"Je suis en face de vous. Un détail sur mon fonctionnement est disponible à gauche des portes qui mènent aux autres stands."},
            { 2,"Je suis là. Le stand de détail est en face de l'escaliler."}
        };
        public static Dictionary<int, string> OrientationMaeva = new Dictionary<int, string>() {
            { 0,"La démonstration de maeva se situe dans la salle du fond en face de vous en entrant."},
            { 1,"Le stand Meava est immédiatement après les portes."},
            { 2,"Vous trouverez Maeva dans la partie arrière de cet espace juste après les portes."},
        };
        public static Dictionary<int, string> OrientationAPIMANAGEMENT = new Dictionary<int, string>() {
            { 0,"La démonstration API Managemente est à droite après les doubles portes."},
            { 1,"Le stand API Managemente est situé à droite dans la salle du fond."}
        };
        public static Dictionary<int, string> OrientationVILLAGECA = new Dictionary<int, string>() {
            { 0,"L'espace de communication sur notre partenariat est juste derrière moi."},
            { 1,"Le stand de présentation du partenariat est situé dans mon dos."}
        };
        public static Dictionary<int, string> OrientationBLOCKCHAIN = new Dictionary<int, string>() {
            { 0,"Le stand Block Chain se trouve tout au fond à gauche de l'espace après les portes."},
            { 1,"L'activité Block Chain est placé après les portes au fond à gauche de la salle."}
        };

        public static Dictionary<int, string> OrientationWC = new Dictionary<int, string>() {
            { 0,"Les comodités sont au rez de chaussée."},
            { 1,"Les toilettes sont en bas."}
        };


        public static Dictionary<int, string> ContenuIOT = new Dictionary<int, string>() {
            { 0,"L'internet des objets est un concept de mise en oeuvre autour d'objets qui communiquent avec des système centraux."},
            { 1,"todo contenu iot 2"},
            { 2,"todo contenu iot 3"}
        };
        public static Dictionary<int, string> ContenuCHATBOT = new Dictionary<int, string>() {
            { 0,"Je suis un assistant conversationnel basé sur la reconnaisance du langage naturel couplé à des fonctionnalités d'intelligence artificielles."},
            { 1,"Un tchat boat est un service de conversation intelligent et autonomme."},
            { 2,"Un tchat boat est un robot logiciel pouvant dialoguer avec un individu ou consommateur par le biais d’un service de conversations automatisées effectuées en grande partie en langage naturel"}
        };
        public static Dictionary<int, string> ContenuAPIMANAGEMENT = new Dictionary<int, string>() {
            { 0,"L'API Management est le processus qui consiste à publier, promouvoir et superviser les interfaces de programmation d'applications au sein d'un environnement sécurisé et évolutif."},
            { 1,"L'API Management aide les organisations à publier des API pour des développeurs externes, partenaires et internes, afin de libérer le potentiel de leurs données et services."},
            { 2,"L'API Management c’est un proxy entre votre API et le reste du monde. Cela vous permet de gérer la sécurité, le rate limiting, la facturation de l’API, avoir des stats d’usage et des alertes en cas d’erreurs."}
        };
        public static Dictionary<int, string> ContenuBLOCKCHAIN = new Dictionary<int, string>() {
            { 0,"La Block Chaine est une base de données distribuée transparente, sécurisée, et fonctionnant sans organe central de contrôle."},
            { 1,"La block chaine est une technologie de stockage et de transmission d’informations, transparente, sécurisée, et fonctionnant sans organe central de contrôle"},
            { 2,"La block chaine est souvent comparée à internet. Internet transfère des paquets de données d’un point A à un point B, alors que la blockchain permet à la « confiance » de s’établir entre des parties distinctes du système"}
        };
        public static Dictionary<int, string> ContenuMAEVA = new Dictionary<int, string>() {
            { 0,"Maeva est une solution logicielle CGI qui permet de dématérialiser les procédures de maintenance et d'assister les intervenants à distance."},
            { 1,"Maeva est une solution collaborative à distance permettant au sein d’un même écran de partager des documents, du son et de la vidéo."},
            { 2,"Maeva permet de bénéficiez en un clic de l'assistance d'un expert et de trouver une réponse a vos problème sans attendre."},
            { 3,"Maeva est une solution permettant l’assistance d’un expert à distance. Son point fort réside dans sa capacité à faire interagir plusieurs acteurs ensemble. "}
        };
        public static Dictionary<int, string> ContenuVILLAGECA = new Dictionary<int, string>() {
            { 0,"CGI et le crédit agricole travaillent ensemble pour aider les jeunes entrepeneurs à démarrer leur activité."},
            { 1,"CGI collabore avec le crédit agricole dans une pouponnière à start up."},
            { 2,"Le crédit agricole et CGI se sont associés pour promouvoir des entreprises locales"}
        };
        public static Dictionary<int, string> ContenuWC = new Dictionary<int, string>() {
            { 0,"C'est un lieu qui permet aux humains de satisfaire certains de leurs besoins physilogiques. J'en suis par chance épargné."}
        };


        public static Dictionary<int, string> FormulesPrezBot = new Dictionary<int, string>() {
            { 0,"Je suis là pour vous orienter dans votre visite."},
            { 1,"Je suis là pour vous guider dans votre parcours."},
            { 2,"Mon objectif est de répondre à vos questions sur le contenu de cet espace"},
            { 3,"Je peux vous guider ou vous orienter."},
            { 4,"J'ai pour objectif de vous aider à naviguer dans cet espace."},
            { 5,"Je peux vous informer et vous guider."}
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