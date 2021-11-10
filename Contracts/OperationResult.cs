using Contracts.Entities;

namespace Contracts
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public Status Status { get; set; }

        public string Message { get; set; }
    }
}
