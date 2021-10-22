using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace HiddenVilla_Server.Helpers
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToasterSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToasterError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async ValueTask SweetAlertError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowSweetAlert", "error", message);
        }
        public static async ValueTask SweetAlertSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowSweetAlert", "success", message);
        }
    }
}
