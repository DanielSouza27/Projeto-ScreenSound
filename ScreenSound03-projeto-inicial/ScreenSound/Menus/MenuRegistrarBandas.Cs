using OpenAI_API;
using ScreenSound.Modelos;


namespace ScreenSound.Menus;

internal class MenuRegistrarBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        var client = new OpenAIAPI("sk-proj-u8SbwGfuIKlsiSfS2jkhT3BlbkFJPIhCff6GhrGPQITJOKbi");

        var chat = client.Chat.CreateConversation();

        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em um paragrafo. Adote um estilo informal");

        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.resumo = resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}