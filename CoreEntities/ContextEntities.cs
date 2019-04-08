using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoreEntities
{
    public class ContextEntities: UElectricsDbContext
    {
        public ContextEntities()
        {
        }
        public ContextEntities(DbContextOptions<UElectricsDbContext> options) : base(options)
        {
           
        }
        public override int SaveChanges()
        {
            try
            {
                var entities = from e in ChangeTracker.Entries()
                               where e.State == EntityState.Added
                                   || e.State == EntityState.Modified
                               select e.Entity;
                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(
                        entity,
                        validationContext,
                        validateAllProperties: true);
                }

                return base.SaveChanges();
            
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
