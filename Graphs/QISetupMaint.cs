using PX.Data;
using PX.Data.BQL.Fluent;

namespace QualityInsights
{
    public class QISetupMaint : PXGraph<QISetupMaint>
    {

        #region Views
        public SelectFrom<QISetup>.View QIPreferences;
        #endregion

        #region Actions
        public PXSave<QISetup> Save;
        public PXCancel<QISetup> Cancel;
        #endregion

    }
}