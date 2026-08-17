namespace FundooNotes.Model.DTOs.Response
{
    // Generic response wrapper sent back to client
    public class ResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}