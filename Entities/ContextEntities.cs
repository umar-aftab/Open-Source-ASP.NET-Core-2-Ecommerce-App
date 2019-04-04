using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ContextEntities: UElectricsEntities
    {
        public ContextEntities()
        {
            base.Configuration.LazyLoadingEnabled = false;
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException err)
            {
                foreach (var validationErrors in err.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var message = String.Format("Property: {0} Error:{1}", validationError.PropertyName, validationError.ErrorMessage);
                        System.Diagnostics.Trace.TraceError(message, err);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message, ex);
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Trace.TraceError(ex.InnerException.Message, ex.InnerException);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.Message, ex);
                if(ex.InnerException != null)
                {
                    System.Diagnostics.Trace.TraceError(ex.InnerException.Message, ex.InnerException);
                }
            }
            return -1;
        }
    }
}
