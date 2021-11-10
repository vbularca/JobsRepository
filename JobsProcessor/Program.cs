using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Contracts.Entities;
using WebAPIWrapper;
using WebAPIWrapper.Abstract;

namespace JobsProcessor
{
    class Program
    {

        private static int NumberOfJobs = 1000;

        private static readonly IWebApiClient WebApiClient = new WebApiWrapper();
        private static readonly Object LockObject = new object();

        static async Task Main(string[] args)
        {
            var jobsToProcess = GetJobs(NumberOfJobs).ToList();
            var watch = new Stopwatch();

            //RUN OPTION ONE
            watch.Start();
            var tasksOne = new ConcurrentBag<Task<OperationResult>>();
            Parallel.ForEach(jobsToProcess, async (job) =>
            {
                var currentTask = WebApiClient.Confirm(job);
                tasksOne.Add(currentTask);
                var result = await currentTask.ConfigureAwait(false);
                PrintResult(result, job);
            });
            await Task.WhenAll(tasksOne);
            watch.Stop();
            
            var msSpentWithOne = watch.ElapsedMilliseconds;
            watch.Reset();


            //RUN OPTION TWO
            watch.Start();
            //var tasksTwo = new ConcurrentDictionary<Task<OperationResult>, Job>();

            //foreach (var jb in jobsToProcess)
            //{
            //    tasksTwo.TryAdd(WebApiClient.Confirm(jb), jb);
            //}

            //while (tasksTwo.Count > 0)
            //{
            //    var completedTask = await Task.WhenAny(tasksTwo.Keys);
            //    tasksTwo.TryRemove(completedTask, out var job);
            //    PrintResult(completedTask.Result, job);
            //}
            //await Task.WhenAll(tasksTwo.Keys);
            watch.Stop();

            Console.WriteLine($"milliseconds spent with one : {msSpentWithOne}");
            Console.WriteLine($"milliseconds spent with two : {watch.ElapsedMilliseconds}");
            Console.ReadKey();
        }

        private static void PrintResult(OperationResult result, Job job)
        {
            lock (LockObject)
            {
                Console.ForegroundColor = result.Success ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
                Console.WriteLine(
                    $"Job Id {job.Id}. Result is {result.Success} , status is {result.Status}, message {result.Message}");
                Console.ResetColor();
            }
        }


        private static IEnumerable<Job> GetJobs(int noOfJobs)
        {
            var jobList = new List<Job>();
            for (var i = 0; i < noOfJobs; i++)
            {
                jobList.Add(
                    new Job
                    {
                        Date = DateTime.Now.AddDays(-i),
                        Id = i,
                        IsProcessed = false,
                        Name = $"job name {i}",
                        Reason = $"just some work",
                        Type = (TaskType)(i % 3)
                    }
                );
            }

            return jobList;
        }
    }
}
