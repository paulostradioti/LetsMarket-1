using LetsMarket.Views.ViewInterface;
using Sharprompt;

namespace LetsMarket.Views
{
    public class LoginView : ILoginView
    {
        public string GetLogin()
        {
            return Prompt.Input<string>("Login");
        }

        public string GetPassword()
        {
            return Prompt.Password("Senha");
        }

        public void ShowError(string error)
        {
            Console.WriteLine(error);
            Console.ReadKey();
        }
    }
}
