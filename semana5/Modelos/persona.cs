using SQLite;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana5.Modelos
{
    [Table("persona")]
    public class persona
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }

        [MaxLength(25), Unique]
        public string name { get; set; }




    }
}
