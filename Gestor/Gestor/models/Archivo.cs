using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor.models
{
    public class Archivo
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeFile { get; set; }
        public int Father { get; set; }

        public override string ToString()
        {
            string info = "Id: " + Id + "\nName: " + Name + "\nTipo de Archivo: " + TypeFile + "\nPadre: " + Father+"\n";
            return info;
        }
    }
}
