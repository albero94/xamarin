using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using ZUMOAPPNAMEService.DataObjects;
using ZUMOAPPNAMEService.Models;

namespace ZUMOAPPNAMEService.Controllers
{
    public class NoteController : TableController<Note>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ZUMOAPPNAMEContext context = new ZUMOAPPNAMEContext();
            DomainManager = new EntityDomainManager<Note>(context, Request);
        }

        // GET tables/TodoNote
        public IQueryable<Note> GetAllNotes()
        {
            return Query();
        }

        // GET tables/TodoNote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Note> GetTodoNote(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoNote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Note> PatchTodoNote(string id, Delta<Note> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoNote
        public async Task<IHttpActionResult> PostTodoNote(Note note)
        {
            Note current = await InsertAsync(note);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoNote/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoNote(string id)
        {
            return DeleteAsync(id);
        }
    }
}