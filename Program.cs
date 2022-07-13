using Discord;
using Discord.WebSocket;
public class Program
{
    private DiscordSocketClient _client;
    public static Task Main(string[] args) => new Program().MainAsync();
    public async Task MainAsync()
    {
        //load environment variables from appsettings.env
        DotNetEnv.Env.Load("./appsettings.env");
        var token = Environment.GetEnvironmentVariable("Token");

        //Establish socket connection and hook log event to handler
        _client = new DiscordSocketClient();
        _client.Log += Log;

        //Login and start connection logic
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        //Block this task until the program is closed
        await Task.Delay(-1);
        
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
   
}
