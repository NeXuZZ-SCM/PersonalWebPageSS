using Microsoft.JSInterop;

namespace PWPCli.Shared
{
    public class ScrollInfoService : IScrollInfoService
    {
        public event EventHandler<int?> OnScroll;

        public ScrollInfoService(IJSRuntime jsRuntime)
        {
            RegisterServiceViaJsRuntime(jsRuntime);
        }

        private void RegisterServiceViaJsRuntime(IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeVoidAsync("RegisterScrollInfoService", DotNetObjectReference.Create(this));
        }

        public int? YValue { get; private set; }

        [JSInvokable("OnScroll")]
        public void JsOnScroll(int? yValue)
        {
            if (yValue.HasValue)
            {
                YValue = yValue;
                //Console.WriteLine("ScrollInfoService.OnScroll " + yValue);
                OnScroll?.Invoke(this, yValue);
            }
        }
    }

    public interface IScrollInfoService
    {
        event EventHandler<int?> OnScroll;
        int? YValue { get; }
    }
 
}
