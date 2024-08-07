using Microsoft.Extensions.Logging;
#region EntryHandler
#if ANDROID
using Android.Content.Res;
using Microsoft.Maui.Platform;
#endif
#if IOS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endif
#endregion
namespace Test
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSans-Regular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSans-Semibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            #region EntryHandler

#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(MauiProgram), (h, v, d) =>
        {
            h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.ModifyMapping(nameof(MauiProgram), (h, v, d) =>
        {
            h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
        });
#endif
#if IOS
            Microsoft.Maui.Handlers.EntryHandler.Mapper.ModifyMapping(nameof(MauiProgram), (handler, view, property) =>
            {
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
            });
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.ModifyMapping(nameof(MauiProgram), (handler, view, property) =>
            {
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
            });
#endif
            #endregion

            return builder.Build();
        }
    }
}
