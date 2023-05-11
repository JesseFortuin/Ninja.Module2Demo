using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomain.Application
{
    public interface INinjaFacade
    {
        public void InsertNinja();

        public void InsertMultipleNinjas();

        public void SimpleNinjaQueries();

        public void QueryAndUpdateNinja();

        public void QueryAndUpdateNinjaDisconnected();

        public void RetrieveDataWithFind();

        public void RetrieveDataWithStoredProc();

        public void RemoveNinja();

        public void RemoveNinjaWithKeyValue();

        public void RemoveNinjaViaStoredProcedure();

        public void InsertNinjaWithEquipment();

        public void SimpleNinjaGraphQuery();

        public void ProjectionQuery();
    }
}
