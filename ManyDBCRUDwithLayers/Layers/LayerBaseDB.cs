using ManyDBCRUDwithLayers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManyDBCRUDwithLayers.Layers
{
    public abstract class LayerBaseDB
    {

        public abstract DataTable FindAll();


        public abstract TableStajModel FindOne(int id);


        public abstract int Create(TableStajModel tableStaj);


        public abstract int Edit(int id, TableStajModel tableStajModel);


        public abstract int Delete(int id);
    }
}
