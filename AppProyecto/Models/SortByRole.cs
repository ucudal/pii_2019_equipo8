using System;
using System.Collections.Generic;

namespace AppProyecto.Models
{
    public class SortByRole : ISort
    {
        public Role role;
        public List<Worker> SortWorker (List<Worker> Workerlist)
        {
            List<Worker> result = new List<Worker>();
            foreach (Worker worker in Workerlist)
            {
                if (worker.Rolelist.Contains(this.role))
                {
                    result.Add(worker);
                }
            }
            return result;
        }
    }
}