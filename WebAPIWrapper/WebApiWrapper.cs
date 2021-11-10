using System.Threading.Tasks;
using Contracts;
using WebAPIMock;
using WebAPIWrapper.Abstract;

namespace WebAPIWrapper
{
    public class WebApiWrapper : IWebApiClient

    {
    private static JobController jobsAPIClient = new JobController();

    public async Task<OperationResult> Init(Job job)
    {
        return await jobsAPIClient.Init(job).ConfigureAwait(false);
    }

    public async Task<OperationResult> Confirm(Job job)
    {
        return await jobsAPIClient.Confirm(job).ConfigureAwait(false);
    }

    public async Task<OperationResult> Reject(Job job)
    {
        return await jobsAPIClient.Reject(job).ConfigureAwait(false);
    }

    public async Task<OperationResult> Update(Job job)
    {
        return await jobsAPIClient.Update(job).ConfigureAwait(false);
    }

    public async Task<OperationResult> Add(Job job)
    {
        return await jobsAPIClient.Add(job).ConfigureAwait(false);
    }

    public async Task<OperationResult> Remove(Job job)
    {
        return await jobsAPIClient.Remove(job).ConfigureAwait(false);
    }
    }
}
