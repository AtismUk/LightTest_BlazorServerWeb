namespace LightTest_BlazorServerWeb.Models
{
    public class ResponseService<T>
    {
        public bool isValid { get; set; } = false;
        public T? Value { get; set; }
        public string? Message { get; set; }
    }
}
