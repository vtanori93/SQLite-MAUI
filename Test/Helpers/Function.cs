namespace Test.Helpers
{
    public class Function
    {
        public static async Task ShowMessageAsync(string Message)
        {
            await Shell.Current.DisplayAlert("Alerta", Message, "Aceptar");
        }
    }
}
