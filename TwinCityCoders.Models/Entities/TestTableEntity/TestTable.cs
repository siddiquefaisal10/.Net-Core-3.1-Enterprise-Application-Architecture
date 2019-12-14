using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwinCityCoders.Models.Entities.TestTableEntity
{
    [Table("TestTable")]
    public class TestTable
    {
        public string UserName { get; set; }
        [Key]
        public int ID { get; set; }
    }
}