using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading;

namespace CGIDigitalWeekBot
{


    [Serializable]
    [LuisModel("bb5d41fe-72cc-4eca-a831-c6589cf7ffcc", "510379c0ade04cf68ce0fa435024a7e0")]
    public class RootLuisDialog : LuisDialog<object>
    {
        //Défintion des entités LUIS
        private const string Entity_IOT_Type = "stand::iot";
        private const string Entity_BC_Type = "stand::block chain";
        private const string Entity_Meava_Type = "stand::maeva";
        private const string Entity_Partner_Type = "stand::partenariat";
        private const string Entity_APIM_Type = "stand::api management";
        private const string Entity_CB_Type = "stand::chat bot";
        private const string Entity_WC_Type = "Toilettes";
        private const string Entity_CGI_Type = "cgi";

        //constante prenom du bot
        public const string BotName = "Natacha";

        //variable pour le stockage des métadonnées emotion + direction
        //public string Metadatas = string.Empty;

        //Variable pour le stockge de contexte entre les différentes questions
        EntityRecommendation ContextEntity;

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Je n'ai pas compris ce que vous voulez dire. Demandez moi de l'aide ou appelez un de mes collègue à votre rescousse.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        #region Accueil du visiteur
        [LuisIntent("Accueil")]
        public async Task Accueil(IDialogContext context, LuisResult result)
        {
            var message = result;
            TextHelper.SetMetadatas("", "accueill heureux");
            //await context.Forward(new PresentationDialog(), this.ResumeAfterPresentationDialog, message, CancellationToken.None);
            await context.PostAsync(TextHelper.GetRndText(TextHelper.FormulesMonNom) + " " + BotName + ". " + TextHelper.GetRndText(TextHelper.FormulesQuefaire) + "?");

            context.Wait(this.MessageReceived);
        }
        //private async Task ResumeAfterAccueilDialog(IDialogContext context, IAwaitable<object> result)
        //{
        //    var resultFromAccueil = await result;
        //    UserName = resultFromAccueil.ToString();
        //    string message = $"{TextHelper.GetRndText(TextHelper.FormulesEnchante)} {resultFromAccueil}.";
        //    await context.PostAsync($"{message}");
        //    if (UserName.Contains(BotName))
        //    {
        //        Thread.Sleep(2000); //timer entre les deux réponses du bot
        //        await context.PostAsync($"{TextHelper.GetRndText(TextHelper.FormulesMemePrenom)}.");
        //    }
        //    Thread.Sleep(2000); //timer entre les deux réponses du bot
        //    await context.PostAsync($"{TextHelper.GetRndText(TextHelper.FormulesQuefaire)} ?");
        //    context.Wait(this.MessageReceived);
        //}
        #endregion
        //Présentation du salon
        [LuisIntent("Presentation")]
        public async Task Presentation(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var message = result;
            //await context.Forward(new PresentationDialog(), this.ResumeAfterPresentationDialog, message, CancellationToken.None);
            await context.PostAsync(TextHelper.GetRndText(TextHelper.FormulesPrezSalon));

            context.Wait(this.MessageReceived);
        }
        //Présentation des stand
        [LuisIntent("stand")]
        public async Task Stand(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var message = result;
            await context.PostAsync(TextHelper.GetRndText(TextHelper.ListeStands));

            context.Wait(this.MessageReceived);
        }

