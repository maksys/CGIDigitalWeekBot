﻿using System;
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
    public class PresentationDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            // Root dialog initiates and waits for the next message from the user. 
            // When a message arrives, call MessageReceivedAsync.
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result; // We've got a message!
            if (message.Text.ToLower().Contains("order"))
            {
                // User said 'order', so invoke the New Order Dialog and wait for it to finish.
                // Then, call ResumeAfterNewOrderDialog.
                //await context.Forward(new NewOrderDialog(), this.ResumeAfterNewOrderDialog, message, CancellationToken.None);
            }
            // User typed something else; for simplicity, ignore this input and wait for the next message.
            context.Wait(this.MessageReceivedAsync);
        }


        private async Task ResumeAfterNewOrderDialog(IDialogContext context, IAwaitable<string> result)
        {
            // Store the value that NewOrderDialog returned. 
            // (At this point, new order dialog has finished and returned some value to use within the root dialog.)
            var resultFromNewOrder = await result;

            await context.PostAsync($"New order dialog just told me this: {resultFromNewOrder}");

            // Again, wait for the next message from the user.
            context.Wait(this.MessageReceivedAsync);
        }

    }
}

