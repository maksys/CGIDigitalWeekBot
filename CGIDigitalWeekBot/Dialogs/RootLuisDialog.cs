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

namespace CGIDigitalWeekBot
{
    [Serializable]
    [LuisModel("bb5d41fe-72cc-4eca-a831-c6589cf7ffcc", "510379c0ade04cf68ce0fa435024a7e0")]
    public class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Je n'ai pas compris ce que vous voulez dire par '{result.Query}'. Demandez moi de l'aide ou appelez un de mes collègue à votre rescousse.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }


        [LuisIntent("Presentation")]
        public async Task Presentation(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            await context.PostAsync("Bonjour Je m'appel CGO BOT je sais faire plein de choses'");

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Orientation")]
        public async Task Orientation(IDialogContext context, LuisResult result)
        {
            string message = $"Le '{result.Query}' est passé par ici, il repassera par là.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Contenu")]
        public async Task Contenu(IDialogContext context, LuisResult result)
        {
            string message = $"CGI et le crédit Agricole travaillent ensemble.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
        [LuisIntent("restauration")]
        public async Task Restauration(IDialogContext context, LuisResult result)
        {
            string message = $"CGI n'offre pas de service de restauration. Vous pouvez trouver des casse croute à l'entrée.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
    }
}