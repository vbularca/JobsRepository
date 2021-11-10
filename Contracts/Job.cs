using System;
using Contracts.Entities;

namespace Contracts
{
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public TaskType Type { get; set; } = TaskType.Undefined;

        public bool IsProcessed { get; set; }

        public string Reason { get; set; }
    }
}
