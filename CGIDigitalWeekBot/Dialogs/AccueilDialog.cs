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
    public class AccueilDialog : IDialog<object>
    {
        private Dictionary<int, string> FormulesEnchante = new Dictionary<int, string>() {
            { 0,"Enchanté de vous connaitre"},
            { 1,"Ravi de vous rencontrer"},
            { 2,"Je suis enchanté"},
            { 3,"Content de vous connaitre"},
            { 4,"Heureux de faire votre connaissance"},
            { 5,"Enchanté de faire votre connaissance"},
            { 6,"Ravi de vous connaitre"}
        };
        private Dictionary<int, string> FormulesTonNom = new Dictionary<int, string>() {
            { 0,"Quel est votre prénom"},
            { 1,"Comment vous nommez vous"},
            { 2,"Comment dois-je vous appeler"},
            { 3,"Comment vous appeler vous"}
        };
        private Dictionary<int, string> FormulesMonNom = new Dictionary<int, string>() {
            { 0,"Je m'appel"},
            { 1,"Mon prénom est"},
            { 2,"Je me nomme"},
            { 3,"Je suis"},
            { 4,"Ont m'appel"},
            { 5,"Je me prénomme"}
        };


        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            Random rd = new Random(DateTime.Now.Millisecond);
            int tonNomValue = rd.Next(0, FormulesTonNom.Count);
            int monNomValue = rd.Next(0, FormulesMonNom.Count);
            PromptDialog.Text(context, ResumeAfterAccueilDialog, $"{message.Text}. {FormulesMonNom[monNomValue]} {RootLuisDialog.BotName}. {FormulesTonNom[tonNomValue]} ?");
            
            context.Wait(this.MessageReceivedAsync);
        }


        private async Task ResumeAfterAccueilDialog(IDialogContext context, IAwaitable<string> result)
        {
            var resultFromAccueil = await result;

            //await context.PostAsync($"New order dialog just told me this: {resultFromNewOrder}");

            Random rd = new Random(DateTime.Now.Millisecond);
            int formuleValue = rd.Next(0, FormulesEnchante.Count);
            string message = $"{FormulesEnchante[formuleValue]} {resultFromAccueil}.";
            //context.Wait(this.MessageReceivedAsync);
            context.Done(message);
        }

    }
}

