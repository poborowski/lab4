using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication3.Models
{
    public class BooksModel
    {

  

            public int Id { get; set; }

            public string Title { get; set; }

            [DataType(DataType.Date)] //we need Date only

            public DateTime ReleaseDate { get; set; }

            public string Category { get; set; }

            public decimal Price { get; set; }

        

    
}
}


