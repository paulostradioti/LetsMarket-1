namespace LetsMarket.Views.ViewInterface
{
    public interface ILoginView
    {
        public string GetLogin();
        public string GetPassword();
        public void ShowError(string error);
    }
}
