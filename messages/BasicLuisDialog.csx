using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("explain")]
    public async Task ExplainIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I can Explain this: Booking acceptance rate card uses TM on-line data as its source, It is the Number of Bookings sent and accepted by the carrier last month/ Total number of bookings sent to carrier last month  * 100"); //
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("greetings")]
    public async Task GreetingsIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hello, Welcome! I'm the Transport Management Chatbot, how can I help you?"); //
        context.Wait(MessageReceived);
    }

	[LuisIntent("givedocumentation")]
	public async Task givedocumentationIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"this is the link to the documentation"); //
        context.Wait(MessageReceived);
    }
    
}

