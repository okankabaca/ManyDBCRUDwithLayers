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

        public virtual DataTable FindAll()
        {
            return null;
        }

        public virtual TableStajModel FindOne(int id)
        {
            return null;
        }

        public virtual int Create(TableStajModel tableStaj)
        {
            return -1;
        }

        public virtual int Edit(int id,TableStajModel tableStajModel)
        {
            return -1;
        }

        public virtual int Delete(int id)
        {
            return -1;
        }
    }
}
