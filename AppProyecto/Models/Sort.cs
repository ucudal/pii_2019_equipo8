using System;
using System.Collections.Generic;

namespace AppProyecto.Models
{
    public interface ISort
    {
        List<Worker> SortWorker(List<Worker> Workerlist);
    }
}