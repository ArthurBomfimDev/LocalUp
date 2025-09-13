namespace LocalUp.Application.DTOs
{
    public class BulkOperationResult
    {
        public List<long> CreatedIds { get; set; } = new List<long>();
        public List<BulkOperationError> Errors { get; set; } = new List<BulkOperationError>();
        public bool Success => Errors.Count == 0;
    }
}
