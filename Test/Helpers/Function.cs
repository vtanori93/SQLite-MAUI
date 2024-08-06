namespace Test.Helpers
{
    public class Function
    {
        public static async Task ShowMessageAsync(string Message)
        {
            await Shell.Current.DisplayAlert("Alerta", Message, "Aceptar");
        }
        public static async Task<bool> QuestionAsync(string Message)
        {
            return await Task.FromResult(await Shell.Current.DisplayAlert("Alerta", Message,"Aceptar","Cancelar"));
        }
    }
}
