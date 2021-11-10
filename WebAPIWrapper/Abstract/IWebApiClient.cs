using System.Threading.Tasks;
using Contracts;

namespace WebAPIWrapper.Abstract
{
    public interface IWebApiClient
    {
        public Task<OperationResult> Init(Job job);

        public Task<OperationResult> Confirm(Job job);

        public Task<OperationResult> Reject(Job job);

        public Task<OperationResult> Update(Job job);

        public Task<OperationResult> Add(Job job);

        public Task<OperationResult> Remove(Job job);
    }
}