        //Présentation du bot
        [LuisIntent("bot")]
        public async Task Bot(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var message = result;
            await context.PostAsync(TextHelper.GetRndText(TextHelper.FormulesPrezBot));

            context.Wait(this.MessageReceived);
        }
        //Orientation vers les stands
        [LuisIntent("Orientation")]
        public async Task Orientation(IDialogContext context, LuisResult result)
        {
            EntityRecommendation entityreco;
            string message = "";
                      
            
            //verifie qu'il n'y a pas de d'entité (contexte dans le result et qu'il y a un contexte stocké en global pour propager le contexte entre ou et quoi
            
            if (result.TryFindEntity(Entity_IOT_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationIOT);
            }
            else if (result.TryFindEntity(Entity_CB_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationChatBot);
            }
            else if (result.TryFindEntity(Entity_APIM_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationAPIMANAGEMENT);
            }
            else if (result.TryFindEntity(Entity_BC_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationBLOCKCHAIN);
            }
            else if (result.TryFindEntity(Entity_Meava_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationMaeva);
            }
            else if (result.TryFindEntity(Entity_Partner_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationVILLAGECA);
            }
            else if (result.TryFindEntity(Entity_WC_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.OrientationWC);
            }
            else
            {
                message = TextHelper.GetRndText(TextHelper.OrientationInconnue); 
            }
            if (entityreco != null) ContextEntity = entityreco;
            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
        //TODO :: remplacer le switch / intégrer un dico texthelper
        [LuisIntent("Contenu")]
        public async Task Contenu(IDialogContext context, LuisResult result)
        {
            string message = "";
            var res = result;
            EntityRecommendation entityreco;
            //verifie qu'il n'y a pas de d'entité (contexte dans le result et qu'il y a un contexte stocké en global pour propager le contexte entre ou et quoi
            //if (res.Entities.Count < 1 && ContextEntity != null) res.Entities.Add(ContextEntity);
            if (res.TryFindEntity(Entity_IOT_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuIOT);
            }
            else if (result.TryFindEntity(Entity_CB_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuCHATBOT);
            }
            else if (result.TryFindEntity(Entity_APIM_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuAPIMANAGEMENT);
            }
            else if (result.TryFindEntity(Entity_BC_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuBLOCKCHAIN);
            }
            else if (result.TryFindEntity(Entity_Meava_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuMAEVA);
            }
            else if (result.TryFindEntity(Entity_Partner_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuVILLAGECA);
            }
            else if (result.TryFindEntity(Entity_WC_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuWC);
            }
            else
            {
                message = $"Je suis navré mais je ne peux pas donner de détails sur ce sujet. N'hésitez pas à questionner un de mes collègues.";
            }
            //else
            //{
            //    message = $"Je ne connais pas encore '{result.Query}'. N'hésitez pas à demander à un de mes collègues.";
            //}
            if (entityreco != null) ContextEntity = entityreco;
            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("restauration")]
        public async Task Restauration(IDialogContext context, LuisResult result)
        {
            string message = $"CGI n'offre pas de service de restauration. Il y a un restaurant à votre disposition au rez de chaussée.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("digitalweek")]
        public async Task DigitalWeek(IDialogContext context, LuisResult result)
        {
            string message = $"Porté par Nantes Métropole et produit par la Cité des Congrès de Nantes, Nantes Digital Week vous invite à partager des moments de rencontres, d’expérimentation, de formation, de création, de réflexion sur les enjeux liés au numérique.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
        [LuisIntent("concurrence")]
        public async Task Concurrence(IDialogContext context, LuisResult result)
        {
            string message = "";
            EntityRecommendation entityreco;

            if (result.TryFindEntity(Entity_IOT_Type, out entityreco))
            {
                message = TextHelper.GetRndText(TextHelper.ContenuIOT);
            }

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
        //TODO proposer une note
        [LuisIntent("Fin")]
        public async Task Fin(IDialogContext context, LuisResult result)
        {
            string message = $"{TextHelper.GetRndText(TextHelper.FormulesAurevoir)}.";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);

        }
        //TODO proposer une note
        [LuisIntent("collegue")]
        public async Task Collegue(IDialogContext context, LuisResult result)
        {
            string message = $"{TextHelper.GetRndText(TextHelper.FormulesCollegue)}.";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);

        }

        [LuisIntent("Patron")]
        public async Task Patron(IDialogContext context, LuisResult result)
        {
            string message = "";
            EntityRecommendation entityreco;
            if (result.TryFindEntity("famille", out entityreco))
            {
                var v = entityreco.Resolution.Values.Last().ToString();
                if (v.Contains("maman"))
                {
                    message = "Je n'ai pas de maman, j'ai été créé à partir du vide par mon père.";
                }
                if (v.Contains("papa"))
                {
                    if (entityreco.Entity == "patron")
                    {
                        message = "Je travail pour CGI. Mon grand patron est Serge Godin.";
                    }
                    else
                    {
                        message = "Mon créateur est Frédéric Macaigne, Il travail pour CGI.";
                    }

                }
                if (v.Contains("CGI"))
                {
                    message = "CGI est la cinquième plus importante entreprise indépendante de services en technologies de l'information et en gestion des processus d'affaires au monde.";
                }
            }
            else
            {
                message = "Je travail pour CGI. Mon grand patron est Serge Godin.";
            }
            await context.PostAsync(message);
        }
        

        private async Task ResumeAfterPresentationDialog(IDialogContext context, IAwaitable<string> result)
        {
            var resultFromPresentation = await result;
            await context.PostAsync($"New order dialog just told me this: {resultFromPresentation}");
            //context.Wait(this.MessageReceived);
        }
    }


}