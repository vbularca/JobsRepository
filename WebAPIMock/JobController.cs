using System.Threading.Tasks;
using Contracts;
using WebAPIMock.DataProcessing;
using WebAPIMock.Entities;

namespace WebAPIMock
{
    public class JobController
    {
        private static readonly JobProcessor JobProcessor = new JobProcessor();

        public async Task<OperationResult> Init(Job job)
        {
            return await JobProcessor.Process(job, ProcessingType.Init).ConfigureAwait(false);
        }

        public async Task<OperationResult> Confirm(Job job)
        {
            return await JobProcessor.Process(job, ProcessingType.Confirm).ConfigureAwait(false);
        }

        public async Task<OperationResult> Reject(Job job)
        {
            return await JobProcessor.Process(job, ProcessingType.Reject).ConfigureAwait(false);
        }

        public async Task<OperationResult> Update(Job job)
        {
            return await JobProcessor.Process(job, ProcessingType.Update).ConfigureAwait(false);
        }

        public async Task<OperationResult> Add(Job job)
        {
            return await JobProcessor.Process(job, ProcessingType.Add).ConfigureAwait(false);
        }

        public async Task<OperationResult> Remove(Job job)
        {
            return await JobProcessor.Process(job, ProcessingType.Remove).ConfigureAwait(false);
        }
    }
}
