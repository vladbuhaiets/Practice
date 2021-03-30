using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUD_Airport.Controllers 
{ 
public abstract class CRUDController : ControllerBase
{

    public abstract Task<IActionResult> Findall();
    public abstract Task<IActionResult> Find(int id);
    public abstract Task<IActionResult> Create<T>([FromBody] T type);
    public abstract Task<IActionResult> Update<T>([FromBody] T type);
    public abstract Task<IActionResult> Delete(int id);
}
}