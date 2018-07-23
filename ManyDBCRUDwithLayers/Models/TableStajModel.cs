using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManyDBCRUDwithLayers.Models
{
    public class TableStajModel
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string lastname { get; set; }

        public int age { get; set; }

        public int user { get; set; }
    }
}