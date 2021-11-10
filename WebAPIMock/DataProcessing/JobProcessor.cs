using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Contracts.Entities;
using WebAPIMock.Entities;

namespace WebAPIMock.DataProcessing
{
    internal class JobProcessor
    {
        private static readonly Random Random = new Random();
        private static int _delaystep = 250;

        internal async Task<OperationResult> Process(Job jobToProcess, ProcessingType processingType)
        {
            return await Task.Run(() =>
            {
                var randomResultSet = Random.Next(0, 3);
                Thread.Sleep(_delaystep * randomResultSet);
                return InternalProcess(Random.Next(0, 3), jobToProcess, processingType);
            });
        }

        private OperationResult InternalProcess(int resultSetId, Job jobToProcess, ProcessingType processingType)
        {
            switch (processingType)
            {
                case ProcessingType.Init:
                    return InternalInit(resultSetId, jobToProcess);
                case ProcessingType.Add:
                    return InternalAdd(resultSetId, jobToProcess);
                case ProcessingType.Confirm:
                    return InternalConfirm(resultSetId, jobToProcess);
                case ProcessingType.Reject:
                    return InternalReject(resultSetId, jobToProcess);
                case ProcessingType.Remove:
                    return InternalRemove(resultSetId, jobToProcess);
                case ProcessingType.Update:
                    return InternalUpdate(resultSetId, jobToProcess);
            }

            return new OperationResult
                {Message = "Operation not supported", Status = Status.Undefined, Success = false};
        }

        #region Real processing done here
        private OperationResult InternalInit(int resultSetId, Job jobToProcess)
        {
            switch (resultSetId)
            {
                case 0:
                    return new OperationResult() { Success = true, Status = Status.Initialized, Message = $"intialized job: {jobToProcess.Id}" };
                case 1:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = "failed to initialize" };
                case 2:
                    return new OperationResult() { Success = true, Status = Status.Initialized, Message = $"intialized job: {jobToProcess.Id}" };
                case 3:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = $"won't work : {jobToProcess.Id}" };
            }
            return new OperationResult
                { Message = "Cannot intiialize job processing", Status = Status.Undefined, Success = false };
        }

        private OperationResult InternalAdd(int resultSetId, Job jobToProcess)
        {
            switch (resultSetId)
            {
                case 0:
                    return new OperationResult() { Success = true, Status = Status.Added, Message = $"added job: {jobToProcess.Id}" };
                case 1:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = "failed to add" };
                case 2:
                    return new OperationResult() { Success = true, Status = Status.Added, Message = $"job was added: {jobToProcess.Id}" };
                case 3:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = $"won't work : {jobToProcess.Id}" };
            }
            return new OperationResult
                { Message = "Cannot add job processing", Status = Status.Undefined, Success = false };
        }

        private OperationResult InternalConfirm(int resultSetId, Job jobToProcess)
        {
            switch (resultSetId)
            {
                case 0:
                    return new OperationResult() { Success = true, Status = Status.Confirmed, Message = $"confirmed job: {jobToProcess.Id}" };
                case 1:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = "failed to confirm" };
                case 2:
                    return new OperationResult() { Success = true, Status = Status.Confirmed, Message = $"job is confirmed: {jobToProcess.Id}" };
                case 3:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = $"won't work : {jobToProcess.Id}" };
            }
            return new OperationResult
                { Message = "Cannot confrim job processing", Status = Status.Undefined, Success = false };
        }

        private OperationResult InternalReject(int resultSetId, Job jobToProcess)
        {
            switch (resultSetId)
            {
                case 0:
                    return new OperationResult() { Success = true, Status = Status.Rejected, Message = $"rejected job: {jobToProcess.Id}" };
                case 1:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = "failed to reject" };
                case 2:
                    return new OperationResult() { Success = true, Status = Status.Rejected, Message = $"job rejected: {jobToProcess.Id}" };
                case 3:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = $"won't work : {jobToProcess.Id}" };
            }
            return new OperationResult
                { Message = "Cannot reject job", Status = Status.Undefined, Success = false };
        }

        private OperationResult InternalRemove(int resultSetId, Job jobToProcess)
        {
            switch (resultSetId)
            {
                case 0:
                    return new OperationResult() { Success = true, Status = Status.Removed, Message = $"removed job: {jobToProcess.Id}" };
                case 1:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = "failed to remove" };
                case 2:
                    return new OperationResult() { Success = true, Status = Status.Removed, Message = $"job removed: {jobToProcess.Id}" };
                case 3:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = $"won't work : {jobToProcess.Id}" };
            }
            return new OperationResult
                { Message = "Cannot remove job", Status = Status.Undefined, Success = false };
        }

        private OperationResult InternalUpdate(int resultSetId, Job jobToProcess)
        {
            switch (resultSetId)
            {
                case 0:
                    return new OperationResult() { Success = true, Status = Status.Updated, Message = $"update job: {jobToProcess.Id}" };
                case 1:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = "failed to update" };
                case 2:
                    return new OperationResult() { Success = true, Status = Status.Updated, Message = $"job updated: {jobToProcess.Id}" };
                case 3:
                    return new OperationResult() { Success = false, Status = Status.Undefined, Message = $"won't work : {jobToProcess.Id}" };
            }
            return new OperationResult
                { Message = "Cannot update job processing", Status = Status.Undefined, Success = false };
        }

        #endregion
    }
}
