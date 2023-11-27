namespace OpenAILib;

public class Class1
{
    public async Task ConnectToOpenAI()
    {
        var api = new OpenAIAPI(new APIAuthentication(""));
        var result = await api.Completions.CreateCompletionAsync("I would like to ", Model.DefaultModel);
        Console.WriteLine(result.Completions[0].Text.Trim());
    }
}