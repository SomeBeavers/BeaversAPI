namespace OpenAILib;

public class Class1
{
    public async Task ConnectToOpenAI()
    {
        var api = new OpenAIAPI(new APIAuthentication("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"));
        var result = await api.Completions.CreateCompletionAsync("I would like to ", Model.DefaultModel);
        Console.WriteLine(result.Completions[0].Text.Trim());
    }
}