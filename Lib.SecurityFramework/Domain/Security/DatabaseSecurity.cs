using System.Collections.Generic;
using Lib.SecurityFramework.Framework;
using Lib.SecurityFramework.Domain.Actions;
namespace Lib.SecurityFramework.Domain.Security
{
    public class DatabaseSecurity : IActions<SecurityCheckResult>
    {
        public virtual IContext Context { get; set; }

        private readonly DomainObjects domainObject;

        protected DatabaseSecurity(DomainObjects domainObject)
        {
            this.domainObject = domainObject;
        }

        protected SecurityCheckResult Ok()
        {
            return SecurityCheckResult.Ok;
        }

        protected SecurityCheckResult Result(bool result)
        {
            return result ? Ok() : Fail();
        }

        protected SecurityCheckResult Fail()
        {
            return SecurityCheckResult.Fail;
        }

        public virtual SecurityCheckResult Create()
        {
            if (UserHasPermission(CRUD.Create))
                return Ok();
            else
                return Fail();
        }

        public virtual SecurityCheckResult Read()
        {
            if (UserHasPermission(CRUD.Read))
                return Ok();
            else
                return Fail();
        }

        public virtual SecurityCheckResult Update()
        {
            if (UserHasPermission(CRUD.Update))
                return Ok();
            else
                return Fail();
        }

        public virtual SecurityCheckResult Delete()
        {
            if (UserHasPermission(CRUD.Delete))
                return Ok();
            else
                return Fail();
        }

        private bool UserHasPermission(CRUD operation)
        {
            //go to database and collect user permissions

            var permissions = new Dictionary<DomainObjects, List<CRUD>>();

            permissions.Add(DomainObjects.Invoice, new List<CRUD>());
            permissions[DomainObjects.Invoice].Add(CRUD.Read);
            permissions[DomainObjects.Invoice].Add(CRUD.Update);

            permissions.Add(DomainObjects.InvoiceItem, new List<CRUD>());
            permissions[DomainObjects.InvoiceItem].Add(CRUD.Create);
            permissions[DomainObjects.InvoiceItem].Add(CRUD.Read);
            permissions[DomainObjects.InvoiceItem].Add(CRUD.Update);
            permissions[DomainObjects.InvoiceItem].Add(CRUD.Delete);
            
            return this.Context.UserID == 1 &&
                   permissions.ContainsKey(domainObject) &&
                   permissions[domainObject].Contains(operation);
        }
    }
}