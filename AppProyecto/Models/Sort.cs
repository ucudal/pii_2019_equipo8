using System;
using System.Collections.Generic;

//Aquí aplicamos el principio OCP ya que Sort es nuestra clase abierta a la extensión 
//(podemos agregarle otros tipos de orden u otros objetos a ordenar) y los subtipos de Sort 
//cómo SortByRole o SortByRanking son nuestras clases cerradas a la modificación (si queremos 
//agregar un nueva forma de ordenar creamos otro subtipo de Sort; no modificamos las clases
//SortByRole o SortByRanking).
namespace AppProyecto.Models
{
    public interface ISort
    {
        List<Worker> SortWorker(List<Worker> Workerlist);
    }
}