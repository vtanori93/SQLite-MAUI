using System.Resources;
namespace Test.Language
{
    #region TranslateExtension
    public class TranslateExtension : IMarkupExtension
    {
        #region Variables
        public string Text { get; set; } = string.Empty;
        #endregion
        #region ProvideValue
        public object ProvideValue(IServiceProvider ServiceProvider)
        {
            string Value = "";
            if (Text == null)
                return "";
            ResourceManager ResourceManager = new ResourceManager("Test.Language.AppResources", typeof(TranslateExtension).Assembly);
            var Translation = ResourceManager.GetString(Text);
            if (!string.IsNullOrEmpty(Translation))
            {
                Value = Translation;
            }
            return Value;
        }
        #endregion
    }
    #endregion
}
